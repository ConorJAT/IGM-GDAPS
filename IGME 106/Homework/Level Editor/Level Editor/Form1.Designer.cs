
namespace Level_Editor
{
    partial class FormMain
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
            this.buttonLoad = new System.Windows.Forms.Button();
            this.groupBoxNewMap = new System.Windows.Forms.GroupBox();
            this.buttonCreateMap = new System.Windows.Forms.Button();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.groupBoxNewMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(12, 12);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(248, 89);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load Map";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.LoadMap);
            // 
            // groupBoxNewMap
            // 
            this.groupBoxNewMap.Controls.Add(this.buttonCreateMap);
            this.groupBoxNewMap.Controls.Add(this.textBoxHeight);
            this.groupBoxNewMap.Controls.Add(this.textBoxWidth);
            this.groupBoxNewMap.Controls.Add(this.labelHeight);
            this.groupBoxNewMap.Controls.Add(this.labelWidth);
            this.groupBoxNewMap.Location = new System.Drawing.Point(12, 107);
            this.groupBoxNewMap.Name = "groupBoxNewMap";
            this.groupBoxNewMap.Size = new System.Drawing.Size(248, 201);
            this.groupBoxNewMap.TabIndex = 1;
            this.groupBoxNewMap.TabStop = false;
            this.groupBoxNewMap.Text = "Generate New Map:";
            // 
            // buttonCreateMap
            // 
            this.buttonCreateMap.Location = new System.Drawing.Point(6, 112);
            this.buttonCreateMap.Name = "buttonCreateMap";
            this.buttonCreateMap.Size = new System.Drawing.Size(235, 80);
            this.buttonCreateMap.TabIndex = 6;
            this.buttonCreateMap.Text = "Create Map";
            this.buttonCreateMap.UseVisualStyleBackColor = true;
            this.buttonCreateMap.Click += new System.EventHandler(this.CreateMap);
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(105, 76);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(137, 23);
            this.textBoxHeight.TabIndex = 5;
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(105, 37);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(137, 23);
            this.textBoxWidth.TabIndex = 4;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(6, 79);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(93, 15);
            this.labelHeight.TabIndex = 3;
            this.labelHeight.Text = "Height (In Tiles):";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(10, 40);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(89, 15);
            this.labelWidth.TabIndex = 2;
            this.labelWidth.Text = "Width (In Tiles):";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 321);
            this.Controls.Add(this.groupBoxNewMap);
            this.Controls.Add(this.buttonLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Level Editor";
            this.groupBoxNewMap.ResumeLayout(false);
            this.groupBoxNewMap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.GroupBox groupBoxNewMap;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Button buttonCreateMap;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.Label labelHeight;
    }
}

