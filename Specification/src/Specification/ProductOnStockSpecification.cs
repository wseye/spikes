using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Specification
{
    public class ProductOnStockSpecification : ISpecification<Product>
    {
        #region ISpecification<Product> Members

        public bool IsSatisfiedBy(Product item)
        {
            return item.ItemsOnStock > 0;
        }

        #endregion
    }
}
