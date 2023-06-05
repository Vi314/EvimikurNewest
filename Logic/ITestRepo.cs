using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic;

public interface ITestRepo<TMain>
{ 
    public void CreateConnections(int id, List<int> connectionIds);
    public string ConnectionPropertyName { get; set; }
    public string MainPropertyName { get; set; }
}
