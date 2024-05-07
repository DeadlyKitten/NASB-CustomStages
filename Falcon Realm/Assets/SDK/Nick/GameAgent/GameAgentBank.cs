using System;
using UnityEngine;

namespace Nick
{
    [CreateAssetMenu(fileName = "GameAgentBank", menuName = "ScriptableObjects/GameAgentBank", order = 1)]
	public class GameAgentBank : ScriptableObject
	{
		[Serializable]
		public class IdAgent
		{
			public string id;

			public GameAgent ga;
		}

		public IdAgent[] ags;
	}
}
