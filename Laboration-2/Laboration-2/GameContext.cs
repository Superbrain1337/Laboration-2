﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_2
{
    public class GameContext : DbContext
    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Laboration-2-Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public GameContext() : base(connectionString) { }

        public DbSet<Level> Levels { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var levelConfig = modelBuilder.Entity<Level>();
            var playerConfig = modelBuilder.Entity<Player>();
            var scoreConfig = modelBuilder.Entity<Score>();

            playerConfig.ToTable("Players");
            levelConfig.ToTable("Levels");
            scoreConfig.ToTable("Scores");

            levelConfig.HasMany(l => l.Players);
            playerConfig.HasMany(p => p.Scores);
            scoreConfig.HasRequired(s => s.Levels);

            base.OnModelCreating(modelBuilder);
        }


    }
}
