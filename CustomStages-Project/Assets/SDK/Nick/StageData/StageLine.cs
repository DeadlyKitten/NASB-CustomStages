using UnityEngine;

namespace Nick
{
	public struct StageLine
	{
		public enum WallType
		{
			NONE = 0,
			FLOOR = 1,
			ROOF = 2,
			WALL_L = 4,
			WALL_R = 8,
			ANY = 0xF,
			NOTFLOOR = 14,
			WALLS = 12
		}

		public enum StageLayer
		{
			General,
			IgnoreProjectiles,
			None
		}

		public enum Solidity
		{
			SOLID,
			PASS,
			FALL
		}

		public StageLayer stageLayer;

		public int order_added;

		public static void GizmoLine(Vector2 a, Vector2 b, WallType t)
		{
			Vector2 vector = b - a;
			Vector2 vector2 = VectorUtility.OrthoV2(vector) * -1f;
			if (t == WallType.ANY)
			{
				t = CalcType(vector2);
			}
			Color color = Color.white;
			switch (t)
			{
				case WallType.FLOOR:
					color = Color.white;
					break;
				case WallType.ROOF:
					color = Color.red;
					break;
				case WallType.WALL_L:
					color = Color.blue;
					break;
				case WallType.WALL_R:
					color = Color.green;
					break;
			}
			color.a = 1f;
			Gizmos.color = color;
			Gizmos.DrawLine(a, b);
			Gizmos.DrawLine(a + vector * 0.5f, a + vector * 0.5f + vector2 * -0.1f);
		}

		public static WallType CalcType(Vector2 normal)
		{
			float f = Vector2.Angle(Vector2.up, normal) * Mathf.Sign(Vector2.Dot(Vector2.right, normal));
			if (Mathf.Abs(f) <= 70f)
			{
				return WallType.FLOOR;
			}
			if (Mathf.Abs(f) >= 150f)
			{
				return WallType.ROOF;
			}
			if (Mathf.Sign(f) > 0f)
			{
				return WallType.WALL_L;
			}
			return WallType.WALL_R;
		}
	}
}
