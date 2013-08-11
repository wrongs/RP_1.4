using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RP_1._4.Logic
{
    public class Player : IEquatable<Player>
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public int Difficulty { get; set; }

        public Player() { }

        public Player(string name, int type, int difficulty)
        {
            Name = name;
            Type = type;
            Difficulty = difficulty;
        }

        public bool isPC()
        {
            if (Type == 0) return true;
            return false;
        }

        public bool isHuman()
        {
            if (Type == 0) return false;
            return true;
        }

        public bool Equals(Player player)
        {
            if (Name != player.Name) return false;
            if (Type != player.Type) return false;
            if (Difficulty != player.Difficulty) return false;
            return true;
        }
    }
}
