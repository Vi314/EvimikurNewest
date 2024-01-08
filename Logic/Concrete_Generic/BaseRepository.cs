using DataAccess;
using Entity.Base;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Logic;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly DataAccess.Context _context;
    private readonly DbSet<T> _entity;

    public BaseRepository(DataAccess.Context context)
    {
        _context = context;
        _entity = context.Set<T>();
    }

    public virtual HttpStatusCode Create(T thing)
    {
        try
        {
            var entity = _entity.Add(thing);
            var result = _context.SaveChanges();
            _context.ChangeTracker.Clear();
            if (result == 1)
                return HttpStatusCode.Created;
            
            return HttpStatusCode.BadRequest;
        }
        catch (Exception ex)    
        {
            Console.WriteLine(ex);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode CreateRange(IEnumerable<T> Thing)
    {
        try
        {
            if (!Thing.Any())
                return HttpStatusCode.BadRequest;
            _context.BulkInsert(Thing);
            _context.BulkSaveChanges();
			return HttpStatusCode.OK;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public virtual HttpStatusCode Update(T Thing)
    {
        try
        {
            _entity.Entry(Thing).State = EntityState.Modified;
            var result = _context.SaveChanges();
            _context.ChangeTracker.Clear();
            if (result == 1)
                return HttpStatusCode.OK;

            return HttpStatusCode.BadRequest;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode UpdateRange(IEnumerable<T> Thing)
    {
        try
        {
            if (!Thing.Any())
                return HttpStatusCode.BadRequest;
            _context.BulkUpdate(Thing);
            _context.BulkSaveChanges();
            return HttpStatusCode.OK;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public virtual HttpStatusCode Delete(int id)
    {
        try
        {
            var entity = GetById(id);
            entity.State = EntityState.Deleted;
            Update(entity);
            var result = _context.SaveChanges();
            _context.ChangeTracker.Clear();
            if (result == 1)
                return HttpStatusCode.OK;

            return HttpStatusCode.BadRequest;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode DeleteRange(IEnumerable<int> ids)
    {
        try
        {
            if (!ids.Any())
                return HttpStatusCode.BadRequest;
            _context.BulkDelete(GetByIds(ids));
            _context.BulkSaveChanges();
			return HttpStatusCode.OK;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public virtual T GetById(int id)
    {
        try
        {
            var entity = _entity.Find(id);
            if (entity.State != EntityState.Deleted)
            {
                return entity;
            }
            throw new NullReferenceException();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
			throw new NullReferenceException();
		}
	}

	public IEnumerable<T> GetByIds(IEnumerable<int> ids)
    {
        return _entity.Where(x => x.State != EntityState.Deleted && ids.Contains(x.Id));
    }

    public virtual IEnumerable<T> GetAll()
    {
        return _entity.Where(x => x.State != EntityState.Deleted).ToList();
    }

    public virtual int ExecuteRawSql(string command)
    {
        return _context.Database.ExecuteSqlRaw(command);
    }
}