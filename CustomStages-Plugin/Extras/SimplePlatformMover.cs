using Nick;
using UnityEngine;

namespace CustomStages.Extras
{
    class SimplePlatformMover : UpdateMe
    {
		public EdgeCollider2D Path;
		public float StartTraveled;
		public bool ClosedPath;
		public float moveTime = 1f;

		private float currentMoveTime;
		private Vector2[] pointCache;
		private float[] lengthsAt;
		private float pathLength;
		private bool hasPath;
		private Transform pathTransform;
		private float part;

		private AnimationCurve sampleCurve;

#if EDITOR
		void Start() => restart();

		void Update() => upd(Time.deltaTime);
#endif

        public override void restart()
        {
			part = 0f;
			currentMoveTime = StartTraveled * moveTime;
			hasPath = false;

			if (!ClosedPath)
            {
				var frames = new Keyframe[]
				{
					new Keyframe(0f, 0f),
					new Keyframe(0.5f, 1f),
					new Keyframe(1f, 0f)
				};
				sampleCurve = new AnimationCurve(frames);
            }
			else
            {
				sampleCurve = AnimationCurve.Linear(0, 0, 1, 1);
            }

			if (Path != null)
			{
				pointCache = Path.points;
				lengthsAt = new float[pointCache.Length];
				hasPath = true;
				pathTransform = Path.transform;
			}
			if (hasPath)
			{
				pathLength = 0f;
				for (int i = 0; i < pointCache.Length - 1; i++)
				{
					lengthsAt[i] = pathLength;
					pathLength += (pointCache[i + 1] - pointCache[i]).magnitude;
				}
				lengthsAt[pointCache.Length - 1] = pathLength;
			}
		}

		public override void upd(float dt)
		{
			if (!hasPath)
			{
				return;
			}
			currentMoveTime += dt;
			if (currentMoveTime > moveTime)
			{
				currentMoveTime %= moveTime;
			}
			if (moveTime <= 0f)
			{
				return;
			}
			part = Mathf.Clamp01(sampleCurve.Evaluate(currentMoveTime / moveTime));
			part *= pathLength;

			if (part > pathLength)
				part %= pathLength;

			for (int i = 0; i < lengthsAt.Length - 1; i++)
			{
				if (part >= lengthsAt[i] && part < lengthsAt[i + 1])
				{
					if (lengthsAt[i] == lengthsAt[i + 1])
					{
						UpdatePosition(GetWorldPosition(i));
						return;
					}
					float num = (part - lengthsAt[i]) / (lengthsAt[i + 1] - lengthsAt[i]);
					UpdatePosition(GetWorldPosition(i) + (GetWorldPosition(i + 1) - GetWorldPosition(i)) * num);
					return;
				}
			}
			UpdatePosition(GetWorldPosition(pointCache.Length - 1));
		}

		private Vector2 GetWorldPosition(int pointIndex)
		{
			if (!hasPath)
			{
				return pathTransform.position;
			}
			if (pointIndex < 0)
			{
				pointIndex = 0;
			}
			if (pointIndex >= pointCache.Length)
			{
				pointIndex = pointCache.Length - 1;
			}
			return pathTransform.TransformPoint(pointCache[pointIndex]);
		}

		private void UpdatePosition(Vector2 position)
		{
			transform.position = position;
		}

	}
}
