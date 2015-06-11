namespace OnlineShop.Domain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopContext : DbContext
    {
        public ShopContext()
            : base("name=OnlineShop")
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<EstadoPedido> EstadoPedido { get; set; }
        public virtual DbSet<Imagenes> Imagenes { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<MediodePago> MediodePago { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Pedido_Producto> Pedido_Producto { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Producto_Proveedor> Producto_Proveedor { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Producto)
                .WithOptional(e => e.Categoria)
                .HasForeignKey(e => e.IdCategoria);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Pedido)
                .WithOptional(e => e.Cliente)
                .HasForeignKey(e => e.IdCliente);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Pedido)
                .WithOptional(e => e.Empleado)
                .HasForeignKey(e => e.IdEmpleado);

            modelBuilder.Entity<EstadoPedido>()
                .HasMany(e => e.Pedido)
                .WithOptional(e => e.EstadoPedido)
                .HasForeignKey(e => e.IdEstadoPed);

            modelBuilder.Entity<Imagenes>()
                .Property(e => e.Ruta)
                .IsUnicode(false);

            modelBuilder.Entity<Imagenes>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Imagenes>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Marca>()
                .HasMany(e => e.Producto)
                .WithOptional(e => e.Marca)
                .HasForeignKey(e => e.IdMarca);

            modelBuilder.Entity<MediodePago>()
                .HasMany(e => e.Pedido)
                .WithOptional(e => e.MediodePago)
                .HasForeignKey(e => e.IdMedioDePago);

            modelBuilder.Entity<Pedido>()
                .HasMany(e => e.Pedido_Producto)
                .WithOptional(e => e.Pedido)
                .HasForeignKey(e => e.IdPedido);

            modelBuilder.Entity<Pedido_Producto>()
                .Property(e => e.Descuento)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Pedido_Producto>()
                .Property(e => e.Precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Pedido_Producto>()
                .Property(e => e.Igv)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Pedido_Producto>()
                .Property(e => e.PTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Producto>()
                .Property(e => e.PrecioCosto)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Sku)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Imagenes)
                .WithOptional(e => e.Producto)
                .HasForeignKey(e => e.IdProducto);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Pedido_Producto)
                .WithOptional(e => e.Producto)
                .HasForeignKey(e => e.IdProducto);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Producto_Proveedor)
                .WithOptional(e => e.Producto)
                .HasForeignKey(e => e.IdProducto);

            modelBuilder.Entity<Proveedor>()
                .HasMany(e => e.Producto_Proveedor)
                .WithOptional(e => e.Proveedor)
                .HasForeignKey(e => e.IdProveedor);
        }
    }
}
