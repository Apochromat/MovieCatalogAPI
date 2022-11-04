using Microsoft.EntityFrameworkCore;
using webNET_Hits_backend_aspnet_project_1.Models;

namespace webNET_Hits_backend_aspnet_project_1 {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext() : base() {
            //Database.EnsureCreated();
        }

        // Объявляем используемые при создании БД Модели данных
        public DbSet<User>? Users { get; set; }
        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Genre>? Genres { get; set; }
        public DbSet<Review>? Reviews { get; set; }

        // Указывам ключи и индексы атрибутов БД
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>().HasKey(x => x.UserId);
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<Movie>().HasKey(x => x.MovieId);
            modelBuilder.Entity<Genre>().HasKey(x => x.GenreId);
            modelBuilder.Entity<Review>().HasKey(x => x.ReviewId);
        }

        // Задаем подключение к базе данных
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 30)));
            //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=film_catalog;Username=postgres;Password=postgres");
        }
    }
}
