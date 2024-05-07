using HarmonyLib;
using CustomStages.Core;
using Nick;

namespace CustomStages.Patches
{
    [HarmonyPatch(typeof(AgentLoading), nameof(AgentLoading.RequestLoad))]
    class AgentLoading_RequestLoad
    {
        static void Prefix(ref AgentLoading.LoadRequest req)
        {
            Plugin.LogInfo($"Agent loading request: {req.Id}");

            if (StageManager.TrySelectCustomStage(req.Id, out var stage))
                stage.LoadAssetBundle();
        }
    }
}
