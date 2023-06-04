using DataAccess;
using Entity.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic;

public class TestRepo<T, X> : BaseRepository<T> where T : BaseEntity 
												where X : BaseEntity
{
	private readonly Context _context;
	private readonly DbSet<T> _entity;
	private readonly DbSet<X> _connectionEntity;

	public TestRepo(Context context) : base(context)
	{
		_context = context;
		_entity = _context.Set<T>();
		_connectionEntity = _context.Set<X>();
	}

	void UpdateConnections(int id, List<int> connectionIds)
	{
		
	}


}
