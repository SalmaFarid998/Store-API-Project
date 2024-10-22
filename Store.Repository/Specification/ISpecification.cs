using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specification
{
    public interface ISpecification<T>
    {
        //For where conditions
        Expression<Func<T, bool>> Criteria { get; }
        //For Includes
        List<Expression<Func<T,object>>> Includes { get; }
        //For Order
        Expression<Func<T,object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDesc { get; }
        //For pagination
        int Take { get; }
        int Skip { get; }
        bool IsPaginated { get; }


    }
}
