using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;

namespace DAL.EF
{
    public class Context : DbContext
    {
        public Context() : base("DbConnection") { }

        public DbSet<Account> Accounts { get; set; }
    }
}
