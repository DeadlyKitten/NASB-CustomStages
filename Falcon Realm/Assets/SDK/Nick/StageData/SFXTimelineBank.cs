using System;
using UnityEngine;

namespace Nick
{
	public class SFXTimelineBank : MonoBehaviour
	{
		[Serializable]
		public class TLID
		{
			public string id;

			public SFXTimeline timeline;
		}

		public TLID[] entries;
	}
}
