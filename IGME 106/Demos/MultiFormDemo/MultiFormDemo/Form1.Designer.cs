
namespace MultiFormDemo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonPopUp = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPopUp
            // 
            this.buttonPopUp.Location = new System.Drawing.Point(12, 12);
            this.buttonPopUp.Name = "buttonPopUp";
            this.buttonPopUp.Size = new System.Drawing.Size(126, 71);
            this.buttonPopUp.TabIndex = 0;
            this.buttonPopUp.Text = "Open Message Box";
            this.buttonPopUp.UseVisualStyleBackColor = true;
            this.buttonPopUp.Click += new System.EventHandler(this.buttonPopUp_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(144, 12);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(126, 71);
            this.buttonOpen.TabIndex = 1;
            this.buttonOpen.Text = "Open File";
            this.buttonOpen.UseVisualStyleBackColor = true;
            //this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(276, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 71);
            this.button3.TabIndex = 2;
            this.button3.Text = "Open Custom Form";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 91);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonPopUp);
            this.Name = "Form1";
            this.Text = "Multi Form Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPopUp;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button button3;
    }
}

