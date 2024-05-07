using Nick;
using SMU.Utilities;
using System.Collections;
using System.IO;
using System.IO.Compression;
using System.Linq;
using UnityEngine;

namespace CustomStages.Data
{
    class CustomStage
    {
        public string id;
        public string name;
        public string author;

        public string stageBundlePath;
        public string musicBundlePath;

        public string stagePath;

        public string musicId;
        public string musicPath;

        public float blastzoneDistUp;
        public float blastzoneDistDown;
        public float blastzoneDistLeft;
        public float blastzoneDistRight;

        public float cameraDistUp;
        public float cameraDistDown;
        public float cameraDistLeft;
        public float cameraDistRight;
        public float cameraMinDist;

        public string portraitPath;
        private Texture2D _portrait;
        public Texture2D Portrait => _portrait ??= LoadTextureFromZip(portraitPath);

        public GameAgent agent;
        public bool loading = false;
        public string zipPath;
        public StageMetaData meta;
        public AssetBundle bundle;

        public void PrewarmTextures() => _ = Portrait;

        private StagesUIMetaData.StageUIElements _UIElements;
        public StagesUIMetaData.StageUIElements UIElements
        {
            get
            {
                if (_UIElements == null)
                {
                    var sprite = Sprite.Create(Portrait, new Rect(0, 0, Portrait.width, Portrait.height), new Vector2(0.5f, 0.5f), 100);
                    _UIElements = new StagesUIMetaData.StageUIElements()
                    {
                        ID = id,
                        StageSmall = sprite,
                        StageSelectThumbnail = sprite
                    };
                }
                return _UIElements;
            }
        }

        public void LoadAssetBundle()
        {
            if (!bundle && !loading)
                SharedCoroutineStarter.StartCoroutine(LoadAssetBundleCoroutine());
        }

        public void UnloadAssetBundle()
        {
            if (!bundle || loading) return;

            Plugin.LogInfo($"Unloading Assetbundle for {name}...");
            loading = true;

            var idScenesDict = Object.FindObjectOfType<AgentLoading>().idScenes.IdDict;
            idScenesDict.Remove(id);

            bundle.Unload(true);

            bundle = null;
            loading = false;
        }

        IEnumerator LoadAssetBundleCoroutine()
        {
            Plugin.LogInfo($"Loading Assetbundle for {name}...");
            loading = true;
            using (var archive = ZipFile.OpenRead(zipPath))
            {
                using var stream = new MemoryStream();
                archive.GetEntry(stageBundlePath).Open().CopyTo(stream);
                var request = AssetBundle.LoadFromStreamAsync(stream);

                while (!request.isDone) yield return null;

                bundle = request.assetBundle;

                var idScenesDict = Object.FindObjectOfType<AgentLoading>().idScenes.IdDict;
                idScenesDict.Add(id, stagePath);
            }
            Plugin.LogInfo($"{name} loaded!");
            loading = false;
        }

        private Texture2D LoadTextureFromZip(string path)
        {
            using (var archive = ZipFile.OpenRead(zipPath))
            {
                Plugin.LogInfo($"Loading texture {path}");

                var textureEntry = archive.Entries.FirstOrDefault(x => x.FullName == path);
                if (textureEntry != null)
                {
                    var stream = new MemoryStream();
                    var texture = new Texture2D(2, 2);

                    textureEntry.Open().CopyTo(stream);
                    texture.LoadImage(stream.ToArray());
                    return texture;
                }
            }

            return null;
        }

        public GameMusic GetStageMusic()
        {
            GameMusic gameMusic;
            using (var archive = ZipFile.OpenRead(zipPath))
            {
                using var stream = new MemoryStream();
                archive.GetEntry(musicBundlePath).Open().CopyTo(stream);
                var musicBundle = AssetBundle.LoadFromStream(stream);
                gameMusic = musicBundle.LoadAsset<GameMusic>(musicPath);
            }
            return gameMusic;
        }
    }
}
