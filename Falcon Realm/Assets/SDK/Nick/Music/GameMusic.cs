using UnityEngine;

namespace Nick
{
	[CreateAssetMenu(fileName = "GameMusic", menuName = "ScriptableObjects/GameMusic")]
	public class GameMusic : ScriptableObject
	{
		public AudioClip clip;

		public float volume = 1f;

		public float loopTime = -1f;

		public float loopWhere;
	}
}
