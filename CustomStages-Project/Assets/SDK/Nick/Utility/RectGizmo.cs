using UnityEngine;

namespace Nick
{
	public class RectGizmo : MonoBehaviour
	{
		public Color gizmoColor;

		public bool cross;

		private void OnDrawGizmos()
		{
			int childCount = base.transform.childCount;
			if (childCount != 0)
			{
				AABB2D @default = AABB2D.Default;
				for (int i = 0; i < childCount; i++)
				{
					Transform child = base.transform.GetChild(i);
					@default.Include(child.position);
				}
				GizmosUtility.DrawBox(@default.topl, @default.botr, gizmoColor, cross);
			}
		}
	}
}
