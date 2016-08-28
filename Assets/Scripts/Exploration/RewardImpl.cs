using System;
using System.Collections.Generic;
using UnityEngine;

public static class RewardImpl
{

	public class AnimalReward : Reward {
		private List<AnimalDef> animals = new List<AnimalDef>();

		public AnimalReward(AnimalDef animal) {
			animals.Add(animal);
		}

		public AnimalReward(List<AnimalDef> animals) {
			animals.ForEach(this.animals.Add);
		}

		public void grant(Party party) {
			GameManager.Instance.worldState.GetInventory().AddAll(animals);
		}
	}

	public class FoodReward : Reward
	{

		int foodCount;

		public FoodReward (int foodCount)
		{
			this.foodCount = foodCount;
		}

		public void grant (Party party)
		{
			if (this.foodCount > 0) {
				GameManager.Instance.AddFood (this.foodCount);
			} else {
				GameManager.Instance.worldState.GetInventory ().subtractFood (-this.foodCount);
			}
		}
	}

	public class FoodPenalty: FoodReward
	{
		public FoodPenalty (int foodCount) : base (-foodCount)
		{
		}
	}

	public class RandomAnimalPenalty : Reward
	{
		public RandomAnimalPenalty ()
		{
		}


		public void grant (Party party)
		{
			if (GameManager.Instance.worldState.GetParty ().Size () > 0) {
				int index = UnityEngine.Random.Range (0, party.Size ());
				Debug.Log ("One of your " + party.Size () + " animimals will die, the " + index + "th one");
				GameObject toDie = party.RemoveMember (index);
				Animal dyingAnimal = toDie.GetComponent<Animal> ();
				Debug.Log ("Billy the " + dyingAnimal.SpeciesTrait.name + " has died");

				string remaining = "";
				foreach (GameObject partyMember in party.GetMembers()) {
					Animal a = partyMember.GetComponent<Animal> ();
					remaining += a.SpeciesTrait.name + ", ";
				}
				Debug.Log ("remaining: " + remaining);
			} else {
				Debug.Log ("All of your friends are already dead.  No one loves you.");
				GameManager.Instance.GoHome ();
			}
		}
	}
}

