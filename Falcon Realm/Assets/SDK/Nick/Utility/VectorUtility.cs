using UnityEngine;

namespace Nick
{
	public class VectorUtility
	{
		public static Vector3 AddV3V2(Vector3 v3, Vector2 v2)
		{
			return new Vector3(v3.x + v2.x, v3.y + v2.y, v3.z);
		}

		public static Vector2 AddV2V3(Vector2 v2, Vector3 v3)
		{
			return new Vector2(v3.x + v2.x, v3.y + v2.y);
		}

		public static void AddV3V2(Vector3 v3, Vector2 v2, ref Vector3 r)
		{
			r.x = v3.x + v2.x;
			r.y = v3.y + v2.y;
			r.z = v3.z;
		}

		public static Vector2 OrthoV2(Vector2 v)
		{
			return new Vector2(v.y, 0f - v.x);
		}

		public static Vector2 Rotate(Vector2 v, float degrees)
		{
			return Quaternion.Euler(0f, 0f, degrees) * v;
		}

		public static float InverseLerpDot(Vector3 a, Vector3 b, Vector3 t)
		{
			Vector3 rhs = b - a;
			float num = rhs.magnitude;
			if (num <= 0f)
			{
				num = 1f;
			}
			return Vector3.Dot(t - a, rhs) / (num * num);
		}

		public static Vector2 ReflectAway(Vector2 v, Vector2 normal)
		{
			Vector2 vector = Vector2.Reflect(v, normal);
			if (Vector2.Dot(vector, normal) < 0f)
			{
				Vector2 vector2 = OrthoV2(normal);
				vector = ((!(Vector2.Dot(vector, vector2) > 0f)) ? Vector2.Reflect(vector, OrthoV2(vector2)) : Vector2.Reflect(vector, OrthoV2(-vector2)));
			}
			return vector;
		}

		public static float Sign(Vector2 p1, Vector2 p2, Vector2 p3)
		{
			return (p1.x - p3.x) * (p2.y - p3.y) - (p2.x - p3.x) * (p1.y - p3.y);
		}

		public static bool PointInTriangle(Vector2 pt, Vector2 v1, Vector2 v2, Vector2 v3)
		{
			bool num = Sign(pt, v1, v2) < 0f;
			bool flag = Sign(pt, v2, v3) < 0f;
			bool flag2 = Sign(pt, v3, v1) < 0f;
			if (num == flag)
			{
				return flag == flag2;
			}
			return false;
		}

		public static Vector3 MoveTowardsIfSmaller(Vector3 current, Vector3 target, float maxDistanceDelta)
		{
			if (Vector3.Dot(current, target) > target.magnitude)
			{
				return current;
			}
			return Vector3.MoveTowards(current, target, maxDistanceDelta);
		}

		public static Vector3 PushOut(Vector3 current, Vector3 push)
		{
			float x = push.x;
			float y = push.y;
			float z = push.z;
			if (x > 0f)
			{
				if (x > current.x)
				{
					current.x = Mathf.MoveTowards(current.x, x, x);
				}
			}
			else if (x < 0f && x < current.x)
			{
				current.x = Mathf.MoveTowards(current.x, x, Mathf.Abs(x));
			}
			if (y > 0f)
			{
				if (y > current.y)
				{
					current.y = Mathf.MoveTowards(current.y, y, y);
				}
			}
			else if (y < 0f && y < current.y)
			{
				current.y = Mathf.MoveTowards(current.y, y, Mathf.Abs(y));
			}
			if (z > 0f)
			{
				if (z > current.z)
				{
					current.z = Mathf.MoveTowards(current.z, z, z);
				}
			}
			else if (z < 0f && z < current.z)
			{
				current.z = Mathf.MoveTowards(current.z, z, Mathf.Abs(z));
			}
			return current;
		}

		public static Vector3 GetBezierPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
		{
			t = Mathf.Clamp01(t);
			float num = 1f - t;
			return num * num * p0 + 2f * num * t * p1 + t * t * p2;
		}

		public static Vector3 ReturnCatmullRom(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
		{
			Vector3 vector = 0.5f * (2f * p1);
			Vector3 vector2 = 0.5f * (p2 - p0);
			Vector3 vector3 = 0.5f * (2f * p0 - 5f * p1 + 4f * p2 - p3);
			Vector3 vector4 = 0.5f * (-p0 + 3f * p1 - 3f * p2 + p3);
			return vector + vector2 * t + vector3 * t * t + vector4 * t * t * t;
		}

		public static Vector3[] ChaikinCurve(Vector3[] pts, int passes)
		{
			if (pts.Length < 3)
			{
				return pts;
			}
			Vector3[] array = new Vector3[(pts.Length - 2) * 2 + 2];
			array[0] = pts[0];
			array[array.Length - 1] = pts[pts.Length - 1];
			int num = 1;
			for (int i = 0; i < pts.Length - 2; i++)
			{
				array[num] = pts[i] + (pts[i + 1] - pts[i]) * 0.75f;
				array[num + 1] = pts[i + 1] + (pts[i + 2] - pts[i + 1]) * 0.25f;
				num += 2;
			}
			passes--;
			if (passes > 0)
			{
				return ChaikinCurve(array, passes);
			}
			return array;
		}
	}
}
