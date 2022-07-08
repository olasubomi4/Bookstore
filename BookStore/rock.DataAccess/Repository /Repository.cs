using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using rock.Data;
using rock.DataAccess.IRepository;

namespace rock.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _db;

		internal DbSet<T> dbSet;

		public Repository(ApplicationDbContext db)
		{
			_db = db;
			//s_db.products.Include(u=>u.Category).Include(u=>u.CoverType)
			this.dbSet = _db.Set<T>();

			
		}

	

		public void Add(T entity)
		{
			dbSet.Add(entity);	
		}
		public IEnumerable<T> GetAll(string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			if(includeProperties != null)
			{
				foreach(var includePrep in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includePrep);
				}
			
			 }


            return query.ToList();
		}

		public T GetFirstOrDefault(Expression<Func<T,bool>> filter, string? includeProperties = null) {

            IQueryable<T> query = dbSet;
	        query =query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includePrep in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includePrep);
                }

            }
            return query.FirstOrDefault();
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entity)
		{
			dbSet.RemoveRange(entity);
		}

		

	}
}

