using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TIEDPAG.Common;

namespace TIEDPAG.Dispense.IDAL
{
    public interface IBaseDAL<T>: IDiBase
    {
        T Find<Tkey>(Tkey key);

        IQueryable<T> FindAll(Expression<Func<T, bool>> conditions);

        IQueryable<T> FindAll<TField>(Expression<Func<T, bool>> conditions, Expression<Func<T, TField>> orderExpression, bool isAsc, int pageIndex, int pageSize, out int total);

        bool Add(T entity);

        bool Delete(T key);

        bool Update(T entity);

        bool SaveChange();
    }
}
