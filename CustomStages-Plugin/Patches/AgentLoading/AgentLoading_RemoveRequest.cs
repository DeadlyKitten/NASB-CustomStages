using HarmonyLib;
using CustomStages.Core;
using Nick;

namespace CustomStages.Patches
{
    [HarmonyPatch(typeof(AgentLoading), nameof(AgentLoading.RequestLoad))]
    class AgentLoading_RemoveRequest
    {
        static void Prefix(ref AgentLoading.LoadRequest req) => StageManager.UnloadStage(req.Id);
    }
}
