using DataAccess;
using Entity.Base;
using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic;

public class TestRepo<TMain, XConnect> : BaseRepository<TMain>, ITestRepo<TMain, XConnect> where TMain : BaseEntity 
																						   where XConnect : BaseEntity
{
	private readonly Context _context;
	private readonly DbSet<TMain> _entity;
	private readonly DbSet<XConnect> _connectionEntity;

	public TestRepo(Context context) : base(context)
	{
		_context = context;
		_entity = _context.Set<TMain>();
		_connectionEntity = _context.Set<XConnect>();
	}

	public string ConnectionPropertyName { get; set; }
	public string MainPropertyName { get; set; }

	public void CreateConnections(int id, List<int> connectionIds)
	{
		foreach (var i in connectionIds)
		{
            var instance = Activator.CreateInstance<XConnect>();
            _context.Entry(instance).Property(ConnectionPropertyName).CurrentValue = i;
            _context.Entry(instance).Property(MainPropertyName).CurrentValue = id;
			_connectionEntity.Add(instance);
        }

		_context.BulkSaveChanges();
    } 


	void UpdateConnections(int id, List<int> connectionIds)
	{
		
	}


}
