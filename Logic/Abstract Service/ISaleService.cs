using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Service
{
    public interface ISaleService
    {
        string CreateOne(Sale sale);

		string CreateOne(Sale sale, List<int> dealerId, List<int> productId);
        string UpdateOne(Sale sale);

		string UpdateOne(Sale sale, List<int> dealerId, List<int> productId);
        string DeleteOne(int id);
        IEnumerable<Sale> GetAll();
        Sale GetById(int id);
    }
}
