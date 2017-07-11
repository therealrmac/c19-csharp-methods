using System;
using System.Collections.Generic;

namespace expression_members
{
    class Program
    {
        static void Main(string[] args)
        {
           Bug spider= new Bug("Spidey", "Spider", new List<string>(){"Birds"}, new List<string>(){"fly"});
           Bug mantis= new Bug("Jeff", "Mantis", new List<string>(){"Birds"}, new List<string>(){"Aphids", "ants"});
           string mantisFood= mantis.PreyList();
           Console.WriteLine(mantis.FormalName );
           Console.WriteLine(mantis.PreyList()); 
           Console.WriteLine(mantis.PredatorList()); 
           Console.WriteLine(mantis.Eat("ants")); 

        }
    }
    public class Bug
{
    /*
        You can declare a typed public property, make it read-only,
        and initialize it with a default value all on the same
        line of code in C#. Readonly properties can be set in the
        class' constructors, but not by external code.
    */
    public string Name { get; } = "";
    public string Species { get; } = "";
    public ICollection<string> Predators { get; } = new List<string>();
    public ICollection<string> Prey { get; } = new List<string>();

    // Convert this readonly property to an expression member
    public string FormalName
    {
        get
        {
            return $"{this.Name} the {this.Species}";
        }
    }

    // Class constructor
    public Bug(string name, string species, List<string> predators, List<string> prey)
    {
        this.Name = name;
        this.Species = species;
        this.Predators = predators;
        this.Prey = prey;
    }

    // Convert this method to an expression member
    string commaDelimitedPrey;
    public string PreyList() => commaDelimitedPrey = string.Join(",", this.Prey) ;
    

    // Convert this method to an expression member
    string commaDelimitedPredators;
    public string PredatorList() => commaDelimitedPredators = string.Join(",", this.Predators);
    

    // Convert this to expression method (hint: use a C# ternary)
    public string Eat(string food) =>   this.Prey.Contains(food) ? $"{this.Name} ate the {food}.": $"{this.Name} is still hungry.";
  
}
}
