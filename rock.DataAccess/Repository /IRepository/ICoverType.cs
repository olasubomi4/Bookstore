using System;
using rock.DataAccess.IRepository;
using rock.Models;
namespace rock.DataAccess.Repository.IRepository
{
	public interface ICoverType:IRepository<CoverType>
	{

		void Update(CoverType t);
	}
}

