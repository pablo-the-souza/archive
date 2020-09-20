using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class PoliciesWithBoxSpecification : BaseSpecification<Policy>
    {
        public PoliciesWithBoxSpecification()
        {
            AddInclude(x => x.Box);
        }

        public PoliciesWithBoxSpecification(Guid id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Box);
        }
    }
}