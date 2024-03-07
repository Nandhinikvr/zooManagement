using Microsoft.EntityFrameworkCore;
using ZooManagement.Enums;
using ZooManagement.Models.Data;

namespace ZooManagement;

public class Zoo : DbContext
{
    public DbSet<Animal> Animals { get; set; } = null!;
    public DbSet<Species> Species { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=zoo; Username=zoo; Password=zoo;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var lion = new Species
        {
            Id = -1,
            Name = "lion",
            Classification = Classification.Mammal,
        };

        modelBuilder.Entity<Species>().HasData(lion);

        var simba = new Animal
        {
            Id = -1,
            Name = "simba",
            SpeciesId = -1,
            Sex = Sex.Male,
            DateOfBirth = new DateTime(1997, 10, 16).ToUniversalTime(),
            DateOfAcquisition = new DateTime(2000, 1, 1).ToUniversalTime(),
        };
        var nala = new Animal
        {
            Id = -2,
            Name = "nala",
            SpeciesId = -1,
            Sex = Sex.Female,
            DateOfBirth = new DateTime(1997, 9, 10).ToUniversalTime(),
            DateOfAcquisition = new DateTime(2001, 2, 3).ToUniversalTime(),
        };

        modelBuilder.Entity<Animal>().HasData(simba, nala);  
         SeedData(modelBuilder);

    }

     private static void SeedData(ModelBuilder modelBuilder)
    {
        // 10 species
        for (var n = 2; n <= 11; n++)
        {
            Random random = new Random();
            var species = GenerateSpecies(n, $"species_{n}", random.Next(6));
            modelBuilder.Entity<Species>().HasData(species);

            // 10 animals each
            for (var m = 0; m <= 9; m++)
            {
                int id = n*10+m;
                var animal = GenerateAnimal(id, $"animal_{id}", species.Id, random.Next(2), DateTime.Now.AddDays(-random.Next(3000)), DateTime.Now);
                modelBuilder.Entity<Animal>().HasData(animal);
            }

        }
    }

    private static Species GenerateSpecies(int id, string name, int classification)
    {
        return new Species
        {
            Id = -id,
            Name = name,
            Classification = (Classification)classification,
        };
    }

    private static Animal GenerateAnimal(int id, string name, int speciesId, int sex, DateTime dateOfBirth, DateTime dateOfAcquisition)
    {
        return new Animal
        {
            Id = -id,
            Name = name,
            SpeciesId = speciesId,
            Sex = (Sex)sex,
            DateOfBirth = dateOfBirth.ToUniversalTime(),
            DateOfAcquisition = dateOfAcquisition.ToUniversalTime(),   
        };   
    }
}
