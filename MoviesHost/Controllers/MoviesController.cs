using Aplication.Contract.DTOs;
using Aplication.Contract.Movies;
using DomainShared.ViewModels.Movies;
using DomainShared.ViewModels.PagedResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MoviesHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMovieAppServies _movieServies;

        public MoviesController(IMovieAppServies movieServies)
        {
            _movieServies = movieServies;
        }

        [HttpGet]
        [Route("")]
        public async Task<PagedResulViewModel<MoviesListViewModel>> GetMoviesList([FromQuery]PaginationDto<MoviesListDTO> dto)
        {
            return await _movieServies.GetMoviesList(dto);
        }


        [HttpPost]
        [Route("")]
        public async Task<(string error, bool isSuccess)> CreateMovies(CreateMoviesDTO dto)
        {
            return await _movieServies.Create(dto);
        }
    }
}
