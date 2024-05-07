using System;
using System.Collections.Generic;
using UnityEngine;

namespace Nick
{
	public class ParticleArrayFX : GameFX
	{
		public ParticleSystem[] particlesystems;

		public bool doneOnLength;

		public float warmup;

		public bool randomWarmup;

		public float randomWarmUpLength;

		public bool randomSeed;

		public bool clearOnRestart = true;

		public float loopedExtraTime = 2f;

		[Header("Mirror attributes")]
		public Transform scaleObjectReference;

		public Vector3 _flipInfluenceVector = new Vector3(1f, 0f, 0f);

		public struct PS_SubEmitters
		{
			public ParticleSystem[] subemitters;
		}
	}
}
