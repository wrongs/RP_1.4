using RP_1._4.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace RP_1._4.Logic
{
    public class XmlManager
    {
        private GameManager Manager;

        public XmlManager(GameManager manager)
        {
            Manager = manager;
        }

        public void SaveGame(String fileName)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration deklarace = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement koren = doc.CreateElement("GameSave");
            XmlElement players = doc.CreateElement("players");
            XmlElement player1 = SavePlayer(doc, Manager.P1);
            XmlElement player2 = SavePlayer(doc, Manager.P2);
            XmlElement chessboard = doc.CreateElement("chessboard");
            //XmlElement onMove = doc.CreateElement("onMove");
            XmlElement undoStack = SaveStack(doc, doc.CreateElement("UndoStack"), Manager.Board.UndoStack);

            //onMove.SetAttribute("Player", Manager.Rules.OnMove.Name);

            doc.AppendChild(deklarace);
            koren.AppendChild(players);
            koren.AppendChild(chessboard);
            players.AppendChild(player1);
            players.AppendChild(player2);
            //chessboard.AppendChild(onMove);
            chessboard.AppendChild(undoStack);

            doc.AppendChild(koren);
            doc.Save(fileName);
        }

        public XmlElement SavePlayer(XmlDocument doc, Player player)
        {
            XmlElement elementPlayer = doc.CreateElement("player");
            elementPlayer.SetAttribute("type", player.Type.ToString());
            XmlElement name = doc.CreateElement("name");
            name.InnerText = player.Name;
            XmlElement diffuculty = doc.CreateElement("diffuculty");
            diffuculty.InnerText = player.Difficulty.ToString();
            elementPlayer.AppendChild(name);
            elementPlayer.AppendChild(diffuculty);
            return elementPlayer;
        }

        public XmlElement SaveStack(XmlDocument doc, XmlElement elementStack, Stack<Move> stack)
        {
            List<Move> reversedStack = stack.ToList();
            reversedStack.Reverse();
            foreach (Move move in reversedStack)
            {
                XmlElement elementMove = doc.CreateElement("move");
                int stone = (int)move.GetStone();
                elementMove.SetAttribute("Figurine", stone.ToString());
                //elementPlayer.SetAttribute("type", player.GetPlayerType().ToString());
                foreach (Shift s in move.GetShifts())
                {
                    int jumped = (int)s.Jumped;
                    XmlElement elementShift = doc.CreateElement("shift");
                    elementShift.SetAttribute("X1", s.X1.ToString());
                    elementShift.SetAttribute("Y1", s.Y1.ToString());
                    elementShift.SetAttribute("X2", s.X2.ToString());
                    elementShift.SetAttribute("Y2", s.Y2.ToString());
                    elementShift.SetAttribute("Jumped", jumped.ToString());
                    elementShift.SetAttribute("X3", s.X3.ToString());
                    elementShift.SetAttribute("Y3", s.Y3.ToString());
                    elementMove.AppendChild(elementShift);
                }

                elementStack.AppendChild(elementMove);
            }
            return elementStack;
        }

        public void LoadGame(String filename)
        {
            int i = 0;
            Player[] players = { new Player(), new Player() };
            Chessboard loadedBoard = new Chessboard();
            Rules LoadedRules = new Rules(loadedBoard);
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);

            XmlNode root = doc.DocumentElement;
            XmlElement playersElement = (XmlElement)root.ChildNodes.Item(0);
            foreach (XmlNode playerNode in playersElement.ChildNodes)
            {
                XmlElement player = (XmlElement)playerNode;
                players[i].Type = int.Parse(player.GetAttribute("type"));
                XmlElement name = (XmlElement)playerNode.ChildNodes.Item(0);
                players[i].Name = name.InnerText;
                XmlElement difficulty = (XmlElement)playerNode.ChildNodes.Item(1);
                players[i].Difficulty = (int.Parse(difficulty.InnerText));
                i++;
            }

            XmlElement boardElement = (XmlElement)root.ChildNodes.Item(1);
            //XmlElement onMoveElement = (XmlElement)boardElement.ChildNodes.Item();
            loadedBoard.FillBoard();
            //if (players[0].Name.Equals(onMoveElement.GetAttribute("Player"))) LoadedRules = new Rules(players[0], loadedBoard, players[1]);
            //else LoadedRules = new Rules(players[1], loadedBoard, players[0]);
            LoadedRules = new Rules(players[0], loadedBoard, players[1]);

            XmlElement stackElement = (XmlElement)boardElement.ChildNodes.Item(0);
            Move move;
            foreach (XmlNode moveNode in stackElement.ChildNodes)
            {
                move = new Move();
                XmlElement moveElement = (XmlElement)moveNode;
                Stone figurine = (Stone)int.Parse(moveElement.GetAttribute("Figurine"));
                move.SetStone(figurine);

                foreach (XmlNode shiftNode in moveElement.ChildNodes)
                {
                    XmlElement shiftElement = (XmlElement)shiftNode;
                    move.AddShift(int.Parse(shiftElement.GetAttribute("X1")), int.Parse(shiftElement.GetAttribute("Y1")), int.Parse(shiftElement.GetAttribute("X2")),
                                         int.Parse(shiftElement.GetAttribute("Y2")), int.Parse(shiftElement.GetAttribute("X3")), int.Parse(shiftElement.GetAttribute("Y3")),
                                         (Stone)int.Parse(shiftElement.GetAttribute("Jumped")));
                }
                LoadedRules.DoMoveInRules(move);
                loadedBoard.UndoStack.Push(move);
                loadedBoard.RedoStack.Clear();
                LoadedRules.ChangeOnMove();
            }
            Manager.NewGame(players[0], players[1], LoadedRules, loadedBoard);
            /*
            Manager.Rules = LoadedRules;
            Manager.Board = loadedBoard;
            Manager.P1 = players[0];
            Manager.P2 = players[1];
            Manager.SetOnLoad();
             * */

        }
    }
}
