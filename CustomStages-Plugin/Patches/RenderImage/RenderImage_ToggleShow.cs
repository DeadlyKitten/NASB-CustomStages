using HarmonyLib;
using CustomStages.Core;
using System;
using UnityEngine.UI;
using UnityEngine;

namespace CustomStages.Patches
{
    [HarmonyPatch(typeof(RenderImage), nameof(RenderImage.ToggleShow), new Type[] { typeof(bool), typeof(RenderVisualizer.RenderSize), typeof(bool), typeof(bool) })]
    class RenderImage_ToggleShow
    {
        static void Postfix(RenderImage __instance, ref bool ___seekingTexture, ref RawImage ___rawImage, ref Image ___image, ref bool ___usesPath, ref RenderVisualizer ___renderVisualizer)
        {
            if (__instance.StageMetaData)
            {
                if (StageManager.stages.TryGetValue(__instance.StageMetaData.id, out var stage))
                {
                    Plugin.LogInfo($"Stage ID: {__instance.StageMetaData.id}");
                    ___seekingTexture = false;
                    ___rawImage.texture = stage.Portrait;
                    ___rawImage.enabled = true;

                    ___image.sprite = Sprite.Create(stage.Portrait, new Rect(0, 0, stage.Portrait.width, stage.Portrait.height), new Vector2(0.5f, 0.5f), 100f);
                    ___renderVisualizer?.ToggleLoading(false);
                }
            }
        }
    }
}
