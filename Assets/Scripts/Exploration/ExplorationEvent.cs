using UnityEngine;
using System.Collections.Generic;

public class ExplorationEvent {

//	public class Probability {
//		public Reward reward;
//		public float probability;
//
//		public Probability(Reward reward, float probability) {
//			this.reward = reward;
//			this.probability = probability;
//		}
//	}

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
        public Option(string description, string attribute, int passingScore, Reward passReward, Reward failReward, List<string> specialRequirements)
        {
            this.description = description;
            //            this.attribute = attribute;
            //            this.passingScore = passingScore;
            //            this.reward = reward;
            this.specialRequirements = specialRequirements;

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
		public Dictionary<Reward, int> probability(Party party) {
			int m = 100;  //For percent calculations

			Dictionary<Reward, int> counts = new Dictionary<Reward, int> ();

			foreach (var i in System.Linq.Enumerable.Range(0, m)) {
				Reward r = attempt (party);
				if (counts.ContainsKey (r)) {
					counts [r] += 1;
				} else {
					counts [r] = 1;
				}
			}
			return counts;

		}

		public Reward attempt(Party party)
        {
            //int score = party.GetAttributeScore(attribute);
            int roll = Random.Range(1, 7);
            //Debug.Log("you have a score of " + score + " + " + roll + " and need " + passingScore + " to win");
//            score += roll;
//            return score >= passingScore;
			Reward r =  ed.explore(party, roll);
			return r;
        }

        public bool checkSpecialRequirements(Party party)
        {
            if (specialRequirements == null) return true;
            int requirementSatisfactionCount = 0;
            
            foreach (string trait in specialRequirements)
            {
                foreach (GameObject obj in party.GetMembers())
                {
                    Animal a = obj.GetComponent<Animal>();
                    if (a != null && a.hasTrait(trait))
                    {
                        requirementSatisfactionCount++;
                        break;
                    }
                }
            }
            return requirementSatisfactionCount >= specialRequirements.Count;

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
