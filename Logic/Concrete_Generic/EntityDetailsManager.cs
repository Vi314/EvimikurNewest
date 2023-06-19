using DataAccess;
using Entity.Base;
using Logic.Abstract_Generic;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Logic.Concrete_Generic;

public class EntityDetailsManager<T> : IEntityDetailsManager<T> where T : BaseDetailsModel
{
    private readonly Context _context;
    private readonly DbSet<T> _entity;

    public EntityDetailsManager(Context context)
    {
        _context = context;
        _entity = _context.Set<T>();
    }
    
    public List<T> GetDetailsByHeaderId(int headerId)
    {
        try
        {
            return _entity.Where(x => x.HeaderId == headerId).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new();
        }
    }

    public HttpStatusCode BulkCreateDetails(List<T> models)
    {
        try
        {
            _context.BulkInsert(models);
            _context.BulkSaveChanges();
            return HttpStatusCode.Created;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode BulkDeleteDetails(int id)
    {
        try
        {
            var modelsToBeDeleted = GetDetailsByHeaderId(id);
            _context.BulkDelete(modelsToBeDeleted);
            _context.BulkSaveChanges();
            return HttpStatusCode.OK;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode BulkUpdateDetails(List<T> models, int headerId)
    {
        try
        {
            var existingDetailsList = GetDetailsByHeaderId(headerId);
            
            _context.BulkDelete(existingDetailsList.Where(x => !models.Contains(x)).ToList());
            _context.BulkInsert(existingDetailsList.Where(x => models.Contains(x)).ToList());
            
            _context.BulkUpdate(models);
            _context.BulkSaveChanges();
            return HttpStatusCode.OK;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

}
