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
                currentEvent = ExplorationEventFactory.createEvent();
                Debug.Log("=============================================");
                Debug.Log(currentEvent.description);
                for (int i = 0; i < currentEvent.options.Count; i++)
                {
                    Debug.Log("   press " + (i + 1) + " to " + currentEvent.options[i].description);
                }
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
                int partyFoodCost = worldState.GetParty().GetFoodRequirement();
                state = worldState.GetInventory().subtractFood(partyFoodCost) ? State.Continue : State.GoingHome;
                break;
            case State.GoingHome:
                Debug.Log("Time to go home");
                break;
            default:
                break;
        }
    }

    public void attempt(int choice)
    {
        if (state == State.EncounterEvent && currentEvent != null && choice < currentEvent.options.Count)
        {
            ExplorationEvent.Option option = currentEvent.options[choice];
            Debug.Log("you chose to " + option.description);
            bool pass = option.attempt(worldState.GetParty());
            if (pass)
            {
                Debug.Log("You win");
                worldState.GetInventory().AddAll(option.reward);
            }
            else
            {
                Debug.Log("You lose");
                if (worldState.GetParty().Size() > 0)
                {
                    Party party = worldState.GetParty();
                    int index = Random.Range(0, party.Size());
                    Debug.Log("One of your " + party.Size() + " animimals will die, the " + index + "th one");
                    GameObject toDie = party.RemoveMember(index);
                    Animal dyingAnimal = toDie.GetComponent<Animal>();
                    Debug.Log("Billy the " + dyingAnimal.SpeciesTrait.name + " has died");

                    string remaining = "";
                    foreach (GameObject partyMember in party.GetMembers())
                    {
                        Animal a = partyMember.GetComponent<Animal>();
                        remaining += a.SpeciesTrait.name + ", ";
                    }
                    Debug.Log("remaining: " + remaining);
                }
                else
                {
                    Debug.Log("All of your friends are already dead.  No one loves you.");
                    GameManager.Instance.GoHome();
                }
            }

            state = State.AfterEvent;
        }
    }
}
