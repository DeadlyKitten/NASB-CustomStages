using UnityEngine;

namespace Nick
{
	public class LineMath
	{
		public struct LineSegment
		{
			public Vector2 P0;

			public Vector2 P1;

			public LineSegment(Vector2 p0, Vector2 p1)
			{
				P0 = p0;
				P1 = p1;
			}

			public void Set(Vector2 p0, Vector2 p1)
			{
				P0 = p0;
				P1 = p1;
			}
		}

		public static float DistanceToLineSegment(Vector2 v, Vector2 w, Vector2 p)
		{
			float num = (w - v).magnitude * (w - v).magnitude;
			if ((double)num == 0.0)
			{
				return (v - p).magnitude;
			}
			float num2 = Mathf.Max(0f, Mathf.Min(1f, Vector2.Dot(p - v, w - v) / num));
			Vector2 vector = v + num2 * (w - v);
			return (p - vector).magnitude;
		}

		private static float perp(Vector2 u, Vector2 v)
		{
			return u.x * v.y - u.y * v.x;
		}

		public static bool intersect2D_2Segments(Vector2 a0, Vector2 a1, Vector2 b0, Vector2 b1)
		{
			Vector2 I;
			Vector2 I2;
			return intersect2D_2Segments(a0, a1, b0, b1, out I, out I2) > 0;
		}

		public static int intersect2D_2Segments(Vector2 a0, Vector2 a1, Vector2 b0, Vector2 b1, out Vector2 I0, out Vector2 I1)
		{
			LineSegment s = new LineSegment(a0, a1);
			LineSegment s2 = new LineSegment(b0, b1);
			return intersect2D_2Segments(s, s2, out I0, out I1);
		}

		public static bool intersect2D_2Segments(LineSegment S1, LineSegment S2)
		{
			Vector2 I;
			Vector2 I2;
			return intersect2D_2Segments(S1, S2, out I, out I2) > 0;
		}

		public static int intersect2D_2Segments(LineSegment S1, LineSegment S2, out Vector2 I0, out Vector2 I1)
		{
			I0 = Vector2.zero;
			I1 = Vector2.zero;
			Vector2 vector = S1.P1 - S1.P0;
			Vector2 vector2 = S2.P1 - S2.P0;
			Vector2 v = S1.P0 - S2.P0;
			float num = perp(vector, vector2);
			if (Mathf.Abs(num) < 1E-08f)
			{
				if (perp(vector, v) != 0f || perp(vector2, v) != 0f)
				{
					return 0;
				}
				float num2 = Vector2.Dot(vector, vector);
				float num3 = Vector2.Dot(vector2, vector2);
				if (num2 == 0f && num3 == 0f)
				{
					if (S1.P0 != S2.P0)
					{
						return 0;
					}
					I0 = S1.P0;
					return 1;
				}
				if (num2 == 0f)
				{
					if (inSegment(S1.P0, S2) == 0)
					{
						return 0;
					}
					I0 = S1.P0;
					return 1;
				}
				if (num3 == 0f)
				{
					if (inSegment(S2.P0, S1) == 0)
					{
						return 0;
					}
					I0 = S2.P0;
					return 1;
				}
				Vector2 vector3 = S1.P1 - S2.P0;
				float num4;
				float num5;
				if (vector2.x != 0f)
				{
					num4 = v.x / vector2.x;
					num5 = vector3.x / vector2.x;
				}
				else
				{
					num4 = v.y / vector2.y;
					num5 = vector3.y / vector2.y;
				}
				if (num4 > num5)
				{
					float num6 = num4;
					num4 = num5;
					num5 = num6;
				}
				if (num4 > 1f || num5 < 0f)
				{
					return 0;
				}
				num4 = ((num4 < 0f) ? 0f : num4);
				num5 = ((num5 > 1f) ? 1f : num5);
				if (num4 == num5)
				{
					I0 = S2.P0 + num4 * vector2;
					return 1;
				}
				I0 = S2.P0 + num4 * vector2;
				I1 = S2.P0 + num5 * vector2;
				return 2;
			}
			float num7 = perp(vector2, v) / num;
			if (num7 < 0f || num7 > 1f)
			{
				return 0;
			}
			float num8 = perp(vector, v) / num;
			if (num8 < 0f || num8 > 1f)
			{
				return 0;
			}
			I0 = S1.P0 + num7 * vector;
			return 1;
		}

		private static int inSegment(Vector2 P, LineSegment S)
		{
			if (S.P0.x != S.P1.x)
			{
				if (S.P0.x <= P.x && P.x <= S.P1.x)
				{
					return 1;
				}
				if (S.P0.x >= P.x && P.x >= S.P1.x)
				{
					return 1;
				}
			}
			else
			{
				if (S.P0.y <= P.y && P.y <= S.P1.y)
				{
					return 1;
				}
				if (S.P0.y >= P.y && P.y >= S.P1.y)
				{
					return 1;
				}
			}
			return 0;
		}
	}
}
