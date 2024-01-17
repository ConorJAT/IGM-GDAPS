
namespace Bomb_Game__GUI_Creation_
{
    partial class formGame
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
            this.components = new System.ComponentModel.Container();
            this.buttonWire1 = new System.Windows.Forms.Button();
            this.groupboxWires = new System.Windows.Forms.GroupBox();
            this.buttonWire5 = new System.Windows.Forms.Button();
            this.buttonWire4 = new System.Windows.Forms.Button();
            this.buttonWire3 = new System.Windows.Forms.Button();
            this.buttonWire2 = new System.Windows.Forms.Button();
            this.listboxInfo = new System.Windows.Forms.ListBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.progressbarTime = new System.Windows.Forms.ProgressBar();
            this.textboxStatus = new System.Windows.Forms.TextBox();
            this.timerBomb = new System.Windows.Forms.Timer(this.components);
            this.labelStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupboxWires.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonWire1
            // 
            this.buttonWire1.Enabled = false;
            this.buttonWire1.Location = new System.Drawing.Point(0, 37);
            this.buttonWire1.Name = "buttonWire1";
            this.buttonWire1.Size = new System.Drawing.Size(282, 10);
            this.buttonWire1.TabIndex = 0;
            this.buttonWire1.UseVisualStyleBackColor = true;
            this.buttonWire1.Click += new System.EventHandler(this.CutWire);
            // 
            // groupboxWires
            // 
            this.groupboxWires.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.groupboxWires.Controls.Add(this.buttonWire5);
            this.groupboxWires.Controls.Add(this.buttonWire4);
            this.groupboxWires.Controls.Add(this.buttonWire3);
            this.groupboxWires.Controls.Add(this.buttonWire2);
            this.groupboxWires.Controls.Add(this.buttonWire1);
            this.groupboxWires.ForeColor = System.Drawing.SystemColors.Control;
            this.groupboxWires.Location = new System.Drawing.Point(300, 26);
            this.groupboxWires.Name = "groupboxWires";
            this.groupboxWires.Size = new System.Drawing.Size(282, 242);
            this.groupboxWires.TabIndex = 5;
            this.groupboxWires.TabStop = false;
            this.groupboxWires.Text = "Wires:";
            // 
            // buttonWire5
            // 
            this.buttonWire5.Enabled = false;
            this.buttonWire5.Location = new System.Drawing.Point(0, 203);
            this.buttonWire5.Name = "buttonWire5";
            this.buttonWire5.Size = new System.Drawing.Size(282, 10);
            this.buttonWire5.TabIndex = 4;
            this.buttonWire5.UseVisualStyleBackColor = true;
            this.buttonWire5.Click += new System.EventHandler(this.CutWire);
            // 
            // buttonWire4
            // 
            this.buttonWire4.Enabled = false;
            this.buttonWire4.Location = new System.Drawing.Point(0, 164);
            this.buttonWire4.Name = "buttonWire4";
            this.buttonWire4.Size = new System.Drawing.Size(282, 10);
            this.buttonWire4.TabIndex = 3;
            this.buttonWire4.UseVisualStyleBackColor = true;
            this.buttonWire4.Click += new System.EventHandler(this.CutWire);
            // 
            // buttonWire3
            // 
            this.buttonWire3.Enabled = false;
            this.buttonWire3.Location = new System.Drawing.Point(0, 120);
            this.buttonWire3.Name = "buttonWire3";
            this.buttonWire3.Size = new System.Drawing.Size(282, 10);
            this.buttonWire3.TabIndex = 2;
            this.buttonWire3.UseVisualStyleBackColor = true;
            this.buttonWire3.Click += new System.EventHandler(this.CutWire);
            // 
            // buttonWire2
            // 
            this.buttonWire2.Enabled = false;
            this.buttonWire2.Location = new System.Drawing.Point(0, 78);
            this.buttonWire2.Name = "buttonWire2";
            this.buttonWire2.Size = new System.Drawing.Size(282, 10);
            this.buttonWire2.TabIndex = 1;
            this.buttonWire2.UseVisualStyleBackColor = true;
            this.buttonWire2.Click += new System.EventHandler(this.CutWire);
            // 
            // listboxInfo
            // 
            this.listboxInfo.BackColor = System.Drawing.Color.White;
            this.listboxInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listboxInfo.FormattingEnabled = true;
            this.listboxInfo.ItemHeight = 15;
            this.listboxInfo.Items.AddRange(new object[] {
            "Rules of the Game:",
            "Objective: Defuse the bomb by cutting the right",
            "wire before the bomb explodes.",
            "",
            "Controls:",
            "Click \'Start Game\' to begin defusal.",
            "Click a wire to cut it.",
            "",
            "Hints:",
            "     > If there are no red wires, cut the second wire.",
            "     > Otherwise, if the last wire is white, cut the",
            "         last wire.",
            "     > Otherwise, if there is more than one blue wire,",
            "         cut the last blue wire.",
            "     > Otherwise, cut the last wire."});
            this.listboxInfo.Location = new System.Drawing.Point(12, 26);
            this.listboxInfo.Name = "listboxInfo";
            this.listboxInfo.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listboxInfo.Size = new System.Drawing.Size(282, 244);
            this.listboxInfo.TabIndex = 5;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(588, 23);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(200, 154);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start Game";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.StartGame);
            // 
            // progressbarTime
            // 
            this.progressbarTime.Location = new System.Drawing.Point(588, 198);
            this.progressbarTime.Name = "progressbarTime";
            this.progressbarTime.Size = new System.Drawing.Size(200, 23);
            this.progressbarTime.TabIndex = 6;
            // 
            // textboxStatus
            // 
            this.textboxStatus.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textboxStatus.Location = new System.Drawing.Point(588, 245);
            this.textboxStatus.Name = "textboxStatus";
            this.textboxStatus.ReadOnly = true;
            this.textboxStatus.Size = new System.Drawing.Size(200, 23);
            this.textboxStatus.TabIndex = 7;
            // 
            // timerBomb
            // 
            this.timerBomb.Tick += new System.EventHandler(this.Tick);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(588, 224);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(83, 15);
            this.labelStatus.TabIndex = 8;
            this.labelStatus.Text = "Bomb Output:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(588, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Time Remaining:";
            // 
            // formGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 291);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textboxStatus);
            this.Controls.Add(this.progressbarTime);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.listboxInfo);
            this.Controls.Add(this.groupboxWires);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "formGame";
            this.Text = "Keep Talking & Nobody Explodes!";
            this.Load += new System.EventHandler(this.LoadGame);
            this.groupboxWires.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.Button buttonWire5;
        private System.Windows.Forms.Button buttonWire4;
        private System.Windows.Forms.Button buttonWire3;
        private System.Windows.Forms.Button buttonWire2;
        private System.Windows.Forms.Button buttonWire1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.GroupBox groupboxWires;
        private System.Windows.Forms.ListBox listboxInfo;
        private System.Windows.Forms.ProgressBar progressbarTime;
        private System.Windows.Forms.TextBox textboxStatus;
        private System.Windows.Forms.Timer timerBomb;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label1;
    }
}

