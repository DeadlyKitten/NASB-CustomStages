using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nick;

public class RandomShower2 : MonoBehaviour
{
	[SerializeField]
    public RandomShowerCollection[] list;

    [System.Serializable]
    public class RandomShowerCollection
    {
        public int odds;
        public GameObject[] hide;
        public GameObject[] show;
    }

    public void Start()
    {
		Debug.Log("Start");
		Check();
    }

    public void Update()
    {
		if (Input.GetKeyDown(KeyCode.T))
			Check();
    }

    public void Check()
	{
		foreach(var item in list)
        {
			var rng = Random.Range(0, item.odds);
			Debug.Log(rng);
			if (rng == 0)
			{
				Jackpot(item);
				return;
			}
		}
	}

	public void Jackpot(RandomShowerCollection collection)
	{
		for (int i = 0; i < collection.hide.Length; i++)
		{
			collection.hide[i].SetActive(false);
		}
		for (int j = 0; j < collection.show.Length; j++)
		{
			//collection.show[j].transform.localPosition = new Vector3(0f, 0f, 0f);
			collection.show[j].SetActive(true);
		}
	}
}
