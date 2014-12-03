namespace Library.Control
{
    partial class RichConsoleControl
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txConsole = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txConsole
            // 
            this.txConsole.BackColor = System.Drawing.Color.Black;
            this.txConsole.EnableAutoDragDrop = true;
            this.txConsole.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txConsole.ForeColor = System.Drawing.Color.White;
            this.txConsole.Location = new System.Drawing.Point(0, 0);
            this.txConsole.Name = "txConsole";
            this.txConsole.ReadOnly = true;
            this.txConsole.Size = new System.Drawing.Size(85, 105);
            this.txConsole.TabIndex = 0;
            this.txConsole.Text = "";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // RichConsoleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txConsole);
            this.Name = "RichConsoleControl";
            this.Size = new System.Drawing.Size(111, 145);
            this.Load += new System.EventHandler(this.RichConsoleControl_Load);
            this.SizeChanged += new System.EventHandler(this.RichConsoleControl_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txConsole;
        private System.Windows.Forms.Timer timer1;
    }
}
