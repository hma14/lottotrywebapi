namespace Lottotry.WebApi.Dtos.Shared
{
    public abstract class BasePaginationParameters
    {
        internal virtual int MaxPageSize { get; } = 100;
        internal virtual int DefaultPageSize { get; set; } = 100;

        public virtual int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get
            {
                return DefaultPageSize;
            }
            set
            {
                DefaultPageSize = value > MaxPageSize ? MaxPageSize : value;
            }
        }
    }
}