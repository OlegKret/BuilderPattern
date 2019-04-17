using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house
{
    class Program
    {
        public interface IHouse
        {
            int House(int side);
            string GetDescription();
            double GetCost();
        }

        public class MyHouse:IHouse
        {
            public double GetCost()
            {
                return 50.0;
            }

            public string GetDescription()
            {
                return "Bad House";
            }

           
            public int House(int side)
            {
                for(int row=1; row<=5;row++)
                {
                    for(int col=1; col<=5;col++)
                    {
                        if (col <= row)
                            Console.Write('*');
                        else
                            Console.Write('#');

                    }
                     Console.WriteLine();
                   
                }
                return 0;
            }
           
        }
        public class DeluxeHouse : IHouse
        {
            public double GetCost()
            {
                return 150.0; 
            }

            public string GetDescription()
            {
                return "Good House";
            }

            public int House(int side)
            {
                for (int row = 1; row <= 15; row++)
                {
                    for (int col = 1; col <= 15; col++)
                    {
                        if (col <= row)
                            Console.Write('*');
                        else
                            Console.Write('#');

                    }
                    Console.WriteLine();
                }
                return 0;
            }
        }

        public class LuxaryHouse : IHouse
        {
            public double GetCost()
            {
                return 250.0;
            }

            public string GetDescription()
            {
                return "Very Good House";
            }

            public int House(int side)
            {
                for (int row = 1; row <= 25; row++)
                {
                    for (int col = 1; col <= 25; col++)
                    {
                        if (col <= row)
                            Console.Write('*');
                        else
                            Console.Write('#');

                    }
                    Console.WriteLine();
                }
                return 0;
            }
        }

        public abstract class HouseAccessoriesDecorator : IHouse
        {
            private IHouse _house;
            public HouseAccessoriesDecorator(IHouse ahouse)
            {
                this._house = ahouse;
            }
            public virtual double GetCost()
            {
                return this._house.GetCost();
            }
            public virtual string GetDescription()
            {
                return this._house.GetDescription();
            }
            public virtual int House(int side)
            {
               return this._house.House(side);
            }
        }

        public class BasicAccessories: HouseAccessoriesDecorator
        {
            public BasicAccessories(IHouse aHouse) : base(aHouse) { }

            public override double GetCost()
            {
                return base.GetCost()+17.0;
            }
            public override string GetDescription()
            {
                return base.GetDescription()+", Basic Accesories Package";
            }
            public override int House(int side)
            {
               return base.House(side+5);
            }
        }

        public class AdvancedAccesories:HouseAccessoriesDecorator
        {
            public AdvancedAccesories(IHouse aHouse):base(aHouse) { }
            public override double GetCost()
            {
                return base.GetCost()+300.0;
            }
            public override string GetDescription()
            {
                return base.GetDescription()+",Advanced Accessories Package";
            }
            public override int House(int side)
            {
               return base.House(side+15);
            }
        }

        static void Main(string[] args)
        {
            //IHouse objHouse = new MyHouse();
            //HouseAccessoriesDecorator objAccessoriesDecorator = new BasicAccessories(objHouse);
            //objAccessoriesDecorator = new AdvancedAccesories(objAccessoriesDecorator);
            //Console.Write("House Details: " + objAccessoriesDecorator.GetDescription());
            //Console.WriteLine("\n\n");
            //Console.Write("House Price: " + objAccessoriesDecorator.GetCost());
            //Console.WriteLine("\n\n");
            //Console.Write("House Obj: {0}", objAccessoriesDecorator.House(30));

            IHouse objHouse = new LuxaryHouse();
            HouseAccessoriesDecorator objAccessoriesDecorator = new BasicAccessories(objHouse);
            objAccessoriesDecorator = new AdvancedAccesories(objAccessoriesDecorator);
            Console.Write("House Details: " + objAccessoriesDecorator.GetDescription());
            Console.WriteLine("\n\n");
            Console.Write("House Price: " + objAccessoriesDecorator.GetCost());
            Console.WriteLine("\n\n");
            Console.Write("House Obj: {0}", objAccessoriesDecorator.House(30));
            Console.ReadLine();
        }
    }
}
