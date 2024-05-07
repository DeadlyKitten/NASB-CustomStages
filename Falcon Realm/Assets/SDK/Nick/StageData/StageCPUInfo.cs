using System;
using UnityEngine;

namespace Nick
{
	public class StageCPUInfo : MonoBehaviour
	{
		public enum Type
		{
			Ground = 0,
			Platform = 1,
			FalsifyCollisionChecks = 2,
			NotInfo = 9999999
		}

		public Type type;

		public AABB2D BoundingBox;

		[NonSerialized]
		public bool include;

		private void OnEnable()
		{
			include = true;
		}

		private void OnDisable()
		{
			include = false;
		}

		public void Recalculate()
		{
			if (include)
			{
				BoundingBox.Reset();
				BoundingBox.Include(base.transform.position);
				for (int i = 0; i < base.transform.childCount; i++)
				{
					BoundingBox.Include(base.transform.GetChild(i).position);
				}
			}
		}

		private void OnDrawGizmos()
		{
			AABB2D @default = AABB2D.Default;
			@default.Include(base.transform.position);
			for (int i = 0; i < base.transform.childCount; i++)
			{
				@default.Include(base.transform.GetChild(i).position);
			}
			Color c = Color.red;
			switch (type)
			{
				case Type.Ground:
					c = XKCDColors.Orange;
					break;
				case Type.Platform:
					c = XKCDColors.Teal;
					break;
				case Type.FalsifyCollisionChecks:
					c = XKCDColors.TomatoRed;
					break;
			}
			GizmosUtility.DrawBox(@default.topl, @default.botr, c);
		}
	}
}
