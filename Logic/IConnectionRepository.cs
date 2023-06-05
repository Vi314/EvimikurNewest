namespace Logic;

public interface IConnectionRepository<TMain>
{
    public void CreateConnections(int id, List<int> connectionIds);

    public void UpdateConnections(int id, List<int> connectionIds);

    public void DeleteConnections(int id);

    public string ConnectionPropertyName { get; set; }
    public string MainPropertyName { get; set; }
}