using System.Xml.Serialization;

namespace PracticeProject
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // testing thread
            Thread mainThread = Thread.CurrentThread;
            mainThread.Name = "Main Thread";

            Thread thread1 = new Thread(() => UpTimer("Timer1"));
            Thread thread2 = new Thread(() => DownTimer("Timer2"));

            thread1.Start();
            thread2.Start();


            //testing file and folder

            string pathString = @"C:\Users\shakil\Desktop\Test\TestFolder";
            if (!Directory.Exists(pathString))
            {
                Directory.CreateDirectory(pathString);
            }

            string filePath = @"C:\Users\shakil\Desktop\Test\TestFolder\file.txt";

            FileStream fileStream = File.Create(filePath);

            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.WriteLine("Hello there!");
                writer.WriteLine("Good Evening!");
            }
            fileStream.Close();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Console.WriteLine(line);
                }
            }
            Console.WriteLine();

            //reading asynchronously
            string contents = await ReadFileAsync(filePath);

            Console.WriteLine(contents);

            // testing serialization

            List<Animal> animals = new List<Animal>
            {
                new Animal("Dog", 4),
                new Animal("Penguin", 2),
                new Animal("Kangaroo", 2),
                new Animal("DolPhin", 0)
            };

            using (FileStream fs = new FileStream(@"C:\Users\shakil\Desktop\Test\Practice\animals.xml",
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer1 = new XmlSerializer(typeof(List<Animal>));
                serializer1.Serialize(fs, animals);
            }

            animals = null;

            XmlSerializer serializer = new XmlSerializer(typeof(List<Animal>));

            using (FileStream fs = File.OpenRead(@"C:\Users\shakil\Desktop\Test\Practice\animals.xml"))
            {
                animals = (List<Animal>)serializer.Deserialize(fs);
            }

            foreach (Animal a in animals)
            {
                Console.WriteLine(a.ToString());
            }

            Console.WriteLine(mainThread.Name + " is completed.");
        }

        public static void UpTimer(string timerName)
        {
            Console.WriteLine(timerName);
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i + " secondes");
                Thread.Sleep(1000);
            }
            Console.WriteLine(timerName + " is completed.");
        }

        public static void DownTimer(string timerName)
        {
            Console.WriteLine(timerName);
            for(int i = 10; i>=1; i--)
            {
                Console.WriteLine(i + " secondes");
                Thread.Sleep(1000);
            }
            Console.WriteLine(timerName + " is completed.");
        }

        static async Task<string> ReadFileAsync(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}