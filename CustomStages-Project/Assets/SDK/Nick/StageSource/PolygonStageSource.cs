using UnityEngine;

namespace Nick
{
	public class PolygonStageSource : MonoStageSource
	{
		public PolygonColliderStageSource pcss;

		private void OnDrawGizmos()
		{
			pcss.gizmolines();
		}
	}
}
