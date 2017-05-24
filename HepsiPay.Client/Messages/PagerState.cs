namespace HepsiPay.Client.Messages
{
    public class PagerState
    {
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public int PageIndex { get; set; }
        public long PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}