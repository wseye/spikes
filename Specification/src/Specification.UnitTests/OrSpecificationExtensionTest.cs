using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Specification.UnitTests
{
    [TestFixture]
    public class OrSpecificationExtensionTest
    {
        [Test]
        public void ShouldBeSatisfiedWhenLeftAndRightIsSatisfied()
        {
            Product p = new Product() { Name = "Portable", Price = 1999.99m, ItemsOnStock = 5 };

            ISpecification<Product> left = new ProductPriceGreaterThanSpecification(1200m);
            ISpecification<Product> right = new ProductOnStockSpecification();

            Assert.IsTrue(left.Or(right).IsSatisfiedBy(p));
        }

        [Test]
        public void ShouldBeSatisfiedWhenOnlyLeftIsSatisfied()
        {
            Product p = new Product() { Name = "Portable", Price = 1999.99m, ItemsOnStock = 0 };

            ISpecification<Product> left = new ProductPriceGreaterThanSpecification(1200m);
            ISpecification<Product> right = new ProductOnStockSpecification();

            Assert.IsTrue(left.Or(right).IsSatisfiedBy(p));
        }

        [Test]
        public void ShouldBeSatisfiedWhenOnlyRightIsSatisfied()
        {
            Product p = new Product() { Name = "Portable", Price = 1999.99m, ItemsOnStock = 5 };

            ISpecification<Product> left = new ProductPriceGreaterThanSpecification(2200m);
            ISpecification<Product> right = new ProductOnStockSpecification();

            Assert.IsTrue(left.Or(right).IsSatisfiedBy(p));
        }

        [Test]
        public void ShouldNotBeStatisfiedWhenLeftAndRightIsNotSatisfied()
        {
            Product p = new Product() { Name = "Portable", Price = 1999.99m, ItemsOnStock = 0 };

            ISpecification<Product> left = new ProductPriceGreaterThanSpecification(2200m);
            ISpecification<Product> right = new ProductOnStockSpecification();

            Assert.IsFalse(left.Or(right).IsSatisfiedBy(p));
        }
    }
}
