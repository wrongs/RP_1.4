using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using RP_1._4.Enums;

namespace RP_1._4.Logic
{
    public class Chessboard
    {
        // public const int _WhitePawn = 25;
        // public const int _BlackPawn = -25;
        // public const int _WhiteChecker = 100;
        // public const int _BlackChecker = -100;
        public const int _TopBorder = 0;
        public const int _BottomBorder = 9;
        public const int _LefBorder = 0;
        public const int _RightBorder = 9;

        private Stone[,] Board;

        public Stack<Move> UndoStack { get; private set; }
        public Stack<Move> RedoStack { get; private set; }

        public Chessboard()
        {
            Board = new Stone[10, 10];
            //FillBoard();
            UndoStack = new Stack<Move>();
            RedoStack = new Stack<Move>();
        }

        public Stone[,] GetBoard()
        {
            return Board;
        }

        //Fukce ktera naplni hraci desku na zakladní rozestavení podle pravidel friske damy
        public void FillBoard()
        {
            for (int i = _TopBorder; i <= _BottomBorder; i++)
                for (int j = _LefBorder; j <= _RightBorder; j++)
                {
                    if (i < 4)
                    {
                        if (((i % 2 == 0) & (j % 2 == 1)) | (i % 2 == 1) & (j % 2 == 0)) Board[i, j] = Stone.BlackPawn;//BlackPawn;
                    }
                    if (i > 5)
                    {
                        if (((i % 2 == 0) & (j % 2 == 1)) | (i % 2 == 1) & (j % 2 == 0)) Board[i, j] = Stone.WhitePawn;
                    }
                }
        }

        public void CleanBoard()
        {
            for (int i = _TopBorder; i <= _BottomBorder; i++)
                for (int j = _LefBorder; j <= _RightBorder; j++)
                {
                    Board[i, j] = Stone.None;
                }
            UndoStack.Clear();
            RedoStack.Clear();
        }


        // Funkce provádí zmenu obsahu hraci desky podle daného tahu
        public void DoMove(Move t)
        {
            foreach (Shift s in t.GetShifts())
            {
                Board[s.X1, s.Y1] = 0;
                Board[s.X3, s.Y3] = t.GetStone();
            }
        }

        // provadi odstraneni kamenu z desky
        public void DoRemove(Move t)
        {
            foreach (Shift s in t.GetShifts())
            {
                if (s.Jumped != 0) Board[s.X2, s.Y2] = 0;
            }
        }

        // provadeni inverzniho tahu
        public void DoInvMove(Move t)
        {
            List<Shift> reversed = t.GetShifts().GetRange(0, t.GetShifts().Count());
            reversed.Reverse();
            foreach (Shift s in reversed)
            {
                Board[s.X1, s.Y1] = t.GetStone();
                //if (s.Jumped != 0) Board[s.X2, s.Y2] = s.Jumped;
                if (s.Jumped != 0) SetValueOnPosition(s.X2, s.Y2, s.Jumped);
                Board[s.X3, s.Y3] = 0;
            }
        }
        /*
        // metoda vrací hodnotu daného policka desky
        public Piece GetValueOnPosition(int x, int y)
        {
            if (IsInBoard(x, y)) return Board[x, y];
            return -1;
        }
        */
        // metoda vrací hodnotu daného policka desky  ------------------------------------------------- mozna zmena pridat exeption
        public Stone GetValueOnPosition(int x, int y)
        {
            return Board[x, y];
        }

        //metoda na zjisteni jestli je dane policko prazdne
        public bool IsEmpty(int x, int y)
        {
            if (IsInBoard(x, y) && (Board[x, y] == 0)) return true;
            return false;
        }

        //medoa zjistujici zda je dane policko na desce
        public bool IsInBoard(int x, int y)
        {
            if ((x <= _BottomBorder) && (_TopBorder <= x) && (y <= _RightBorder) && (_LefBorder <= y)) return true;
            return false;
        }

        // metoda nastavujici hodnotu policka 
        public Chessboard SetValueOnPosition(int x, int y, Stone stone)
        {
            Board[x, y] = stone;
            return this;
        }

        // metoda která porovnává hodnotu policka x,y s hodnotou value 
        public bool EquaStoneOnPosition(Stone stone, int x, int y)
        {
            if (stone == GetValueOnPosition(x, y)) return true;
            return false;
        }

        public Stone[,] CopyBoard()
        {
            Stone[,] copyBoard = new Stone[10, 10];
            Array.Copy(Board, copyBoard, Board.Length);
            return copyBoard;
        }
    }
}
