using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeTracker.Models
{
    public enum CoffeeType { Espresso,Macchiato,Ristretto,Latte,Cappuccino};
    public enum CoffeeSize { Small , Medium, Large };

    public class CoffeeItems
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string ProfileId { get; set; }

         public DateTime CreationDate { get ; set; }

        public CoffeeType CoffeeType { get; set; }

        public CoffeeSize CoffeeSize { get; set; }



    }
}
