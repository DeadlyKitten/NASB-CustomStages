using UnityEngine;

namespace Nick
{
	public class GizmosUtility
	{
		public static void DrawGizmoLine(Vector3 from, Vector3 to, Color c)
		{
			Gizmos.color = c;
			Gizmos.DrawLine(from, to);
		}

		public static void DrawGizmoArrow(Vector3 from, Vector3 to, Color c, bool powered, float fromRadius = 0.5f, float toRadius = 0.5f)
		{
			Gizmos.color = c;
			Vector3 normalized = (to - from).normalized;
			Vector3 vector = VectorUtility.OrthoV2(normalized) * 0.5f;
			Vector3 vector2 = normalized * fromRadius;
			Vector3 vector3 = normalized * toRadius * -1f;
			normalized *= 0.5f;
			Vector3 vector4 = to + vector3;
			Gizmos.DrawLine(from + vector2, vector4);
			Gizmos.DrawLine(vector4, vector4 - normalized + vector);
			Gizmos.DrawLine(vector4, vector4 - normalized - vector);
			if (powered)
			{
				Gizmos.DrawLine(vector4 - normalized, vector4 - normalized * 2f + vector);
				Gizmos.DrawLine(vector4 - normalized, vector4 - normalized * 2f - vector);
				Gizmos.DrawLine(vector4 - normalized * 2f, vector4 - normalized * 3f + vector);
				Gizmos.DrawLine(vector4 - normalized * 2f, vector4 - normalized * 3f - vector);
			}
		}

		public static void DrawGizmoConnection(Vector3 from, Vector3 to, Color c, Color c2, Color c3, float fromRadius = 0.5f, float toRadius = 0.5f)
		{
			Gizmos.color = c;
			Vector3 normalized = (to - from).normalized;
			_ = (Vector3)(VectorUtility.OrthoV2(normalized) * 0.5f);
			Vector3 vector = normalized * fromRadius;
			Vector3 vector2 = normalized * toRadius * -1f;
			_ = normalized * 0.5f;
			Vector3 vector3 = from + vector;
			Vector3 vector4 = to + vector2;
			Gizmos.DrawLine(vector3, vector4);
			Gizmos.color = c2;
			Gizmos.DrawSphere(vector3, 0.2f);
			Gizmos.color = c3;
			Gizmos.DrawSphere(vector4, 0.2f);
		}

		public static void DrawBox(Vector2 topl, Vector2 botr, Color c, bool cross = true)
		{
			Gizmos.color = c;
			Vector2 vector = topl;
			Vector2 vector2 = botr;
			vector.x = botr.x;
			vector2.x = topl.x;
			Gizmos.DrawLine(topl, vector);
			Gizmos.DrawLine(vector, botr);
			Gizmos.DrawLine(botr, vector2);
			Gizmos.DrawLine(vector2, topl);
			if (cross)
			{
				Gizmos.DrawLine(topl, botr);
				Gizmos.DrawLine(vector2, vector);
			}
		}

		public static void DrawWeirdBox(Vector3 A, Vector3 B, Vector3 C, Vector3 D, Color c, bool cross = true)
		{
			Gizmos.color = c;
			Gizmos.DrawLine(A, B);
			Gizmos.DrawLine(B, C);
			Gizmos.DrawLine(C, D);
			Gizmos.DrawLine(D, A);
			if (cross)
			{
				Gizmos.DrawLine(A, C);
				Gizmos.DrawLine(D, B);
			}
		}
	}
}
