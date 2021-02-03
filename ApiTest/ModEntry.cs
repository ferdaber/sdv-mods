using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SObject = StardewValley.Object;

namespace ApiTest
{
    public interface IDeluxeGrabberReduxApi
    {
        /// <summary>
        /// This is a delegate that should be set by other mods to override the default harvest outcome of a mushroom.
        /// <br /><br />
        /// <b>Parameter types:</b>
        /// <list type="number">
        ///     <item>
        ///         <term>SObject mushroom</term>
        ///         <description>The original object to be harvested (will be a mushroom object).</description>
        ///     </item>
        ///     <item>
        ///         <term>Vector2 tile</term>
        ///         <description>The tile where the mushroom box was located.</description>
        ///     </item>
        ///     <item>
        ///         <term>GameLocation location</term>
        ///         <description>The location that the harvest occurred in.</description>
        ///     </item>
        /// </list>
        /// <br /><br />
        /// <b>Return type (KeyValuePair):</b>
        /// <list type="number">
        ///     <item>
        ///         <term>SObject newMushroom</term>
        ///         <description>The object that will be harvested instead.</description>
        ///     </item>
        ///     <item>
        ///         <term>int expGain</term>
        ///         <description>The foraging skill EXP to be gained if the harvest was succesful.</description>
        ///     </item>
        /// </list>
        /// </summary>
        Func<SObject, Vector2, GameLocation, KeyValuePair<SObject, int>> GetMushroomHarvest { get; set; }

        /// <summary>
        /// This is a delegate that should be set by other mods to override the default harvest outcome of a berry bush.
        /// <br /><br />
        /// <b>Parameter types:</b>
        /// <list type="number">
        ///     <item>
        ///         <term>SObject berry</term>
        ///         <description>The original object to be harvested (will be a berry or tea leaves).</description>
        ///     </item>
        ///     <item>
        ///         <term>Vector2 tile</term>
        ///         <description>The tile where the bush was located.</description>
        ///     </item>
        ///     <item>
        ///         <term>GameLocation location</term>
        ///         <description>The location that the harvest occurred in.</description>
        ///     </item>
        /// </list>
        /// <br /><br />
        /// <b>Return type (KeyValuePair):</b>
        /// <list type="number">
        ///     <item>
        ///         <term>SObject newBerry</term>
        ///         <description>The object that will be harvested instead.</description>
        ///     </item>
        ///     <item>
        ///         <term>int expGain</term>
        ///         <description>The foraging skill EXP to be gained if the harvest was succesful.</description>
        ///     </item>
        /// </list>
        /// </summary>
        Func<SObject, Vector2, GameLocation, KeyValuePair<SObject, int>> GetBerryBushHarvest { get; set; }
    }

    public class ModEntry : Mod
    {
        private Dictionary<Vector2, Random> rs;
        public override void Entry(IModHelper helper)
        {
            rs = new Dictionary<Vector2, Random>();
            //Helper.Events.GameLoop.DayStarted += GameLoop_DayStarted;
            //Helper.Events.GameLoop.GameLaunched += GameLoop_GameLaunched;
        }

        private void GameLoop_DayStarted(object sender, StardewModdingAPI.Events.DayStartedEventArgs e)
        {
            rs.Clear();
        }

        private void GameLoop_GameLaunched(object sender, StardewModdingAPI.Events.GameLaunchedEventArgs e)
        {
            var api = Helper.ModRegistry.GetApi<IDeluxeGrabberReduxApi>("ferdaber.DeluxeGrabberRedux");
            api.GetBerryBushHarvest = GetBerryBushHarvest;
            api.GetBerryBushHarvest = GetBerryBushHarvestToo;
        }

        private KeyValuePair<SObject, int> GetBerryBushHarvest(SObject berry, Vector2 bushTile, GameLocation location)
        {
            if (!rs.TryGetValue(bushTile, out Random r))
            {
                r = new Random((int)bushTile.X + (int)bushTile.Y * 5000 + (int)Game1.uniqueIDForThisGame + (int)Game1.stats.DaysPlayed);
                rs.Add(bushTile, r);
            }
            var q = r.NextDouble();
            berry.Quality = q < 0.05 ? SObject.bestQuality : q < 0.1 ? SObject.highQuality : q < 0.4 ? SObject.medQuality : SObject.lowQuality;
            return new KeyValuePair<SObject, int>(berry, 0);
        }

        private KeyValuePair<SObject, int> GetBerryBushHarvestToo(SObject berry, Vector2 bushTile, GameLocation location)
        {
            if (!rs.TryGetValue(bushTile, out Random r))
            {
                r = new Random((int)bushTile.X + (int)bushTile.Y * 5000 + (int)Game1.uniqueIDForThisGame + (int)Game1.stats.DaysPlayed);
                rs.Add(bushTile, r);
            }
            var q = r.NextDouble();
            berry.Quality = q < 0.05 ? SObject.bestQuality : q < 0.1 ? SObject.highQuality : q < 0.4 ? SObject.medQuality : SObject.lowQuality;
            return new KeyValuePair<SObject, int>(berry, 0);
        }
    }
}
