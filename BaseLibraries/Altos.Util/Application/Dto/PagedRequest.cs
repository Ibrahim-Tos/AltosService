namespace Altos.Util.Application.Dto
{
    public abstract class PagedRequest
    {
        public int PageIndex { get; set; } = 0;
        private int ps = 10;
        public int PageSize { get { return (ps != 0) ? ps : int.MaxValue; } set { ps = value; } }
    }
}
