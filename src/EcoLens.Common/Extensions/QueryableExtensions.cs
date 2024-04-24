namespace EcoLens.Common.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int page, int pageSize)
    {
        int skip = (page - 1) * pageSize;
        return query.Skip(skip).Take(pageSize);
    }
}

