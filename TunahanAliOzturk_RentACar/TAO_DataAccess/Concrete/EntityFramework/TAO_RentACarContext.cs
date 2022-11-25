using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.Entities.Concrete;
using TAO_Entities.Concrete;

namespace TAO_DataAccess.Concrete.EntityFramework
{
  public class TAO_RentACarContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Server =(localdb)\MSSQLLocalDB;Database =TAO_RentACar;Trusted_Connection=true");
    }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Colour> Colors { get; set; }
    public DbSet<Rental> Rentals { get; set; }

    //public DbSet<Customer> Customers { get; set; }
    public DbSet<CarImage> CarImages { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

  }
}
