using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes__.Utilities
{
    public class LayoutService
    {
        private string _pageTitle = "Untitled Note Page";
        public string PageTitle
        {
            get => _pageTitle;
            set { _pageTitle = value; }
        }
    }
}
