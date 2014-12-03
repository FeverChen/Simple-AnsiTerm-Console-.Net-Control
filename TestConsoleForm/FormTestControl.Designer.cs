namespace TestConsole
{
    partial class FormTestControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtConsole = new Library.Control.RichConsoleControl();
            this.SuspendLayout();
            // 
            // rtConsole
            // 
            this.rtConsole.AutoSize = true;
            this.rtConsole.ConsoleColumn = 50;
            this.rtConsole.ConsoleRow = 500;
            this.rtConsole.Location = new System.Drawing.Point(-1, -3);
            this.rtConsole.Name = "rtConsole";
            this.rtConsole.Size = new System.Drawing.Size(1923, 2827);
            this.rtConsole.TabIndex = 0;
            // 
            // FormTestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 470);
            this.Controls.Add(this.rtConsole);
            this.Name = "FormTestControl";
            this.Text = "FormTest";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Library.Control.RichConsoleControl rtConsole;


    }
}