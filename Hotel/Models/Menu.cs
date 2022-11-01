using System;
using System.Collections.Generic;

#nullable disable

namespace Hotel.Models
{
    public partial class Menu
    {
        public Menu()
        {
            OrderiringMealInRooms = new HashSet<OrderiringMealInRoom>();
            Restaurants = new HashSet<Restaurant>();
        }

        public int IdMenu { get; set; }
        public string NameOfTheDish { get; set; }
        public int Protein { get; set; }
        public int Fats { get; set; }
        public int Carbohydrates { get; set; }
        public int Price { get; set; }
        public bool Deleting { get; set; }

        public virtual ICollection<OrderiringMealInRoom> OrderiringMealInRooms { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
