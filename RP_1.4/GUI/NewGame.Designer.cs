namespace RP_1._4.GUI
{
    partial class NewGame
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
            this.OkButton = new System.Windows.Forms.Button();
            this.StornoButton = new System.Windows.Forms.Button();
            this.WhiteIcon = new System.Windows.Forms.PictureBox();
            this.WhiteBox = new System.Windows.Forms.GroupBox();
            this.WhiteDifficultyLabel = new System.Windows.Forms.Label();
            this.WhiteTypeLabel = new System.Windows.Forms.Label();
            this.WhiteShowCbox = new System.Windows.Forms.CheckBox();
            this.WhiteDifficultyCBox = new System.Windows.Forms.ComboBox();
            this.WhiteTypeCBox = new System.Windows.Forms.ComboBox();
            this.WhiteNameLabel = new System.Windows.Forms.Label();
            this.WhiteNameBox = new System.Windows.Forms.TextBox();
            this.BlackBox = new System.Windows.Forms.GroupBox();
            this.BlackDifficultyLabel = new System.Windows.Forms.Label();
            this.BlackTypeLabel = new System.Windows.Forms.Label();
            this.BlackShowCBox = new System.Windows.Forms.CheckBox();
            this.BlackDifficultyCBox = new System.Windows.Forms.ComboBox();
            this.BlackTypeCBox = new System.Windows.Forms.ComboBox();
            this.BlackNameLabel = new System.Windows.Forms.Label();
            this.BlackNameBox = new System.Windows.Forms.TextBox();
            this.BlackIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.WhiteIcon)).BeginInit();
            this.WhiteBox.SuspendLayout();
            this.BlackBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlackIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.BackColor = System.Drawing.Color.White;
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(100, 238);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(147, 43);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // StornoButton
            // 
            this.StornoButton.BackColor = System.Drawing.Color.White;
            this.StornoButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.StornoButton.Location = new System.Drawing.Point(253, 238);
            this.StornoButton.Name = "StornoButton";
            this.StornoButton.Size = new System.Drawing.Size(147, 43);
            this.StornoButton.TabIndex = 1;
            this.StornoButton.Text = "Storno";
            this.StornoButton.UseVisualStyleBackColor = false;
            this.StornoButton.Click += new System.EventHandler(this.StornoButton_Click);
            // 
            // WhiteIcon
            // 
            this.WhiteIcon.BackgroundImage = global::RP_1._4.Properties.Resources.white_pawn_move;
            this.WhiteIcon.Location = new System.Drawing.Point(6, 19);
            this.WhiteIcon.Name = "WhiteIcon";
            this.WhiteIcon.Size = new System.Drawing.Size(64, 64);
            this.WhiteIcon.TabIndex = 2;
            this.WhiteIcon.TabStop = false;
            // 
            // WhiteBox
            // 
            this.WhiteBox.BackColor = System.Drawing.Color.Transparent;
            this.WhiteBox.Controls.Add(this.WhiteDifficultyLabel);
            this.WhiteBox.Controls.Add(this.WhiteTypeLabel);
            this.WhiteBox.Controls.Add(this.WhiteShowCbox);
            this.WhiteBox.Controls.Add(this.WhiteDifficultyCBox);
            this.WhiteBox.Controls.Add(this.WhiteTypeCBox);
            this.WhiteBox.Controls.Add(this.WhiteNameLabel);
            this.WhiteBox.Controls.Add(this.WhiteNameBox);
            this.WhiteBox.Controls.Add(this.WhiteIcon);
            this.WhiteBox.Location = new System.Drawing.Point(12, 12);
            this.WhiteBox.Name = "WhiteBox";
            this.WhiteBox.Size = new System.Drawing.Size(235, 220);
            this.WhiteBox.TabIndex = 3;
            this.WhiteBox.TabStop = false;
            this.WhiteBox.Text = "White player";
            // 
            // WhiteDifficultyLabel
            // 
            this.WhiteDifficultyLabel.AutoSize = true;
            this.WhiteDifficultyLabel.Location = new System.Drawing.Point(35, 155);
            this.WhiteDifficultyLabel.Name = "WhiteDifficultyLabel";
            this.WhiteDifficultyLabel.Size = new System.Drawing.Size(47, 13);
            this.WhiteDifficultyLabel.TabIndex = 13;
            this.WhiteDifficultyLabel.Text = "Difficulty";
            // 
            // WhiteTypeLabel
            // 
            this.WhiteTypeLabel.AutoSize = true;
            this.WhiteTypeLabel.Location = new System.Drawing.Point(35, 128);
            this.WhiteTypeLabel.Name = "WhiteTypeLabel";
            this.WhiteTypeLabel.Size = new System.Drawing.Size(31, 13);
            this.WhiteTypeLabel.TabIndex = 11;
            this.WhiteTypeLabel.Text = "Type";
            // 
            // WhiteShowCbox
            // 
            this.WhiteShowCbox.AutoSize = true;
            this.WhiteShowCbox.Location = new System.Drawing.Point(87, 184);
            this.WhiteShowCbox.Name = "WhiteShowCbox";
            this.WhiteShowCbox.Size = new System.Drawing.Size(132, 17);
            this.WhiteShowCbox.TabIndex = 11;
            this.WhiteShowCbox.Text = "Show available moves";
            this.WhiteShowCbox.UseVisualStyleBackColor = true;
            // 
            // WhiteDifficultyCBox
            // 
            this.WhiteDifficultyCBox.FormattingEnabled = true;
            this.WhiteDifficultyCBox.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "Hard"});
            this.WhiteDifficultyCBox.Location = new System.Drawing.Point(87, 152);
            this.WhiteDifficultyCBox.Name = "WhiteDifficultyCBox";
            this.WhiteDifficultyCBox.Size = new System.Drawing.Size(134, 21);
            this.WhiteDifficultyCBox.TabIndex = 8;
            // 
            // WhiteTypeCBox
            // 
            this.WhiteTypeCBox.FormattingEnabled = true;
            this.WhiteTypeCBox.Items.AddRange(new object[] {
            "Computer",
            "User"});
            this.WhiteTypeCBox.Location = new System.Drawing.Point(87, 125);
            this.WhiteTypeCBox.Name = "WhiteTypeCBox";
            this.WhiteTypeCBox.Size = new System.Drawing.Size(134, 21);
            this.WhiteTypeCBox.TabIndex = 7;
            this.WhiteTypeCBox.SelectedValueChanged += new System.EventHandler(this.WhiteTypeCBox_SelectedValueChanged);
            // 
            // WhiteNameLabel
            // 
            this.WhiteNameLabel.AutoSize = true;
            this.WhiteNameLabel.Location = new System.Drawing.Point(35, 102);
            this.WhiteNameLabel.Name = "WhiteNameLabel";
            this.WhiteNameLabel.Size = new System.Drawing.Size(35, 13);
            this.WhiteNameLabel.TabIndex = 6;
            this.WhiteNameLabel.Text = "Name";
            // 
            // WhiteNameBox
            // 
            this.WhiteNameBox.Location = new System.Drawing.Point(87, 99);
            this.WhiteNameBox.Name = "WhiteNameBox";
            this.WhiteNameBox.Size = new System.Drawing.Size(134, 20);
            this.WhiteNameBox.TabIndex = 3;
            // 
            // BlackBox
            // 
            this.BlackBox.BackColor = System.Drawing.Color.Transparent;
            this.BlackBox.Controls.Add(this.BlackDifficultyLabel);
            this.BlackBox.Controls.Add(this.BlackTypeLabel);
            this.BlackBox.Controls.Add(this.BlackShowCBox);
            this.BlackBox.Controls.Add(this.BlackDifficultyCBox);
            this.BlackBox.Controls.Add(this.BlackTypeCBox);
            this.BlackBox.Controls.Add(this.BlackNameLabel);
            this.BlackBox.Controls.Add(this.BlackNameBox);
            this.BlackBox.Controls.Add(this.BlackIcon);
            this.BlackBox.Location = new System.Drawing.Point(253, 12);
            this.BlackBox.Name = "BlackBox";
            this.BlackBox.Size = new System.Drawing.Size(239, 220);
            this.BlackBox.TabIndex = 4;
            this.BlackBox.TabStop = false;
            this.BlackBox.Text = "Black player";
            // 
            // BlackDifficultyLabel
            // 
            this.BlackDifficultyLabel.AutoSize = true;
            this.BlackDifficultyLabel.Location = new System.Drawing.Point(35, 155);
            this.BlackDifficultyLabel.Name = "BlackDifficultyLabel";
            this.BlackDifficultyLabel.Size = new System.Drawing.Size(47, 13);
            this.BlackDifficultyLabel.TabIndex = 14;
            this.BlackDifficultyLabel.Text = "Difficulty";
            // 
            // BlackTypeLabel
            // 
            this.BlackTypeLabel.AutoSize = true;
            this.BlackTypeLabel.Location = new System.Drawing.Point(35, 128);
            this.BlackTypeLabel.Name = "BlackTypeLabel";
            this.BlackTypeLabel.Size = new System.Drawing.Size(31, 13);
            this.BlackTypeLabel.TabIndex = 12;
            this.BlackTypeLabel.Text = "Type";
            // 
            // BlackShowCBox
            // 
            this.BlackShowCBox.AutoSize = true;
            this.BlackShowCBox.Location = new System.Drawing.Point(95, 184);
            this.BlackShowCBox.Name = "BlackShowCBox";
            this.BlackShowCBox.Size = new System.Drawing.Size(132, 17);
            this.BlackShowCBox.TabIndex = 10;
            this.BlackShowCBox.Text = "Show available moves";
            this.BlackShowCBox.UseVisualStyleBackColor = true;
            // 
            // BlackDifficultyCBox
            // 
            this.BlackDifficultyCBox.FormattingEnabled = true;
            this.BlackDifficultyCBox.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "Hard"});
            this.BlackDifficultyCBox.Location = new System.Drawing.Point(94, 152);
            this.BlackDifficultyCBox.Name = "BlackDifficultyCBox";
            this.BlackDifficultyCBox.Size = new System.Drawing.Size(134, 21);
            this.BlackDifficultyCBox.TabIndex = 9;
            // 
            // BlackTypeCBox
            // 
            this.BlackTypeCBox.FormattingEnabled = true;
            this.BlackTypeCBox.Items.AddRange(new object[] {
            "Computer",
            "User"});
            this.BlackTypeCBox.Location = new System.Drawing.Point(94, 125);
            this.BlackTypeCBox.Name = "BlackTypeCBox";
            this.BlackTypeCBox.Size = new System.Drawing.Size(134, 21);
            this.BlackTypeCBox.TabIndex = 6;
            this.BlackTypeCBox.SelectedIndexChanged += new System.EventHandler(this.BlackTypeCBox_SelectedIndexChanged);
            // 
            // BlackNameLabel
            // 
            this.BlackNameLabel.AutoSize = true;
            this.BlackNameLabel.Location = new System.Drawing.Point(35, 102);
            this.BlackNameLabel.Name = "BlackNameLabel";
            this.BlackNameLabel.Size = new System.Drawing.Size(35, 13);
            this.BlackNameLabel.TabIndex = 5;
            this.BlackNameLabel.Text = "Name";
            // 
            // BlackNameBox
            // 
            this.BlackNameBox.Location = new System.Drawing.Point(94, 99);
            this.BlackNameBox.Name = "BlackNameBox";
            this.BlackNameBox.Size = new System.Drawing.Size(134, 20);
            this.BlackNameBox.TabIndex = 4;
            // 
            // BlackIcon
            // 
            this.BlackIcon.BackgroundImage = global::RP_1._4.Properties.Resources.black_pawn_move;
            this.BlackIcon.Location = new System.Drawing.Point(6, 19);
            this.BlackIcon.Name = "BlackIcon";
            this.BlackIcon.Size = new System.Drawing.Size(64, 64);
            this.BlackIcon.TabIndex = 3;
            this.BlackIcon.TabStop = false;
            // 
            // NewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RP_1._4.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(503, 286);
            this.Controls.Add(this.BlackBox);
            this.Controls.Add(this.WhiteBox);
            this.Controls.Add(this.StornoButton);
            this.Controls.Add(this.OkButton);
            this.Name = "NewGame";
            this.Text = "New_game";
            ((System.ComponentModel.ISupportInitialize)(this.WhiteIcon)).EndInit();
            this.WhiteBox.ResumeLayout(false);
            this.WhiteBox.PerformLayout();
            this.BlackBox.ResumeLayout(false);
            this.BlackBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlackIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button StornoButton;
        private System.Windows.Forms.PictureBox WhiteIcon;
        private System.Windows.Forms.GroupBox WhiteBox;
        private System.Windows.Forms.GroupBox BlackBox;
        private System.Windows.Forms.TextBox WhiteNameBox;
        private System.Windows.Forms.PictureBox BlackIcon;
        private System.Windows.Forms.Label WhiteNameLabel;
        private System.Windows.Forms.ComboBox BlackTypeCBox;
        private System.Windows.Forms.Label BlackNameLabel;
        private System.Windows.Forms.TextBox BlackNameBox;
        private System.Windows.Forms.Label WhiteDifficultyLabel;
        private System.Windows.Forms.Label WhiteTypeLabel;
        private System.Windows.Forms.CheckBox WhiteShowCbox;
        private System.Windows.Forms.ComboBox WhiteDifficultyCBox;
        private System.Windows.Forms.ComboBox WhiteTypeCBox;
        private System.Windows.Forms.Label BlackDifficultyLabel;
        private System.Windows.Forms.Label BlackTypeLabel;
        private System.Windows.Forms.CheckBox BlackShowCBox;
        private System.Windows.Forms.ComboBox BlackDifficultyCBox;
    }
}