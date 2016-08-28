using UnityEngine;
using System.Collections;

public class ExploreState : BaseState {
    public enum State { Start, EncounterEvent, ResolveEvent, Continue };

    public State state = State.Start;

    public ExplorationEvent currentEvent;

    // TODO initialize this using start exploration, not by creating a thing here.
    WorldState worldState = new WorldState();

    //new exploration event

    //resolve exploration event
    //penaltiy or reward

    //turn back or continue

    //consume food

    public void StartExploration(WorldState worldState)
    {
        this.worldState = worldState;
    }

    public override void Step()
    {
        print("Explore state step");
        switch (state)
        {
            case State.Start:
                string remaining = "";
                foreach (GameObject partyMember in worldState.GetParty().GetMembers())
                {
                    Animal a = partyMember.GetComponent<Animal>();
                    remaining += a.speciesTrait.name + ", ";
                }
                print("party: " + remaining);
                state = State.Continue;
                break;
            case State.Continue:
                currentEvent = ExplorationEventFactory.createEvent();
                print("=============================================");
                print(currentEvent.description);
                for (int i = 0; i < currentEvent.options.Count; i++)
                {
                    print("   press " + (i + 1) + " to " + currentEvent.options[i].description);
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
            case State.ResolveEvent:
                state = State.Continue;
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
            print("you chose to " + option.description);
            bool pass = option.attempt(worldState.GetParty());
            if (pass)
            {
                print("You win");
                worldState.GetInventory().AddAll(option.reward);
            }
            else
            {
                print("You lose");
                if (worldState.GetParty().Size() > 0)
                {
                    Party party = worldState.GetParty();
                    int index = Random.Range(0, party.Size());
                    print("One of your " + party.Size() + " animimals will die, the " + index + "th one");
                    GameObject toDie = party.RemoveMember(index);
                    Animal dyingAnimal = toDie.GetComponent<Animal>();
                    print("Billy the " + dyingAnimal.speciesTrait.name + " has died");

                    string remaining = "";
                    foreach (GameObject partyMember in party.GetMembers())
                    {
                        Animal a = partyMember.GetComponent<Animal>();
                        remaining += a.speciesTrait.name + ", ";
                    }
                    print("remaining: " + remaining);
                }
                else
                {
                    print("All of your friends are already dead.  No one loves you.");
                }
            }

            state = State.ResolveEvent;
        }
    }
}
