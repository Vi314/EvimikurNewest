using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IDealerRepository
	{
		string Create(Dealer dealer);
		string Update(Dealer dealer);
		string Delete(int id);
		Dealer GetById(int id);
		IEnumerable<Dealer> GetAll();
		int ExecuteRawSql(string command);
	}
}
