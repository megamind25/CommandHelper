using System;
using System.Collections.Generic;
using System.Linq;
using CommandHelper.Models;

namespace CommandHelper.Data
{
    public class SqlCommandHelperRepo : ICommandHelperRepo
    {
        private readonly CommandHelperContext _context;

        public SqlCommandHelperRepo(CommandHelperContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException();
            }

            _context.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException();
            }

            _context.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int ID)
        {
            return _context.Commands.FirstOrDefault(x => x.ID == ID);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
            //
        }
    }
}