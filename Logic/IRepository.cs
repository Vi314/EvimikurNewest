using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic;

public interface IRepository<T>
{
    string Create(T Thing);
    string Update(T Thing);
    string Delete(int id);

    IEnumerable<T> GetAll();
    T GetById(int id);
    int ExecuteRawSql(string command);

}
