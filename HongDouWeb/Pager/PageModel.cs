using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HongDouWeb.Pager
{
    public class PageModel<T> where T : new()
    {
        public List<T> list;
        public int currentPage;
        public int totalPages;
        public int totalRecords;
        public bool error { get; set; }
    }
}