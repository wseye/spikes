using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Specification.UnitTests
{
    [TestFixture]
    public class ProductPriceGreaterThanSpecificationTest
    {
        [Test]
        public void ShouldBeSatisfiedWhenProductPriceIsGreater()
        {
            Product p = new Product() { Name = "Portable", Price = 1999.99m, ItemsOnStock = 5 };

            ISpecification<Product> spec = new ProductPriceGreaterThanSpecification(1200m);
            Assert.IsTrue(spec.IsSatisfiedBy(p));            
        }

        [Test]
        public void ShouldNotBeSatisfiedWhenProductPriceIsLess()
        {
            Product p = new Product() { Name = "Portable", Price = 1999.99m, ItemsOnStock = 5 };

            ISpecification<Product> spec = new ProductPriceGreaterThanSpecification(3200m);
            Assert.IsFalse(spec.IsSatisfiedBy(p));
        }
    }
}
