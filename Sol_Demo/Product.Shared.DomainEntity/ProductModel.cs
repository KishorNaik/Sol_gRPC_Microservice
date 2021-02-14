using System;

namespace Product.Shared.DomainEntity
{
    public class ProductModel
    {
        public Guid? ProductIdentity { get; set; }

        public String ProductName { get; set; }

        public double UnitPrice { get; set; }
    }
}