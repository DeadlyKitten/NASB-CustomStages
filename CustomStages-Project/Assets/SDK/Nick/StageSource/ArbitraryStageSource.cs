using System;
using UnityEngine;

namespace Nick
{
	public class ArbitraryStageSource : MonoStageSource
	{
		[Serializable]
		public struct StageLineRep
		{
			public Vector3 start;

			public Vector3 end;

			public StageLine.WallType walltype;

			public StageLine.StageLayer stageLayer;

			public StageLine.Solidity solid;

			public float conveyorspeed;

			public float inheritMovementIsOneMinusThis;

			public bool dontInheritOnLand;
		}

		public StageLineRep[] str;

		[SerializeField]
		private StageLine[] lines;

		private void OnDrawGizmos()
		{
			if (str != null)
			{
				for (int i = 0; i < str.Length; i++)
				{
					StageLineRep stageLineRep = str[i];
					StageLine.GizmoLine(base.transform.TransformPoint(stageLineRep.start), base.transform.TransformPoint(stageLineRep.end), stageLineRep.walltype);
				}
			}
		}
	}
}
