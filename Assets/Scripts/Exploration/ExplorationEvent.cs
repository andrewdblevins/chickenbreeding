﻿using UnityEngine;
using System.Collections.Generic;

public class ExplorationEvent {

    public class Option
    {
        public string description;

        public string attribute;

        public int passingScore;

        public List<BaseTrait> specialRequirements;

        //TODO: penalty datatype?

        public List<AnimalDef> reward;

        public Option(string description, string attribute, int passingScore, List<AnimalDef> reward, List<BaseTrait> specialRequirements)
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

    public List<Option> options;


}
