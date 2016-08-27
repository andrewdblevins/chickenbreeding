using UnityEngine;
using System.Collections.Generic;

public class ExplorationEvent {

    public class Option
    {
        public string description;

        public string attribute;

        public int passingScore;

        public List<BaseTrait> specialRequirements;

        //TODO: penalty datatype?

        public List<Animal> reward;

        public Option(string description, string attribute, int passingScore, List<Animal> reward, List<BaseTrait> specialRequirements)
        {
            this.description = description;
            this.attribute = attribute;
            this.passingScore = passingScore;
            this.reward = reward;
            this.specialRequirements = specialRequirements;
        }

        public bool attempt(List<Animal> party)
        {
            int score = Random.Range(1, 7);
            foreach (Animal a in party)
            {
                score += a.GetAttributeScore(attribute);
            }
            return score >= passingScore;
        }
    }

    public string description;

    public List<Option> options;


}
