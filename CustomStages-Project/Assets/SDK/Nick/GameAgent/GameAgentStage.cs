using System;
using UnityEngine;

namespace Nick
{
    public class GameAgentStage : AttachedGameAgent
	{
		[Serializable]
		public class StagePart
		{
			public string id;

			public MonoStageSource stageSource;

			public StageEdge[] edges;

			public bool defaultActive = true;
		}

		[Serializable]
		public class ExtraBlastzone
		{
			public Transform a;

			public Transform b;

			public Blastzone.ZoneType zoneType = Blastzone.ZoneType.Bottom;
		}

		[SerializeField]
		private StagePart[] parts;

		[SerializeField]
		private GameStage.StageSpawn[] spawnPoints;

		[SerializeField]
		private Transform[] stageEnclose;

		[SerializeField]
		private EnvironmentEffect[] environmentEffects;

		[SerializeField]
		private ExtraBlastzone[] extraBlastzones;

		public GameStage.StageSpawn[] SpawnPoints => spawnPoints;
	}
}
