﻿using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeGrabberRedux.Grabbers
{
    class IndoorPotGrabber : ObjectsMapGrabber
    {
        public IndoorPotGrabber(ModEntry mod, GameLocation location) : base(mod, location)
        {
        }

        public override bool GrabObject(Vector2 tile, StardewValley.Object obj)
        {
            if (Config.harvestCrops && Config.harvestCropsIndoorPots && obj is IndoorPot pot && pot.hoeDirt.Value.crop != null)
            {
                var dirt = pot.hoeDirt.Value;
                var crops = Helpers.HarvestCropFromHoeDirt(Player, dirt, tile, !Config.flowers, out int exp);
                var availableGrabbers = GlobalLocation != null ? GrabberPairs : Helpers.GetNearbyObjectsToTile(tile, GrabberPairs, Config.harvestCropsRange, Config.harvestCropsRangeMode);
                if (TryAddItems(crops, availableGrabbers))
                {
                    if (dirt.crop.regrowAfterHarvest.Value == -1)
                    {
                        dirt.destroyCrop(tile, false, Location);
                    }
                    else
                    {
                        dirt.crop.fullyGrown.Value = true;
                        dirt.crop.dayOfCurrentPhase.Value = dirt.crop.regrowAfterHarvest.Value;
                    }
                    GainExperience(Skills.Farming, exp);
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
    }
}
