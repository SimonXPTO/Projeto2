using System;
using MealPlanner.Model;

namespace MealPlanner.Model
{
    /// <summary>
    /// Default implementation of IIngredient.
    /// </summary>
    public class Ingredient : IIngredient
    {
        public string Name { get; }
        public string Type { get; }

        public Ingredient(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public override bool Equals(object obj)
        {
            return obj is IIngredient other && Equals(other);
        }

        public bool Equals(IIngredient other)
        {
            return other != null && string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase) && string.Equals(Type, other.Type, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return (Name?.ToLowerInvariant() + Type?.ToLowerInvariant()).GetHashCode();
        }
    }
}
