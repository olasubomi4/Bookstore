using System;
using rock.Data;
using rock.DataAccess.Repository.IRepository;
using rock.Models;
namespace rock.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverType
    {
        private readonly ApplicationDbContext _db;

        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }




        public void Update(CoverType obj)
        {


            _db.coverTypes.Update(obj);
        }

    }
}
