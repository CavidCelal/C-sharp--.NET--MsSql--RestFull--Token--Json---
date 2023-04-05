namespace PYS.Security.TestForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.TxtCleanText = new System.Windows.Forms.TextBox();
            this.TxtEncyriptText = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.TxtDencyriptText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(231, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtCleanText
            // 
            this.TxtCleanText.Location = new System.Drawing.Point(24, 41);
            this.TxtCleanText.Name = "TxtCleanText";
            this.TxtCleanText.Size = new System.Drawing.Size(201, 20);
            this.TxtCleanText.TabIndex = 1;
            // 
            // TxtEncyriptText
            // 
            this.TxtEncyriptText.Location = new System.Drawing.Point(313, 27);
            this.TxtEncyriptText.Name = "TxtEncyriptText";
            this.TxtEncyriptText.Size = new System.Drawing.Size(379, 20);
            this.TxtEncyriptText.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(231, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TxtDencyriptText
            // 
            this.TxtDencyriptText.Location = new System.Drawing.Point(313, 54);
            this.TxtDencyriptText.Name = "TxtDencyriptText";
            this.TxtDencyriptText.Size = new System.Drawing.Size(379, 20);
            this.TxtDencyriptText.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TxtDencyriptText);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TxtEncyriptText);
            this.Controls.Add(this.TxtCleanText);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtCleanText;
        private System.Windows.Forms.TextBox TxtEncyriptText;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TxtDencyriptText;
    }
}

