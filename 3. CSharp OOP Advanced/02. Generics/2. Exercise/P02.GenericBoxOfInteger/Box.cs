namespace P02.GenericBoxOfInteger
{
    public class Box<T>
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            string output = $"{this.value.GetType().FullName}: {this.value}";

            return output;
        }
    }
}