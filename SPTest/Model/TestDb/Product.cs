using System;
using System.Collections.Generic;

#nullable disable

namespace SPTest.Model.TestDb
{
    public partial class Product
    {
        public Product()
        {
            ProductVersions = new HashSet<ProductVersion>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProductVersion> ProductVersions { get; set; }
    }
}
