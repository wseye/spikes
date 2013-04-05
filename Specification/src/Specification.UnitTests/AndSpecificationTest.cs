using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Specification.UnitTests
{
    [TestFixture]
    public class AndSpecificationTest
    {
        [Test]
        public void ShouldBeStatisfiedWhenLeftAndRightIsSatisfied()
        {
            Product p = new Product() { Name = "Portable", Price = 1999.99m, ItemsOnStock = 5 };

            ISpecification<Product> left = new ProductPriceGreaterThanSpecification(1200m);
            ISpecification<Product> right = new ProductOnStockSpecification();

            Assert.IsTrue(new AndSpecification<Product>(left, right).IsSatisfiedBy(p));
        }

        [Test]
        public void ShouldNotBeStatisfiedWhenLeftIsNotSatisfied()
        {
            Product p = new Product() { Name = "Portable", Price = 1999.99m, ItemsOnStock = 5 };

            ISpecification<Product> left = new ProductPriceGreaterThanSpecification(2200m);
            ISpecification<Product> right = new ProductOnStockSpecification();

            Assert.IsFalse(new AndSpecification<Product>(left, right).IsSatisfiedBy(p));
        }

        [Test]
        public void ShouldNotBeStatisfiedWhenRightIsNotSatisfied()
        {
            Product p = new Product() { Name = "Portable", Price = 1999.99m, ItemsOnStock = 0 };

            ISpecification<Product> left = new ProductPriceGreaterThanSpecification(1200m);
            ISpecification<Product> right = new ProductOnStockSpecification();

            Assert.IsFalse(new AndSpecification<Product>(left, right).IsSatisfiedBy(p));
        }

        [Test]
        public void ShouldNotBeStatisfiedWhenLeftAndRightIsNotSatisfied()
        {
            Product p = new Product() { Name = "Portable", Price = 1999.99m, ItemsOnStock = 0 };

            ISpecification<Product> left = new ProductPriceGreaterThanSpecification(2200m);
            ISpecification<Product> right = new ProductOnStockSpecification();

            Assert.IsFalse(new AndSpecification<Product>(left, right).IsSatisfiedBy(p));
        }
    }
}
