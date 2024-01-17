
namespace Level_Editor
{
    partial class FormEditor
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
            this.groupBoxColors = new System.Windows.Forms.GroupBox();
            this.buttonColor6 = new System.Windows.Forms.Button();
            this.buttonColor5 = new System.Windows.Forms.Button();
            this.buttonColor4 = new System.Windows.Forms.Button();
            this.buttonColor3 = new System.Windows.Forms.Button();
            this.buttonColor2 = new System.Windows.Forms.Button();
            this.buttonColor1 = new System.Windows.Forms.Button();
            this.groupBoxChosenColor = new System.Windows.Forms.GroupBox();
            this.pictureBoxChosen = new System.Windows.Forms.PictureBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.labelMap = new System.Windows.Forms.Label();
            this.groupBoxColors.SuspendLayout();
            this.groupBoxChosenColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChosen)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxColors
            // 
            this.groupBoxColors.Controls.Add(this.buttonColor6);
            this.groupBoxColors.Controls.Add(this.buttonColor5);
            this.groupBoxColors.Controls.Add(this.buttonColor4);
            this.groupBoxColors.Controls.Add(this.buttonColor3);
            this.groupBoxColors.Controls.Add(this.buttonColor2);
            this.groupBoxColors.Controls.Add(this.buttonColor1);
            this.groupBoxColors.Location = new System.Drawing.Point(13, 13);
            this.groupBoxColors.Name = "groupBoxColors";
            this.groupBoxColors.Size = new System.Drawing.Size(150, 236);
            this.groupBoxColors.TabIndex = 0;
            this.groupBoxColors.TabStop = false;
            this.groupBoxColors.Text = "Color Selector:";
            // 
            // buttonColor6
            // 
            this.buttonColor6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.buttonColor6.Location = new System.Drawing.Point(77, 164);
            this.buttonColor6.Name = "buttonColor6";
            this.buttonColor6.Size = new System.Drawing.Size(65, 65);
            this.buttonColor6.TabIndex = 4;
            this.buttonColor6.UseVisualStyleBackColor = false;
            this.buttonColor6.Click += new System.EventHandler(this.PickColor);
            // 
            // buttonColor5
            // 
            this.buttonColor5.BackColor = System.Drawing.SystemColors.Desktop;
            this.buttonColor5.Location = new System.Drawing.Point(6, 164);
            this.buttonColor5.Name = "buttonColor5";
            this.buttonColor5.Size = new System.Drawing.Size(65, 65);
            this.buttonColor5.TabIndex = 2;
            this.buttonColor5.UseVisualStyleBackColor = false;
            this.buttonColor5.Click += new System.EventHandler(this.PickColor);
            // 
            // buttonColor4
            // 
            this.buttonColor4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(207)))));
            this.buttonColor4.Location = new System.Drawing.Point(77, 93);
            this.buttonColor4.Name = "buttonColor4";
            this.buttonColor4.Size = new System.Drawing.Size(65, 65);
            this.buttonColor4.TabIndex = 2;
            this.buttonColor4.UseVisualStyleBackColor = false;
            this.buttonColor4.Click += new System.EventHandler(this.PickColor);
            // 
            // buttonColor3
            // 
            this.buttonColor3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(225)))), ((int)(((byte)(128)))));
            this.buttonColor3.Location = new System.Drawing.Point(6, 93);
            this.buttonColor3.Name = "buttonColor3";
            this.buttonColor3.Size = new System.Drawing.Size(65, 65);
            this.buttonColor3.TabIndex = 3;
            this.buttonColor3.UseVisualStyleBackColor = false;
            this.buttonColor3.Click += new System.EventHandler(this.PickColor);
            // 
            // buttonColor2
            // 
            this.buttonColor2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(191)))), ((int)(((byte)(83)))));
            this.buttonColor2.Location = new System.Drawing.Point(77, 22);
            this.buttonColor2.Name = "buttonColor2";
            this.buttonColor2.Size = new System.Drawing.Size(65, 65);
            this.buttonColor2.TabIndex = 2;
            this.buttonColor2.UseVisualStyleBackColor = false;
            this.buttonColor2.Click += new System.EventHandler(this.PickColor);
            // 
            // buttonColor1
            // 
            this.buttonColor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(202)))), ((int)(((byte)(227)))));
            this.buttonColor1.Location = new System.Drawing.Point(6, 22);
            this.buttonColor1.Name = "buttonColor1";
            this.buttonColor1.Size = new System.Drawing.Size(65, 65);
            this.buttonColor1.TabIndex = 1;
            this.buttonColor1.UseVisualStyleBackColor = false;
            this.buttonColor1.Click += new System.EventHandler(this.PickColor);
            // 
            // groupBoxChosenColor
            // 
            this.groupBoxChosenColor.Controls.Add(this.pictureBoxChosen);
            this.groupBoxChosenColor.Location = new System.Drawing.Point(13, 255);
            this.groupBoxChosenColor.Name = "groupBoxChosenColor";
            this.groupBoxChosenColor.Size = new System.Drawing.Size(150, 135);
            this.groupBoxChosenColor.TabIndex = 1;
            this.groupBoxChosenColor.TabStop = false;
            this.groupBoxChosenColor.Text = "Current Color:";
            // 
            // pictureBoxChosen
            // 
            this.pictureBoxChosen.Location = new System.Drawing.Point(42, 35);
            this.pictureBoxChosen.Name = "pictureBoxChosen";
            this.pictureBoxChosen.Size = new System.Drawing.Size(65, 65);
            this.pictureBoxChosen.TabIndex = 0;
            this.pictureBoxChosen.TabStop = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(13, 474);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(149, 88);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save Map";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.SaveMap);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(13, 568);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(149, 88);
            this.buttonLoad.TabIndex = 3;
            this.buttonLoad.Text = "Load Map";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.LoadMap);
            // 
            // labelMap
            // 
            this.labelMap.AutoSize = true;
            this.labelMap.Location = new System.Drawing.Point(180, 10);
            this.labelMap.Name = "labelMap";
            this.labelMap.Size = new System.Drawing.Size(34, 15);
            this.labelMap.TabIndex = 4;
            this.labelMap.Text = "Map:";
            // 
            // FormEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 668);
            this.Controls.Add(this.labelMap);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxChosenColor);
            this.Controls.Add(this.groupBoxColors);
            this.MaximizeBox = false;
            this.Name = "FormEditor";
            this.Text = "Level Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseEditor);
            this.groupBoxColors.ResumeLayout(false);
            this.groupBoxChosenColor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChosen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonColor6;
        private System.Windows.Forms.Button buttonColor5;
        private System.Windows.Forms.Button buttonColor4;
        private System.Windows.Forms.Button buttonColor3;
        private System.Windows.Forms.Button buttonColor2;
        private System.Windows.Forms.Button buttonColor1;
        private System.Windows.Forms.GroupBox groupBoxChosenColor;
        private System.Windows.Forms.PictureBox pictureBoxChosen;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Label labelMap;
        private System.Windows.Forms.GroupBox groupBoxColors;
    }
}