using DomainShared.Constants;

namespace Aplication.Contract.DTOs
{
    public class PaginationDto<T>
    {
        public int PageCount { get; set; } = CoreConstants.PageCount;
        public int PageNumber { get; set; } = 1;
        public T SearchParams { get; set; } = default!;
    }
}
