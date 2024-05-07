using BepInEx;
using CustomStages.Data;
using Newtonsoft.Json;
using Nick;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CustomStages.Core
{
    static class StageManager
    {
        private static readonly string baseFolder = Path.Combine(Paths.BepInExRootPath, "Custom Stages");

        internal static Dictionary<string, CustomStage> stages = new Dictionary<string, CustomStage>();
        private static readonly List<string> allowedFileTypes = new List<string> { ".zip", ".stage", ".nickstage" };

        private static CustomStage currentStage;
        internal static CustomStage CurrentStage { get => currentStage; set => currentStage = value; }

        public static void Init()
        {
            Plugin.LogInfo("Loading custom stages...");
            Directory.CreateDirectory(baseFolder);
            foreach (var file in Directory.GetFiles(baseFolder).Where(x => allowedFileTypes.Contains(Path.GetExtension(x).ToLower())))
            {
                using var archive = ZipFile.OpenRead(file);

                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    Plugin.LogWarning(entry.FullName);
                }

                var jsonFile = archive.Entries.Where(x => x.Name.ToLower() == "package.json").FirstOrDefault();

                if (jsonFile != null)
                    LoadCustomStage(file, jsonFile);
            }

            PrepareStageMetadatas();

            Plugin.LogInfo($"Loaded {stages.Keys.Count} custom stages!");
        }

        private static void LoadCustomStage(string file, ZipArchiveEntry jsonFile)
        {
            CustomStage stage;
            using (var stream = new StreamReader(jsonFile.Open(), Encoding.UTF8))
            {
                var jsonString = stream.ReadToEnd();
                stage = JsonConvert.DeserializeObject<CustomStage>(jsonString);
            }

            stage.zipPath = file;

            if (stages.ContainsKey(stage.id))
                Plugin.LogWarning($"Stage with ID '{stage.id}' already exists. Skipping!");
            else
                stages.Add(stage.id, stage);
        }

        private static void PrepareStageMetadatas()
        {
            var gameMeta = Resources.FindObjectsOfTypeAll<GameMetaData>().FirstOrDefault();
            var stageMeta = gameMeta.stageMetas.ToList();

            foreach (var stage in stages.Values)
            {
                var meta = CreateStageMetadata(stage);
                stageMeta.Add(meta);
            }

            gameMeta.stageMetas = stageMeta.ToArray();
        }

        private static StageMetaData CreateStageMetadata(CustomStage stage)
        {
            var meta = ScriptableObject.CreateInstance<StageMetaData>();

            meta.hide = false;
            meta.id = stage.id;
            meta.locName = stage.name;
            meta.showId = stage.id;
            meta.isDLC = false;
            meta.musicIdDefault = stage.musicId;

            meta.blastzoneDistUp = stage.blastzoneDistUp;
            meta.blastzoneDistDown = stage.blastzoneDistDown;
            meta.blastzoneDistLeft = stage.blastzoneDistLeft;
            meta.blastzoneDistRight = stage.blastzoneDistRight;

            meta.cameraDistUp = stage.cameraDistUp;
            meta.cameraDistDown = stage.cameraDistDown;
            meta.cameraDistLeft = stage.cameraDistLeft;
            meta.cameraDistRight = stage.cameraDistRight;
            meta.cameraMinDist = stage.cameraMinDist;

            meta.skins = new StageMetaData.StageSkinMetaData[0];
            meta.stageNameAnnouncerId = null;
            meta.unlockedByUnlockIds = null;

            meta.hide = false;

            stage.meta = meta;
            return meta;
        }

        public static void HideCustomStages(bool hide)
        {
            foreach (var stage in stages)
                stage.Value.meta.hide = hide;
        }

        public static bool TrySelectCustomStage(string id, out CustomStage stage)
        {
            if (stages.TryGetValue(id, out stage))
            {
                Plugin.LogInfo($"Loading {stage.id}");
                currentStage = stage;
                return true;
            }
            return false;
        }

        public static void UnloadStage(string id)
        {
            if (currentStage?.id == id)
                currentStage.UnloadAssetBundle();
        }
    }
}
