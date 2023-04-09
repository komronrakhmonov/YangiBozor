using Microsoft.EntityFrameworkCore;
using YangiBozor.Domain.Entities;

namespace YangiBozor.Data.DbContexts;

public class YangiBozorDbContext : DbContext
{
	public YangiBozorDbContext(DbContextOptions<YangiBozorDbContext> options)
		: base(options)
	{

	}

	public DbSet<User> Users { get; set; }
	public DbSet<Cart> Carts { get; set; }
	public DbSet<ChatBox> ChatBoxes { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<OrderItem> OrderItems { get; set; }
	public DbSet<Payment> Payments { get; set; }
	public DbSet<Product> Products { get; set; }
}
