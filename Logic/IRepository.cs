using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic;

public interface IRepository<T>
{
    HttpStatusCode Create(T Thing);
	HttpStatusCode CreateRange(IEnumerable<T> Thing);
	
	HttpStatusCode Update(T Thing);
	HttpStatusCode UpdateRange(IEnumerable<T> Thing);
	
	HttpStatusCode Delete(int id);
	HttpStatusCode DeleteRange(IEnumerable<int> id);

	IEnumerable<T> GetAll();
	
	T GetById(int id);
	IEnumerable<T> GetByIds(IEnumerable<int> id);


	int ExecuteRawSql(string command);

}
