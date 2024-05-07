using UnityEngine;

namespace Nick
{
	public class Quadrangle
	{
		public Vector2 top;

		public Vector2 right;

		public Vector2 bottom;

		public Vector2 left;

		public Vector2 mid => (top + bottom + right + left) * 0.25f;

		public AABB2D GetBBox()
		{
			AABB2D @default = AABB2D.Default;
			@default.Include(this);
			return @default;
		}

		public bool Clip(Quadrangle other)
		{
			Vector2 pt = (other.top + other.right + other.bottom + other.left) * 0.25f;
			Vector2 vector = Mathf.Abs(other.top.y - other.bottom.y) * Vector2.up;
			Vector2 vector2 = Mathf.Abs(other.right.x - other.left.x) * Vector2.right;
			Quadrangle @object = QuadranglePool.GetObject();
			@object.Set(top + vector * 0.5f, bottom + vector * -0.5f, left + vector2 * -0.5f, right + vector2 * 0.5f);
			bool result = @object.Inside(pt);
			QuadranglePool.PutObject(@object);
			return result;
		}

		public Vector2 GetPullPoint(Vector2 dir)
		{
			Vector2 vector = mid;
			float num = float.MaxValue;
			float num2 = Vector2.Angle(dir, top - vector);
			float num3 = Vector2.Angle(dir, bottom - vector);
			float num4 = Vector2.Angle(dir, right - vector) - 3f;
			float num5 = Vector2.Angle(dir, left - vector) - 3f;
			if (num2 < num)
			{
				vector = top;
				num = num2;
			}
			if (num4 < num)
			{
				vector = right;
				num = num4;
			}
			if (num5 < num)
			{
				vector = left;
				num = num5;
			}
			if (num3 < num)
			{
				vector = bottom;
				num = num3;
			}
			return vector;
		}

		public float ThicknessInDir(Vector2 dir)
		{
			return ThicknessInDir(dir, 0.1f);
		}

		public float ThicknessInDir(Vector2 dir, float min)
		{
			if (dir == Vector2.zero)
			{
				return min;
			}
			float b = min;
			Vector2 normalized = dir.normalized;
			Vector2 vector = mid;
			if (normalized.x == 0f)
			{
				b = ((!(normalized.y > 0f)) ? Mathf.Abs(vector.y - bottom.y) : Mathf.Abs(top.y - vector.y));
			}
			else if (normalized.y == 0f)
			{
				b = ((!(normalized.x > 0f)) ? Mathf.Abs(vector.x - left.x) : Mathf.Abs(right.x - vector.x));
			}
			else
			{
				Vector2 vector2 = ((normalized.y > 0f) ? top : bottom);
				Vector2 vector3 = ((normalized.x > 0f) ? right : left);
				if (Mathf.Sign(normalized.y) == Mathf.Sign((vector2 - vector).y) && Mathf.Sign(normalized.x) == Mathf.Sign((vector3 - vector).x))
				{
					float magnitude = (vector3 - vector2).magnitude;
					normalized *= magnitude;
					if (LineMath.intersect2D_2Segments(vector, vector + normalized, vector2, vector3, out var I, out var _) > 0)
					{
						b = (I - vector).magnitude;
					}
				}
			}
			return Mathf.Max(min, b);
		}

		public bool Inside(Vector2 pt)
		{
			if (!VectorUtility.PointInTriangle(pt, top, right, left))
			{
				return VectorUtility.PointInTriangle(pt, left, right, bottom);
			}
			return true;
		}

		public bool TouchLine(Vector2 a0, Vector2 a1)
		{
			if (Inside(a0) || Inside(a1))
			{
				return true;
			}
			if (LineMath.intersect2D_2Segments(a0, a1, top, right, out var I, out var I2) > 0)
			{
				return true;
			}
			if (LineMath.intersect2D_2Segments(a0, a1, right, bottom, out I, out I2) > 0)
			{
				return true;
			}
			if (LineMath.intersect2D_2Segments(a0, a1, bottom, left, out I, out I2) > 0)
			{
				return true;
			}
			if (LineMath.intersect2D_2Segments(a0, a1, left, top, out I, out I2) > 0)
			{
				return true;
			}
			return false;
		}

		public void LineNW(ref LineMath.LineSegment ls)
		{
			ls.Set(left, top);
		}

		public void LineNE(ref LineMath.LineSegment ls)
		{
			ls.Set(top, right);
		}

		public void LineSW(ref LineMath.LineSegment ls)
		{
			ls.Set(bottom, left);
		}

		public void LineSE(ref LineMath.LineSegment ls)
		{
			ls.Set(right, bottom);
		}

		public void CopyPts(Quadrangle other)
		{
			top = other.top;
			bottom = other.bottom;
			left = other.left;
			right = other.right;
		}

		public void Set(Vector2 t, Vector2 b, Vector2 l, Vector2 r)
		{
			top = t;
			bottom = b;
			left = l;
			right = r;
		}

		public void Move(Vector2 move)
		{
			top += move;
			bottom += move;
			left += move;
			right += move;
		}
	}
}
