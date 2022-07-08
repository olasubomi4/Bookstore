using System;
using rock.DataAccess.IRepository;
using rock.Models;

namespace rock.DataAccess.Repository.IRepository
{
	public interface IProduct:IRepository<Product>
    {

        void Update(Product t);
    }
	
}

