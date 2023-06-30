using System.Collections.Generic;
using CommandHelper.Models;

namespace CommandHelper.Data
{
    public interface ICommandHelperRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();

        Command GetCommandById(int ID);

        void CreateCommand(Command cmd);

        void UpdateCommand(Command cmd);

        void DeleteCommand(Command cmd);
        
    }
}