using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Specification.UnitTests
{
    [TestFixture]
    public class ProductOnStockSpecificationTest
    {
        [Test]
        public void ShouldBeSatisfiedIfProductHasStock()
        {
            Product p = new Product() { Name = "Portable", Price = 1999.99m, ItemsOnStock = 5 };

            ISpecification<Product> spec = new ProductOnStockSpecification();
            Assert.IsTrue(spec.IsSatisfiedBy(p));
        }

        [Test]
        public void ShouldNotBeSatisfiedIfProductHasNoStock()
        {
            Product p = new Product() { Name = "Portable", Price = 1999.99m, ItemsOnStock = 0 };

            ISpecification<Product> spec = new ProductOnStockSpecification();
            Assert.IsFalse(spec.IsSatisfiedBy(p));
        }
    }
}
