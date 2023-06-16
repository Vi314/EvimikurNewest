using DataAccess;
using Entity.Base;
using Microsoft.EntityFrameworkCore;

namespace Logic;

public class EntityConnectionManager<TModel> : BaseRepository<TModel>, IEntityConnectionManager<TModel> where TModel : BaseEntity
{
	private readonly Context _context;
	private readonly DbSet<TModel> _entity;

	public EntityConnectionManager(Context context) : base(context)
	{
		_context = context;
		_entity = _context.Set<TModel>();
	}

	public string MainPropertyName { get; set; }
	public string ConnectionPropertyName { get; set; }

	public int GetMainProperty(TModel instance)
	{
		return Convert.ToInt32(_context.Entry(instance).Property(MainPropertyName).CurrentValue);
	}

	public int GetConnectionProperty(TModel instance)
	{
		return Convert.ToInt32(_context.Entry(instance).Property(ConnectionPropertyName).CurrentValue);
	}

	public TModel GetNew(int mainId, int connectionId)
	{
		var instance = Activator.CreateInstance<TModel>();
		_context.Entry(instance).Property(ConnectionPropertyName).CurrentValue = connectionId;
		_context.Entry(instance).Property(MainPropertyName).CurrentValue = mainId;

		return instance;
	}

	public IEnumerable<TModel> GetAllByMainId(int mainId)
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