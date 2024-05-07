using UnityEngine;

namespace Nick
{
	public class Blastzone : MonoBehaviour
	{
		public enum ZoneType
		{
			None,
			Bottom,
			Top,
			Left,
			Right,
			InstaKill
		}

		public ZoneType zone = ZoneType.Bottom;
	}
}
