﻿using System;
using UnityEngine;

namespace Nick
{
    public class GameSFX : MonoBehaviour
	{
		[Serializable]
		public class SFXLikely
		{
			public AudioClip clip;

			public int likely = 1;

			public float volume = 1f;

			[Tooltip("Range of random pitching when over 0")]
			[SerializeField]
			private float pitchRange = -1f;

			[SerializeField]
			private float defaultPitch = 1f;

			public float Pitch
			{
				get
				{
					if (pitchRange > 0f)
					{
						return defaultPitch + UnityEngine.Random.Range(0f - pitchRange, pitchRange);
					}
					return defaultPitch;
				}
			}
		}

		public SFXLikely[] sfx = new SFXLikely[0];

		public bool sidechain;

		public float delay;

		public bool blockRepeatPlayback;

		public float blockRepeatPlayback_ms;

		[SerializeField]
		private string blockRepeatPlaybackId;

		public string chokedById;

		public string chokeId;

		public bool shuffle;

		public GameSFX layeredSound;
	}
}
