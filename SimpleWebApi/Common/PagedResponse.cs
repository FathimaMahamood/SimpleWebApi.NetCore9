namespace SimpleWebApi.Common
{
    public class PagedResponse<T>
    {
        public IReadOnlyList<T> Data { get; set; }= new List<T>();
        public int TotalRecords { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool HasNext => Page * PageSize < TotalRecords;
    }
}
