using Aplication.Contract.DTOs;
using DomainShared.ViewModels.Movies;
using DomainShared.ViewModels.PagedResult;

namespace Aplication.Contract.Movies
{
    public interface IMovieAppServies
    {
        Task<PagedResulViewModel<MoviesListViewModel>> GetMoviesList(PaginationDto<MoviesListDTO> dto);
        Task<(string error, bool isSuccess)> Create(CreateMoviesDTO dto);
    }
}
