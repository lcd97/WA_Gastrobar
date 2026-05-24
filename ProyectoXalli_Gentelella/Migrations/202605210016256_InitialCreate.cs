namespace ProyectoXalli_Gentelella.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Inv.Bodegas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoBodega = c.String(nullable: false, maxLength: 3),
                        DescripcionBodega = c.String(nullable: false, maxLength: 50),
                        EstadoBodega = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Menu.CategoriasMenu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoCategoriaMenu = c.String(nullable: false, maxLength: 3),
                        DescripcionCategoriaMenu = c.String(nullable: false, maxLength: 50),
                        EstadoCategoriaMenu = c.Boolean(nullable: false),
                        BodegaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Inv.Bodegas", t => t.BodegaId)
                .Index(t => t.BodegaId);
            
            CreateTable(
                "Menu.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoMenu = c.String(nullable: false, maxLength: 3),
                        DescripcionMenu = c.String(nullable: false, maxLength: 350),
                        PrecioMenu = c.Double(nullable: false),
                        TiempoEstimado = c.String(maxLength: 10),
                        EstadoMenu = c.Boolean(nullable: false),
                        Inventariado = c.Boolean(nullable: false),
                        CategoriaMenuId = c.Int(nullable: false),
                        ImagenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Menu.CategoriasMenu", t => t.CategoriaMenuId)
                .ForeignKey("Menu.Imagenes", t => t.ImagenId)
                .Index(t => t.CategoriaMenuId)
                .Index(t => t.ImagenId);
            
            CreateTable(
                "Ord.DetallesDeOrden",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CantidadOrden = c.Int(nullable: false),
                        NotaDetalleOrden = c.String(maxLength: 150),
                        EstadoDetalleOrden = c.Boolean(nullable: false),
                        PrecioOrden = c.Double(nullable: false),
                        OrdenId = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Menu.Menus", t => t.MenuId)
                .ForeignKey("Ord.Ordenes", t => t.OrdenId)
                .Index(t => t.OrdenId)
                .Index(t => t.MenuId);
            
            CreateTable(
                "Ord.Ordenes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoOrden = c.Int(nullable: false),
                        FechaOrden = c.DateTime(nullable: false),
                        EstadoOrden = c.Int(nullable: false),
                        MeseroId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        ImagenId = c.Int(nullable: false),
                        TipoOrdenId = c.Int(nullable: false),
                        MesaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Ord.Meseros", t => t.MeseroId)
                .ForeignKey("Ord.Clientes", t => t.ClienteId)
                .ForeignKey("Menu.Imagenes", t => t.ImagenId)
                .ForeignKey("Ord.Mesas", t => t.MesaId)
                .ForeignKey("Ord.TiposDeOrden", t => t.TipoOrdenId)
                .Index(t => t.MeseroId)
                .Index(t => t.ClienteId)
                .Index(t => t.ImagenId)
                .Index(t => t.TipoOrdenId)
                .Index(t => t.MesaId);
            
            CreateTable(
                "Ord.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailCliente = c.String(nullable: false, maxLength: 150),
                        TelefonoCliente = c.String(maxLength: 9),
                        EstadoCliente = c.Boolean(nullable: false),
                        PasaporteCliente = c.String(maxLength: 10),
                        DatoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Inv.Datos", t => t.DatoId)
                .Index(t => t.DatoId);
            
            CreateTable(
                "Inv.Datos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cedula = c.String(maxLength: 16),
                        PNombre = c.String(maxLength: 50),
                        PApellido = c.String(maxLength: 50),
                        RUC = c.String(maxLength: 14),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Ord.Meseros",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        INSS = c.String(nullable: false, maxLength: 9),
                        HoraEntrada = c.String(nullable: false, maxLength: 10),
                        HoraSalida = c.String(nullable: false, maxLength: 10),
                        EstadoMesero = c.Boolean(nullable: false),
                        DatoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Inv.Datos", t => t.DatoId)
                .Index(t => t.DatoId);
            
            CreateTable(
                "Inv.Proveedores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreComercial = c.String(maxLength: 50),
                        Telefono = c.String(nullable: false, maxLength: 9),
                        EstadoProveedor = c.Boolean(nullable: false),
                        Local = c.Boolean(nullable: false),
                        RetenedorIR = c.Boolean(nullable: false),
                        DatoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Inv.Datos", t => t.DatoId)
                .Index(t => t.DatoId);
            
            CreateTable(
                "Inv.Entradas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoEntrada = c.String(nullable: false, maxLength: 3),
                        FechaEntrada = c.DateTime(nullable: false),
                        EstadoEntrada = c.Boolean(nullable: false),
                        TipoEntradaId = c.Int(nullable: false),
                        BodegaId = c.Int(nullable: false),
                        ProveedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Inv.Bodegas", t => t.BodegaId)
                .ForeignKey("Inv.Proveedores", t => t.ProveedorId)
                .ForeignKey("Inv.TiposDeEntrada", t => t.TipoEntradaId)
                .Index(t => t.TipoEntradaId)
                .Index(t => t.BodegaId)
                .Index(t => t.ProveedorId);
            
            CreateTable(
                "Inv.DetallesDeEntrada",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CantidadEntrada = c.Double(nullable: false),
                        PrecioEntrada = c.Double(nullable: false),
                        EntradaId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Inv.Entradas", t => t.EntradaId)
                .ForeignKey("Inv.Productos", t => t.ProductoId)
                .Index(t => t.EntradaId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "Inv.Productos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoProducto = c.String(nullable: false, maxLength: 3),
                        NombreProducto = c.String(nullable: false, maxLength: 100),
                        MarcaProducto = c.String(maxLength: 50),
                        PresentacionProducto = c.Double(nullable: false),
                        CantidadMaxProducto = c.Double(nullable: false),
                        CantidadMinProducto = c.Double(nullable: false),
                        EstadoProducto = c.Boolean(nullable: false),
                        UnidadMedidaId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Inv.CategoriasProducto", t => t.CategoriaId)
                .ForeignKey("Inv.UnidadesDeMedida", t => t.UnidadMedidaId)
                .Index(t => t.UnidadMedidaId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "Inv.CategoriasProducto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoCategoria = c.String(nullable: false, maxLength: 3),
                        DescripcionCategoria = c.String(nullable: false, maxLength: 50),
                        EstadoCategoria = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Menu.Ingredientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Menu.Menus", t => t.MenuId)
                .ForeignKey("Inv.Productos", t => t.ProductoId)
                .Index(t => t.MenuId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "Inv.UnidadesDeMedida",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoUnidadMedida = c.String(nullable: false, maxLength: 3),
                        DescripcionUnidadMedida = c.String(nullable: false, maxLength: 50),
                        AbreviaturaUM = c.String(nullable: false, maxLength: 10),
                        EstadoUnidadMedida = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Inv.TiposDeEntrada",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoTipoEntrada = c.String(nullable: false, maxLength: 3),
                        DescripcionTipoEntrada = c.String(nullable: false, maxLength: 50),
                        EstadoTipoEntrada = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Menu.Imagenes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ruta = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Fact.Pagos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroPago = c.Int(nullable: false),
                        FechaPago = c.DateTime(nullable: false),
                        Descuento = c.Int(nullable: false),
                        IVA = c.Int(nullable: false),
                        Propina = c.Double(nullable: false),
                        TipoCambio = c.Double(nullable: false),
                        MonedaId = c.Int(nullable: false),
                        ImagenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Fact.Monedas", t => t.MonedaId)
                .ForeignKey("Menu.Imagenes", t => t.ImagenId)
                .Index(t => t.MonedaId)
                .Index(t => t.ImagenId);
            
            CreateTable(
                "Fact.DetallesDePago",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CantidadPagar = c.Double(nullable: false),
                        MontoRecibido = c.Double(nullable: false),
                        TipoPagoId = c.Int(nullable: false),
                        PagoId = c.Int(nullable: false),
                        MonedaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Fact.Monedas", t => t.MonedaId)
                .ForeignKey("Fact.Pagos", t => t.PagoId)
                .ForeignKey("Fact.TiposDePago", t => t.TipoPagoId)
                .Index(t => t.TipoPagoId)
                .Index(t => t.PagoId)
                .Index(t => t.MonedaId);
            
            CreateTable(
                "Fact.Monedas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoMoneda = c.String(nullable: false, maxLength: 3),
                        DescripcionMoneda = c.String(nullable: false, maxLength: 50),
                        EstadoMoneda = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Fact.TiposDePago",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoTipoPago = c.String(nullable: false, maxLength: 3),
                        DescripcionTipoPago = c.String(nullable: false, maxLength: 50),
                        EstadoTipoPago = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Fact.OrdenesPago",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrdenId = c.Int(nullable: false),
                        PagoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Ord.Ordenes", t => t.OrdenId)
                .ForeignKey("Fact.Pagos", t => t.PagoId)
                .Index(t => t.OrdenId)
                .Index(t => t.PagoId);
            
            CreateTable(
                "Ord.Mesas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoMesa = c.String(nullable: false, maxLength: 3),
                        DescripcionMesa = c.String(nullable: false, maxLength: 50),
                        EstadoMesa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Ord.TiposDeOrden",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoTipoOrden = c.String(nullable: false, maxLength: 3),
                        DescripcionTipoOrden = c.String(nullable: false, maxLength: 50),
                        EstadoTipoOrden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Tasa.TasasCambio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaTasa = c.DateTime(nullable: false),
                        Cambio = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Ord.Ordenes", "TipoOrdenId", "Ord.TiposDeOrden");
            DropForeignKey("Ord.Ordenes", "MesaId", "Ord.Mesas");
            DropForeignKey("Fact.OrdenesPago", "PagoId", "Fact.Pagos");
            DropForeignKey("Fact.OrdenesPago", "OrdenId", "Ord.Ordenes");
            DropForeignKey("Fact.Pagos", "ImagenId", "Menu.Imagenes");
            DropForeignKey("Fact.DetallesDePago", "TipoPagoId", "Fact.TiposDePago");
            DropForeignKey("Fact.DetallesDePago", "PagoId", "Fact.Pagos");
            DropForeignKey("Fact.Pagos", "MonedaId", "Fact.Monedas");
            DropForeignKey("Fact.DetallesDePago", "MonedaId", "Fact.Monedas");
            DropForeignKey("Ord.Ordenes", "ImagenId", "Menu.Imagenes");
            DropForeignKey("Menu.Menus", "ImagenId", "Menu.Imagenes");
            DropForeignKey("Ord.DetallesDeOrden", "OrdenId", "Ord.Ordenes");
            DropForeignKey("Ord.Ordenes", "ClienteId", "Ord.Clientes");
            DropForeignKey("Inv.Entradas", "TipoEntradaId", "Inv.TiposDeEntrada");
            DropForeignKey("Inv.Entradas", "ProveedorId", "Inv.Proveedores");
            DropForeignKey("Inv.Productos", "UnidadMedidaId", "Inv.UnidadesDeMedida");
            DropForeignKey("Menu.Ingredientes", "ProductoId", "Inv.Productos");
            DropForeignKey("Menu.Ingredientes", "MenuId", "Menu.Menus");
            DropForeignKey("Inv.DetallesDeEntrada", "ProductoId", "Inv.Productos");
            DropForeignKey("Inv.Productos", "CategoriaId", "Inv.CategoriasProducto");
            DropForeignKey("Inv.DetallesDeEntrada", "EntradaId", "Inv.Entradas");
            DropForeignKey("Inv.Entradas", "BodegaId", "Inv.Bodegas");
            DropForeignKey("Inv.Proveedores", "DatoId", "Inv.Datos");
            DropForeignKey("Ord.Ordenes", "MeseroId", "Ord.Meseros");
            DropForeignKey("Ord.Meseros", "DatoId", "Inv.Datos");
            DropForeignKey("Ord.Clientes", "DatoId", "Inv.Datos");
            DropForeignKey("Ord.DetallesDeOrden", "MenuId", "Menu.Menus");
            DropForeignKey("Menu.Menus", "CategoriaMenuId", "Menu.CategoriasMenu");
            DropForeignKey("Menu.CategoriasMenu", "BodegaId", "Inv.Bodegas");
            DropIndex("Fact.OrdenesPago", new[] { "PagoId" });
            DropIndex("Fact.OrdenesPago", new[] { "OrdenId" });
            DropIndex("Fact.DetallesDePago", new[] { "MonedaId" });
            DropIndex("Fact.DetallesDePago", new[] { "PagoId" });
            DropIndex("Fact.DetallesDePago", new[] { "TipoPagoId" });
            DropIndex("Fact.Pagos", new[] { "ImagenId" });
            DropIndex("Fact.Pagos", new[] { "MonedaId" });
            DropIndex("Menu.Ingredientes", new[] { "ProductoId" });
            DropIndex("Menu.Ingredientes", new[] { "MenuId" });
            DropIndex("Inv.Productos", new[] { "CategoriaId" });
            DropIndex("Inv.Productos", new[] { "UnidadMedidaId" });
            DropIndex("Inv.DetallesDeEntrada", new[] { "ProductoId" });
            DropIndex("Inv.DetallesDeEntrada", new[] { "EntradaId" });
            DropIndex("Inv.Entradas", new[] { "ProveedorId" });
            DropIndex("Inv.Entradas", new[] { "BodegaId" });
            DropIndex("Inv.Entradas", new[] { "TipoEntradaId" });
            DropIndex("Inv.Proveedores", new[] { "DatoId" });
            DropIndex("Ord.Meseros", new[] { "DatoId" });
            DropIndex("Ord.Clientes", new[] { "DatoId" });
            DropIndex("Ord.Ordenes", new[] { "MesaId" });
            DropIndex("Ord.Ordenes", new[] { "TipoOrdenId" });
            DropIndex("Ord.Ordenes", new[] { "ImagenId" });
            DropIndex("Ord.Ordenes", new[] { "ClienteId" });
            DropIndex("Ord.Ordenes", new[] { "MeseroId" });
            DropIndex("Ord.DetallesDeOrden", new[] { "MenuId" });
            DropIndex("Ord.DetallesDeOrden", new[] { "OrdenId" });
            DropIndex("Menu.Menus", new[] { "ImagenId" });
            DropIndex("Menu.Menus", new[] { "CategoriaMenuId" });
            DropIndex("Menu.CategoriasMenu", new[] { "BodegaId" });
            DropTable("Tasa.TasasCambio");
            DropTable("Ord.TiposDeOrden");
            DropTable("Ord.Mesas");
            DropTable("Fact.OrdenesPago");
            DropTable("Fact.TiposDePago");
            DropTable("Fact.Monedas");
            DropTable("Fact.DetallesDePago");
            DropTable("Fact.Pagos");
            DropTable("Menu.Imagenes");
            DropTable("Inv.TiposDeEntrada");
            DropTable("Inv.UnidadesDeMedida");
            DropTable("Menu.Ingredientes");
            DropTable("Inv.CategoriasProducto");
            DropTable("Inv.Productos");
            DropTable("Inv.DetallesDeEntrada");
            DropTable("Inv.Entradas");
            DropTable("Inv.Proveedores");
            DropTable("Ord.Meseros");
            DropTable("Inv.Datos");
            DropTable("Ord.Clientes");
            DropTable("Ord.Ordenes");
            DropTable("Ord.DetallesDeOrden");
            DropTable("Menu.Menus");
            DropTable("Menu.CategoriasMenu");
            DropTable("Inv.Bodegas");
        }
    }
}
