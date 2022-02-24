using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.JsonSystem;
using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Utils;

namespace Prestigious_Prestige_Classes.Reworks
{
    [HarmonyPatch]
    static class AssassinRework
    {
        static readonly string assassinClass = "eb284ea8d40a2d045911f525eb96c43d";
        static readonly string assassinClassLevelEntries = "eb284ea8d40a2d045911f525eb96c43d";
        static readonly string fullBaseAttackBonus = "b3057560ffff3514299e8b93e7648a9d";
        static readonly string fastStealth = "97a6aa2b64dd21a4fac67658a91067d7";

        [HarmonyPatch(nameof(BlueprintsCache.Init)), HarmonyPostfix]
        static void Postfix(){ Rework(); }

        private static void Rework()
        {   
            //Alter Assassin Class Characteristics
            CharacterClassConfigurator.For(assassinClass)
                .SetBaseAttackBonus(fullBaseAttackBonus)
                .Configure();

            //Alter Assassin Class Level Progression
            ProgressionConfigurator.For(assassinClassLevelEntries)
                .OnConfigure(bp => { PopulateLevelEntries(bp.LevelEntries); })
                .Configure();
        }

        private static void PopulateLevelEntries(LevelEntry[] entries)
        {
            entries[2].m_Features.Add(BlueprintTool.GetRef<BlueprintFeatureBaseReference>(fastStealth));

            return;
        }


    }
}
