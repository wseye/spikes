using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Specification
{
    public class ProductPriceGreaterThanSpecification : ISpecification<Product>
    {
        private decimal _price;

        public ProductPriceGreaterThanSpecification(decimal price)
        {
            _price = price;
        }

        #region ISpecification<Product> Members

        public bool IsSatisfiedBy(Product item)
        {
            return item.Price > _price;
        }

        #endregion
    }
}
