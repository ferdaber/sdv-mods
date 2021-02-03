using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace MineralCraftingRecipes
{
    class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            Helper.Events.GameLoop.SaveLoaded += OnSaveLoaded;
        }

        private void OnSaveLoaded(object sender, SaveLoadedEventArgs e)
        {
            var craftingRecipesEditor = new CraftingRecipesEditor(this);
            Helper.Content.AssetEditors.Add(craftingRecipesEditor);
            craftingRecipesEditor.LearnRecipes();
        }
    }
}
