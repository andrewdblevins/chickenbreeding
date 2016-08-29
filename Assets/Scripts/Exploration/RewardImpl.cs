using System;
using System.Collections.Generic;
using UnityEngine;

public static class RewardImpl
{

	public class DoNothingReward : Reward {
		string message;

		public DoNothingReward(string message = "Nothing interesting happens.") {
			this.message = message;
		}

		public override string ToString()
		{
			return message;
		}

		public void grant(Party party) {
			//Do nothing
		}

		public string RewardText(){
			return "Nothing Happens";
		}
	}

	public class AnimalReward : Reward {
		private List<AnimalDef> animals = new List<AnimalDef>();
        protected string message;

        public AnimalReward(AnimalDef animal) {
			animals.Add(animal);
		}

        public AnimalReward(AnimalDef animal, string message)
        {
            animals.Add(animal);
            this.message = message;
        }

        public AnimalReward(List<AnimalDef> animals) {
			animals.ForEach(this.animals.Add);
		}

        public AnimalReward(List<AnimalDef> animals, string message)
        {
            animals.ForEach(this.animals.Add);
            this.message = message;
        }

        public void grant(Party party) {
			GameManager.Instance.worldState.GetInventory().AddAll(animals);
		}

        public override string ToString()
        {
            if (message != null)
            {
                return message;
            } else if (animals.Count > 0)
            {
                return "Success.  You have captured " + animals.Count + " " + animals[0].SpeciesTrait.name;
            }
            return "Success. All of your animals survived";
        }

		public string RewardText(){
			return "Good Stuff Happens";
		}
	}

	public class FoodReward : Reward
	{

		protected int foodCount;
        protected string message;

        public FoodReward (int foodCount)
		{
			this.foodCount = foodCount;
		}

        public FoodReward(int foodCount, string message)
        {
            this.foodCount = foodCount;
            this.message = message;
        }

        public void grant (Party party)
		{
			if (this.foodCount > 0) {
				GameManager.Instance.AddFood (this.foodCount);
			} else {
				GameManager.Instance.worldState.GetInventory ().subtractFood (-this.foodCount);
			}
		}

        public override string ToString()
        {
            if (message == null) return "The blood of your enemies is delicous.  You gained " + foodCount + " food";
            return message;
        }

		public string RewardText(){
			return "Good Stuff Happens";
		}
    }

	public class FoodPenalty: FoodReward
	{
		public FoodPenalty (int foodCount) : base (-foodCount)
		{
		}

        public FoodPenalty(int foodCount, string message) : base(-foodCount, message)
        {
        }

        public override string ToString()
        {
            if (message == null) return "You lost " + foodCount + " food";
            return message;
        }

		public string RewardText(){
			return "Bad Stuff Happens";;
		}
    }

	public class RandomAnimalPenalty : Reward
	{
        private string resultText;
        private string message;

		public RandomAnimalPenalty ()
		{
		}

        public RandomAnimalPenalty(string message)
        {
            this.message = message;
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

                resultText = "Billy the " + dyingAnimal.SpeciesTrait.name + " has died.";
            } else {
				Debug.Log ("All of your friends are already dead.  No one loves you.");
                resultText = "All of your friends are already dead.  No one loves you.";
                GameManager.Instance.GoHome ();
			}
		}

        public override string ToString()
        {
            if (message != null) return message + "  " + resultText == null ? "" : resultText;
            return resultText == null ? "One of your animals died" : resultText;
        }

		public string RewardText(){
			return "Bad Stuff Happens";;
		}
    }
}

