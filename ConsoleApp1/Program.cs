using ExtensionMethods;

namespace PracticeProject
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // anonymous function
            var animals = new Animals();

            animals[0] = "Cat using indexer";
            animals[1] = "Dog using indexer";
            Console.WriteLine(animals[0]);


            var anonType = new { Name = "Alligator", Age = 23, Size = new { Height = 23, Width = 23, Weight = 150 } };

            string str = $"Name = {anonType.Name} \n" +
                $"Age = {anonType.Age} \n" +
                $"Height = {anonType.Size.Height} \n" +
                $"Width  = {anonType.Size.Width} \n" +
                $"Weight = {anonType.Size.Weight}";

            Console.WriteLine(str);



            // LINQ

            string[] games = { "Call of Duty", "Far Cry", "Deus EX", "Prince of Persia", "GTA" };

            var selectedGames = from g in games where g.Length> 10 orderby g ascending select g;

            foreach(var game in selectedGames)
            {
                Console.WriteLine(game);
            }

            Car[] cars = new[]
            {
                new Car{Name = "Veyron Grand Sport Vitesse", Brand = "Bugatti", TopSpeedKPH = 408 , PriceUSD = 2500000 },
                new Car{Name = "Centodieci", Brand = "Bugatti", TopSpeedKPH = 380 , PriceUSD = 9000000 },
                new Car{Name = "Ferrari 812 Superfast", Brand = "Ferrari", TopSpeedKPH = 340 , PriceUSD = 3400000 },
                new Car{Name = "Aventador S", Brand = "Lamborghini", TopSpeedKPH = 350 , PriceUSD = 4200000 },
                new Car{Name = "Ford GT", Brand = "Ford", TopSpeedKPH = 347 , PriceUSD = 500000 }
            };

            var topCars = from car in cars where car.TopSpeedKPH >= 350 orderby car.PriceUSD descending select car;

            foreach(Car car in topCars)
            {
                Console.WriteLine(car);
            }


            // Extension method

            int k = 1;
            Console.WriteLine(k.IsGreatarThanZero().ToString());

            str = "The grass was greener";
            Console.WriteLine(str.FillSpaceWithStar());

            str = "Shakil";
            Console.WriteLine(str.GetYourCountry("Bangladesh"));



            // Operator Overload

            Point P1 = new Point(3, 7, 8);
            Point P2 = new Point(3, 7, 8);

            Console.WriteLine((P1 == P2).ToString());

            P2++;
            P1--;

            Console.WriteLine((P1 == P2).ToString());
            Console.WriteLine(P1.ToString());
            Console.WriteLine(P2.ToString());

        }
    }
}