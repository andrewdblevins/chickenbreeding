using UnityEngine;
using System.Collections.Generic;

public class ExplorationEvent {

	public class Option //: BooleanExplorationDefinition
    {
        public string description;

//        public string attribute;

//        public int passingScore;

        public List<string> specialRequirements; //stringly typed required traits

        //TODO: penalty datatype?

//		public List<ExplorationOption> possibleResults;

//        public List<AnimalDef> reward;

		ExplorationDefinition ed;

		//TODO: Merge this with Exploration definition
        public Option(string description, string attribute, int passingScore, List<AnimalDef> reward, List<string> specialRequirements)
        {
            this.description = description;
//            this.attribute = attribute;
//            this.passingScore = passingScore;
//            this.reward = reward;
//            this.specialRequirements = specialRequirements;

			Reward passReward = new RewardImpl.AnimalReward(reward);
			Reward failReward = new RewardImpl.RandomAnimalPenalty();

			ed = new BooleanExplorationDefinition(description, attribute, passingScore, passReward, failReward);
        }

		//TODO: Merge this with Exploration definition
		public Option(string description, string attribute, int passingScore, Reward passReward, Reward failReward)
		{
			this.description = description;

			ed = new BooleanExplorationDefinition(description, attribute, passingScore, passReward, failReward);
		}

		public Option(string description, List<ExplorationCriteria> explorationCriteria) {
			this.description = description;

			ed = new ExplorationDefinition(description,explorationCriteria);
		}

		public Option(string description, ExplorationDefinition expd) {
			this.description = description;

			ed = expd;
		}

		//TODO: This is hacky way to estimate probability; do better
//		public float probability(Party party) {
//			int m = 50;
//			int cntSuccess = 0;
//			int cntFailure = 0;
//			foreach (var i in System.Linq.Enumerable.Range(0, m)) {
//				if (attempt (party)) {
//					cntSuccess++;
//				} else {
//					cntFailure++;
//				}
//			}
//			return (float)cntSuccess / (float)(cntSuccess + cntFailure);
//		}

		public Reward attempt(Party party)
        {
            //int score = party.GetAttributeScore(attribute);
            int roll = Random.Range(1, 7);
            //Debug.Log("you have a score of " + score + " + " + roll + " and need " + passingScore + " to win");
//            score += roll;
//            return score >= passingScore;
			return ed.explore(party, roll);
        }

//		public bool attempt(Party party)
//		{
//		}
    }

    public string description;

    public EventCondition precondition;

    public List<Option> options;

    public ExplorationEvent()
    {
        precondition = EventCondition.alwaysTrue();
    }
}
