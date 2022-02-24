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

        // These are the GUIDS for the different parts of the game I want to alter
        // It's good practice to store raw strings like this as constant values within your class,
        // and not within the body of a function.

        // Some programming langauges like to use the word method instead of the word function. They're the same thing.
        // I'm not sure what the norm in C# is.
        static readonly string assassinClass = "eb284ea8d40a2d045911f525eb96c43d";
        static readonly string assassinClassLevelEntries = "eb284ea8d40a2d045911f525eb96c43d";
        static readonly string fullBaseAttackBonus = "b3057560ffff3514299e8b93e7648a9d";
        static readonly string fastStealth = "97a6aa2b64dd21a4fac67658a91067d7";


        // Harmony attribute to let the game know it should call this function after initializing the blueprint cache
        [HarmonyPatch(nameof(BlueprintsCache.Init)), HarmonyPostfix]
        static void Postfix(){ Rework(); }


        // This is the function that does all of the "work"
        private static void Rework()
        {   
            //Alter Assassin Class Characteristics
            // I'm using Wolfie's blueprint core to get access to these functions.
            // So far, the API is amazing. Highly recommend checking it out.
            CharacterClassConfigurator.For(assassinClass) // .For is the configurator function for altering an existing blueprint
                .SetBaseAttackBonus(fullBaseAttackBonus) // Here I tell the game which BaB blueprint assassin should reference
                .Configure(); // Configure commits my changes to the blueprint.

            //Alter Assassin Class Level Progression
            ProgressionConfigurator.For(assassinClassLevelEntries) // Class feat progression is saved as an array of level entries. 
                .OnConfigure(bp => { PopulateLevelEntries(bp.LevelEntries); }) // This code passes the level entries array to a function where I alter the level entries
                .Configure();
        }

        private static void PopulateLevelEntries(LevelEntry[] entries)
        {
            entries[2].m_Features.Add(BlueprintTool.GetRef<BlueprintFeatureBaseReference>(fastStealth)); // Here I'm adding the fastStealth feat to Assassin at level THREE***
                                                                                                         // Array indexing starts at 0, so 0 => level 1, 1 => level 2, etc
            return;
        }


    }
}
