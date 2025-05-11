namespace Arrows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Arrow arrow = GetArrow();
            Console.WriteLine($"The arrow costs {arrow.Cost} gold.");

            Arrow GetArrow()
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

        public Arrow(Arrowhead arrowhead, Fletching fletching, float length)
        {
            Arrowhead = arrowhead;
            Fletching = fletching;
            Length = length;
        }

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
