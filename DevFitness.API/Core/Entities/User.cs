using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFitness.API.Core.Entities
{
    public class User: BaseEntity
    {
        /*Construtor - Atalho para gerar construtor Alt+Enter*/
        public User(string fullName, decimal heigth, decimal weight, DateTime birthDate) : base()
        {
            FullName = fullName;
            Heigth = heigth;
            Weight = weight;
            BirthDate = birthDate;

            Meals = new List<Meal>();
        }

        public string FullName { get; private set; }
        public decimal Heigth { get; private set; }
        public decimal Weight { get; private set; }
        public DateTime BirthDate { get; private set; }

        public IEnumerable<Meal> Meals { get; private set; }

        public void Update(decimal height, decimal weight)
        {
            Heigth = height;
            Weight = weight;
        }

    }
}
