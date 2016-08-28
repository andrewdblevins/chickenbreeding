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


    void Update()
    {
        switch (state)
        {
            case State.Start:
                GameObject obj = new GameObject();
                Animal wolfAnimal = obj.AddComponent<Animal>();
                wolfAnimal.Initialize(SpeciesFactory.createWolf(), SizeFactory.createMidsized());
                Animal rabbitAnimal = obj.AddComponent<Animal>();
                rabbitAnimal.Initialize(SpeciesFactory.createRabbit(), SizeFactory.createTiny());
                Animal chickenAnimal = obj.AddComponent<Animal>();
                chickenAnimal.Initialize(SpeciesFactory.createChicken(), SizeFactory.createTiny());

                party = new List<Animal>() {
                    wolfAnimal,
                    rabbitAnimal,
                    chickenAnimal
                };
                string remaining = "";
                foreach (Animal a in party)
                {
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
            print("you chose to " + option.description);
            bool pass = option.attempt(party);
            if (pass)
            {
                print("You win");
                party.AddRange(option.reward);
            } else
            {
                print("You lose");
                if (party.Count > 0)
                {
                    int index = Random.Range(0, party.Count);
                    print("One of your " + party.Count + " animimals will die, the " + index + "th one");
                    print("Billy the " + party[index].speciesTrait.name + " has died");
                    party.RemoveAt(index);

                    string remaining = "";
                    foreach (Animal a in party)
                    {
                        remaining += a.speciesTrait.name + ", ";
                    }
                    print("remaining: " + remaining);
                } else
                {
                    print("All of your friends are already dead.  No one loves you.");
                }
            }

            state = State.ResolveEvent;
        }
    }

}
