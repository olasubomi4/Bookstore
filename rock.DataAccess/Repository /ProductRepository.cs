using System;
using rock.Data;
using rock.DataAccess.Repository.IRepository;
using rock.Models;

namespace rock.DataAccess.Repository
{
	public class ProductRepository: Repository<Product>, IProduct

	{ 
		private  ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }




        public void Update(Product obj)
        {
            var objFromDb = _db.products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {

                objFromDb.Title = obj.Title;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Author = obj.Author;
                objFromDb.CoverTypeId = obj.CoverTypeId;

                if(obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
		        }
	    
	    
	    
	        
	    
	        }

         
        }



   }

		
}


