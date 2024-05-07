using UnityEngine;

namespace Nick
{
	public struct AABB2D
	{
		public static TypedArrayPools<AABB2D> BBoxArrayPools = new TypedArrayPools<AABB2D>();

		public Vector2 topl;

		public Vector2 botr;

		public static readonly AABB2D Default = new AABB2D(float.MinValue, float.MaxValue, float.MaxValue, float.MinValue);

		public Vector2 topr => new Vector2(botr.x, topl.y);

		public Vector2 botl => new Vector2(topl.x, botr.y);

		public float width => botr.x - topl.x;

		public float height => topl.y - botr.y;

		public Vector2 center => (topl + botr) * 0.5f;

		public Vector2 top => (topl + topr) * 0.5f;

		public Vector2 bottom => (botl + botr) * 0.5f;

		public Vector2 right => (topr + botr) * 0.5f;

		public Vector2 left => (topl + botl) * 0.5f;

		public AABB2D(float toply, float botry, float toplx, float botrx)
		{
			topl.y = toply;
			botr.y = botry;
			topl.x = toplx;
			botr.x = botrx;
		}

		public void Grow(float amount)
		{
			topl.y += amount;
			topl.x -= amount;
			botr.y -= amount;
			botr.x += amount;
		}
		public void GrowH(float amount)

		{
			topl.x -= amount;
			botr.x += amount;
		}

		public void GrowV(float amount)
		{
			topl.y += amount;
			botr.y -= amount;
		}

		public void Move(Vector2 dist)
		{
			topl += dist;
			botr += dist;
		}

		public void Reset()
		{
			topl.y = float.MinValue;
			botr.y = float.MaxValue;
			topl.x = float.MaxValue;
			botr.x = float.MinValue;
		}

		public void Include(Vector2 pt)
		{
			if (pt.y > topl.y)
			{
				topl.y = pt.y;
			}
			if (pt.y < botr.y)
			{
				botr.y = pt.y;
			}
			if (pt.x < topl.x)
			{
				topl.x = pt.x;
			}
			if (pt.x > botr.x)
			{
				botr.x = pt.x;
			}
		}

		public void IncludeOnlyX(Vector2 pt)
		{
			if (pt.x < topl.x)
			{
				topl.x = pt.x;
			}
			if (pt.x > botr.x)
			{
				botr.x = pt.x;
			}
		}

		public void Include(Vector2 pt0, Vector2 pt1)
		{
			Include(pt0);
			Include(pt1);
		}

		public void Include(LineMath.LineSegment l0, LineMath.LineSegment l1)
		{
			Include(l0.P0, l0.P1);
			Include(l1.P0, l1.P1);
		}

		public void Include(AABB2D other)
		{
			Include(other.topl, other.botr);
		}

		public void IncludeOnlyX(AABB2D other)
		{
			IncludeOnlyX(other.topl);
			IncludeOnlyX(other.botr);
		}

		public void Include(AABB2D A, AABB2D B)
		{
			Include(A);
			Include(B);
		}

		public void Include(Quadrangle quad)
		{
			Include(quad.bottom, quad.left);
			Include(quad.right, quad.top);
		}

		public void Include(Quadrangle quad0, Quadrangle quad1)
		{
			Include(quad0);
			Include(quad1);
		}

		public bool Intersects(AABB2D other)
		{
			Vector2 vector = (other.botr - other.topl) * 0.5f;
			Vector2 vector2 = topl - vector * 1.01f;
			Vector2 vector3 = botr + vector * 1.01f;
			Vector2 vector4 = other.topl + vector;
			if (vector4.x <= vector3.x && vector4.x >= vector2.x && vector4.y <= vector2.y)
			{
				return vector4.y >= vector3.y;
			}
			return false;
		}

		public bool IntersectsLineSegment(Vector2 a, Vector2 b)
		{
			LineMath.LineSegment ls = new LineMath.LineSegment(a, b);
			return IntersectsLineSegment(ls);
		}

		public bool IntersectsLineSegment(Vector2 a, Vector2 b, out bool startInside, out bool endInside, out Vector2 intersectPoint0, out Vector2 intersectPoint1)
		{
			LineMath.LineSegment ls = new LineMath.LineSegment(a, b);
			return IntersectsLineSegment(ls, out startInside, out endInside, out intersectPoint0, out intersectPoint1);
		}

		public bool IntersectsLineSegment(LineMath.LineSegment ls)
		{
			if (Inside(ls.P0))
			{
				return true;
			}
			if (Inside(ls.P1))
			{
				return true;
			}
			LineMath.LineSegment s = new LineMath.LineSegment(topl, botr);
			if (LineMath.intersect2D_2Segments(s, ls))
			{
				return true;
			}
			s.P0 = topr;
			s.P1 = botl;
			return LineMath.intersect2D_2Segments(s, ls);
		}

