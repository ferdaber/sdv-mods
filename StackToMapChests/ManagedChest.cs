using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackToMapChests
{
    class ManagedChest
    {
        public Chest Chest { get; set; }
        public Vector2 Tile { get; set; }
        public GameLocation Location { get; set; }

        public override string ToString()
        {
            return $"Chest at ({Tile.X}, {Tile.Y}) in {Location.Name}";
        }
    }
}
