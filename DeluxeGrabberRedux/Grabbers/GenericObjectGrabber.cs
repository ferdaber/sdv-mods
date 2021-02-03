using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Objects;
using System.Collections.Generic;
using SObject = StardewValley.Object;

namespace DeluxeGrabberRedux.Grabbers
{
    class GenericObjectGrabber : ObjectsMapGrabber
    {
        private static readonly HashSet<int> ForageableItems = new HashSet<int>()
        {
            ItemIds.Truffle,
            ItemIds.Seaweed,
            ItemIds.Mussel
        };

        public GenericObjectGrabber(ModEntry mod, GameLocation location) : base(mod, location)
        {
        }

        public override bool GrabObject(Vector2 tile, SObject obj)
        {
            if (IsGrabbable(obj))
            {
                if (TryAddItem(Helpers.SetForageStatsBasedOnProfession(Player, obj, tile)))
                {
                    Location.Objects.Remove(tile);
                    GainExperience(Skills.Foraging, 7);
                    return true;
                } else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool IsGrabbable(SObject obj)
        {
            if (obj.bigCraftable.Value) return false;
            else if (obj.isForage(null) && obj.ParentSheetIndex != ItemIds.GoldenWalnut) return true;
            else return ForageableItems.Contains(obj.ParentSheetIndex);
        }
    }
}
