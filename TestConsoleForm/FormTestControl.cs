using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;
using Library.VT100;

namespace TestConsole
{
    public partial class FormTestControl : Form
    {
        byte counter = 0;
        int _row = 1;

        private void ShowTest()
        {
            for (int k = 0; k < 11; k++)
            {
                char esc = Convert.ToChar(0x1b);
                //rtConsole.WriteString(esc.ToString() + "[" + _row.ToString() + ";1H" + esc + "[0m");
                _row++;

                int b;
                b = (++counter) % 10;
                b += 0x30;
                /*
                rtConsole.WriteString(esc.ToString() + "[1;1H" + esc + "[0m");
                rtConsole.WriteString("test line  yes abcdefg");
                */

                if (counter % 5 == 0)
                {
                    /*
                    if (counter % 10 == 0)
                    {
                        InputConsoleString(esc.ToString() + "[2J");
                        _row = 1;
                    }
                     */
                    //if (counter % 10 == 0) 
                    {
                        rtConsole.WriteString(esc.ToString() + "[33;41m");
                        for (int i = 0; i < rtConsole.ConsoleColumn / 2; i++)
                        {
                            rtConsole.WriteByte(Convert.ToByte(b));
                        }
                        rtConsole.WriteString(esc.ToString() + "[1;44m");
                        for (int i = 0; i < rtConsole.ConsoleColumn / 2; i++)
                        {
                            rtConsole.WriteByte(Convert.ToByte(b));
                        }
                        rtConsole.WriteString(esc.ToString() + "[0m");
                    }
                }
                else
                {
                    for (int i = 0; i < rtConsole.ConsoleColumn; i++)
                    {
                        rtConsole.WriteByte(Convert.ToByte(b));
                    }

                }
            }
        }
        public FormTestControl()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowTest();
        }
    }
}
