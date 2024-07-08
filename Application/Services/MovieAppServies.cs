using Aplication.Contract.DTOs;
using Aplication.Contract.Movies;
using Domain.IRepositories;
using DomainShared.ViewModels.Movies;
using DomainShared.ViewModels.PagedResult;

namespace Application.Services
{
    public class MovieAppServies(IUnitOfWork unitOfWork) : IMovieAppServies
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<(string error, bool isSuccess)> Create(CreateMoviesDTO dto)
        {
            try
            {
                // check if catequry or genre is not exest => errore logic
                await _unitOfWork.MoviesRepository.Create(dto.name, dto.rate, dto.catequryId, dto.genreId);
                await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                if (ex is ArgumentException aex)
                {
                    return new(aex.Message, false);
                }
                return new(" خطا در اتصال به پایگاه داده code(47t46993)!!!", false);
            }
            return new(string.Empty, true);
        }

        public async Task<PagedResulViewModel<MoviesListViewModel>> GetMoviesList(PaginationDto<MoviesListDTO> dto)
        {
            return await _unitOfWork.MoviesRepository.GetMoviesList(dto.SearchParams.Name, dto.SearchParams.CatequryId, dto.SearchParams.GenreId, dto.PageNumber, dto.PageCount);
        }
    }
}
