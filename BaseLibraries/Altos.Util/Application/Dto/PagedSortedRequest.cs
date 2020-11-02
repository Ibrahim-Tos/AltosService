namespace Altos.Util.Application.Dto
{
    public abstract class PagedSortedRequest : PagedRequest
    {
        public string SortProperty { get; set; }
        public SortDirection? SortDirection { get; set; }
    }
}
