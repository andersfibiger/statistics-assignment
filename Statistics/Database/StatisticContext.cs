using System;
using Microsoft.EntityFrameworkCore;
using Statistics.Models;

namespace Statistics.Database
{
    public class StatisticContext : DbContext
    {
        public StatisticContext(DbContextOptions<StatisticContext> options) : base(options)
        {
        }

        public virtual DbSet<DailyStatistic> DailyStatistics { get; set; }
        private ModelBuilder _modelBuilder;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            _modelBuilder = modelBuilder;

            CreateTestData(1,380,4);
            CreateTestData(2,395,5);
            CreateTestData(3,407,6);
            CreateTestData(4,415,7);
        }

        private void CreateTestData(long id, int numberOfExperiences, int day)
        {
            _modelBuilder.Entity<DailyStatistic>().HasData(
                new DailyStatistic
                {
                    Id = id,
                    NumberOfExperiences = numberOfExperiences,
                    TimeStamp = new DateTime(2020, 08, day)
                });
        }
    }
}
