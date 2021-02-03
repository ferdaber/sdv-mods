using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeGrabberRedux
{    
    class ModConfig
    {
        public bool slimeHutch;
        public bool farmCaveMushrooms;
        public bool harvestCrops;
        public bool harvestCropsIndoorPots;
        public int harvestCropsRange;
        public bool artifactSpots;
        public bool orePan;
        public bool bushes;
        public bool fruitTrees;
        public bool flowers;
        public bool reportYield;
        public bool gainExperience;
        public bool fellSecretWoodsStumps;

        public ModConfig()
        {
            slimeHutch = true;
            farmCaveMushrooms = true;
            harvestCrops = false;
            harvestCropsIndoorPots = true;
            harvestCropsRange = -1;
            artifactSpots = false;
            orePan = false;
            bushes = true;
            fruitTrees = false;
            flowers = false;
            reportYield = true;
            gainExperience = true;
            fellSecretWoodsStumps = false;
        }
    }
}
