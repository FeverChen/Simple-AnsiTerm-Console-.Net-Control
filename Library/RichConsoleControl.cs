using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Library.VT100;

namespace Library.Control
{
    public partial class RichConsoleControl : UserControl
    {
        IAnsiDecoder vt100 = new AnsiDecoder();
        Library.VT100.Screen scr;
        Library.VT100.Screen scr2;
        bool bRefresh = false;
        int consoleRow=100;
        int consoleCol=500;
        long timestamp = 0;

        [Browsable(true), Category("Appearance"), DefaultValue("500"), Description("Console row"), ReadOnly(false)]
        public int ConsoleRow
        {
            get { return consoleRow; }
            set { consoleRow = value; }
        }

        [Browsable(true), Category("Appearance"), DefaultValue("50"), Description("Console column"), ReadOnly(false)]
        public int ConsoleColumn
        {
            get { return consoleCol; }
            set { consoleCol = value; }
        }

        private void RichConsoleControl_SizeChanged(object sender, EventArgs e)
        {
            txConsole.Location = new Point(0, 0);
            txConsole.Width = this.Width;
            txConsole.Height = this.Height;
        }
        private void RefreshTxConsole()
        {
            for (int i = 0; i <= scr.BottomCursorPosition.Y; i++)
            {
                for (int j = 0; j < ConsoleColumn; j++)
                {
                    Library.VT100.Screen.Character c = scr[j, i];
                    Library.VT100.Screen.Character d = scr2[j, i];
                    if (d.Char != c.Char ||
                        d.Attributes.BackgroundColor != c.Attributes.BackgroundColor ||
                        d.Attributes.ForegroundColor != c.Attributes.ForegroundColor)
                    {
                        UpdateConsoleChar(i, j, c);
                    }
                }
            }
        }

        private void UpdateConsoleChar(int i, int j, Library.VT100.Screen.Character c)
        {
            scr2[j, i].Attributes = scr[j, i].Attributes;
            scr2[j, i].Char = scr[j, i].Char;

            Library.VT100.Screen.GraphicAttributes ga = c.Attributes;
            int s = txConsole.GetFirstCharIndexFromLine(i) + j;
            txConsole.SelectionStart = s;  // i * (console_width + 1) + j;
            txConsole.SelectionLength = 1;
            txConsole.SelectionColor = ga.ForegroundColor;
            txConsole.SelectionBackColor = ga.BackgroundColor;

            FontStyle fs = FontStyle.Regular;
            if (c.Attributes.Underline.ToString() != "None")
            {
                fs |= FontStyle.Underline;
            }

            if (c.Attributes.Bold.ToString() != "False")
            {
                fs |= FontStyle.Bold;
            }

            txConsole.SelectionFont = new Font(txConsole.SelectionFont, fs);
            txConsole.SelectedText = c.Char.ToString();
            // make cursor here
            txConsole.Select(i * (ConsoleColumn + 1) + j + 1, 1);
        }
        private void RichConsoleControl_Load(object sender, EventArgs e)
        {
            scr = new Library.VT100.Screen(ConsoleColumn, ConsoleRow);
            scr2 = new Library.VT100.Screen(ConsoleColumn, ConsoleRow);

            vt100.Encoding = Encoding.GetEncoding("ibm437");
            vt100.Subscribe(scr);
            Clear();
            timer1.Start();
        }
        public RichConsoleControl()
        {
            InitializeComponent();
        }
        public void WriteByte(byte b)
        {
            if (b == '\t')
            {
                vt100.Input(new byte[8] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 });
            }
            else
            {
                vt100.Input(new byte[1] { b });
            }
            bRefresh = true;
        }

        public void WriteString(String s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                WriteByte(Convert.ToByte(s[i]));
            }
        }

        public void Clear()
        {
            StringBuilder tx = new StringBuilder(String.Empty);
            txConsole.Clear();
            for (int i = 0; i < ConsoleRow; i++)
            {
                for (int j = 0; j < ConsoleColumn; j++)
                {
                    Library.VT100.Screen.Character c = scr[j, i];
                    tx.Append(c.Char);
                    //tx.Append(' ');
                }
                tx.Append("\r\n");
            }
            txConsole.Text = tx.ToString();
            txConsole.SelectAll();
            txConsole.SelectionBackColor = Color.Black;
        }

        public void SaveRTF(String filename)
        {
            try
            {
                String rtf = (String)txConsole.Rtf.Clone();
                int start = txConsole.GetFirstCharIndexFromLine(scr.BottomCursorPosition.Y + 1);
                int len = txConsole.TextLength - start;
                txConsole.SelectionStart = start;
                txConsole.SelectionLength = len;
                txConsole.SelectedText = " ";

                txConsole.SaveFile(filename);
                txConsole.Rtf = rtf;
            }
            catch (Exception e)
            {
                MessageBox.Show("Save RTF file fail!", "Error");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bRefresh)
            {
                RefreshTxConsole();
                timestamp = DateTime.Now.Ticks;
            }

        }

    }
}
