using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TIEDPAG.Dispense.DAL
{
    public class BaseDAL<T> where T : class
    {
        private tiedpag_dispenseContext dbContext { get; set; }

        public BaseDAL()
        {
            dbContext = new tiedpag_dispenseContext();
        }

        public T Find<Tkey>(Tkey key)
        {
            return dbContext.Find<T>(key);
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> conditions)
        {
            return dbContext.Set<T>().Where(conditions);
        }

        public IQueryable<T> FindAll<TField>(Expression<Func<T, bool>> conditions, Expression<Func<T, TField>> orderExpression, bool isAsc, int pageIndex, int pageSize, out int total)
        {
            var qList = FindAll(conditions);
            total = qList.Count();
            var orderQList = isAsc ? qList.OrderBy(orderExpression) : qList.OrderByDescending(orderExpression);
            return orderQList.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public bool Add(T entity)
        {
            try
            {
                dbContext.Add(entity);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Delete(T key)
        {
            try
            {
                dbContext.Remove(key);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Update(T entity)
        {
            try
            {
                dbContext.Update(entity);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool SaveChange()
        {
            try
            {
                return dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
