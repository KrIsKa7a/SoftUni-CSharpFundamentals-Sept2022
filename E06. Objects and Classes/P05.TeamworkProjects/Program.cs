namespace P05.TeamworkProjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            InitializeTeams(teams);
            JoinTeams(teams);

            PrintValidTeams(teams);
            PrintTeamsToDisband(teams);
        }

        static void InitializeTeams(List<Team> teams)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] teamArgs = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);

                string creator = teamArgs[0];
                string teamName = teamArgs[1];

                if (TeamExists(teams, teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (AlreadyCreatedATeam(teams, creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    Team newTeam = new Team(teamName, creator);
                    teams.Add(newTeam);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }
        }

        static bool TeamExists(List<Team> teams, string teamName)
        {
            return teams.Any(t => t.Name == teamName);
        }

        static bool AlreadyCreatedATeam(List<Team> teams, string creator)
        {
            return teams.Any(t => t.Creator == creator);
        }

        static void JoinTeams(List<Team> teams)
        {
            string command;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] cmdArgs = command
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);
                string user = cmdArgs[0];
                string teamName = cmdArgs[1];

                if (!TeamExists(teams, teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (AlreadyAMemberOfATeam(teams, user))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                }
                else
                {
                    Team teamToJoin = teams
                        .First(t => t.Name == teamName);
                    teamToJoin.AddMember(user);
                }
            }
        }

        static bool AlreadyAMemberOfATeam(List<Team> teams, string user)
        {
            return teams.Any(t => t.Members.Contains(user)) ||
                teams.Any(t => t.Creator == user);
        }

        static void PrintValidTeams(List<Team> teams)
        {
            List<Team> teamsWithMembers = teams
                .Where(t => t.Members.Count > 0)
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.Name)
                .ToList();
            foreach (Team team in teamsWithMembers)
            {
                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- {team.Creator}");
                foreach (string memberName in team.Members.OrderBy(m => m))
                {
                    Console.WriteLine($"-- {memberName}");
                }
            }
        }

        static void PrintTeamsToDisband(List<Team> teams)
        {
            List<Team> teamsToDisband = teams
                .Where(t => t.Members.Count == 0)
                .OrderBy(t => t.Name)
                .ToList();
            Console.WriteLine($"Teams to disband:");
            foreach (Team disbandTeam in teamsToDisband)
            {
                Console.WriteLine($"{disbandTeam.Name}");
            }
        }
    }

    public class Team
    {
        private readonly List<string> members;

        public Team(string name, string creator)
        {
            this.Name = name;
            this.Creator = creator;

            this.members = new List<string>();
        }

        public string Name { get; private set; }

        public string Creator { get; private set; }

        //Get-only property
        //To be right => IReadOnlyCollection<string>
        public List<string> Members
            => this.members;

        public void AddMember(string memberName)
        {
            this.members.Add(memberName);
        }
    }
}
