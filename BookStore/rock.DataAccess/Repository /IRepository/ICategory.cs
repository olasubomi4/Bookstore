using System;
using rock.DataAccess.IRepository;
using rock.Models;

namespace rock.DataAccess.Repository.IRepository
{
	public interface ICategory : IRepository<Category>
	{
		void Update(Category obj);


	}
}

