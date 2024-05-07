using System;
using UnityEngine;

namespace Nick
{
    public class GameFXBank : MonoBehaviour
	{
		[Serializable]
		public class Entry
		{
			public string id = string.Empty;

			public GameFX fx;
		}

		[SerializeField]
		private Entry[] entries;
	}
}
