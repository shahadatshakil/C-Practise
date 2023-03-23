using System.Runtime.Serialization;

namespace PracticeProject
{
    [Serializable()]
    public class Animal: ISerializable
    {
        public string Name { get; set; }
        public int Legs { get; set; }

        public Animal() { }
        public Animal(string name, int legs)
        {
            Name = name;
            Legs = legs;
        }

        public override string ToString()
        {
            return $"{Name} has {Legs} legs!";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Legs", Legs);
        }

        //public Animal(SerializationInfo info, StreamingContext context)
        //{
        //    Name = (String)info.GetValue("Name", typeof(String));
        //    Legs = (int)info.GetValue("Legs", typeof(int));
        //}
    }
}
