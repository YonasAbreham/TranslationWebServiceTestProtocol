using Data.Model.Translation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class TranslationWebServiceContext : DbContext
    {
        public DbSet<Translation> Translations { get; set; }

        public TranslationWebServiceContext()
            : base(new DbContextOptionsBuilder<TranslationWebServiceContext>().UseMySql("server=localhost;userid=root;password=PassWord;port=3306;database=translationwebervice; sslmode=none;",
                ServerVersion.AutoDetect("server=localhost;userid=root;password=PassWord;port=3306;database=translationwebervice; sslmode=none;")).Options)
        {
        }

        public TranslationWebServiceContext(DbContextOptions<TranslationWebServiceContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
