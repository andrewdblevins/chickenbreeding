using System;
using System.Collections.Generic;

public class ExplorationCriteria
{
	int minScore;
	int maxScore;
	string attribute;
	List<BaseTrait> specialTraitRequirements;

	Reward reward;

	//TODO: move to requirements so that we can have preconditions
//	public class Requirements(int minScore, int maxScore, List<BaseTrait> specialTraitRequirements = null) {
//		
//	}
//
	public ExplorationCriteria (string attribute, int minScore, int maxScore, Reward reward, 
		List<BaseTrait> specialTraitRequirements = null)
	{
		this.attribute = attribute;
		this.minScore = minScore;
		this.maxScore = maxScore;
		this.reward = reward;
		this.specialTraitRequirements = specialTraitRequirements == null ?  new List<BaseTrait>() : specialTraitRequirements;
	}

	private bool meetsSpecialTraitRequirements(Party party) {
		foreach (BaseTrait rq in  this.specialTraitRequirements) {
			if (party.getTraits ().Contains (rq)) {
				return true;
			}
		}
		return false;
	}

	public bool attempt(Party party, int roll) {
		int score = party.GetAttributeScore (this.attribute) + roll;
		return (meetsSpecialTraitRequirements(party) || score >= minScore && score < maxScore);
	}

	//TODO: This is hacky way to estimate probability; do better
//	public float probability(Party party) {
//		int m = 50;
//		int cntSuccess = 0;
//		int cntFailure = 0;
//		foreach (var i in System.Linq.Enumerable.Range(0, m)) {
//			if (attempt (party)) {
//				cntSuccess++;
//			} else {
//				cntFailure++;
//			}
//		}
//		return (float)cntSuccess / (float)(cntSuccess + cntFailure);
//	}


	public Reward getReward(Party party) {
		return reward;
	}
}


