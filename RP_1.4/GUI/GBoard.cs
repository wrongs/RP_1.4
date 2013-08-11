using RP_1._4.Enums;
using RP_1._4.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RP_1._4.GUI
{
    public class GBoard
    {
        public Bitmap[] tiles = new Bitmap[2];
        public Bitmap[] pieces = new Bitmap[4];
        public Bitmap[] moving = new Bitmap[4];
        private Chessboard Board;
        private Stone[,] GraphicsBoard;
        public const int boardsize = 10;
        public const int tilesize = 64;

        public GBoard(Chessboard board)
        {
            GraphicsBoard = board.CopyBoard();
            LoadImages();
            Board = board;
        }

        public void UpdateGBoard()
        {
            GraphicsBoard = Board.CopyBoard();
        }

        private void LoadImages()
        {
            tiles[0] = (Bitmap)RP_1._4.Properties.Resources.white_tile;
            tiles[1] = (Bitmap)RP_1._4.Properties.Resources.black_tile;
            pieces[0] = (Bitmap)RP_1._4.Properties.Resources.white_pawn;
            pieces[1] = (Bitmap)RP_1._4.Properties.Resources.black_pawn;
            pieces[2] = (Bitmap)RP_1._4.Properties.Resources.white_checker;
            pieces[3] = (Bitmap)RP_1._4.Properties.Resources.black_checker;
            moving[0] = (Bitmap)RP_1._4.Properties.Resources.white_pawn_move;
            moving[1] = (Bitmap)RP_1._4.Properties.Resources.black_pawn_move;
            moving[2] = (Bitmap)RP_1._4.Properties.Resources.white_checker_move;
            moving[3] = (Bitmap)RP_1._4.Properties.Resources.black_checker_move;

        }

        public void DrawBoard (PaintEventArgs e)
        {
            for (int i = 0; i <= Chessboard._BottomBorder; i++)
                {
                    for (int j = 0; j <= Chessboard._RightBorder; j++)
                    {

                        switch (GetStoneOnPosition(i, j))
                        {
                            case Stone.BlackPawn:
                                e.Graphics.DrawImage(pieces[1], j * tilesize, i * tilesize, tilesize, tilesize);       
                                break;
                            case Stone.WhitePawn:
                                e.Graphics.DrawImage(pieces[0], j * tilesize, i * tilesize, tilesize, tilesize);       
                                break;
                            case Stone.BlackChecker:
                                e.Graphics.DrawImage(pieces[3], j * tilesize, i * tilesize, tilesize, tilesize);
                                break;
                            case Stone.WhiteChecker:
                                e.Graphics.DrawImage(pieces[2], j * tilesize, i * tilesize, tilesize, tilesize);
                                break;
                            default:
                                {
                                    if (((i + j) % 2) != 0) e.Graphics.DrawImage(tiles[1], j * tilesize, i * tilesize, tilesize, tilesize);
                                    else e.Graphics.DrawImage(tiles[0], j * tilesize, i * tilesize, tilesize, tilesize);
                                }
                                break;
                        }
                    }
                }
        }

        public void DrawMove (int x, int y , Stone stone, PaintEventArgs e)
        {
            switch (stone)
            {
                case Stone.BlackPawn:
                    e.Graphics.DrawImage(moving[1], x - tilesize / 2, y - tilesize / 2, tilesize, tilesize);
                    break;
                case Stone.WhitePawn:
                    e.Graphics.DrawImage(moving[0], x - tilesize / 2, y - tilesize / 2, tilesize, tilesize);
                    break;
                case Stone.BlackChecker:
                    e.Graphics.DrawImage(moving[3], x - tilesize / 2, y - tilesize / 2, tilesize, tilesize);
                    break;
                case Stone.WhiteChecker:
                    e.Graphics.DrawImage(moving[2], x - tilesize / 2, y - tilesize / 2, tilesize, tilesize);
                    break;
            }
        }

        // Zkontroluje,že pozice je platná (tj. v mezích velikosti šachovnice)
        // Pokud není, vyhodí výjimku InvalidCoordinatesException
        public bool CheckPosition(int x, int y)// Toto je jen pro kontrolu
        {   
            if((x >= 0) & (x <= 9) & (y >= 0) & (y <= 9)) return true;
            return false;
        }
        // Vrací typ figurky na dané pozici
        public Stone GetStoneOnPosition(int x, int y)
        {
            return GraphicsBoard[x, y];
        }

        public GBoard SetStoneOnPosition(int x, int y, Stone stone)
        {
            GraphicsBoard[x, y] = stone;
            return this;
        }



        // Pohne figurkou
        //public void MovePiece(int sx, int sy, int dx, int dy); 
        public Point CordsToBoard(int x, int y)
        {
            //int temp = y;
            Point point = new Point();
            point.Y =  x / tilesize;
            point.X =  y / tilesize;
            return point;
        }
    }

}
