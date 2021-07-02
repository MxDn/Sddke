using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sddke.Shared.Domain.Specification
{
    /// <summary>
    /// The i specification.
    /// </summary>
    public interface ISpecification<T>
    {

        /// <summary>
        /// Gets the criteria.
        /// </summary>
        Expression<Func<T, bool>> Criteria { get; }

        /// <summary>
        /// Gets the includes.
        /// </summary>
        List<Expression<Func<T, object>>> Includes { get; }

        /// <summary>
        /// Gets the include strings.
        /// </summary>
        List<string> IncludeStrings { get; }
    }
}
