namespace P06.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var teams = new List<Team>();

            while (true)
            {
                var commandArgs = Console.ReadLine().Split(';');

                var command = commandArgs[0];

                if (command == "END")
                {
                    break;
                }

                var teamName = commandArgs[1];

                if (command == "Team")
                {
                    teams.Add(new Team(teamName));
                    continue;
                }

                try
                {
                    ProcessCommands(teams, commandArgs, command, teamName);
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine(argEx.Message);
                }
            }
        }

        private static void ProcessCommands(List<Team> teams, string[] commandArgs, string command, string teamName)
        {
            var team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            switch (command)
            {
                case "Add":
                    var playerName = commandArgs[2];
                    var endurance = int.Parse(commandArgs[3]);
                    var sprint = int.Parse(commandArgs[4]);
                    var dribble = int.Parse(commandArgs[5]);
                    var passing = int.Parse(commandArgs[6]);
                    var shooting = int.Parse(commandArgs[7]);
                    team.AddPlayer(new Player(playerName, endurance, sprint, dribble, passing, shooting));
                    break;
                case "Remove":
                    team.RemovePlayer(commandArgs[2]);
                    break;
                case "Rating":
                    Console.WriteLine(team);
                    break;
            }
        }
    }
}