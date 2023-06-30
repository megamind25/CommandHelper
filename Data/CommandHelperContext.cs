using CommandHelper.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandHelper.Data
{
    public class CommandHelperContext : DbContext
    {
        public CommandHelperContext(DbContextOptions<CommandHelperContext> opt) : base(opt)
        {
            
        }

        public DbSet<Command> Commands { get; set; }
    }
}