using System;
using UnityEngine;

namespace Nick
{
	[Serializable]
	public class PolygonColliderStageSource : StageSource
	{
		public PolygonCollider2D edge;

		public Transform parent;

		public StageLine.StageLayer stageLayer;

		public StageLine.Solidity solid;

		public float conveyorspeed;

		public float inheritMovement = 1f;

		public bool inheritOnLand = true;

		public override void gizmolines()
		{
			if (edge == null || parent == null)
			{
				return;
			}
			Vector2[] points = edge.points;
			if (points.Length >= 2)
			{
				for (int i = 0; i < points.Length; i++)
				{
					StageLine.GizmoLine(parent.TransformPoint(points[i]), parent.TransformPoint(points[(i + 1) % points.Length]), type);
				}
			}
		}
	}
}
