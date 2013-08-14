using RP_1._4.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace RP_1._4.GUI
{
    public partial class MainForm : Form
    {

        private GraphicsUI Gui;
        public BackgroundWorker PlayerMWorker;
        public BackgroundWorker ComputerMWorker;
        public delegate void ProgresBarHandler(int value);
        public ProgresBarHandler progresHandler;
        public MainForm(GraphicsUI gui)
        {
            Gui = gui;
            InitializeComponent();
            this.pad.Size = new System.Drawing.Size(GBoard.boardsize * GBoard.tilesize, GBoard.boardsize * GBoard.tilesize);
            PlayerMWorker = PlayerMoveWorker;
            ComputerMWorker = ComputerMoveWorker;
            progresHandler = new ProgresBarHandler(ChangeProgressBarValue);
            UpdateButtons();

            // this.ClientSize = new Size(pad.Width + pad.Left * 2, pad.Height + pad.Top * 2);
        }

        private void pad_Paint(object sender, PaintEventArgs e) { Gui.PaintBoard(e); }
        private void pad_MouseDown(object sender, MouseEventArgs e) { if (Gui.DoMouseDown(e)) pad.Invalidate(); }
        private void pad_MouseUp(object sender, MouseEventArgs e) { if (Gui.DoMouseUp(e)) pad.Invalidate(); }
        private void pad_MouseMove(object sender, MouseEventArgs e) { if (Gui.DoMouseMove(e)) pad.Invalidate(); }
        
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gui.Manager.StopManaging();
            GameSetings newGame = new GameSetings(Gui, true);
            if (newGame.ShowDialog(this) == DialogResult.OK)
            {
                Gui.Update();
                UpdateForm();
                Gui.ActualMove = new Move();
            }
            Gui.Manager.StartManaging();
        }



        public void UpdateForm()
        {
            UpdateLabels();
            UpdateOnMove();
            UpdateButtons();
            UpdateList();

            pad.Invalidate();
        }

        public void UpdateList()
        {
            int index = MoveHistoryListBox.SelectedIndex;
            MoveHistoryListBox.Items.Clear();
            List<object[]> reversedStack = Gui.Manager.Board.UndoStack.ToList();
            reversedStack.Reverse();
            foreach (object[] historyItem in reversedStack)
            {
                MoveHistoryListBox.Items.Add(historyItem[0].ToString());
            }
            reversedStack = Gui.Manager.Board.RedoStack.ToList();
            foreach (object[] historyItem in reversedStack)
            {
                MoveHistoryListBox.Items.Add(historyItem[0].ToString());
            }
            //MoveHistoryListBox.SelectedIndex = index;
        }

        public void UpdateButtons()
        {
            if (Gui.Manager.Board.RedoStack.Count == 0) redoToolStripMenuItem.Enabled = false;
            else redoToolStripMenuItem.Enabled = true; ;
            if (Gui.Manager.Board.UndoStack.Count == 0) unToolStripMenuItem.Enabled = false;
            else unToolStripMenuItem.Enabled = true;
            if (Gui.Manager.P1 == null || Gui.Manager.P2 == null)
            {
                setingsToolStripMenuItem.Enabled = false;
                saveGameToolStripMenuItem.Enabled = false;
            }
            else
            {
                setingsToolStripMenuItem.Enabled = true;
                saveGameToolStripMenuItem.Enabled = true;
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void UpdateLabels()
        {
            WhiteNameLabel.Text = Gui.Manager.P1.Name;
            BlackNameLabel.Text = Gui.Manager.P2.Name;
            WithoutChangeLabel.Text = "Tahu bez změny" + ": " + Gui.Manager.Rules.NoJumpMoves.ToString();
        }

        private void UpdateOnMove()
        {
            if (Gui.Manager.Rules.OnMove == Gui.Manager.P1)
            {
                WhiteFlowLayout.BackColor = System.Drawing.Color.Green;
                BlackFlowLayout.BackColor = System.Drawing.Color.White;
            }
            else
            {
                WhiteFlowLayout.BackColor = System.Drawing.Color.White;
                BlackFlowLayout.BackColor = System.Drawing.Color.Green;
            }
        }

        public void ComitResult(int result)
        {
            Gui.Update();
            DialogResult Dresult;

            if (result == 2) Dresult = MessageBox.Show(this, "Hra konci remizou! /nChcete zahájit novou hru?", "Konec hry", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == 1) Dresult = MessageBox.Show(this, string.Format("Hra konci vytezi {0}!/nChcete zahájit novou hru?", Gui.Manager.Rules.WhoNotOnMove().Name), "Konec hry", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           // if (Dresult == System.Windows.Forms.DialogResult.Yes) ;
        }

        public void GetPlayerMove_DoWork(object sender, DoWorkEventArgs e)
        {   
            Gui.DoGetPlayerMove_DoWork(e);
        }

        private void ComputerMoveWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //progressBar.Visible = true;
            Gui.ActualMove = Gui.Manager.Brain.GenerateBestMove(Gui.Manager.Rules.OnMove, this);
            return;
        }

        private void ComputerMoveWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar.Value = e.ProgressPercentage;

        }

        private void ComputerMoveWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Gui.MoveFinished = true;
            this.Invoke(progresHandler, 0);
        }

        private void PlayerMoveWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void PlayerMoveWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Gui.MoveFinished = true;
            this.Invoke(progresHandler, 0);
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gui.DoSaveGame();
        }

        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gui.DoLoadGame();
        }

        public void ChangeProgressBarValue(int value)
        {
            progressBar.Value = value;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Aktuální hra není uložena. Přejete si hru uložit?", "Pozor", MessageBoxButtons.YesNoCancel);
            if(result == DialogResult.Yes)
            {
                Gui.DoSaveGame();
            }
            if (result == DialogResult.Cancel) 
            {
                e.Cancel = true;
            }
        }

        private void quitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            /*
            DialogResult result = MessageBox.Show("Aktuální hra není uložena. Přejete si hru uložit?", "Pozor", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                Gui.DoSaveGame();
            }
            if (result == DialogResult.Cancel) return;
             * */
            this.Close();

        }

        private void unToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gui.Manager.StopManaging();
            Gui.Manager.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gui.Manager.StopManaging();
            Gui.Manager.Redo();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Gui.Manager.StartManaging();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            Gui.Manager.StopManaging();
        }

        private void setingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gui.Manager.StopManaging();
            GameSetings gameSetings = new GameSetings(Gui, false);
            if (gameSetings.ShowDialog(this) == DialogResult.OK)
            {
                Gui.Update();
                UpdateForm();
                Gui.ActualMove = new Move();
            }
            Gui.Manager.StartManaging();
        }

        private void MoveHistoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int actual = MoveHistoryListBox.SelectedIndex;
            Gui.Manager.jumpTo(actual);
            Text = actual.ToString();
        }
    }
}
