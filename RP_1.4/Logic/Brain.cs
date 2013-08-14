using RP_1._4.Enums;
using RP_1._4.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace RP_1._4.Logic
{

    public class Brain
    {
        Rules Rules;
        Chessboard Board;
        //----------konstanta _MAX je pro označní konce hry
        private int _MAX = 3000;
        //----------konstanta _Mnoho slouží pro rozlišení tahů ukončujících hru a bežných tahů
        private int _Mnoho = 2500;
        //----------directions - pole obsahující všechny možné směry 
        private int[,] directions = { { -1, -1 }, { -2, 0 }, { -1, 1 }, { 0, -2 }, { 0, 2 }, { 1, -1 }, { 2, 0 }, { 1, 1 } };

        public Brain(Rules rules, Chessboard board)
        {
            Rules = rules;
            Board = board;
        }

        //pomocné funkce při práci v rekurzi
        private int Farther(int value)
        {
            if (value > _Mnoho)
            {
                return value++;
            }
            if (value < -_Mnoho)
            {
                return value--;
            }
            return value;
        }

        //pomocné funkce při práci v rekurzi
        private int Closer(int value)
        {
            if (value > _Mnoho)
            {
                return value--;
            }
            if (value < -_Mnoho)
            {
                return value++;
            }
            return value;
        }

        //minimax s alfabeta ořezáváním pro větří rychlost algoritmu
        private int Alfabeta(Player player, int depth, int alfa, int beta)
        {
            if (Rules.IsLoose(player)) return -_MAX;
            if (Rules.IsWin(player)) return _MAX;
            if (Rules.EndGame(player) == 2) return 0;
            if (depth == 0) return EvaluationBoard(Board, player);

            List<Move> moves = Rules.GenerateMoves(player);
            foreach (Move move in moves)
            {
                int tNoChange = 0, tLastSum = 0;
                SaveVariables(ref tNoChange, ref tLastSum);

                Rules.DoMoveInRules(move);
                int ohodnoceni = -Alfabeta(Rules.OppositePlayer(player), depth - 1, Farther(-beta), Farther(-alfa));

                Rules.DoInvMoveInRules(move);
                LoadVariables(tNoChange, tLastSum);

                ohodnoceni = Closer(ohodnoceni);
                if (ohodnoceni > alfa)
                {
                    alfa = ohodnoceni;
                    if (ohodnoceni >= beta) return beta;
                }
            }
            return alfa;
        }

        //generování nejlepšího tahu
        public Move GenerateBestMove(Player player, MainForm Mform)
        {
            List<Move> moves = Rules.GenerateMoves(player);
            int alfa = -_MAX;
            Move BestMove = moves.First();
            int i = 0;
            foreach (Move m in moves)
            {
                if (Mform.ComputerMWorker.CancellationPending)
                {
                    return new Move();
                }
                i++;
                Mform.Invoke(Mform.progresHandler, 100 * i / moves.Count);
                //worker.ReportProgress(100 * i / moves.Count);
                int tNoChange = 0, tLastSum = 0;
                SaveVariables(ref tNoChange, ref tLastSum);

                Rules.DoMoveInRules(m);
                int ohodnoceni = -Alfabeta(Rules.OppositePlayer(player), player.Difficulty, -_MAX, Farther(-alfa)); ///zmena - na +

                Rules.DoInvMoveInRules(m);
                LoadVariables(tNoChange, tLastSum);

                ohodnoceni = Closer(ohodnoceni);
                if (ohodnoceni > alfa)
                {
                    alfa = ohodnoceni;
                    BestMove = m;
                }
            }
            return BestMove;
        }

        //ohodnocovací funkce
        private int EvaluationBoard(Chessboard board, Player player)
        {
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Stone value = board.GetValueOnPosition(i, j);
                    sum += (int)value;
                    if (value != 0)
                    {
                        if (Rules.PlayerStone(Rules.GetWhitePlayer(), value))
                        {
                            if (i == 9) sum += 3;
                            else if ((i == 0) && (value == Stone.WhiteChecker)) sum += 2;
                            else if ((j == 0) || (j == 9)) sum += 2;
                            for (int k = 0; k < 8; k++)
                            {
                                int x = i + directions[k, 0];
                                int y = j + directions[k, 1];
                                if (Board.IsInBoard(x, y))
                                {
                                    if (Rules.PlayerStone(Rules.GetWhitePlayer(), board.GetValueOnPosition(x, y))) sum += 1;
                                }
                            }
                        }
                        else
                        {
                            if (i == 0) sum -= 3;
                            else if ((i == 9) && (value == Stone.BlackChecker)) sum -= 2;
                            else if ((j == 0) || (j == 9)) sum -= 2;

                            for (int k = 0; k < 8; k++)
                            {
                                int x = i + directions[k, 0];
                                int y = j + directions[k, 1];
                                if (Board.IsInBoard(x, y))
                                {
                                    if (Rules.PlayerStone(Rules.GetBlackPlayer(), board.GetValueOnPosition(x, y))) sum -= 1;
                                }
                            }
                        }
                    }
                }
            }
            if (Rules.IsWhitePlayer(player)) return sum;
            return -sum;
        }

        //pomocné funkce pro ukládání a načítání proměnných použitých v rekurzi
        private void SaveVariables(ref int variable1, ref int variable2)
        {
            variable1 = Rules.NoJumpMoves;
            variable2 = Rules.StonesCount;
        }

        private void LoadVariables(int variable1, int variable2)
        {
            Rules.NoJumpMoves = variable1;
            Rules.StonesCount = variable2;
        }

    }
}
