namespace StorageMaster.Factories
{
    using System;
    using Entities.Products;

    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            Product product;

            switch (type)
            {
                case nameof(Gpu):
                    product = new Gpu(price);
                    break;
                case nameof(HardDrive):
                    product = new HardDrive(price);
                    break;
                case nameof(Ram):
                    product = new Ram(price);
                    break;
                case nameof(SolidStateDrive):
                    product = new SolidStateDrive(price);
                    break;
                default:
                    throw new InvalidOperationException("Invalid product type!");
            }

            return product;
        }
    }
}