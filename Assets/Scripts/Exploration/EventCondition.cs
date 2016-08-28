using UnityEngine;
using System.Collections.Generic;

public class EventCondition {

    public delegate float source(WorldState ec);


	public bool check(WorldState ec)
    {
        return true;
    }
}
