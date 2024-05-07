using HarmonyLib;
using CustomStages.Core;
using Nick;
using System.Collections.Generic;

// add a new LoadState for each custom stage
namespace CustomStages.Patches
{
    [HarmonyPatch(typeof(AgentLoading), "Awake")]
    class AgentLoading_Awake
    {
        static void Postfix(ref Dictionary<string, AgentLoading.LoadState> ___loadStates)
        {
            foreach (var stage in StageManager.stages.Values)
                ___loadStates.Add(stage.id, new AgentLoading.LoadState());
        }
    }
}
