using DataAccess;
using Entity.Base;
using Microsoft.EntityFrameworkCore;

namespace Logic;

public class ConnectionRepository<TMain> : BaseRepository<TMain>, IConnectionRepository<TMain> where TMain : BaseEntity
{
    private readonly Context _context;
    private readonly DbSet<TMain> _entity;

    public ConnectionRepository(Context context) : base(context)
    {
        _context = context;
        _entity = _context.Set<TMain>();
    }

    public string MainPropertyName { get; set; }
    public string ConnectionPropertyName { get; set; }

    public int GetMainProperty(TMain instance)
    {
        return Convert.ToInt32(_context.Entry(instance).Property(MainPropertyName).CurrentValue);
    }

    public int GetConnectionProperty(TMain instance)
    {
        return Convert.ToInt32(_context.Entry(instance).Property(ConnectionPropertyName).CurrentValue);
    }

    public TMain GetNew(int mainId, int connectionId)
    {
        var instance = Activator.CreateInstance<TMain>();
        _context.Entry(instance).Property(ConnectionPropertyName).CurrentValue = connectionId;
        _context.Entry(instance).Property(MainPropertyName).CurrentValue = mainId;

        return instance;
    }

    public IEnumerable<TMain> GetAllByMainId(int mainId)
    {
        var connectionsList = base.GetAll();
        var connectionsByMainList = connectionsList.Where(x => GetMainProperty(x) == mainId).ToList();

        return connectionsByMainList;
    }

    public void CreateConnections(int id, List<int> connectionIds)
    {
        var newConnections = connectionIds.Select(x => GetNew(id, x));

        _context.BulkInsert(newConnections);
        _context.BulkSaveChanges();
    }

    public void UpdateConnections(int id, List<int> connectionIds)
    {
        var existingConnections = GetAllByMainId(id).ToList();

        var deletedConnections = existingConnections.Where(x => !connectionIds.Contains(GetConnectionProperty(x))).ToList();

        var newConnections = connectionIds
            .Where(x => existingConnections.FirstOrDefault(y => GetConnectionProperty(y) == x) == null)
            .Select(x => GetNew(id, x));

        _entity.BulkDelete(deletedConnections);
        _entity.BulkInsert(newConnections);
        _context.BulkSaveChanges();
    }

    public void DeleteConnections(int id)
    {
        var connectionsByMainList = GetAllByMainId(id);

        _entity.BulkDelete(connectionsByMainList);
        _context.BulkSaveChanges();
    }


}

