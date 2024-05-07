using UnityEngine;

namespace Nick
{
	public class EnvironmentEffect : MonoBehaviour
	{
		[SerializeField]
		private Transform A;

		[SerializeField]
		private Transform B;

		[SerializeField]
		private Vector2 activationDir;

		[SerializeField]
		private string spawnFXid;

		[SerializeField]
		private string spawnSFXid;
	}
}
