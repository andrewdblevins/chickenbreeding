using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class OptionButtonBehavior : MonoBehaviour {

	public int optionNum;
	public ExploreState state;

    public void myOnClick()
    {
        state.attempt(optionNum);
    }
		
}
