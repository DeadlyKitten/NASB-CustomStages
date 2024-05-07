using CustomStages.Core;
using HarmonyLib;
using Nick;
using System.Linq;
using UnityEngine;

// Disable custom stages online outside of custom lobbies
namespace CustomStages.Patches
{
    [HarmonyPatch(typeof(GameMetaData), "GetValidStages")]
    class GameMetaData_GetValidStages
    {
        static MenuSystem menuSystem;

        static void Prefix()
        {
            menuSystem ??= Resources.FindObjectsOfTypeAll<MenuSystem>().FirstOrDefault();

            if (Photon.Pun.PhotonNetwork.IsConnected && 
                menuSystem?.sharedState?.retrieveCharacterSelectMode() != CharacterSelectScreen.Mode.OnlineLobby)
                StageManager.HideCustomStages(true);
            else
                StageManager.HideCustomStages(false);
        }
    }
}
