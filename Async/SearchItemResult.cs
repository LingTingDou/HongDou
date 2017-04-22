using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Prism.Mvvm;

namespace Async
{
    public class SearchItemResult : BindableBase
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string url;
        public string Url
        {
            get { return url; }
            set { SetProperty(ref url, value); }
        }

        private string thumbnailUrl;
        public string ThumbnailUrl
        {
            get { return thumbnailUrl; }
            set { SetProperty(ref thumbnailUrl, value); }
        }

        private string source;
        public string Source
        {
            get { return source; }
            set { SetProperty(ref source, value); }
        }
    }
}
