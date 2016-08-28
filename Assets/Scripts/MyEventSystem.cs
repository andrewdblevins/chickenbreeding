using UnityEngine;
using System.Collections;

public static class MyEventSystem  {

    public delegate void SeasonAdvance();
    public static event SeasonAdvance OnSeasonAdvance;

    public static void AdvanceSeasons()
    {
        OnSeasonAdvance();
    }
}
