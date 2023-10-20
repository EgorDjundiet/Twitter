﻿using Microsoft.EntityFrameworkCore;
using Twitter.Domain.Models;
using Twitter.Repository.Configuration;

namespace Twitter.Repository
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<PollItem> PollItems { get; set; }

        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TweetConfiguration());
        }
    }
}