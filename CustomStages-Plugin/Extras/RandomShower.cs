using Nick;
using System.Linq;
using UnityEngine;

public class RandomShower : UpdateMe
{
	[SerializeField]
	[Range(0,1)]
	private float odds;
	[SerializeField]
	private GameObject[] hideObjects;
	[SerializeField]
	private GameObject[] showObjects;

#if PLUGIN
	public override void restart() => Check();

	private void Check()
	{
		var game = Resources.FindObjectsOfTypeAll<GameInstance>().FirstOrDefault();

		CustomStages.Plugin.LogDebug($"RandomShower: Rolling for odds {odds}");
		var roll = game.random.RangeFloat(0f, 1f);
		CustomStages.Plugin.LogDebug($"RandomShower: Rolled {roll}");
		
		if (roll <= odds) Jackpot();
	}

	private void Jackpot()
	{
		CustomStages.Plugin.LogDebug("RandomShower: Jackpot!");

		if (hideObjects != null)
		{
			for (int i = 0; i < hideObjects.Length; i++)
				hideObjects[i].SetActive(false);
		}

		if (showObjects != null)
		{
			for (int j = 0; j < showObjects.Length; j++)
				showObjects[j].SetActive(true);
		}
	}

#endif
}
