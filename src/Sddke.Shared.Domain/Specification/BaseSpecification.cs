using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sddke.Shared.Domain.Specification
{
    /// <summary>
    /// The base specification.
    /// </summary>
    public abstract class BaseSpecification<T> : ISpecification<T>
    {

        /// <summary>
        /// The .ctor.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        /// <summary>
        /// Gets the criteria.
        /// </summary>
        public Expression<Func<T, bool>> Criteria { get; }

        /// <summary>
        /// Gets the includes.
        /// </summary>
        public List<Expression<Func<T, object>>> Includes { get; } =
                                               new List<Expression<Func<T, object>>>();

        /// <summary>
        /// Gets the include strings.
        /// </summary>
        public List<string> IncludeStrings { get; } = new List<string>();

        /// <summary>
        /// The add include.
        /// </summary>
        /// <param name="includeExpression">The include expression.</param>
        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        /// <summary>
        /// The add include.
        /// </summary>
        /// <param name="includeString">The include string.</param>
        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }
    }
}
