using System.Collections.Generic;
using System.IO;
using System.Linq;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DAL.EF
{
    public class TwinkeltjeDbContext : DbContext
    {
        private static bool hasRunDuringAppExecution = false;

        public DbSet<Product> Products { get; set; }
        public DbSet<Allergie> Allergies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TwinkeltjeDb_EFCodeFirst.db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductAllergie>()
                .HasKey(t => new {t.ProductId, t.AllergieId});

            modelBuilder.Entity<ProductAllergie>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductAllergies)
                .HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<ProductAllergie>()
                .HasOne(pt => pt.Allergie)
                .WithMany(t => t.ProductAllergies)
                .HasForeignKey(pt => pt.AllergieId);
        }

        public static void Initialize(TwinkeltjeDbContext context, bool dropCreateDatabase = false)
        {
            if (!hasRunDuringAppExecution)
            {
                // Delete database if requested
                if (dropCreateDatabase)
                    context.Database.EnsureDeleted();
                // Create database and initial data if needed
                if (context.Database.EnsureCreated())
                SeedProducts(context);
                hasRunDuringAppExecution = true;
            }
        }

        private static void SeedProducts(TwinkeltjeDbContext context)
        {
            Allergie Gluten = new Allergie
            {
                Naam = "Gluten", Beschrijving = "Gluten", ProductAllergies = new List<ProductAllergie>()
            };

            Allergie Ei = new Allergie
            {
                Naam = "Ei", Beschrijving = "Eieren", ProductAllergies = new List<ProductAllergie>()
            };

            Allergie Lactose = new Allergie
            {
                Naam = "Lactose", Beschrijving = "Lactose", ProductAllergies = new List<ProductAllergie>()
            };

            Allergie Noten = new Allergie
            {
                Naam = "Noten", Beschrijving = "Noten", ProductAllergies = new List<ProductAllergie>()
            };

            Allergie Mosterd = new Allergie
            {
                Naam = "Mosterd", Beschrijving = "Mosterd", ProductAllergies = new List<ProductAllergie>()
            };

            Allergie Melk = new Allergie
            {
                Naam = "Melk", Beschrijving = "Melk", ProductAllergies = new List<ProductAllergie>()
            };

            Allergie Geen = new Allergie
            {
                Naam = "Geen", Beschrijving = "Geen", ProductAllergies = new List<ProductAllergie>()
            };

            Product product1 = new Product
            {
                Beschrijving =
                    "Een lekker smeuïge paté, wat zorgt voor een zeer aangenaam mondgevoel, met een sublieme smaak. De paté wordt gepresenteerd in een witte terrine van slechts 1.5 kg, wat resulteert in een snelle rotatie. Kortom, met deze paté zal u zeker scoren bij uw klanten!",
                Naam = "Crèmepaté",
                ImageData = File.ReadAllBytes("Images/cremepate.jpg"),
                ProductAllergies = new List<ProductAllergie>(new []{new ProductAllergie
                {
                    Allergie = new Allergie
                    {
                        Naam = "Ei",Beschrijving = "Eieren"
                    }, Naam = "Ei"
                }, new ProductAllergie
                {
                    Allergie = new Allergie
                    {
                        Naam = "Lactose",Beschrijving = "Lactose"
                    }, Naam = "Lactose"
                }, new ProductAllergie
                {
                    Allergie = new Allergie
                    {
                        Naam = "Melk",Beschrijving = "Melk"
                    }, Naam = "Melk"
                }, })
            };
            Product product2 = new Product
            {
                Beschrijving =
                    "Dit traditionele vleesbrood bestaat voor 100% uit grof gemalen varkensvlees. Dit product is verkrijgbaar in de artisanale broodvorm of in de rendabele blokvorm.",
                Naam = "Vleesbrood (1/2)",
                ImageData = File.ReadAllBytes("Images/vleesbrood.jpg"),
                ProductAllergies = new List<ProductAllergie>(new []{new ProductAllergie
                {
                    Allergie = new Allergie
                    {
                        Naam = "Ei",Beschrijving = "Eieren"
                    }, Naam = "Ei"
                }, new ProductAllergie
                {
                    Allergie = new Allergie
                    {
                        Naam = "Lactose",Beschrijving = "Lactose"
                    }, Naam = "Lactose"
                }, new ProductAllergie
                {
                    Allergie = new Allergie
                    {
                        Naam = "Melk",Beschrijving = "Melk"
                    }, Naam = "Melk"
                }, })
            };
            Product product3 = new Product
            {
                Naam = "Blokpaté",
                Beschrijving =
                    "Deze blokpaté krijgt zijn unieke, intense smaak door het gebruik van verse lever. Door de verzorgde afwerking met natuurlijk lardeerspek en het nabranden verkrijgt deze smakelijke blokpaté zijn mooie presentatie.",
                ImageData = File.ReadAllBytes("Images/blokpate.jpg"),
                ProductAllergies = new List<ProductAllergie>(new []{new ProductAllergie
                {
                    Allergie = new Allergie
                    {
                        Naam = "Ei",Beschrijving = "Eieren"
                    }, Naam = "Ei"
                }, new ProductAllergie
                {
                    Allergie = new Allergie
                    {
                        Naam = "Lactose",Beschrijving = "Lactose"
                    }, Naam = "Lactose"
                }, new ProductAllergie
                {
                    Allergie = new Allergie
                    {
                        Naam = "Melk",Beschrijving = "Melk"
                    }, Naam = "Melk"
                }, })
            };
            Product product4 = new Product
            {
                Naam = "Lunchworst Patron",
                Beschrijving =
                    "De Lunchworst Patron wordt vervaardigd uit varkensvlees met grove ham. De milde roking zorgt voor een extra smaakvol aspect. Door zijn typische ringvorm onderscheidt de Lunchworst Patron zich van de andere kookworsten.",
                ImageData = File.ReadAllBytes("Images/lunchworst_patron.jpg"),
                ProductAllergies = new List<ProductAllergie>(new []{new ProductAllergie
                {
                    Allergie = new Allergie
                    {
                        Naam = "Ei",Beschrijving = "Eieren"
                    }, Naam = "Ei"
                }, new ProductAllergie
                {
                    Allergie = new Allergie
                    {
                        Naam = "Lactose",Beschrijving = "Lactose"
                    }, Naam = "Lactose"
                }, new ProductAllergie
                {
                    Allergie = new Allergie
                    {
                        Naam = "Melk",Beschrijving = "Melk"
                    }, Naam = "Melk"
                }, })
            };
            Product product5 = new Product
            {
                Naam = "Kalfsworst",
                Beschrijving =
                    "Met zijn frisse, zachte smaak is deze Kalfsworst de ideale klassieke, boterhamworst. Deze hespenworst is ook verkrijgbaar met look.",
                ImageData = File.ReadAllBytes("Images/kalfsworst.jpg"),
                ProductAllergies = new List<ProductAllergie>(new []{new ProductAllergie
                {
                    Allergie = new Allergie
                    {
                        Naam = "Ei",Beschrijving = "Eieren"
                    }, Naam = "Ei"
                }, new ProductAllergie
                {
                    Allergie = new Allergie
                    {
                        Naam = "Lactose",Beschrijving = "Lactose"
                    }, Naam = "Lactose"
                }, new ProductAllergie
                {
                    Allergie = new Allergie
                    {
                        Naam = "Melk",Beschrijving = "Melk"
                    }, Naam = "Melk"
                }, })
            };
            Product product6 = new Product
            {
                Naam = "Hespenworst",
                Beschrijving =
                    "Met zijn frisse, zachte smaak is deze Hespenworst de ideale klassieke, boterhamworst. Deze hespenworst is ook verkrijgbaar met look.",
                ImageData = File.ReadAllBytes("Images/hespenworst.jpg"),
                ProductAllergies = new List<ProductAllergie>(new []{new ProductAllergie
                {
                    Allergie = new Allergie
                    {
                        Naam = "Ei",Beschrijving = "Eieren"
                    }, Naam = "Ei"
                }, new ProductAllergie
                {
                    Allergie = new Allergie
                    {
                        Naam = "Lactose",Beschrijving = "Lactose"
                    }, Naam = "Lactose"
                }, new ProductAllergie
                {
                    Allergie = new Allergie
                    {
                        Naam = "Melk",Beschrijving = "Melk"
                    }, Naam = "Melk"
                }, })
            };
            Product product7 = new Product
            {
                Naam = "Mandolino",
                Beschrijving =
                    "Deze ambachtelijke ham vervaardigd uit de beste spierdelen, wordt op aloude wijze gerookt op een bed van smeulend beukenhout en jeneverbessen. Het resultaat is een traditionele ham met verfijne rooksmaak in een optimaal rendabele vorm. De Imperial kroon meer dan waardig!",
                ImageData = File.ReadAllBytes("Images/Mandolino.jpg"),
                ProductAllergies = new List<ProductAllergie>()
            };       
            
                       context.Allergies.AddRange(new []{Ei, Lactose, Melk, Gluten, Mosterd, Noten});

            context.Products.AddRange(new []{product1, product2, product3, product4, product5, product6, product7});

           
            context.SaveChanges();
            foreach (EntityEntry entry in context.ChangeTracker.Entries().ToList())
            {
                entry.State = EntityState.Detached;
            }
        }


    }
}