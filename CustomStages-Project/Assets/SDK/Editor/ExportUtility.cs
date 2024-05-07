using Nick;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class ExportUtility
{

    private static bool exporting = false;
    public static void ExportStage(ExportData exportData)
    {
        if (exporting) return;
        exporting = true;

        var stage = exportData.stage;

        var currentSceneSetup = EditorSceneManager.GetSceneManagerSetup();
        if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            exporting = false;
            return;
        }

        try
        {

#region Prepare Save Location
            var initialPath = EditorPrefs.GetString("STAGE_EXPORT_PATH", Application.dataPath);

            var savePath = EditorUtility.SaveFilePanel(
            "Save Custom Stage",
            initialPath,
            exportData.StageName + ".stage",
            "stage");

            if (string.IsNullOrEmpty(savePath))
            {
                exporting = false;
                return;
            }

            EditorPrefs.SetString("STAGE_EXPORT_PATH", Path.GetDirectoryName(savePath));
            if (File.Exists(savePath)) File.Delete(savePath);

#endregion

            var exportPath = Path.Combine("Assets", "Export");
            Directory.CreateDirectory(exportPath);

            #region Create Stage Scene

            Debug.Log("Creating stage scene...");
            var stageScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            stageScene.name = exportData.StageName;

            var loadedAgent = new GameObject("LoadedAgent").AddComponent<LoadedAgent>();
            loadedAgent.agentId = exportData.stage.gameUniqueIdentifier;
            loadedAgent.agentPrefab = exportData.stage;

            var stageScenePath = Path.Combine(exportPath, $"{exportData.stage.gameUniqueIdentifier}.unity");
            EditorSceneManager.SaveScene(stageScene, stageScenePath);
            Debug.Log("<color=green>Successfully created stage scene!</color>");

#endregion

#region Build AssetBundle

            Debug.Log("Building assetbundle...");
            var assetBundleName = $"{exportData.stage.gameUniqueIdentifier}.assetbundle";
            var build = new AssetBundleBuild
            {
                assetNames = new string[] { stageScenePath },
                assetBundleName = assetBundleName
            };

            BuildPipeline.BuildAssetBundles(
                exportPath,
                new AssetBundleBuild[] { build },
                BuildAssetBundleOptions.None,
                BuildTarget.StandaloneWindows
            );
            Debug.Log("<color=green>Successfully built assetbundle!</color>");

#endregion

#region Copy Portrait

            Debug.Log("Copying portrait...");
            var portraitPath = Path.Combine("portrait");
            AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(exportData.portrait), Path.Combine(exportPath, portraitPath));
            Debug.Log("<color=green>Successfully copied portrait!</color>");

            #endregion

            #region Create package.json

            Debug.Log("Creating package.json...");
            var package = new PackageJSON
            {
                id = stage.gameUniqueIdentifier,
                name = exportData.StageName,
                author = exportData.Author,
                bundlePath = build.assetBundleName,
                stagePath = stageScenePath,
                musicId = exportData.MusicID,
                blastzoneDistUp = exportData.BlastzoneDistUp,
                blastzoneDistDown = exportData.BlastzoneDistDown,
                blastzoneDistLeft = exportData.BlastzoneDistLeft,
                blastzoneDistRight = exportData.BlastzoneDistRight,
                cameraDistUp = exportData.CameraDistUp,
                cameraDistDown = exportData.CameraDistDown,
                cameraDistLeft = exportData.CameraDistLeft,
                cameraDistRight = exportData.CameraDistRight,
                cameraMinDist = exportData.CameraMinDist,
                portraitPath = portraitPath
            };

            var jsonPath = Path.Combine(Application.dataPath, "Export", "package.json");
            var packageJSON = JsonUtility.ToJson(package, true).Replace(@"\\", @"/");

            Debug.Log("Writing...");
            File.WriteAllText(jsonPath, packageJSON);

            Debug.Log("<color=green>Successfully created package.json!</color>");

            #endregion

            Debug.Log("Creating stage file...");
            var zip = ZipFile.Open(savePath, ZipArchiveMode.Create);
            zip.CreateEntryFromFile(Path.Combine(exportPath, assetBundleName), assetBundleName);
            zip.CreateEntryFromFile(Path.Combine(exportPath, portraitPath), portraitPath);
            zip.CreateEntryFromFile(Path.Combine(exportPath, jsonPath), "package.json");
            zip.Dispose();
            Debug.Log("<color=green>Successfully created stage file!</color>");

            Thread.Sleep(50);

            EditorUtility.DisplayDialog("Export Successful!", $"Exported {exportData.StageName}.", "OK");
        }
        catch (Exception e)
        {
            //if (currentSceneSetup != null && currentSceneSetup.Length > 0 &&
            //    currentSceneSetup.Any(x => x.isLoaded) && currentSceneSetup.Any(x => x.isActive))
            //    EditorSceneManager.RestoreSceneManagerSetup(currentSceneSetup);

            Debug.LogError($"<color=red>{e.Message}</color>");
            Debug.LogError($"<color=red>{e.StackTrace}</color>");

            EditorUtility.DisplayDialog("Export Failed!", $"See output log for details.", "OK");
        }
        finally
        {
            exporting = false;
        }
    }

    public static void ExportStages(ExportData[] exportDatas)
    {
        foreach (var data in exportDatas)
            ExportStage(data);
    }
}
