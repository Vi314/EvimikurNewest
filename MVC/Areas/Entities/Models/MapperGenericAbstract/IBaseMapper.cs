using Entity.Base;
using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstractGeneric;

/// <summary>
/// Represents a base mapper interface that provides mapping operations between DTOs and entity models.
/// </summary>
/// <typeparam name="Dto">The type of the data transfer object (DTO).</typeparam>
/// <typeparam name="Model">The type of the entity model.</typeparam>
public interface IBaseMapper<Dto, Model> 
    where Dto : BaseDto
    where Model : BaseEntity
{
    /// <summary>
    /// Converts a DTO to an entity model.
    /// </summary>
    /// <param name="dto">The DTO object to convert.</param>
    /// <returns>The entity model converted from the DTO.</returns>
    public Model FromDto(Dto dto);

    /// <summary>
    /// Converts an entity model to a DTO.
    /// </summary>
    /// <param name="entity">The entity model to convert.</param>
    /// <returns>The DTO converted from the entity model.</returns>
    public Dto FromEntity(Model entity);

    /// <summary>
    /// Converts a collection of entity models to a collection of DTOs.
    /// </summary>
    /// <param name="entities">The collection of entity models to convert.</param>
    /// <returns>The collection of DTOs converted from the entity models.</returns>
    public IEnumerable<Dto> FromEntityRange(IEnumerable<Model> entities);

    /// <summary>
    /// Converts a collection of DTOs to a collection of entity models.
    /// </summary>
    /// <param name="dtos">The collection of DTOs to convert.</param>
    /// <returns>The collection of entity models converted from the DTOs.</returns>
    public IEnumerable<Model> FromDtoRange(IEnumerable<Dto> dtos);
}