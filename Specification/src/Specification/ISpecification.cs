using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Specification
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T item);
    }
}
