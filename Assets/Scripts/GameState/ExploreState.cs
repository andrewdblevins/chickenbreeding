using UnityEngine;
using System.Collections;

public class ExploreState : BaseState {
    public enum State { Start, EncounterEvent, AfterEvent, Continue, GoingHome };

    public State state = State.Start;

    public ExplorationEvent currentEvent;

    WorldState worldState;

    //new exploration event

    //resolve exploration event
    //penaltiy or reward

    //turn back or continue

    //consume food

    public void StartExploration(WorldState worldState)
    {
        Debug.Log("starting exploration");
        this.worldState = worldState;
        state = State.Start;
    }

    public override void Step()
    {
        switch (state)
        {
            case State.Start:
                string remaining = "";
                foreach (GameObject partyMember in worldState.GetParty().GetMembers())
                {
                    Animal a = partyMember.GetComponent<Animal>();
                    remaining += a.SpeciesTrait.name + ", ";
                }
                Debug.Log("party: " + remaining);
                state = State.Continue;
                break;
            case State.Continue:
                currentEvent = RiverlandsExplorationEventFactory.GetInstance().getEvent(worldState);
                for (int i = 0; i < currentEvent.options.Count; i++)
                {
                    Debug.Log("   press " + (i + 1) + " to " + currentEvent.options[i].description);
                }
				ExplorePanelBehavior.Instance.Draw (currentEvent,this);
                state = State.EncounterEvent;
                break;
            case State.EncounterEvent:
                if (Input.GetKeyUp(KeyCode.Alpha1))
                {
                    attempt(0);
                }
                else if (Input.GetKeyUp(KeyCode.Alpha2))
                {
                    attempt(1);
                }
                else if (Input.GetKeyUp(KeyCode.Alpha3))
                {
                    attempt(2);
                }
                break;
            case State.AfterEvent:
                //Debug.Log("Should display results now");
                //ExplorePanelBehavior.Instance.Results(currentEvent, this);
                break;
            case State.GoingHome:
                Debug.Log("Out of food, time to go home");
                GameManager.Instance.GoHome();
                break;
            default:
                break;
        }
    }

    public void goHome()
    {
        GameManager.Instance.GoHome();
    }

    public void attempt(int choice)
    {
		ExplorePanelBehavior.Instance.Close ();
        if (state == State.AfterEvent)
        {
            switch (choice)
            {
                case 0:
                    GameManager.Instance.GoHome();
                    break;
                case 1:
                    int partyFoodCost = worldState.GetParty().GetFoodRequirement();
                    state = worldState.GetInventory().subtractFood(partyFoodCost) ? State.Continue : State.GoingHome;
                    break;
                default:
                    Debug.Log("Nope");
                    break;
            }
        }

        if (state == State.EncounterEvent && currentEvent != null && choice < currentEvent.options.Count)
        {
            ExplorationEvent.Option option = currentEvent.options[choice];
            Debug.Log("you chose to " + option.description);
			Reward reward = option.attempt(worldState.GetParty());

            ExplorePanelBehavior.Instance.Results(reward, this);
            state = State.AfterEvent;
        }
    }
}
