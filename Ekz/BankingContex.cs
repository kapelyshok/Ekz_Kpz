using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekz
{
    internal class BankingContex : DbContext
    {
        public BankingContex() : base()
        {

        }
        public DbSet<Operation> Operations { get; set; }
    }
}
