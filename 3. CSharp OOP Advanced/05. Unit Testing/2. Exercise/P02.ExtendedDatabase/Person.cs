namespace P02.ExtendedDatabase
{
    public class Person
    {
        public Person(long id, string username)
        {
            this.Id = id;
            this.Username = username;
        }
        public long Id { get; }

        public string Username { get; }

        public override bool Equals(object obj)
        {
            var other = (Person)obj;

            return this.Username == other.Username && this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
