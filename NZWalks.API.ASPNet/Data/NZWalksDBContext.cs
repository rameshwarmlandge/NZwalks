﻿
using Microsoft.EntityFrameworkCore;
using NZWalks.API.ASPNet.Models.Domain;

namespace NZWalks.API.ASPNet.Data
{
    public class NZWalksDBContext : DbContext
    {
        public NZWalksDBContext(DbContextOptions<NZWalksDBContext> options):base(options)
        {

        }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulties { get; set; }
        public DbSet<UserInfo> userInfos { get; set; }

    }
}
