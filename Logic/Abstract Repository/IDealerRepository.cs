using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Repository
{
    public interface IDealerRepository
    {
        HttpStatusCode Create(DealerModel dealer);

        HttpStatusCode Update(DealerModel dealer);

        HttpStatusCode Delete(int id);

        HttpStatusCode CreateRange(IEnumerable<DealerModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<DealerModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        DealerModel GetById(int id);

        IEnumerable<DealerModel> GetAll();

        int ExecuteRawSql(string command);
    }
}