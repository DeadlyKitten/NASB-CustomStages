using System;

namespace Nick
{
    [Serializable]
	public class GameAgentBankBank
	{
		[Serializable]
		public class IdBank
		{
			public string id;

			public GameAgentBank bank;
		}

		public IdBank[] banks;
	}
}
