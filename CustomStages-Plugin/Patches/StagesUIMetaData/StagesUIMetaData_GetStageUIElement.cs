using HarmonyLib;
using CustomStages.Core;

namespace CustomStages.Patches
{
    [HarmonyPatch(typeof(StagesUIMetaData), nameof(StagesUIMetaData.GetStageUIElement))]
    class CharactersUIMetaData_GetCharacterUIElement
    {
        static void Postfix(string id, ref StagesUIMetaData.StageUIElements __result)
        {
            if (__result == null && StageManager.stages.TryGetValue(id, out var stage))
                __result = stage.UIElements;
        }
    }
}
