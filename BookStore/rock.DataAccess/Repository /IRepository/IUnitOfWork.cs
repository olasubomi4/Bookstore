using System;
namespace rock.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork
	{

		ICategory category { get; }
		ICoverType coverType { get; }
		IProduct  product { get; }
		void Save();
	}
}

