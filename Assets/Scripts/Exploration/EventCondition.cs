using UnityEngine;
using System.Collections.Generic;

public class EventCondition {

    public delegate float Source(WorldState ws);

    Source sourceHandler;

    public delegate bool Comparator(float source, float threshold);

    Comparator comparatorHandler;

    public float threshold;

    public EventCondition(Source s, Comparator c, float t)
    {
        sourceHandler = s;
        comparatorHandler = c;
        threshold = t;
    }

	public bool check(WorldState ws)
    {
        return comparatorHandler(sourceHandler(ws), threshold);
    }

    public static bool atLeast(float source, float threshold)
    {
        return source >= threshold;
    }

    public static float numWolvesInParty(WorldState ws)
    {
        return 1;
    }
		
	public static float numKeenEyes(WorldState ws){
		BaseTrait trait = TraitFactory.createKeenEyes ();

		float c = 0;
		foreach(GameObject partyMember in ws.GetParty().GetMembers()){
			Animal animal = partyMember.GetComponent<Animal> ();
			if (animal != null) {
				if (animal.Traits.Contains (trait)) {
					c++;
				}
			}
		}
		return c;
	}

    public static EventCondition alwaysTrue()
    {
        return new EventCondition(numWolvesInParty, atLeast, 0);
    }
}
