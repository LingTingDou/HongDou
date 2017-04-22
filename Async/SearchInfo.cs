using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Async
{
    public class SearchInfo:BindableBase
    {
        public SearchInfo() {
        }

        private string searchTerm;
        public string SearchTerm {
            get { return searchTerm; }
            set { SetProperty(ref searchTerm, value); }
        }

        private ObservableCollection<SearchItemResult> list;
        public ObservableCollection<SearchItemResult> List {
            get { return list; }
        }

    }
}
