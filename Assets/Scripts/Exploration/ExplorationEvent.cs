﻿using UnityEngine;
using System.Collections.Generic;

public class ExplorationEvent {

    public class Option
    {
        public string description;

        public string attribute;

        public int passingScore;

        public List<string> specialRequirements; //stringly typed required traits

        //TODO: penalty datatype?

        public List<Animal> reward;

        public Option(string description, string attribute, int passingScore, List<Animal> reward, List<string> specialRequirements)
        {
            this.description = description;
            this.attribute = attribute;
            this.passingScore = passingScore;
            this.reward = reward;
            this.specialRequirements = specialRequirements;
        }

        public bool attempt(Party party)
        {
            int score = party.GetAttributeScore(attribute);
            int roll = Random.Range(1, 7);
            Debug.Log("you have a score of " + score + " + " + roll + " and need " + passingScore + " to win");
            score += roll;
            return score >= passingScore;
        }
    }

    public string description;

    public EventCondition precondition;

    public List<Option> options;

    public ExplorationEvent()
    {
        precondition = EventCondition.alwaysTrue();
    }
}
