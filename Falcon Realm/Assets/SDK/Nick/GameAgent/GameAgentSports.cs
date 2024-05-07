using System;
using UnityEngine;

namespace Nick
{
	public class GameAgentSports : AttachedGameAgent
	{
		[Serializable]
		public class Config
		{
			public bool activeBall;

			public bool bounceOnGoalEdge;

			public int goalScore;

			public bool respawnBall;

			public float inheritPush;

			public void CopyFrom(Config other)
			{
				activeBall = other.activeBall;
				bounceOnGoalEdge = other.bounceOnGoalEdge;
				goalScore = other.goalScore;
				respawnBall = other.respawnBall;
				inheritPush = other.inheritPush;
			}
		}

		[SerializeField]
		private Config config;

		public bool isBall;

		public GameModeSports.Ball ballType;

		public float ballRadius;

		public Vector2 lastCenter;

		public string spawnStateId;

		public string goalStateId;

		public string activateGoalGraphicsStateId = "goalgraphics";

		public SportsHoop[] goals;
	}
}
