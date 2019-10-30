namespace GPLA
{
    partial class Form1
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
            this.display = new System.Windows.Forms.PictureBox();
            this.ControlePanel = new System.Windows.Forms.RichTextBox();
            this.commandline = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.display)).BeginInit();
            this.SuspendLayout();
            // 
            // display
            // 
            this.display.Location = new System.Drawing.Point(322, 12);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(466, 426);
            this.display.TabIndex = 6;
            this.display.TabStop = false;
            // 
            // ControlePanel
            // 
            this.ControlePanel.Location = new System.Drawing.Point(13, 12);
            this.ControlePanel.Name = "ControlePanel";
            this.ControlePanel.Size = new System.Drawing.Size(303, 395);
            this.ControlePanel.TabIndex = 7;
            this.ControlePanel.Text = "";
            // 
            // commandline
            // 
            this.commandline.Location = new System.Drawing.Point(13, 413);
            this.commandline.Name = "commandline";
            this.commandline.Size = new System.Drawing.Size(303, 20);
            this.commandline.TabIndex = 8;
            this.commandline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Commandline_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.commandline);
            this.Controls.Add(this.ControlePanel);
            this.Controls.Add(this.display);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.display)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox display;
        private System.Windows.Forms.RichTextBox ControlePanel;
        private System.Windows.Forms.TextBox commandline;
    }
}

