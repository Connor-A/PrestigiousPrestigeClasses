using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.JsonSystem;
using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Utils;
using PrestigiousPrestigeClasses.Feats;

namespace PrestigiousPrestigeClasses.Reworks
{
    [HarmonyPatch]
    static class AssassinRework
    {
        private static readonly LogWrapper log = LogWrapper.Get("AssassinRework");

        static readonly string assassinClass = "eb284ea8d40a2d045911f525eb96c43d";
        static readonly string assassinClassLevelEntries = "a02e1f0e13baa8c43b758425eda9e973";
        static readonly string assassinCreatePoisonAbilityStrBuff = "c219da8e56fb30045bb69247c695b8c8";
        static readonly string assassinCreatePoisonAbilityDexBuff = "385c07aa91442094f9385510504dde3c";
        static readonly string assassinCreatePoisonAbilityConBuff = "ac4d4b3f14f2b6e41a19a3d8e13e7ee7";

        static readonly string fullBaseAttackBonus = "b3057560ffff3514299e8b93e7648a9d";
        static readonly string fastStealth = "97a6aa2b64dd21a4fac67658a91067d7";
        static readonly string potentPoisons = PotentPoisons.getGuid();

        [HarmonyPatch(typeof(BlueprintsCache), nameof(BlueprintsCache.Init)), HarmonyPostfix]
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

            FeatureConfigurator.For(assassinCreatePoisonAbilityStrBuff)
                .RemoveComponents( component => {
                    if (component is SpellDescriptorComponent)
                        return true;
                    else
                        return false;
                })
                .Configure();

            FeatureConfigurator.For(assassinCreatePoisonAbilityDexBuff)
                .RemoveComponents(component => {
                    if (component is SpellDescriptorComponent)
                        return true;
                    else
                        return false;
                })
                .Configure();

            FeatureConfigurator.For(assassinCreatePoisonAbilityConBuff)
                .RemoveComponents(component => {
                    if (component is SpellDescriptorComponent)
                        return true;
                    else
                        return false;
                })
                .Configure();
        }

        private static void PopulateLevelEntries(LevelEntry[] entries)
        {
            entries[0].m_Features.Add(BlueprintTool.GetRef<BlueprintFeatureBaseReference>(potentPoisons));
            entries[2].m_Features.Add(BlueprintTool.GetRef<BlueprintFeatureBaseReference>(fastStealth));
            return;
        }


    }
}
