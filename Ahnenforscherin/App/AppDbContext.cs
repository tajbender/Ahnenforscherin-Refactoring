using Ahnenforscherin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Microsoft.EntityFrameworkCore;

namespace Ahnenforscherin;

public partial class AppDbContext : DbContext
{
    public DbSet<Person> Personen { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        //options.UseSqlite("Data Source=ahnenforscherin.db");
    }
}
