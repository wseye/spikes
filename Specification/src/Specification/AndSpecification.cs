using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Specification
{
    public class AndSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        #region ISpecification<T> Members

        public bool IsSatisfiedBy(T item)
        {
            return _left.IsSatisfiedBy(item) && _right.IsSatisfiedBy(item);
        }

        #endregion
    }
}
