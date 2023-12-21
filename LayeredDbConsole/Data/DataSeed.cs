using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredDbConsole.Data
{
    public static class DataSeed
    {
        public static void Initialize(AppDbContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.Migrate();
        }
    }
    
}
