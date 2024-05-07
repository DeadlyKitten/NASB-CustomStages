using System;
using UnityEngine;

namespace Nick
{
    public class GameAgent : MonoBehaviour
	{
		[SerializeField]
		public string gameUniqueIdentifier;

		private uint gameUID;

		[SerializeField]
		private string[] agentTags;

		[SerializeField]
		private int agentSorting;

		[NonSerialized]
		public int playerIndex = -1;

		public GameAgentBankBank spawnAgents = new GameAgentBankBank();

		[SerializeField]
		private GameAgentStateMachine statemachine;

		[SerializeField]
		private GameAgentAnimation anim;

		[SerializeField]
		private GameAgentData data;

		[SerializeField]
		private GameAgentCustomCalls customcalls;

		[SerializeField]
		private GameAgentFX fx;

		[SerializeField]
		private GameAgentSFX sfx;

		[SerializeField]
		private GameAgentStage stage;

		[SerializeField]
		private GameAgentSports sports;

		public UpdateMe[] miscUpdate;

		[SerializeField]
		private GameAgentReady[] loadReady;
	}
}
