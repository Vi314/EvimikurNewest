using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Generic;

/// <summary>
/// Represents a base service interface that provides common CRUD operations for entities.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
public interface IBaseService<T> where T : BaseEntity
{
    /// <summary>
    /// Retrieves all entities.
    /// </summary>
    /// <returns>An enumerable collection of all entities.</returns>
    public IEnumerable<T> GetAll();

    /// <summary>
    /// Retrieves an entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to retrieve.</param>
    /// <returns>The entity with the specified ID.</returns>
    public T GetById(int id);

    /// <summary>
    /// Creates a new entity.
    /// </summary>
    /// <param name="thing">The entity to create.</param>
    /// <returns>The HTTP status code representing the result of the operation.</returns>
    public HttpStatusCode Create(T thing);

    /// <summary>
    /// Updates an existing entity.
    /// </summary>
    /// <param name="thing">The entity to update.</param>
    /// <returns>The HTTP status code representing the result of the operation.</returns>
    public HttpStatusCode Update(T thing);

    /// <summary>
    /// Deletes an entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    /// <returns>The HTTP status code representing the result of the operation.</returns>
    public HttpStatusCode Delete(int id);

    /// <summary>
    /// Creates multiple entities.
    /// </summary>
    /// <param name="things">The collection of entities to create.</param>
    /// <returns>The HTTP status code representing the result of the operation.</returns>
    public HttpStatusCode CreateRange(IEnumerable<T> things);

    /// <summary>
    /// Updates multiple entities.
    /// </summary>
    /// <param name="things">The collection of entities to update.</param>
    /// <returns>The HTTP status code representing the result of the operation.</returns>
    public HttpStatusCode UpdateRange(IEnumerable<T> things);

    /// <summary>
    /// Deletes multiple entities by their IDs.
    /// </summary>
    /// <param name="ids">The collection of IDs of the entities to delete.</param>
    /// <returns>The HTTP status code representing the result of the operation.</returns>
    public HttpStatusCode DeleteRange(IEnumerable<int> ids);
}
