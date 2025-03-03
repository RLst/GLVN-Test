using UnityEngine;

namespace LeMinhHuy
{
	[CreateAssetMenu]
	public class GameSettings : ScriptableObject
	{
		public float fieldWidth = 20f;
		public float fieldLength = 40f;

		//Round
		public int roundsPerMatch = 5;
		public float startingRoundRemainingTime = 140f;
		public float penaltyRoundRemainingTime = 40f;
		public float endOfRoundTimescale = 0.4f;

		//Energy
		public float maxEnergy;

		[Header("Strategies")]
		public Strategy offensiveStrategy;
		public Strategy defensiveStrategy;

		[Header("Match Settings")]
		//These are the definite settings as chosen by the user has selected
		//This might allow for a cutscene to play in the background CPU vs CPU
		public TeamSettings teamOneSettings;
		public TeamSettings teamTwoSettings;

		public void SetTeamOneName(string name)
		{
			teamOneSettings.name = name;
		}
		public void SetTeamTwoName(string name)
		{
			teamTwoSettings.name = name;
		}
	}
}