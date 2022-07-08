using System;
using rock.Data;
using rock.DataAccess.IRepository;
using rock.DataAccess.Repository.IRepository;
using rock.Models;

namespace rock.DataAccess.Repository
{
	public class CategoryRepository: Repository<Category>, ICategory

	{ 
		private readonly ApplicationDbContext _db;
	
		public CategoryRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
			
		}



       
        public void Update(Category obj)
		{

		   	
          _db.categories.Update(obj);
		}			


        
        }
	}


