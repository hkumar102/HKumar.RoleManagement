
namespace HKumar.RoleManagement.Models
{
    public class PageRequest
    {

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortOrder { get; set; }
        public string SortProperty { get; set; }
        public string Keyword { get; set; }
    }
}
