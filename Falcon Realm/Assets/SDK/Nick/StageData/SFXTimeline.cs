using System;
using UnityEngine;

namespace Nick
{
	[CreateAssetMenu(fileName = "SFXTimeline", menuName = "ScriptableObjects/SFXTimeline", order = 1)]
	public class SFXTimeline : ScriptableObject
	{
		[Serializable]
		public struct PlaySFX
		{
			public string sfxid;

			public float atMillisecond;
		}

		public float lengthMilliseconds;

		public PlaySFX[] timeline;
	}
}
