using System;
using System.Collections.Generic;

public class ExplorationDefinition
{
	private List<ExplorationCriteria> possibleExplorations;
	string description;
	    
	public ExplorationDefinition (string description, List<ExplorationCriteria> possibleExplorations)
	{
		fakeConstructor (description, possibleExplorations);
	}

	//Some stupid Unity crap
	public ExplorationDefinition() {}

	public void fakeConstructor(string description, List<ExplorationCriteria> possibleExplorations)
	{
		this.description = description;
		this.possibleExplorations = possibleExplorations;
	}

	public Reward explore(Party party, int score) {
		foreach (ExplorationCriteria ec in possibleExplorations) {
			if (ec.attempt (party, score)) {
				return ec.grantReward (party);
			}
		}
		return null;
	}
}

