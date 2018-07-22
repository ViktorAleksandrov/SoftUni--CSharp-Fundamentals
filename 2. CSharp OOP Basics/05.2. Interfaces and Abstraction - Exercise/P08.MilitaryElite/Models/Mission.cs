using System;

public class Mission : IMission
{
    private string state;

    public Mission(string codeName, string state)
    {
        CodeName = codeName;
        State = state;
    }

    public string CodeName { get; }

    public string State
    {
        get => state;

        private set
        {
            CompleteMission(value);
        }
    }

    private void CompleteMission(string value)
    {
        if (value != "inProgress" && value != "Finished")
        {
            throw new ArgumentException();
        }

        state = value;
    }

    public override string ToString()
    {
        return $"  Code Name: {CodeName} State: {State}";
    }
}