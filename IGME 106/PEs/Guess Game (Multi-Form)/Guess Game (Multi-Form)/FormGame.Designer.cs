
namespace Guess_Game__Multi_Form_
{
    partial class FormGame
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
            this.components = new System.ComponentModel.Container();
            this.textBoxGuess = new System.Windows.Forms.TextBox();
            this.labelGuess = new System.Windows.Forms.Label();
            this.buttonGuess = new System.Windows.Forms.Button();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.progressBarTime = new System.Windows.Forms.ProgressBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // textBoxGuess
            // 
            this.textBoxGuess.Location = new System.Drawing.Point(12, 27);
            this.textBoxGuess.Name = "textBoxGuess";
            this.textBoxGuess.Size = new System.Drawing.Size(277, 23);
            this.textBoxGuess.TabIndex = 0;
            // 
            // labelGuess
            // 
            this.labelGuess.AutoSize = true;
            this.labelGuess.Location = new System.Drawing.Point(12, 9);
            this.labelGuess.Name = "labelGuess";
            this.labelGuess.Size = new System.Drawing.Size(99, 15);
            this.labelGuess.TabIndex = 1;
            this.labelGuess.Text = "Enter Guess Here:";
            // 
            // buttonGuess
            // 
            this.buttonGuess.Location = new System.Drawing.Point(12, 56);
            this.buttonGuess.Name = "buttonGuess";
            this.buttonGuess.Size = new System.Drawing.Size(277, 59);
            this.buttonGuess.TabIndex = 2;
            this.buttonGuess.Text = "Submit Guess";
            this.buttonGuess.UseVisualStyleBackColor = true;
            this.buttonGuess.Click += new System.EventHandler(this.buttonGuess_Click);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(12, 121);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.Size = new System.Drawing.Size(277, 23);
            this.textBoxResult.TabIndex = 3;
            // 
            // progressBarTime
            // 
            this.progressBarTime.Location = new System.Drawing.Point(11, 150);
            this.progressBarTime.Name = "progressBarTime";
            this.progressBarTime.Size = new System.Drawing.Size(278, 23);
            this.progressBarTime.TabIndex = 4;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 182);
            this.Controls.Add(this.progressBarTime);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.buttonGuess);
            this.Controls.Add(this.labelGuess);
            this.Controls.Add(this.textBoxGuess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGame";
            this.Text = "Guess That Number!";
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxGuess;
        private System.Windows.Forms.Label labelGuess;
        private System.Windows.Forms.Button buttonGuess;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.ProgressBar progressBarTime;
        private System.Windows.Forms.Timer timer;
    }
}