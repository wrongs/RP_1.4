﻿using RP_1._4.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RP_1._4.Logic
{
    public class Rules
    {

        private const int _Up = -1;
        private const int _Down = 1;
        private int[,] _CheckerDirections = { { -1, -1 }, { -2, 0 }, { -1, 1 }, { 0, -2 }, { 0, 2 }, { 1, -1 }, { 2, 0 }, { 1, 1 } };
        private int[,] _PawnDirections = { { -2, -2 }, { -4, 0 }, { -2, 2 }, { 0, -4 }, { 0, 4 }, { 2, -2 }, { 4, 0 }, { 2, 2 } };
        public int NoJumpMoves { get; set; }
        public int FigurinesCount { get; set; }
        public Player OnMove { get; set; }
        private Player WhitePlayer;
        private Player BlackPlayer;
        private Chessboard Board;

        public Rules(Chessboard board)
        {
            Board = board;
            FigurinesCount = 0;
            NoJumpMoves = 0;
        }

        public Rules(Player onMove, Chessboard board, Player player)    
            : this(board)
        {
            OnMove = onMove;
            WhitePlayer = onMove;
            BlackPlayer = player;
        }

        //metoda provadejici tah na dece podle pravidel vcetne poviseni pescu a vyhozeni skakanych pescu
        public void DoMoveInRules(Move move)
        {
            Board.DoMove(move);
            Board.DoRemove(move);
            Promote(move);
        }

        //metoda provadejici inverzni tah na dece podle pravidel vcetne degradovani pescu a navraceni skakanych pescu
        public void DoInvMoveInRules(Move move)
        {
            Board.DoInvMove(move);
            //Degrade(move);
        }

        public void ChangeOnMove()
        {
            if (IsWhitePlayer(OnMove)) OnMove = BlackPlayer;
            else OnMove = WhitePlayer;
        }

        //metoda vracejici hodnotu hrace ktery neni na tahu
        public Player WhoNotOnMove()
        {
            return OppositePlayer(OnMove);
        }

        //metoda generujici všechny tahy pro danou pozici 
        public List<Move> GenerateMovesForPosition(int x, int y)
        {
            List<Move> moves = new List<Move>();
            Player player;
            Stone stoneOnPosition = Board.GetValueOnPosition(x, y);

            if (Board.IsEmpty(x, y)) return moves;
            player = FigurineWhichPlayer(stoneOnPosition);

            if (Board.EquaStoneOnPosition(Stone.WhitePawn, x, y) || Board.EquaStoneOnPosition(Stone.BlackPawn, x, y))
            {
                moves.AddRange(GenerateJumpPawnMoves(x, y, new List<Move>(), new List<int[]>(), new Move().SetStone(stoneOnPosition), player));
                if (moves.Count == 0) moves.AddRange(GenerateCommonPawnMoves(x, y));
            }
            else
            {
                moves.AddRange(GenerateJumpCheckerMoves(x, y, new List<Move>(), new List<int[]>(), new Move().SetStone(stoneOnPosition), player));
                if (moves.Count == 0) moves.AddRange(GenerateCommonCheckerMoves(x, y));
            }
            return moves;
        }

        // kontrola jestli je tah podle pravidel
        public bool IsInRules(Move m)
        {
            //List<Move> moves = GenerateMovesForPosition(m.GetShifts()[0].X1, m.GetShifts()[0].Y1);
            List<Move> moves = GenerateMoves(OnMove);
            List<Move> availableMoves = AvailableMoves(moves);
            if (availableMoves.Contains(m)) return true;
            return false;
        }

        public bool IsShiftInRules(Move m)
        {
            //List<Move> moves = GenerateMovesForPosition(m.GetShifts()[0].X1, m.GetShifts()[0].Y1);
            List<Move> moves = GenerateMoves(OnMove);
            List<Move> availableMoves = AvailableMoves(moves);
            foreach (Move move in availableMoves)
            {
                List<Shift> reduced = move.GetShifts().GetRange(0, m.GetShifts().Count);
                move.SetShifts(reduced);
            }
            if (availableMoves.Contains(m)) return true;
            return false;
        }

        //generovani vsech moznych tahu pro hrace ktery je na tahu
        public List<Move> GenerateMoves(Player player)
        {
            List<Move> moves = new List<Move>();
            for (int i = Chessboard._TopBorder; i <= Chessboard._BottomBorder; i++)
                for (int j = Chessboard._LefBorder; j <= Chessboard._RightBorder; j++)
                {
                    if (PlayerFigurine(player, Board.GetValueOnPosition(i, j))) moves.AddRange(GenerateMovesForPosition(i, j));
                }
            List<Move> moves2;
            moves2 = AvailableMoves(moves);
            return moves2;
        }


        //generovani neskovych tahu pro normalni figurku
        private List<Move> GenerateCommonPawnMoves(int x, int y)
        {
            Stone stoneOnPosition = Board.GetValueOnPosition(x, y);
            int direction = FigurineDirection(stoneOnPosition);
            List<Move> commonMoves = new List<Move>();
            int xInDirection = x + direction;
            if (Board.IsEmpty(xInDirection, y - 1)) commonMoves.Add(new Move(x, y, xInDirection, y - 1, stoneOnPosition));
            if (Board.IsEmpty(xInDirection, y + 1)) commonMoves.Add(new Move(x, y, xInDirection, y + 1, stoneOnPosition));
            return commonMoves;
        }

        //generovani neskokovych tahu pro damu
        private List<Move> GenerateCommonCheckerMoves(int x, int y)
        {
            List<Move> commonMoves = new List<Move>();
            //int[,] _CheckerDirections = { { -1, -1 }, { -2, 0 }, { -1, 1 }, { 0, -2 }, { 0, 2 }, { 1, -1 }, { 2, 0 }, { 1, 1 } };
            for (int i = 0; i < 8; i++)
            {
                int x2 = x;
                int y2 = y;
                do
                {
                    x2 += _CheckerDirections[i, 0];
                    y2 += _CheckerDirections[i, 1];
                    if (!(Board.IsEmpty(x2, y2))) break;
                    else commonMoves.Add(new Move(x, y, x2, y2, Board.GetValueOnPosition(x, y)));
                } while (Board.IsInBoard(x2, y2));
            }
            return commonMoves;
        }

        //generovani skoku pro normalni figurku
        private List<Move> GenerateJumpPawnMoves(int x, int y, List<Move> jumpMoves, List<int[]> occupied, Move move, Player player)
        {
            Stone stoneOnPosition = Board.GetValueOnPosition(x, y);
            Board.SetValueOnPosition(x, y, 0);
            for (int i = 0; i < 8; i++)
            {
                int x3 = x + _PawnDirections[i, 0];
                int y3 = y + _PawnDirections[i, 1];
                int x2 = (x + x3) / 2;
                int y2 = (y + y3) / 2;
                if (PossibleToPawnJump(x, y, x2, y2, x3, y3, occupied, player))
                {
                    Move nextJump = move.CopyMove();
                    nextJump.AddShift(x, y, x2, y2, x3, y3, Board.GetValueOnPosition(x2, y2));
                    jumpMoves.Add(nextJump);
                    List<int[]> tempOccupied = occupied.GetRange(0, occupied.Count);
                    tempOccupied.Add(new int[] { x2, y2 });
                    GenerateJumpPawnMoves(x3, y3, jumpMoves, tempOccupied, nextJump, player);
                }
            }
            Board.SetValueOnPosition(x, y, stoneOnPosition);
            return jumpMoves;
        }

        //pomocna metoda pro kontrolu moznosti skoku
        private bool PossibleToPawnJump(int x1, int y1, int x2, int y2, int x3, int y3, List<int[]> occupied, Player player)
        {
            if (!(Board.IsInBoard(x3, y3))) return false;
            else if (!(Board.IsEmpty(x3, y3))) return false;
            if (NotPlayerFigurine(player, Board.GetValueOnPosition(x2, y2)))
            {
                foreach (int[] a in occupied)
                {
                    if ((x2 == a[0]) && (y2 == a[1])) return false;
                }
                return true;
            }
            return false;
        }

        //generevani skoku pro damu
        private List<Move> GenerateJumpCheckerMoves(int x, int y, List<Move> jumpMoves, List<int[]> occupied, Move m, Player player)
        {
            Stone stoneOnPosition = Board.GetValueOnPosition(x, y);
            Board.SetValueOnPosition(x, y, 0);
            List<int[]> tempOccupied = new List<int[]>();
            for (int i = 0; i < 8; i++)
            {
                int x3 = x + _CheckerDirections[i, 0];
                int y3 = y + _CheckerDirections[i, 1];
                int x2 = 0, y2 = 0;
                bool jumpEnabled = false;
                while (Board.IsInBoard(x3, y3))
                {
                    Stone actualStone = Board.GetValueOnPosition(x3, y3);
                    if (0 != actualStone & (jumpEnabled == true)) break;
                    if (ContainsOccupied(occupied, x3, y3)) break;
                    if (PlayerFigurine(player, actualStone)) break;
                    else if (!(PlayerFigurine(player, actualStone)) & (0 != actualStone) & jumpEnabled == false)
                    {
                        jumpEnabled = true;
                        x2 = x3;
                        y2 = y3;
                        tempOccupied = occupied.GetRange(0, occupied.Count);
                        tempOccupied.Add(new int[] { x3, y3 });
                    }
                    else if (actualStone == 0 & jumpEnabled == true)
                    {
                        Move nextJump = m.CopyMove();

                        nextJump.AddShift(x, y, x2, y2, x3, y3, Board.GetValueOnPosition(x2, y2));
                        jumpMoves.Add(nextJump); ;
                        GenerateJumpCheckerMoves(x3, y3, jumpMoves, tempOccupied, nextJump, player);
                    }
                    x3 += _CheckerDirections[i, 0];
                    y3 += _CheckerDirections[i, 1];
                }
            }
            Board.SetValueOnPosition(x, y, stoneOnPosition);
            return jumpMoves;
        }

        //metoda ktera filtruje pohyby ktere nejsou podle pravidel skoku
        private List<Move> AvailableMoves(List<Move> moves)
        {
            List<Move> availableMoves = new List<Move>();
            Move bestMove = moves.First();
            double bestSum = 0;
            foreach (Move move in moves)
            {
                double thisMoveSum = move.JumpSum();
                if (thisMoveSum > bestSum)
                    bestSum = thisMoveSum;
            }
            foreach (Move move in moves)
            {
                if (move.JumpSum() == bestSum) availableMoves.Add(move);
            }
            return availableMoves;
        }

        //metoda obsluhujici zmenu kamene na damu
        public void Promote(Move m)
        {
            Shift shift = m.GetShifts().Last();
            if (shift.X3 == Chessboard._TopBorder)
                if (Board.EquaStoneOnPosition(Stone.WhitePawn, shift.X3, shift.Y3)) Board.SetValueOnPosition(shift.X3, shift.Y3, Stone.WhiteChecker);
            if (shift.X3 == Chessboard._BottomBorder)
                if (Board.EquaStoneOnPosition(Stone.BlackPawn, shift.X3, shift.Y3)) Board.SetValueOnPosition(shift.X3, shift.Y3, Stone.BlackChecker);
            //predelano

        }

        ///zmenit zbitecna reverze mozna kontrola -----------------------------------
        //metoda obsluhujicei zmenu damy na pesaka
        public void Degrade(Move m)
        {
            List<Shift> reversed = m.GetShifts().GetRange(0, m.GetShifts().Count());
            reversed.Reverse();
            Shift shift = reversed.First();
            if (shift.X3 == Chessboard._TopBorder)
                if (Board.EquaStoneOnPosition(Stone.WhiteChecker, shift.X3, shift.Y3)) Board.SetValueOnPosition(shift.X3, shift.Y3, Stone.WhitePawn);
            if (shift.X3 == Chessboard._BottomBorder)
                if (Board.EquaStoneOnPosition(Stone.BlackChecker, shift.X3, shift.Y3)) Board.SetValueOnPosition(shift.X3, shift.Y3, Stone.BlackPawn);
        }

        //pomocna metoda vracejici smer hry pro hrace na tahu
        private int FigurineDirection(Stone stone)
        {
            if (PlayerFigurine(WhitePlayer, stone)) return _Up;
            return _Down;
        }

        //metoda kontrolujici jesli dana hodnota value odpovida kameni pro daneko hrace

        public bool OnMoveStone(Stone stone)
        {
            if (stone == OnMoveFigurine()) return true;
            if (stone == OnMoveChecker()) return true;
            return false;
        }

        //metoda vracejici hodnotu normalni figurky pro hrace na tahu
        private Stone OnMoveFigurine()
        {
            if (IsWhitePlayer(OnMove)) return Stone.WhitePawn;
            else return Stone.BlackPawn;
        }

        //metoda vracejici hodnotu damy pro hrace na tahu
        private Stone OnMoveChecker()
        {
            if (IsWhitePlayer(OnMove)) return Stone.WhiteChecker;
            else return Stone.BlackChecker;
        }

        //metoda vraci hrace kteremu patri dana figurka
        public Player FigurineWhichPlayer(Stone stone)
        {
            if (PlayerFigurine(WhitePlayer, stone)) return WhitePlayer;
            return BlackPlayer;
        }

        // metoda kontrolujici zda je figurka daneho hrace
        public bool PlayerFigurine(Player player, Stone stone)
        {
            if (IsWhitePlayer(player))
            {
                if ((stone == Stone.WhitePawn) || (stone == Stone.WhiteChecker)) return true;
            }
            else
            {
                if ((stone == Stone.BlackPawn) || (stone == Stone.BlackChecker)) return true;
            }
            return false;
        }
        // meetoda kontrolujici jestli neni figurka daneho hrace
        private bool NotPlayerFigurine(Player player, Stone stone)
        {
            if (!(PlayerFigurine(player, stone)) && (stone != 0)) return true;
            return false;
        }


        //metoda kontrolujici zda je konec hry
        public int EndGame(Player player)
        {
            if (IsTie()) return 2;
            if (IsLoose(player)) return 1;
            return 0;

        }

        //metoda kontrolujici jestli dany hrac vyhral
        public bool IsWin(Player player)
        {
            for (int i = Chessboard._TopBorder; i <= Chessboard._BottomBorder; i++)
                for (int j = Chessboard._LefBorder; j <= Chessboard._RightBorder; j++)
                {
                    Stone playerStone = Board.GetValueOnPosition(i, j);
                    if (PlayerFigurine(OppositePlayer(player), playerStone))
                    {
                        if (0 < GenerateMovesForPosition(i, j).Count) return false;
                    }
                }
            return true;
        }

        //metoda kontrolujici zda dany hrac prohral
        public bool IsLoose(Player player)
        {
            return IsWin(OppositePlayer(player));
        }

        //metoda kontrolujici remizu
        public bool IsTie()
        {
            int sum = 0;
            for (int i = Chessboard._TopBorder; i <= Chessboard._BottomBorder; i++)
                for (int j = Chessboard._LefBorder; j <= Chessboard._RightBorder; j++)
                {
                    if (!(Board.IsEmpty(i, j))) sum++;
                }
            if (FigurinesCount == sum)
            {
                NoJumpMoves++;
                if (NoJumpMoves == 60) return true;
            }
            else
            {
                NoJumpMoves = 0;
                FigurinesCount = sum;
            }
            return false;
        }

        // pomocna metoda vraci bileho hrace
        public Player GetWhitePlayer()
        {
            return WhitePlayer;
        }

        // pomocna metoda vraci cerneho hrace
        public Player GetBlackPlayer()
        {
            return BlackPlayer;
        }

        //metoda vracejici oponenta daneho hrace
        public Player OppositePlayer(Player player)
        {
            if (IsWhitePlayer(player)) return BlackPlayer;
            return WhitePlayer;
        }

        //metoda kontrolujici jestli je dany hrac bili
        public bool IsWhitePlayer(Player player)
        {
            if (player.Name.Equals(WhitePlayer.Name)) return true;
            return false;
        }

        //pomocna metoda kontrolujici zda je dane policko mezi policky na kterych stoji vyhozena figurka 
        private bool ContainsOccupied(List<int[]> occupied, int x, int y)
        {
            foreach (int[] array in occupied)
                if ((array[0] == x) && (array[1] == y)) return true;
            return false;
        }
    }
}
