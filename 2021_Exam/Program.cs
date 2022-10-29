using System;
using System.Linq;
using System.Collections.Generic;

namespace Exam{
    class Program
    {
        class Company
        {
            // All the air conditioners
            private List<AC> conditioners;
            public string companyName;
            public Company(string companyName)
            {
                conditioners = new List<AC>();
                this.companyName = companyName;
                
            }
            // Add conditioner
            public void Add(AC conditioner)
            {
                conditioners.Add(conditioner);
            }

            // 1) Get total profit
            public double TotalIncome()
            {
                double total = 0;
                foreach(AC conditioner in conditioners)
                {
                    total += conditioner.getPrice();
                }
                return total;
            }
            // 2) Count of inverters
            public int InvertersCount()
            {
                int count = 0;
                foreach(AC conditioner in conditioners)
                {
                    if (conditioner is Inverter)
                    {
                        count++;
                    }
                }
                return count;
            }
            // 3) Average price of non inverters
            public double AveragePrice()
            {
                int count = 0;
                double total = 0;
                foreach(AC conditioner in conditioners)
                {
                    if (conditioner is not Inverter)
                    {
                        total += conditioner.getPrice();
                        count++;
                    } 
                }
                /*for(int x = 0; x < conditioners.Count; x++)
                {
                    if (conditioners[x] is not Inverter)
                    {
                        total += conditioners[x].getPrice();
                        count++;
                    }
                }*/
                return total / count;
            }
            
        }
        abstract class AC
        {
            public int BTU;
            public AC(int nBTU)
            {
                this.BTU = nBTU;
            }
            public abstract double getPrice();
        }
        class Inverter : AC
        {
            // Account for the constructor of the base class
            public Inverter(int BTU): base(BTU)
            {

            }
            public override double getPrice()
            {
                return BTU * 0.8 + 3000;
            }
        }
        class No_inverter: AC
        {
            
            public No_inverter(int BTU) : base(BTU)
            {

            }
            public override double getPrice()
            {
                return BTU * 0.8;
            }
        }
        
        static void Main(string[] args)
        {
            Company c = new Company("X");
            // Objects
            Inverter inverter1 = new Inverter(5000);
            Inverter inverter2 = new Inverter(9000);
            No_inverter no_Inverter1 = new No_inverter(1200);
            No_inverter no_Inverter2 = new No_inverter(5000);
            // Add air conditioners
            c.Add(inverter1);
            c.Add(no_Inverter2);
            c.Add(inverter2);
            c.Add(no_Inverter1);

            Console.WriteLine("Total profit: N$" + c.TotalIncome());
            Console.WriteLine("Inverters: " + c.InvertersCount());
            Console.WriteLine("Average: N$" + c.AveragePrice());
        }
    }
}