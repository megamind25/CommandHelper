using System.Collections.Generic;
using CommandHelper.Models;

namespace CommandHelper.Data
{
    public class MockCommandHelperRepo : ICommandHelperRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commandList = new List<Command>{
                new Command
                {
                    ID = 0, 
                    HowTo = "Running the application through Mock Data",
                    Line = "Run the app",
                    Platform = "Dotnet"
                },
                new Command
                {
                    ID = 1, 
                    HowTo = "Book a Slot",
                    Line = "Run the jar",
                    Platform = "Java"
                },
                new Command
                {
                    ID = 2, 
                    HowTo = "Save a tweet",
                    Line = "Mention the profile name",
                    Platform = "React"
                },
            };

            return commandList;

        }

        public Command GetCommandById(int ID)
        {
            return new Command{ID = 0, 
            HowTo = "Running the application through Mock Data",
            Line = "Run the app",
            Platform = "Dotnet"
            };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}