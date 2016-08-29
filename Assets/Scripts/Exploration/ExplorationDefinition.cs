using System;
using System.Collections.Generic;

public class ExplorationDefinition
{
	private List<ExplorationCriteria> possibleExplorations;

	//Currently unused.
	string description;
	    
	public ExplorationDefinition (string description, List<ExplorationCriteria> possibleExplorations)
	{
		fakeConstructor (description, possibleExplorations);
	}

	public ExplorationDefinition (List<ExplorationCriteria> possibleExplorations)
	{
		fakeConstructor ("", possibleExplorations);
	}

	//Some stupid Unity crap
	public ExplorationDefinition() {}

	public void fakeConstructor(string description, List<ExplorationCriteria> possibleExplorations)
	{
		this.description = description;
		this.possibleExplorations = possibleExplorations;
	}

	public Reward explore(Party party, int roll) {
		foreach (ExplorationCriteria ec in possibleExplorations) {
			if (ec.attempt (party, roll)) {
				return ec.getReward (party);
			}
		}
		return null;
	}
}

