using DataAccess;
using Entity.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic;

public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly Context _context;
    private readonly DbSet<T> _entity;

    public BaseRepository(Context context)
    {
        _context = context;
        _entity = context.Set<T>();
    }

    public virtual HttpStatusCode Create(T thing)
    {
        try
        {
            _entity.Add(thing);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
			return HttpStatusCode.OK;
        }
        catch (Exception ex)
        {
            return HttpStatusCode.BadRequest;
        }
    }
	public HttpStatusCode CreateRange(IEnumerable<T> Thing)
	{
		try
		{
            _context.BulkInsert(Thing);
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
            _context.SaveChanges();
			_context.ChangeTracker.Clear();

			return HttpStatusCode.OK;
        }
        catch (Exception ex)
        {
            return HttpStatusCode.BadRequest;
        }
    }
	public HttpStatusCode UpdateRange(IEnumerable<T> Thing)
	{
        try
        {
            _context.BulkUpdate(Thing);
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
			_context.SaveChanges();
			_context.ChangeTracker.Clear();

			return HttpStatusCode.OK;
		}
		catch (Exception ex)
		{
			return HttpStatusCode.BadRequest;
		}
	}
	public HttpStatusCode DeleteRange(IEnumerable<int> ids)
	{
		try
		{
			foreach (int id in ids)
			{
				Delete(id);
			}
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
            return null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
	public IEnumerable<T> GetByIds(IEnumerable<int> id)
	{
        //TODO NOT IMPLEMENTED PLS IMPLEMENT
		return _entity.Where(x => x.State != EntityState.Deleted).ToList();
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
