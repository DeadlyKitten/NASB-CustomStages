using HarmonyLib;
using CustomStages.Core;
using UnityEngine;

namespace CustomStages.Patches
{
    [HarmonyPatch(typeof(RenderVisualizer), "InitializeStages")]
    class RenderVisualizer_InitializeStages
    {
        static void Prefix(RenderVisualizer __instance, Transform ___stagesParent)
        {
            var go = ___stagesParent.GetChild(0).gameObject;

            foreach (var stage in StageManager.stages.Values)
            {
                if (___stagesParent.Find(stage.id)) continue;

                Plugin.LogInfo("Creating Stage Entry!");

                var instance = Object.Instantiate(go, go.transform.position, go.transform.rotation, ___stagesParent);
                instance.name = stage.id;
                instance.GetComponent<RenderImage>().StageMetaData = stage.meta;
            }
        }
    }
}
