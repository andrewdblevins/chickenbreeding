using System;
using System.Collections.Generic;

public class BooleanExplorationDefinition : ExplorationDefinition
{

	public BooleanExplorationDefinition(string definition, string attribute, int passingScore, 
		Reward passReward, Reward failReward)
	{
		fakeBooleanConstructor (definition, attribute, passingScore, passReward, failReward);
	}

	public BooleanExplorationDefinition() {
	}

	public void fakeBooleanConstructor (string definition, string attribute, int passingScore, 
		Reward passReward, Reward failReward) {

		ExplorationCriteria passExplorationCriteria = new ExplorationCriteria (attribute, passingScore, int.MaxValue, passReward);
		ExplorationCriteria failExplorationCriteria = new ExplorationCriteria (attribute, int.MinValue, passingScore, failReward);
		List<ExplorationCriteria> ec = new List<ExplorationCriteria> ();
		ec.Add (passExplorationCriteria);
		ec.Add (failExplorationCriteria);
		fakeConstructor (definition, ec);

	}

//	private List<T> listConstructor<T> (T first, T second) {
//		List<T> ec = new List<T> ();
//		ec.Add (first);
//		ec.Add (second);
//	}
}


