namespace RP_1._4.GUI
{
    partial class MainForm
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
            this.pad = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.setingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.MoveHistoryListBox = new System.Windows.Forms.ListBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.WithoutChangeLabel = new System.Windows.Forms.Label();
            this.BlackFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.BlackNameLabel = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.WhiteFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.WhiteNameLabel = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.PlayerMoveWorker = new System.ComponentModel.BackgroundWorker();
            this.ComputerMoveWorker = new System.ComponentModel.BackgroundWorker();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pad)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.BlackFlowLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.WhiteFlowLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pad
            // 
            this.pad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pad.Location = new System.Drawing.Point(37, 65);
            this.pad.Name = "pad";
            this.pad.Size = new System.Drawing.Size(64, 64);
            this.pad.TabIndex = 0;
            this.pad.TabStop = false;
            this.pad.Paint += new System.Windows.Forms.PaintEventHandler(this.pad_Paint);
            this.pad.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pad_MouseDown);
            this.pad.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pad_MouseMove);
            this.pad.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pad_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(992, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveGameToolStripMenuItem,
            this.loadGameToolStripMenuItem,
            this.toolStripSeparator2,
            this.quitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.newGameToolStripMenuItem.Text = "New game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(124, 6);
            // 
            // saveGameToolStripMenuItem
            // 
            this.saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            this.saveGameToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.saveGameToolStripMenuItem.Text = "Save game";
            this.saveGameToolStripMenuItem.Click += new System.EventHandler(this.saveGameToolStripMenuItem_Click);
            // 
            // loadGameToolStripMenuItem
            // 
            this.loadGameToolStripMenuItem.Name = "loadGameToolStripMenuItem";
            this.loadGameToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.loadGameToolStripMenuItem.Text = "Load game";
            this.loadGameToolStripMenuItem.Click += new System.EventHandler(this.loadGameToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(124, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click_1);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.setingsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // unToolStripMenuItem
            // 
            this.unToolStripMenuItem.Name = "unToolStripMenuItem";
            this.unToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.unToolStripMenuItem.Text = "Undo";
            this.unToolStripMenuItem.Click += new System.EventHandler(this.unToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(106, 6);
            // 
            // setingsToolStripMenuItem
            // 
            this.setingsToolStripMenuItem.Name = "setingsToolStripMenuItem";
            this.setingsToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.setingsToolStripMenuItem.Text = "Setings";
            this.setingsToolStripMenuItem.Click += new System.EventHandler(this.setingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rulesToolStripMenuItem,
            this.controlsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // rulesToolStripMenuItem
            // 
            this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
            this.rulesToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.rulesToolStripMenuItem.Text = "Rules";
            // 
            // controlsToolStripMenuItem
            // 
            this.controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
            this.controlsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.controlsToolStripMenuItem.Text = "Controls";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "9";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "8";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 534);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 406);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 23);
            this.label7.TabIndex = 5;
            this.label7.Text = "5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 470);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 23);
            this.label8.TabIndex = 8;
            this.label8.Text = "4";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 596);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 23);
            this.label9.TabIndex = 9;
            this.label9.Text = "2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(5, 662);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 23);
            this.label10.TabIndex = 10;
            this.label10.Text = "1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(59, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 23);
            this.label11.TabIndex = 11;
            this.label11.Text = "A";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(123, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 23);
            this.label12.TabIndex = 12;
            this.label12.Text = "B";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(187, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 23);
            this.label13.TabIndex = 13;
            this.label13.Text = "C";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(251, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(25, 23);
            this.label14.TabIndex = 14;
            this.label14.Text = "D";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(315, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 23);
            this.label15.TabIndex = 15;
            this.label15.Text = "E";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(379, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 23);
            this.label16.TabIndex = 16;
            this.label16.Text = "F";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(443, 35);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(26, 23);
            this.label17.TabIndex = 17;
            this.label17.Text = "G";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(507, 35);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 23);
            this.label18.TabIndex = 18;
            this.label18.Text = "H";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(571, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 23);
            this.label19.TabIndex = 19;
            this.label19.Text = "I";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(635, 35);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 23);
            this.label20.TabIndex = 20;
            this.label20.Text = "J";
            // 
            // MoveHistoryListBox
            // 
            this.MoveHistoryListBox.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MoveHistoryListBox.FormattingEnabled = true;
            this.MoveHistoryListBox.ItemHeight = 22;
            this.MoveHistoryListBox.Location = new System.Drawing.Point(720, 157);
            this.MoveHistoryListBox.Name = "MoveHistoryListBox";
            this.MoveHistoryListBox.Size = new System.Drawing.Size(260, 400);
            this.MoveHistoryListBox.TabIndex = 21;
            this.MoveHistoryListBox.SelectedIndexChanged += new System.EventHandler(this.MoveHistoryListBox_SelectedIndexChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(720, 636);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(260, 23);
            this.progressBar.TabIndex = 22;
            // 
            // WithoutChangeLabel
            // 
            this.WithoutChangeLabel.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WithoutChangeLabel.Location = new System.Drawing.Point(720, 35);
            this.WithoutChangeLabel.Name = "WithoutChangeLabel";
            this.WithoutChangeLabel.Size = new System.Drawing.Size(260, 34);
            this.WithoutChangeLabel.TabIndex = 23;
            // 
            // BlackFlowLayout
            // 
            this.BlackFlowLayout.Controls.Add(this.pictureBox2);
            this.BlackFlowLayout.Controls.Add(this.BlackNameLabel);
            this.BlackFlowLayout.Controls.Add(this.label25);
            this.BlackFlowLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.BlackFlowLayout.Location = new System.Drawing.Point(720, 81);
            this.BlackFlowLayout.Name = "BlackFlowLayout";
            this.BlackFlowLayout.Size = new System.Drawing.Size(260, 70);
            this.BlackFlowLayout.TabIndex = 24;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::RP_1._4.Properties.Resources.black_pawn;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // BlackNameLabel
            // 
            this.BlackNameLabel.CausesValidation = false;
            this.BlackNameLabel.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BlackNameLabel.Location = new System.Drawing.Point(73, 0);
            this.BlackNameLabel.Name = "BlackNameLabel";
            this.BlackNameLabel.Size = new System.Drawing.Size(169, 33);
            this.BlackNameLabel.TabIndex = 3;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label25.Location = new System.Drawing.Point(73, 33);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(73, 32);
            this.label25.TabIndex = 3;
            this.label25.Text = "Score";
            // 
            // WhiteFlowLayout
            // 
            this.WhiteFlowLayout.Controls.Add(this.pictureBox1);
            this.WhiteFlowLayout.Controls.Add(this.WhiteNameLabel);
            this.WhiteFlowLayout.Controls.Add(this.label23);
            this.WhiteFlowLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.WhiteFlowLayout.Location = new System.Drawing.Point(720, 563);
            this.WhiteFlowLayout.Name = "WhiteFlowLayout";
            this.WhiteFlowLayout.Size = new System.Drawing.Size(260, 70);
            this.WhiteFlowLayout.TabIndex = 25;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::RP_1._4.Properties.Resources.white_pawn;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // WhiteNameLabel
            // 
            this.WhiteNameLabel.CausesValidation = false;
            this.WhiteNameLabel.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WhiteNameLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.WhiteNameLabel.Location = new System.Drawing.Point(73, 0);
            this.WhiteNameLabel.Name = "WhiteNameLabel";
            this.WhiteNameLabel.Size = new System.Drawing.Size(169, 33);
            this.WhiteNameLabel.TabIndex = 1;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label23.Location = new System.Drawing.Point(73, 33);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(73, 32);
            this.label23.TabIndex = 2;
            this.label23.Text = "Score";
            // 
            // PlayerMoveWorker
            // 
            this.PlayerMoveWorker.WorkerReportsProgress = true;
            this.PlayerMoveWorker.WorkerSupportsCancellation = true;
            this.PlayerMoveWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GetPlayerMove_DoWork);
            this.PlayerMoveWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.PlayerMoveWorker_ProgressChanged);
            this.PlayerMoveWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.PlayerMoveWorker_RunWorkerCompleted);
            // 
            // ComputerMoveWorker
            // 
            this.ComputerMoveWorker.WorkerReportsProgress = true;
            this.ComputerMoveWorker.WorkerSupportsCancellation = true;
            this.ComputerMoveWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ComputerMoveWorker_DoWork);
            this.ComputerMoveWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ComputerMoveWorker_ProgressChanged);
            this.ComputerMoveWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ComputerMoveWorker_RunWorkerCompleted);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(720, 665);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(89, 33);
            this.StartButton.TabIndex = 26;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(815, 665);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(89, 33);
            this.StopButton.TabIndex = 27;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::RP_1._4.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(992, 723);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.WhiteFlowLayout);
            this.Controls.Add(this.BlackFlowLayout);
            this.Controls.Add(this.WithoutChangeLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.MoveHistoryListBox);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pad);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pad)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.BlackFlowLayout.ResumeLayout(false);
            this.BlackFlowLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.WhiteFlowLayout.ResumeLayout(false);
            this.WhiteFlowLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pad;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem setingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ListBox MoveHistoryListBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label WithoutChangeLabel;
        private System.Windows.Forms.FlowLayoutPanel BlackFlowLayout;
        private System.Windows.Forms.FlowLayoutPanel WhiteFlowLayout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label WhiteNameLabel;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label BlackNameLabel;
        private System.Windows.Forms.Label label25;
        private System.ComponentModel.BackgroundWorker PlayerMoveWorker;
        private System.ComponentModel.BackgroundWorker ComputerMoveWorker;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;


    }
}