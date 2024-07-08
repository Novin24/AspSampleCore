namespace Aplication.Contract.DTOs
{
    public record MoviesListDTO
    {
        public string Name { get; set; } = default!;
        public Guid CatequryId { get; set; }
        public Guid GenreId { get; set; }
        public int PageNumber { get; set; }
        public int? PageCount { get; set; }
    }
}
