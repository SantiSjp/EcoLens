namespace EcoLens.Common.Response;

public class PaginationResponse<T> where T : IResponse
{
    public long TotalCount { get; set; }
    public int PageSize { get; set; } = 10;
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public bool HasNext { get; set; }
    public bool HasPrevious { get; set; }
    public IEnumerable<T>? Data { get; set; }
}

