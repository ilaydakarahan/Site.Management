using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions<BaseDbContext> opt) : base(opt)
    {

    }

    public DbSet<Apartment> Apartments { get; set; }
    public DbSet<Block> Blocks { get; set; }
}
