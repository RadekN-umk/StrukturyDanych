using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace StrukturyDanych.Model
{
    public partial class MainModel : DbContext
    {
        public MainModel()
            : base("name=MainModel")
        {
        }

        public virtual DbSet<Change> Change { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Tool> Tool { get; set; }
        public virtual DbSet<ProductLastDateView> ProductLastDateView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Change>()
                .Property(e => e.ChangeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Change>()
                .HasMany(e => e.Tool)
                .WithMany(e => e.Change)
                .Map(m => m.ToTable("ChangeTool").MapLeftKey("ID_Change").MapRightKey("ID_Tool"));

            modelBuilder.Entity<Product>()
                .Property(e => e.AlphanumericKey)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Change)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tool>()
                .Property(e => e.AlphanumericKey)
                .IsUnicode(false);

            modelBuilder.Entity<ProductLastDateView>()
                .Property(e => e.AlphanumericKey)
                .IsUnicode(false);
        }
    }
}
