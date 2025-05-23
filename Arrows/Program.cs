﻿namespace Arrows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What arrow do you want?");
            Console.WriteLine("1 - Elite Arrow");
            Console.WriteLine("2 - Beginner Arrow");
            Console.WriteLine("3 - Marksman Arrow");
            Console.WriteLine("4 - Custom Arrow");

            string choice = Console.ReadLine();

            Arrow arrow = choice switch
            {
                "1" => Arrow.CreateEliteArrow(),
                "2" => Arrow.CreateBeginnerArrow(),
                "3" => Arrow.CreateMarksmanArrow(),
                _ => CreateCustomArrow(),
            };

            Console.WriteLine($"That arrow costs {arrow.Cost} gold.");

            Arrow CreateCustomArrow()
            {
                Arrowhead arrowhead = GetArrowheadType();
                Fletching fletching = GetFletchingType();
                float length = GetLength();

                return new Arrow(arrowhead, fletching, length);
            }

            Arrowhead GetArrowheadType()
            {
                Console.Write("Arrowhead type (steel, wood, obsidian): ");
                string input = Console.ReadLine();
                return input switch
                {
                    "steel" => Arrowhead.Steel,
                    "wood" => Arrowhead.Wood,
                    "obsidian" => Arrowhead.Obsidian
                };
            }

            Fletching GetFletchingType()
            {
                Console.Write("Fletching type (plastic, turkey feather, goose feather): ");
                string input = Console.ReadLine();
                return input switch
                {
                    "plastic" => Fletching.Plastic,
                    "turkey feather" => Fletching.TurkeyFeathers,
                    "goose feather" => Fletching.GooseFeathers
                };
            }

            float GetLength()
            {
                float length = 0;

                while (length < 60 || length > 100)
                {
                    Console.Write("Arrow length (between 60 and 100): ");
                    length = Convert.ToSingle(Console.ReadLine());
                }

                return length;
            }
        }
    }

    class Arrow
    {
        private Arrowhead Arrowhead { get; }
        private Fletching Fletching { get; }
        private float Length { get; }

        // Constructor
        public Arrow(Arrowhead arrowhead, Fletching fletching, float length)
        {
            Arrowhead = arrowhead;
            Fletching = fletching;
            Length = length;
        }

        public static Arrow CreateEliteArrow() => new Arrow(Arrowhead.Steel, Fletching.Plastic, 95f);

        public static Arrow CreateBeginnerArrow() => new Arrow(Arrowhead.Wood, Fletching.GooseFeathers, 75f);

        public static Arrow CreateMarksmanArrow() => new Arrow(Arrowhead.Steel, Fletching.Plastic, 65f);

        public float Cost
        {
            get // Converted the GetCost method to a Cost property with a getter.
            { 
                float arrowheadCost = Arrowhead switch
                {
                    Arrowhead.Steel => 10,
                    Arrowhead.Wood => 3,
                    Arrowhead.Obsidian => 5,
                };

                float fletchingCost = Fletching switch
                {
                    Fletching.Plastic => 10,
                    Fletching.TurkeyFeathers => 5,
                    Fletching.GooseFeathers => 3,
                };

                float lengthCost = Length * 0.05f;

                return arrowheadCost + fletchingCost + lengthCost;
            }
        }
    }

    enum Arrowhead { Steel, Wood, Obsidian }
    enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }
}
