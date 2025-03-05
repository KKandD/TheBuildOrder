namespace Application.Interfaces.Mappers
{
    public interface IMapper<TEntity, TDto>
    {
        TEntity MapToEntity(TDto dto);
        TDto MapToDto(TEntity entity);
    }
}
