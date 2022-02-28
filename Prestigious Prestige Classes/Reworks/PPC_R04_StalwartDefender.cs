using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.JsonSystem;
using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Utils;

namespace PrestigiousPrestigeClasses.Reworks
{
    [HarmonyPatch]
    static class StalwartDefenderRework
    {
        private static readonly LogWrapper log = LogWrapper.Get("AssassinRework");

        [HarmonyPatch(typeof(BlueprintsCache), nameof(BlueprintsCache.Init)), HarmonyPostfix]
        static void AlterBlueprints()
        {
            log.Info("Stalwart Defender Harmony Patch Started...");
            Rework();
            log.Info("Stalwart Defender Harmony Patch Applied");
        }

        private static void Rework()
        {
            return;
        }

        private static void PopulateLevelEntries(LevelEntry[] entries)
        {

            return;
        }


    }
}
