using System.Net;

namespace Logic;

/// <summary>
/// Base repository implementation for CRUD operations on entities of type T.
/// </summary>
/// <typeparam name="T">The type of the entities.</typeparam>
public interface IBaseRepository<T>
{
	/// <summary>
	/// Creates a new entity of type T.
	/// </summary>
	/// <param name="Thing">The entity to create.</param>
	/// <returns>The HTTP status code indicating the result of the operation.</returns>
	HttpStatusCode Create(T Thing);

	/// <summary>
	/// Creates a range of entities of type T.
	/// </summary>
	/// <param name="Thing">The range of entities to create.</param>
	/// <returns>The HTTP status code indicating the result of the operation.</returns>
	HttpStatusCode CreateRange(IEnumerable<T> Thing);

	/// <summary>
	/// Updates an existing entity of type T.
	/// </summary>
	/// <param name="Thing">The entity to update.</param>
	/// <returns>The HTTP status code indicating the result of the operation.</returns>
	HttpStatusCode Update(T Thing);

	/// <summary>
	/// Updates a range of existing entities of type T.
	/// </summary>
	/// <param name="Thing">The range of entities to update.</param>
	/// <returns>The HTTP status code indicating the result of the operation.</returns>
	HttpStatusCode UpdateRange(IEnumerable<T> Thing);

	/// <summary>
	/// Deletes an entity of type T by its ID.
	/// </summary>
	/// <param name="id">The ID of the entity to delete.</param>
	/// <returns>The HTTP status code indicating the result of the operation.</returns>
	HttpStatusCode Delete(int id);

	/// <summary>
	/// Deletes a range of entities of type T by their IDs.
	/// </summary>
	/// <param name="id">The IDs of the entities to delete.</param>
	/// <returns>The HTTP status code indicating the result of the operation.</returns>
	HttpStatusCode DeleteRange(IEnumerable<int> id);

	/// <summary>
	/// Retrieves all entities of type T.
	/// </summary>
	/// <returns>The collection of all entities.</returns>
	IEnumerable<T> GetAll();

	/// <summary>
	/// Retrieves an entity of type T by its ID.
	/// </summary>
	/// <param name="id">The ID of the entity to retrieve.</param>
	/// <returns>The retrieved entity, or null if not found.</returns>
	T GetById(int id);

	/// <summary>
	/// Retrieves a range of entities of type T by their IDs.
	/// </summary>
	/// <param name="id">The IDs of the entities to retrieve.</param>
	/// <returns>The retrieved entities.</returns>
	IEnumerable<T> GetByIds(IEnumerable<int> id);

	/// <summary>
	/// Executes a raw SQL command on the database.
	/// </summary>
	/// <param name="command">The SQL command to execute.</param>
	/// <returns>The number of rows affected.</returns>
	int ExecuteRawSql(string command);
}