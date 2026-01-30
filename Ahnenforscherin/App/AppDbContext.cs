using Ahnenforscherin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace Ahnenforscherin;

public partial class AppDbContext : DbContext
{
    private object optionsBuilder;

    public DbSet<Person> Personen { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        optionsBuilder = options;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\mssqllocaldb;Database=Test;ConnectRetryCount=0",
                            providerOptions => { providerOptions.EnableRetryOnFailure(); });
    }
}
