namespace Logic;

/// <summary>
/// Performs logic for connection entities.
/// Requires the Main PropertyName and ConnectionPropertyName Properties be set to function.
/// </summary>
/// <typeparam name="TMain">The Connection Entity</typeparam>
public interface IEntityConnectionManager<TMain>
{
	///// <summary>
	///// Retrieves the value of the main property for a given instance.
	///// </summary>
	///// <param name="instance">The instance of the connection entity.</param>
	///// <returns>The value of the main property as an integer.</returns>
	//public int GetMainProperty(TMain instance);

	///// <summary>
	///// Retrieves the value of the connection property for a given instance.
	///// </summary>
	///// <param name="instance">The instance of the connection entity.</param>
	///// <returns>The value of the connection property as an integer.</returns>
	//public int GetConnectionProperty(TMain instance);

	///// <summary>
	///// Creates a new instance of the connection entity with the specified main and connection IDs.
	///// </summary>
	///// <param name="mainId">The ID of the main entity.</param>
	///// <param name="connectionId">The ID of the connection entity.</param>
	///// <returns>Returns: A new instance of the connection entity.</returns>
	//public TMain GetNew(int mainId, int connectionId);

	///// <summary>
	///// Retrieves all connection entities associated with a specific main ID.
	///// </summary>
	///// <param name="mainId">The ID of the main entity.</param>
	///// <returns>Returns: An enumerable collection of connection entities filtered by the main ID.</returns>
	//public IEnumerable<TMain> GetAllByMainId(int mainId);

	/// <summary>
	/// Creates new connection entities for a specific main entity using the provided connection IDs.
	/// </summary>
	/// <param name="id">The ID of the main entity.</param>
	/// <param name="connectionIds">The list of connection IDs.</param>
	public void CreateConnections(int id, List<int> connectionIds);

	/// <summary>
	/// Updates the connections of a specific main entity based on the provided connection IDs.
	/// </summary>
	/// <param name="id">The ID of the main entity.</param>
	/// <param name="connectionIds">The list of connection IDs.</param>
	public void UpdateConnections(int id, List<int> connectionIds);

	/// <summary>
	/// Deletes all connection entities associated with a specific main entity.
	/// </summary>
	/// <param name="id">The ID of the main entity.</param>
	public void DeleteConnections(int id);

	/// <summary>
	/// Gets or sets the name of the connection property.
	/// </summary>
	public string ConnectionPropertyName { get; set; }

	/// <summary>
	/// Gets or sets the name of the main property used for the connection.
	/// </summary>
	public string MainPropertyName { get; set; }
}