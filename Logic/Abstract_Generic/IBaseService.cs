using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Generic;

public interface IBaseService<T> where T : BaseEntity
{
    public IEnumerable<T> GetAll();
    public T GetById(int id);
    
    public HttpStatusCode Create(T thing);
    public HttpStatusCode Update(T thing);
    public HttpStatusCode Delete(int id);

    public HttpStatusCode CreateRange(IEnumerable<T> things);
    public HttpStatusCode UpdateRange(IEnumerable<T> things);
    public HttpStatusCode DeleteRange(IEnumerable<int> ids);


}
