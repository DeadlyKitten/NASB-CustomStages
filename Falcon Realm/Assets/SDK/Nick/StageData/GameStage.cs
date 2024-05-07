using System;
using UnityEngine;

namespace Nick
{
    public class GameStage
	{
		public struct EdgeState
		{
			public int order_added;

			public StageEdge.EdgeDirection dir;

			public Vector2 position;

			public int hogger;

			public int framesWithoutRequest;
		}

		public enum MovementEvent
		{
			None = 0,
			Stopped = 1,
			Bounce = 2,
			NewParent = 4,
			Landed = 8,
			LeftParent = 0x10,
			LeftEdge = 0x20,
			StoppedAtEdge = 0x40
		}

		[Serializable]
		public class MovementConfig
		{
			public bool getParented;

			public bool leaveEdges;

			public bool passThrough;

			public bool fallThrough;

			public bool ignoreMovingStage;

			public bool bounce;

			public bool stop;

			public bool leaveParent;

			public float inheritParentVel;

			public StageLine.StageLayer ignoreStageLayer = StageLine.StageLayer.None;

			public float leaveEdgeRestrict;

			public bool simpleFreeMovement;

			public float simpleRadius;
		}

		public enum SpawnPointType
		{
			Single,
			Team,
			Respawn
		}

		[Serializable]
		public struct StageSpawn
		{
			public SpawnPointType spawnType;

			public int playerCountOrTeamIndex;

			public Transform[] spawns;
		}
	}
}
