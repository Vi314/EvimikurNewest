using DataAccess;
using Entity.Base;
using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic;
//? CAN THIS BE RESOLVED WITH 1 GENERIC ?
public class TestRepo<TMain> : BaseRepository<TMain>, ITestRepo<TMain> where TMain : BaseEntity 
																						   
{
	private readonly Context _context;
	private readonly DbSet<TMain> _entity;

	public TestRepo(Context context) : base(context)
	{
		_context = context;
		_entity = _context.Set<TMain>();
	}

	public string ConnectionPropertyName { get; set; }
	public string MainPropertyName { get; set; }

	public void CreateConnections(int id, List<int> connectionIds)
	{
		foreach (var i in connectionIds)
		{
            var instance = Activator.CreateInstance<TMain>();
            _context.Entry(instance).Property(ConnectionPropertyName).CurrentValue = i;
            _context.Entry(instance).Property(MainPropertyName).CurrentValue = id;
			_entity.Add(instance);
        }

		_context.BulkSaveChanges();
    } 


	void UpdateConnections(int id, List<int> connectionIds)
	{
		
	}


}
