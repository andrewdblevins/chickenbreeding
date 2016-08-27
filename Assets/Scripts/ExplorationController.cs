using UnityEngine;
using System.Collections.Generic;

public class ExplorationController : MonoBehaviour
{
    public enum State { Start, EncounterEvent, ResolveEvent, Continue};

    public State state = State.Start;

    public ExplorationEvent currentEvent;

    public List<Animal> party;

    //new exploration event

    //resolve exploration event
    //penaltiy or reward

    //turn back or continue

    //consume food


    void Start()
    {
        //party = List<Animal>() { }
    }

    void Update()
    {
        switch (state)
        {
            case State.Start:
            case State.Continue:
                currentEvent = ExplorationEventFactory.createEvent();
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
                } else if (Input.GetKeyUp(KeyCode.Alpha2))
                {
                    attempt(1);
                } else if (Input.GetKeyUp(KeyCode.Alpha3))
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
            bool pass = option.attempt(party);
            if (pass)
            {
                print("You win");
                party.AddRange(option.reward);
            } else
            {
                print("You lose");
                int index = Random.Range(1, party.Count);
                print("Billy the " + party[index].speciesTrait.name + " has died");
                party.RemoveAt(index);
            }

            state = State.ResolveEvent;
        }
    }

}
