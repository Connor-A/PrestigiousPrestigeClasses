using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Localization;
using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Utils;

namespace PrestigiousPrestigeClasses.Feats
{
    internal class PotentPoisons
    { 
        [HarmonyPatch(typeof(BlueprintsCache), nameof(BlueprintsCache.Init)), HarmonyPostfix]
        private static void AddFeat()
        {
            FeatureConfigurator.New(thisFeat, thisGuid)
                .OnConfigure( bp => ConfigureFeat(bp))
                .Configure();
            return;
        }

        private static void ConfigureFeat(BlueprintFeature bp)
        {
            bp.m_DisplayName = LocalizationTool.CreateString(DisplayNameKey, DisplayName);
            bp.m_Description = LocalizationTool.CreateString(DescriptionKey, Description);
            bp.m_DescriptionShort = LocalizationTool.CreateString(ShortDescriptionKey, ShortDescription);
            
            bp.m_Icon = null;
            bp.m_AllowNonContextActions = false;
            bp.HideInUI = false;
            bp.HideInCharacterSheetAndLevelUp = false;
            bp.HideNotAvailibleInUI = false;
            bp.Ranks = 1;
            bp.ReapplyOnLevelUp = false;
            bp.IsClassFeature = true;
        }

        internal static string getGuid() { return thisGuid; }

        private static readonly string thisFeat = "PotentPoisonsFeat";
        private static readonly string thisGuid = "e55d414807554f84abb5a0f544015d43";

        private static readonly string DisplayName = "Potent Poisons";
        private static readonly string DisplayNameKey = "PotentPoisonsName";
        private static readonly string Description = "Potent Poisons Long Description";
        private static readonly string DescriptionKey = "PotentPoisonsDescription";
        private static readonly string ShortDescription = "Potent Poisons Short Description";
        private static readonly string ShortDescriptionKey = "PotentPoisonsShortDescription";
    }

}
