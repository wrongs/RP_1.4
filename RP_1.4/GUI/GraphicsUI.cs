using RP_1._4.Enums;
using RP_1._4.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RP_1._4.GUI
{
    public class GraphicsUI
    {
        private Stone ActualStone;
        public MainForm MForm { get; private set; }
        public GameManager Manager { get; private set; }
        public Move ActualMove { get; set; }
        public Point ActualPosition { get; set; }
        public Point ActualBoardPosition { get; set; }
        public Point StartPosition { get; private set; }
        public Point EndPosition { get; private set; }
        public bool MouseDown { get; private set; }
        public bool MoveFinished { get; set; }
        public bool IsAlive { get; set; }
        //public Chessboard Board { get; private set; }
        public GBoard GBoard { get; private set; }

        public GraphicsUI(GameManager manager)
        {
            Manager = manager;
            GBoard = new GBoard(Manager.Board);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MForm = new MainForm(this);
            //Application.Run(MForm);
        }

        public void Run()
        {
            Application.Run(MForm);
        }

        public void load()
        {
            GBoard = new GBoard(Manager.Board);
        }

        public void Update()
        {
            GBoard.UpdateGBoard();
            MForm.UpdateForm();
            //update 
            MoveFinished = false;
            ActualMove = new Move();
        }

        public bool DoMouseDown(MouseEventArgs e)
        {
            StartPosition = GBoard.CordsToBoard(e.X, e.Y);

            if (GBoard.GetStoneOnPosition(StartPosition.X, StartPosition.Y) != Stone.None)
            {
                MouseDown = true;
                MForm.Cursor = Cursors.Hand;
                ActualStone = GBoard.GetStoneOnPosition(StartPosition.X, StartPosition.Y);
                GBoard.SetStoneOnPosition(StartPosition.X, StartPosition.Y, Stone.None);
                return true;
            }
            return false;
        }


        public bool DoMouseUp(MouseEventArgs e)
        {
            if (MouseDown)
            {
                EndPosition = GBoard.CordsToBoard(e.X, e.Y);
                if (GBoard.CheckPosition(EndPosition.X, EndPosition.Y)) DoPlayerShift();

                else GBoard.SetStoneOnPosition(StartPosition.X, StartPosition.Y, ActualStone);
                MForm.Cursor = Cursors.Default;
                MouseDown = false;
                return true;
            }
            return false;
        }

        public bool DoMouseMove(MouseEventArgs e)
        {
            ActualPosition = new Point(e.X, e.Y);
            if (MouseDown) return true;
            return false;
        }

        public void PaintBoard(PaintEventArgs e)
        {
            GBoard.DrawBoard(e);
            if (MouseDown) GBoard.DrawMove(ActualPosition.X, ActualPosition.Y, ActualStone, e);
        }

        public Move GetMove()
        {
            IsAlive = true;
            if (Manager.Rules.OnMove.Type == 1) MForm.PlayerMWorker.RunWorkerAsync();
            else
            {
                //MForm.ComputerMWorker.ReportProgress(percentComplete);
                MForm.ComputerMWorker.RunWorkerAsync();
            }
            do
            {
                Thread.Sleep(50);
                if (!IsAlive) return new Move();
            } while (!MoveFinished);
            return ActualMove;
        }

        public void StopWorkers()
        {
            if (MForm.ComputerMWorker.IsBusy)
            {
                MForm.ComputerMWorker.CancelAsync();
                Application.DoEvents();
                //WaitForWorkerToFinish(MForm.ComputerMWorker);
            }
            if (MForm.PlayerMWorker.IsBusy)
            {
                MForm.PlayerMWorker.CancelAsync();
                Application.DoEvents();
                //WaitForWorkerToFinish(MForm.PlayerMWorker);
            }
            IsAlive = false;

        }

        private void WaitForWorkerToFinish(BackgroundWorker worker)
        {
            //Application.DoEvents();
            while (worker.IsBusy)
            {
                Thread.Sleep(50);
            }

        }
        private void DoPlayerShift()
        {
            if (!Manager.GeneratePlayerMove(StartPosition.X, StartPosition.Y, EndPosition.X, EndPosition.Y, ActualMove))
            {
                GBoard.SetStoneOnPosition(StartPosition.X, StartPosition.Y, ActualStone);
                return;
            }
            if (Manager.DoPlayerShift(ActualMove))
            {
                GBoard.SetStoneOnPosition(EndPosition.X, EndPosition.Y, ActualStone);
                if (ActualMove.GetShifts().Last().Jumped != Stone.None) GBoard.SetStoneOnPosition(ActualMove.GetShifts().Last().X2, ActualMove.GetShifts().Last().Y2, Stone.None);
            }
            else
            {
                GBoard.SetStoneOnPosition(StartPosition.X, StartPosition.Y, ActualStone);
                ActualMove = new Move();
            }

            /*
             * switch (Manager.DoPlayerShift(ActualMove))
            {
                case 0: GBoard.SetStoneOnPosition(StartPosition.X, StartPosition.Y, ActualStone);
                    break;
                case 1: GBoard.SetStoneOnPosition(StartPosition.X, StartPosition.Y, ActualStone);
                    break;
                case 2: GBoard.SetStoneOnPosition(StartPosition.X, StartPosition.Y, ActualStone);
                    break;
                case 3: GBoard.SetStoneOnPosition(EndPosition.X, EndPosition.Y, ActualStone);
                    break;
                case 4: GBoard.SetStoneOnPosition(EndPosition.X, EndPosition.Y, ActualStone);
                    break;
                case 5: GBoard.SetStoneOnPosition(EndPosition.X, EndPosition.Y, ActualStone);
                    break;
                default:
                    break;
            }
             * */
        }

        public void DoGetPlayerMove_DoWork(DoWorkEventArgs e)
        {
            do
            {
                if (MForm.PlayerMWorker.CancellationPending) break;
                Thread.Sleep(50);
                if (ActualMove.GetShifts().Count != 0)
                {
                    if (Manager.Rules.IsInRules(ActualMove)) break;
                }
            } while (true);
        }


        public void DoSaveGame()
        {
            Manager.StopManaging();
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = ".xml";
            saveDialog.Filter = "Xml dokumenty (.xml)|*.xml";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                Manager.XManager.SaveGame(saveDialog.FileName);
            }
            Manager.StopManaging();
        }

        public void DoLoadGame()
        {
            Manager.StopManaging();
            OpenFileDialog loadDialog = new OpenFileDialog();
            loadDialog.DefaultExt = ".xml";
            loadDialog.Filter = "Xml dokumenty (.xml)|*.xml";
            if (loadDialog.ShowDialog() == DialogResult.OK)
            {
                string name = loadDialog.FileName;
                Manager.XManager.LoadGame(name);
                load();
                Update();
            }
            Manager.StartManaging();
        }
    }
}
