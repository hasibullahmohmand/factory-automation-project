using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FactoryProject.Infrastructure.Utilities;

public class PagedList<T> : List<T>
{
    public MetaData MetaData{ get; private set; }
    public PagedList(IEnumerable<T> items, int pageNumber,int pageSize,int count)
    {
        MetaData = new MetaData
        {
            TotalCount=count,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalPage =(int)Math.Ceiling(count/(double)pageSize)
        };
        AddRange(items);
    }
    public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
    {
        int count = source.ToList().Count;
        var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        return new PagedList<T>(items,pageNumber,pageSize,count);
    }
}