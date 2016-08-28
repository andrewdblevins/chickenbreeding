using UnityEngine;
using System.Collections.Generic;

public class EventCondition {

    public delegate float source(ExplorationController ec);


	public bool check(ExplorationController ec)
    {
        return true;
    }
}
