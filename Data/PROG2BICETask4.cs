using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PROG2BIceTask4.Models;

namespace PROG2BIceTask4.Data
{
    public class PROG2BICETask4 : DbContext
    {
        public PROG2BICETask4 (DbContextOptions<PROG2BICETask4> options)
            : base(options)
        {
        }

        public DbSet<PROG2BIceTask4.Models.TaskManager> TaskManager { get; set; } = default!;
    }
}
