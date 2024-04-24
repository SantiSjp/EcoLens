using EcoLens.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EcoLens.Common;

public class PaginatedList<T> : List<T>
{
    public int PageIndex { get; private set; }

    public int TotalPages { get; private set; }

    public int TotalItems { get; private set; }

    public int NumItemsStartPage { get; private set; }

    public int NumItemsEndPage { get; private set; }

    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        TotalItems = count;
        var result = (pageIndex * pageSize);
        NumItemsStartPage = (result - pageSize) + 1;
        NumItemsEndPage = result > TotalItems ? TotalItems : result;
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        AddRange(items);
    }

    public bool HasPreviousPage => (PageIndex > 1);

    public bool HasNextPage => (PageIndex < TotalPages);

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int page, int limit)
    {
        var count = await source.CountAsync();
        var items = await source.Paginate(page, limit).ToListAsync();
        return new PaginatedList<T>(items, count, page, limit);
    }
}


