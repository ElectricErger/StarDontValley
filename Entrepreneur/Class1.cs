using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Events;
using StardewValley.Quests;

namespace Entrepreneur
{
    public class ModEntry : Mod
    {
        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            foreach (IContentPack contentPack in this.Helper.ContentPacks.GetOwned())
            {
                this.Monitor.Log($"Reading content pack: {contentPack.Manifest.Name} {contentPack.Manifest.Version} from {contentPack.DirectoryPath}");
                helper.Events.GameLoop.SaveLoaded += GameLoop_SaveLoaded;
            }
        }

        private void GameLoop_SaveLoaded(object sender, SaveLoadedEventArgs e)
        {
            Quest q = GoSomewhereQuest.getQuestFromId(1);
            Game1.player.addQuest(1);
            Game1.player.questLog.Add(q);
        }
    }
}
