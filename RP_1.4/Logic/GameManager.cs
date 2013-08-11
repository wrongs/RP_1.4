using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
//using Ročníkový_projekt_v_1._3.GUI;
using System.Threading;
using RP_1._4.Enums;
using RP_1._4.GUI;

namespace RP_1._4.Logic
{
    public class GameManager
    {
        //private UI UI;
        private GraphicsUI UI;
        private Move TempActualMove;
        private Move ActualMove;
        private Thread mainThread;
        public Player P1 { get; set; }
        public Player P2 { get; set; }
        public Rules Rules { get; set; }
        public Brain Brain { get; private set; }
        public Chessboard Board { get; set; }
        public XmlManager XManager { get; private set; }

        //Trida ktera slouzi jako rozhrani mezi logikou a UI
        public GameManager()
        {
            XManager = new XmlManager(this);
            Board = new Chessboard();
            UI = new GraphicsUI(this);
            UI.Run();
        }


        public void NewGame(String player1, String player2, int type1, int type2, int difficulity1, int difficulity2)
        {
            StopManaging();
            P1 = new Player(player1, type1, difficulity1 * 2);
            P2 = new Player(player2, type2, difficulity2 * 2);

            TempActualMove = new Move();
            ActualMove = new Move();

            Board.CleanBoard();
            Board.FillBoard();
            Rules = new Rules(P1, Board, P2);
            Brain = new Brain(Rules, Board);

            mainThread = new Thread(ManageGame);
            mainThread.IsBackground = true;
            mainThread.Start();
        }

        public void NewGame(Player player1, Player player2, Rules rules, Chessboard board)
        {
           // UI.StopWorkers();
           // StopManageGame();
            StopManaging();
            P1 = player1;
            P2 = player2;

            Rules = rules;
            Board = board;
            Brain =  new Brain(rules, board);

            mainThread = new Thread(ManageGame);
            mainThread.IsBackground = true;
            mainThread.Start();
        }

        public void StopManaging()
        {
            if (mainThread != null && mainThread.IsAlive)
            {
                UI.StopWorkers();
                mainThread.Abort();
            }
        }

        public void StartManaging()
        {
            if (mainThread == null || !mainThread.IsAlive)
            {
                mainThread = new Thread(ManageGame);
                mainThread.IsBackground = true;
                mainThread.Start();
            }
        
        }
        /*
        public void SetOnLoad()
        {
            Rules = new Rules(P1, Board, P2);
            Brain = new Brain(Rules, Board);

            mainThreat = new Thread(ManageGame);
            t.IsBackground = true;
            t.Start();
        }
        */
        /*
        //hlavni smycka ve hre zajistujici prijmani prikazu lidskeho hrace a generovani taho pocitacovym hracem
        public void Play()
        {
            bool konec = false;
            do
            {
                if (Rules.OnMove.GetPlayerType() == 0)
                {
                    System.Threading.Thread.Sleep(2000);
                    UI.CommandComputerMove(ref konec);
                }
                else
                {
                    UI.ReadCommand(ref konec);
                }
            } while (konec != true);
        }
        */

        public void ManageGame()
        {
            do
            {
                UI.Update();
                Move move = UI.GetMove();
                if (move.GetShifts().Count == 0) continue;
                //if (mainThread.ThreadState == ThreadState.Aborted) break;
                if (!mainThread.IsAlive) break;
                if (DoMove(move))
                {
                    UI.Update();
                    break;
                }
                System.Threading.Thread.Sleep(50); 
            } while (true);

        }

        //Metoda ktera nejdrive vygeneruje tak ze vstupu uzivatele a pote provadi kontrolu spravnosti tahu 
        public bool DoPlayerShift(Move TempMove)
        {
            if (Rules.IsShiftInRules(TempMove))
            {
                return true;
            }
            return false;
        }


        //metoda generujici tah hrace ze zadanych souradnic
        public bool GeneratePlayerMove(int x1, int y1, int x2, int y2, Move move)
        {
            int x3 = x1;
            int y3 = y1;
            Stone originalStone;
            Stone jumpedStone = Stone.None;
            int[] direction = ComputeDirection(x1, y1, x2, y2);
            do
            {
                x3 = x3 + direction[0];
                y3 = y3 + direction[1];
                Stone stone = Board.GetValueOnPosition(x3, y3);
                if (0 != stone)
                {
                    jumpedStone = stone;
                    break;
                }
            }
            while (!((x3 == x2) && (y3 == y2)));

            if (move.GetShifts().Count == 0)
            {
                originalStone = Board.GetValueOnPosition(x1, y1);
                if (!(Rules.OnMoveStone(originalStone))) return false;
                move.SetStone(originalStone);
            }

            if (jumpedStone == 0) move.AddShift(x1, y1, x2, y2);
            else move.AddShift(x1, y1, x3, y3, x2, y2, jumpedStone);

            return true;
        }
        /*
        // metoda která provadí tah počítačem
        public int DoComputerMove()
        {
            Move Move = Brain.GenerateBestMove(Rules.OnMove);
            Rules.DoMoveInRules(Move);
            Board.UndoStack.Push(Move);
            Board.RedoStack.Clear();
            Rules.ChangeOnMove();
            int result = Rules.EndGame(Rules.OnMove);
            if (result == 1) return 1;
            if (result == 2) return 2;
            return 0;
        }
        */
        public bool DoMove(Move move)
        {
            Rules.DoMoveInRules(move);
            Board.UndoStack.Push(move);
            Board.RedoStack.Clear();
            Rules.ChangeOnMove();
            int result = Rules.EndGame(Rules.OnMove);
            return ComitResult(result);
        }

        private bool ComitResult(int result)
        {
            if (result == 1)
            {
                UI.MForm.ComitResult(1);
                return true;
            }
            if (result == 2)
            {
                UI.MForm.ComitResult(2);
                return true;
            }
            return false;
        }

        public void Undo()
        {
            Move move = Board.UndoStack.Pop();
            Rules.DoInvMoveInRules(move);
            Board.RedoStack.Push(move);
            Rules.ChangeOnMove();
            UI.Update();
        }

        // metoda pro krok vpred ve hre
        public void Redo()
        {
            Move move = Board.RedoStack.Pop();
            Rules.DoMoveInRules(move);
            Board.UndoStack.Push(move);
            Rules.ChangeOnMove();
            UI.Update();
        }

        //pomocna metoda pro prevod souradnic
        public void TransferToField(ref int x, ref int y)
        {
            x = Math.Abs((x - '0') - 9);
            y = y - 17 - '0';
        }

        //pomocna metoda pro vypocet smeru pohybu
        private int[] ComputeDirection(int x1, int y1, int x2, int y2)
        {
            int d1 = x2 - x1;
            int d2 = y2 - y1;
            int[] direction = new int[2];
            if (d1 != 0) direction[0] = d1 / Math.Abs(d1);
            if (d2 != 0) direction[1] = d2 / Math.Abs(d2);
            return direction;
        }
    }
}
