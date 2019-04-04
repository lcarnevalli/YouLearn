using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;
using YouLearn.Domain.ValueObjects;
using YouLearn.Infra.Persistence.EF.Map;
using YouLearn.Shared;

namespace YouLearn.Infra.Persistence.EF
{
    public class YouLearnContext: DbContext
    {
        public DbSet<Canal> Canais { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Favorito> Favoritos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // criei um projeto com configurações estáticas de settings.
            optionsBuilder.UseSqlServer(Settings.ConnectionString);

            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // consigo definir quais classes devo ignorar 
            // ignorar classes
            modelBuilder.Ignore<Notification>();
            modelBuilder.Ignore<Nome>();
            modelBuilder.Ignore<Email>();
            modelBuilder.Ignore<Senha>();

            //aplicar configurações
            //modelBuilder.ApplyConfiguration(new )
            modelBuilder.ApplyConfiguration(new MapUsuario());
            modelBuilder.ApplyConfiguration(new MapCanal());
            modelBuilder.ApplyConfiguration(new MapPlayList());
            modelBuilder.ApplyConfiguration(new MapVideo());
            //modelBuilder.ApplyConfiguration(new MapFavorito());

            base.OnModelCreating(modelBuilder);


        }
    }
}
