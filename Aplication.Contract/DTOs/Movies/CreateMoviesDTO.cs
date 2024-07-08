namespace Aplication.Contract.DTOs
{
    public record CreateMoviesDTO(string name, byte rate, Guid catequryId, Guid genreId);
}
