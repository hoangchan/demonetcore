using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoProject.Models
{
	public partial class ProjectDemoContext : DbContext
	{
		public virtual DbSet<Order> Order { get; set; }
		public virtual DbSet<OrderDetail> OrderDetail { get; set; }
		public virtual DbSet<Product> Product { get; set; }
		public ProjectDemoContext(DbContextOptions<ProjectDemoContext> options) : base(options) { }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
				optionsBuilder.UseSqlServer(@"Data Source=HCM-SU2-CHANNH;Initial Catalog=ProjectDemo;Integrated Security=True");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>(entity =>
			{
				entity.Property(e => e.DayCreate).HasColumnType("datetime");
			});

			modelBuilder.Entity<OrderDetail>(entity =>
			{
				entity.HasOne(d => d.Order)
					.WithMany(p => p.OrderDetail)
					.HasForeignKey(d => d.OrderId)
					.HasConstraintName("FK_OrderDetail_Order");

				entity.HasOne(d => d.Product)
					.WithMany(p => p.OrderDetail)
					.HasForeignKey(d => d.ProductId)
					.HasConstraintName("FK_OrderDetail_Product");
			});

			modelBuilder.Entity<Product>(entity =>
			{
				entity.Property(e => e.Image).HasMaxLength(250);

				entity.Property(e => e.Name).HasMaxLength(50);
			});
		}
	}
}
