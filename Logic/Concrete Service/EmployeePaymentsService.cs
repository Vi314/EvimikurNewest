using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using System.Net;

namespace Logic.Concrete_Service
{
    public class EmployeePaymentsService : IEmployeePaymentsService
    {
        private readonly IEmployeePaymentsRepository _repository;

        public EmployeePaymentsService(IEmployeePaymentsRepository repository)
        {
            _repository = repository;
        }

        public HttpStatusCode CreateOne(EmployeePaymentsModel dealer)
        {
            try
            {
                return _repository.Create(dealer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return HttpStatusCode.BadRequest;
            }
        }

        public HttpStatusCode CreateRange(IEnumerable<EmployeePaymentsModel> Thing)
        {
            try { return _repository.CreateRange(Thing); } catch (Exception e) { Console.WriteLine(e); return HttpStatusCode.BadRequest; }
        }

        public HttpStatusCode DeleteOne(int id)
        {
            try { return _repository.Delete(id); } catch (Exception e) { Console.WriteLine(e); return HttpStatusCode.BadRequest; }
        }

        public HttpStatusCode DeleteRange(IEnumerable<int> id)
        {
            try { return _repository.DeleteRange(id); } catch (Exception e) { Console.WriteLine(e); return HttpStatusCode.BadRequest; }
        }

        public IEnumerable<EmployeePaymentsModel> GetAll()
        {
            try { return _repository.GetAll(); } catch (Exception e) { Console.WriteLine(e); throw; }
        }

        public EmployeePaymentsModel GetById(int id)
        {
            try { return _repository.GetById(id); } catch (Exception e) { Console.WriteLine(e); throw; }
        }

        public HttpStatusCode UpdateOne(EmployeePaymentsModel dealer)
        {
            try { return _repository.Update(dealer); } catch (Exception e) { Console.WriteLine(e); return HttpStatusCode.BadRequest; }
        }

        public HttpStatusCode UpdateRange(IEnumerable<EmployeePaymentsModel> Thing)
        {
            try { return _repository.UpdateRange(Thing); } catch (Exception e) { Console.WriteLine(e); return HttpStatusCode.BadRequest; }
        }
    }
}