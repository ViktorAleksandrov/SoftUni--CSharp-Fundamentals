using System;
using System.Collections.Generic;
using System.Linq;
using P02.ExtendedDatabase;

public class Database
{
    private readonly Dictionary<string, Person> peopleByUsername;
    private readonly Dictionary<long, Person> peopleById;

    public Database()
    {
        this.peopleByUsername = new Dictionary<string, Person>();
        this.peopleById = new Dictionary<long, Person>();
    }

    public Database(params Person[] inputPersons)
        : this()
    {
        InitializeInputPersons(inputPersons);
    }

    public IReadOnlyDictionary<string, Person> PeopleByUsername => this.peopleByUsername;

    public IReadOnlyDictionary<long, Person> PeopleById => this.peopleById;

    public int Count => this.peopleById.Count;

    private void InitializeInputPersons(Person[] inputPersons)
    {
        if (inputPersons != null)
        {
            foreach (Person person in inputPersons.Where(p => p != null))
            {
                this.peopleByUsername[person.Username] = person;
                this.peopleById[person.Id] = person;
            }
        }
    }

    public void Add(Person person)
    {
        if (this.peopleByUsername.ContainsKey(person.Username) || this.peopleById.ContainsKey(person.Id))
        {
            throw new InvalidOperationException();
        }

        this.peopleByUsername[person.Username] = person;
        this.peopleById[person.Id] = person;
    }

    public void Remove(Person person)
    {
        if (this.peopleById.ContainsKey(person.Id))
        {
            this.peopleByUsername.Remove(person.Username);
            this.peopleById.Remove(person.Id);
        }
    }

    public Person FindByUsername(string username)
    {
        if (username == null)
        {
            throw new ArgumentNullException();
        }

        if (!this.peopleByUsername.ContainsKey(username))
        {
            throw new InvalidOperationException();
        }

        Person person = this.peopleByUsername[username];

        return person;
    }

    public Person FindById(long id)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (!this.peopleById.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }

        Person person = this.peopleById[id];

        return person;
    }
}
