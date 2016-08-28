using UnityEngine;
using System.Collections.Generic;

public class EventCondition {

    public delegate float Source(ExplorationController ec);

    Source sourceHandler;

    public delegate bool Comparator(float source, float threshold);

    Comparator comparatorHnadler;

    public float threshold;

	public bool check(ExplorationController ec)
    {
        return comparatorHnadler(sourceHandler(ec), threshold);
    }

    public static bool atLeast(float source, float threshold)
    {
        return source >= threshold;
    }

    public static float numWolvesInParty(ExplorationController ec)
    {
        return 1;
    }
}
