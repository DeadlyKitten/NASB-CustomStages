using CustomStages.Core;
using HarmonyLib;
using Nick;

namespace CustomStages.Patches
{
    [HarmonyPatch(typeof(GameMusicBank), "GetMusic")]
    class GameMusicBank_GetMusic
    {
        static void Postfix(ref string id, ref GameMusic __result)
        {
            if (__result == null && StageManager.CurrentStage?.musicId == id)
            {
                Plugin.LogInfo("Loading Custom Stage Music");
                __result = StageManager.CurrentStage.GetStageMusic();
            }
        }
    }
}
