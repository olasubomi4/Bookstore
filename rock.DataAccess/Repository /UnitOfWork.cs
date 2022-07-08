using System;
using rock.Data;
using rock.DataAccess.Repository.IRepository;

namespace rock.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            category = new CategoryRepository(_db);
            coverType = new CoverTypeRepository(_db);
            product = new ProductRepository(_db);

        }
        


        public ICategory category { get; private set; }

        public ICoverType coverType { get; private set; }
        public IProduct product { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

