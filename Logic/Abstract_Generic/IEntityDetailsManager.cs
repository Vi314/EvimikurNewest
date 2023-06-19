using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Generic;

public interface IEntityDetailsManager<T> where T : BaseDetailsModel
{
    public List<T> GetDetailsByHeaderId(int headerId);
    public HttpStatusCode BulkCreateDetails(List<T> models);
    public HttpStatusCode BulkUpdateDetails(List<T> models, int headerId);
    public HttpStatusCode BulkDeleteDetails(int modelIds);
}

