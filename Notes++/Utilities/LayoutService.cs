using System;

namespace Notes__.Utilities
{
    public class LayoutService
    {
        public event Action OnChange;

        private string _pageTitle = "Your Folders"; // Default title on app load

        public string PageTitle
        {
            get => _pageTitle;
            set
            {
                if (_pageTitle != value)
                {
                    Console.WriteLine($"[DEBUG] PageTitle updated: {_pageTitle} → {value}"); // Log changes
                    _pageTitle = value;
                    NotifyStateChanged();
                }
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}