		public bool IntersectsLineSegment(LineMath.LineSegment ls, out bool startInside, out bool endInside, out Vector2 intersectPoint0, out Vector2 intersectPoint1)
		{
			bool result = false;
			if (Inside(ls.P0))
			{
				startInside = true;
				result = true;
			}
			else
			{
				startInside = false;
			}
			if (Inside(ls.P1))
			{
				endInside = true;
				result = true;
			}
			else
			{
				endInside = false;
			}
			LineMath.LineSegment lineSegment = new LineMath.LineSegment(topl, botr);
			if (LineMath.intersect2D_2Segments(lineSegment, ls))
			{
				result = true;
			}
			lineSegment.P0 = topr;
			lineSegment.P1 = botl;
			if (LineMath.intersect2D_2Segments(lineSegment, ls))
			{
				result = true;
			}
			Vector2 ci = Vector2.zero;
			Vector2 ci2 = Vector2.zero;
			float ci0d = float.MaxValue;
			float ci1d = float.MaxValue;
			lineSegment.P0 = topl;
			lineSegment.P1 = topr;
			IntersectDistHelper(ls, lineSegment, ref ci, ref ci2, ref ci0d, ref ci1d);
			lineSegment.P0 = topr;
			lineSegment.P1 = botr;
			IntersectDistHelper(ls, lineSegment, ref ci, ref ci2, ref ci0d, ref ci1d);
			lineSegment.P0 = botr;
			lineSegment.P1 = botl;
			IntersectDistHelper(ls, lineSegment, ref ci, ref ci2, ref ci0d, ref ci1d);
			lineSegment.P0 = botl;
			lineSegment.P1 = topl;
			IntersectDistHelper(ls, lineSegment, ref ci, ref ci2, ref ci0d, ref ci1d);
			if (ci0d == float.MaxValue)
			{
				intersectPoint0 = ls.P0;
			}
			else
			{
				intersectPoint0 = ci;
			}
			if (ci1d == float.MaxValue)
			{
				intersectPoint1 = ls.P1;
			}
			else
			{
				intersectPoint1 = ci2;
			}
			return result;
		}

		private void IntersectDistHelper(LineMath.LineSegment ls, LineMath.LineSegment against, ref Vector2 ci0, ref Vector2 ci1, ref float ci0d, ref float ci1d)
		{
			Vector2 I;
			Vector2 I2;
			int num = LineMath.intersect2D_2Segments(ls, against, out I, out I2);
			if (num <= 0)
			{
				return;
			}
			float magnitude = (I - ls.P0).magnitude;
			float magnitude2 = (I - ls.P1).magnitude;
			if (magnitude < ci0d)
			{
				ci0 = I;
				ci0d = magnitude;
			}
			if (magnitude2 < ci1d)
			{
				ci1 = I;
				ci1d = magnitude2;
			}
			if (num > 1)
			{
				float magnitude3 = (I2 - ls.P0).magnitude;
				float magnitude4 = (I2 - ls.P1).magnitude;
				if (magnitude3 < ci0d)
				{
					ci0 = I;
					ci0d = magnitude3;
				}
				if (magnitude4 < ci1d)
				{
					ci1 = I;
					ci1d = magnitude4;
				}
			}
		}

		public float XdistTo(AABB2D other)
		{
			if (other.topl.x >= topl.x && other.topl.x <= botr.x)
			{
				return 0f;
			}
			if (other.botr.x >= topl.x && other.botr.x <= botr.x)
			{
				return 0f;
			}
			if (other.topl.x <= topl.x && other.botr.x >= botr.x)
			{
				return 0f;
			}
			if (other.botr.x < topl.x)
			{
				return Mathf.Abs(other.botr.x - topl.x);
			}
			if (other.topl.x > botr.x)
			{
				return Mathf.Abs(other.topl.x - botr.x);
			}
			return Mathf.Abs(other.center.x - center.x);
		}

		public float YdistTo(AABB2D other)
		{
			if (other.topl.y <= topl.y && other.topl.y >= botr.y)
			{
				return 0f;
			}
			if (other.botr.y <= topl.y && other.botr.y >= botr.y)
			{
				return 0f;
			}
			if (other.topl.y >= topl.y && other.botr.y <= botr.y)
			{
				return 0f;
			}
			if (other.botr.y > topl.y)
			{
				return Mathf.Abs(other.botr.y - topl.y);
			}
			if (other.topl.y < botr.y)
			{
				return Mathf.Abs(other.topl.y - botr.y);
			}
			return Mathf.Abs(other.center.y - center.y);
		}

		public float DistanceTo(AABB2D other)
		{
			Vector2 vector = (other.botr - other.topl) * 0.5f;
			Vector2 vector2 = topl - vector * 1.01f;
			Vector2 vector3 = botr + vector * 1.01f;
			Vector2 vector4 = vector2;
			vector4.x = vector3.x;
			Vector2 vector5 = vector3;
			vector5.x = vector2.x;
			Vector2 vector6 = other.topl + vector;
			if (vector6.x <= vector3.x && vector6.x >= vector2.x && vector6.y <= vector2.y && vector6.y >= vector3.y)
			{
				return 0f;
			}
			if (vector6.x > vector3.x)
			{
				if (vector6.y > vector2.y)
				{
					return (vector4 - vector6).magnitude;
				}
				if (vector6.y < vector3.y)
				{
					return (vector3 - vector6).magnitude;
				}
				return vector6.x - vector3.x;
			}
			if (vector6.x < vector2.x)
			{
				if (vector6.y > vector2.y)
				{
					return (vector2 - vector6).magnitude;
				}
				if (vector6.y < vector3.y)
				{
					return (vector5 - vector6).magnitude;
				}
				return vector2.x - vector6.x;
			}
			if (vector6.y > vector2.y)
			{
				return vector6.y - vector2.y;
			}
			return vector3.y - vector6.y;
		}

		public bool Inside(Vector2 pt)
		{
			if (pt.x <= botr.x && pt.x >= topl.x && pt.y <= topl.y)
			{
				return pt.y >= botr.y;
			}
			return false;
		}

		public Vector2 ClampInside(Vector2 pt)
		{
			if (pt.x > botr.x)
			{
				pt.x = botr.x;
			}
			if (pt.x < topl.x)
			{
				pt.x = topl.x;
			}
			if (pt.y > topl.y)
			{
				pt.y = topl.y;
			}
			if (pt.y < botr.y)
			{
				pt.y = botr.y;
			}
			return pt;
		}
	}
}
