namespace PracticeProject
{
    public class Animals
    {
        private string[] names = new string[20];
        public string this[int index]
        {
            get { return names[index]; }
            set { names[index] = value; }
        }
    }
}
