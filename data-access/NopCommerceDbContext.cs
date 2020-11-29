namespace RoofrackDataAccess
{
    using RoofrackDataAccess.Models;
    using System.Data.Entity;

    public partial class NopCommerceDbContext : DbContext
    {
        public NopCommerceDbContext()
            : base("name=NopCommerceDbContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryTemplate> CategoryTemplates { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<ManufacturerTemplate> ManufacturerTemplates { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_Category_Mapping> Product_Category_Mapping { get; set; }
        public virtual DbSet<Product_Manufacturer_Mapping> Product_Manufacturer_Mapping { get; set; }
        public virtual DbSet<Product_ProductAttribute_Mapping> Product_ProductAttribute_Mapping { get; set; }
        public virtual DbSet<Product_SpecificationAttribute_Mapping> Product_SpecificationAttribute_Mapping { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
        public virtual DbSet<ProductAttributeCombination> ProductAttributeCombinations { get; set; }
        public virtual DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public virtual DbSet<ProductAvailabilityRange> ProductAvailabilityRanges { get; set; }
        public virtual DbSet<ProductTag> ProductTags { get; set; }
        public virtual DbSet<ProductTemplate> ProductTemplates { get; set; }
        public virtual DbSet<RelatedProduct> RelatedProducts { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<VendorAttribute> VendorAttributes { get; set; }
        public virtual DbSet<VendorAttributeValue> VendorAttributeValues { get; set; }
        public virtual DbSet<Hubb_Import> HubbImports { get; set; }
        public virtual DbSet<UrlRecord> UrlRecords { get; set; }
        public virtual DbSet<SpecificationAttribute> SpecificationAttributes { get; set; }
        public virtual DbSet<SpecificationAttributeOption> SpecificationAttributeOptions { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<PictureBinary> PictureBinaries { get; set; }
        public virtual DbSet<Product_Picture_Mapping> Product_Picture_Mapping { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.OverriddenGiftCardAmount)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.AdditionalShippingCharge)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.OldPrice)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductCost)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.MinimumCustomerEnteredPrice)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.MaximumCustomerEnteredPrice)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.BasepriceAmount)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.BasepriceBaseAmount)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Weight)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Length)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Width)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Height)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductTags)
                .WithMany(e => e.Products)
                .Map(m => m.ToTable("Product_ProductTag_Mapping"));

            modelBuilder.Entity<Product_ProductAttribute_Mapping>()
                .HasMany(e => e.ProductAttributeValues)
                .WithRequired(e => e.Product_ProductAttribute_Mapping)
                .HasForeignKey(e => e.ProductAttributeMappingId);

            modelBuilder.Entity<ProductAttributeCombination>()
                .Property(e => e.OverriddenPrice)
                .HasPrecision(18, 4);

            modelBuilder.Entity<ProductAttributeValue>()
                .Property(e => e.PriceAdjustment)
                .HasPrecision(18, 4);

            modelBuilder.Entity<ProductAttributeValue>()
                .Property(e => e.WeightAdjustment)
                .HasPrecision(18, 4);

            modelBuilder.Entity<ProductAttributeValue>()
                .Property(e => e.Cost)
                .HasPrecision(18, 4);
        }
    }
}
