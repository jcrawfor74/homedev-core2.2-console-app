using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using MyMd.PasswordDecrypt.App.Config;
using MyMd.PasswordDecrypt.App.DataAccess.Entities;

namespace MyMd.PasswordDecrypt.App.DataAccess
{
    public class MyDbContext : DbContext
    {
        private readonly AppSettings _appSettings;

        public MyDbContext(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_appSettings.DbConnection);
            }
        }

        public DbSet<Member> Members { get; set; }
    }
}
