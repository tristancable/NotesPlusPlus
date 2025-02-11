using System;

namespace Notes__.Utilities
{
    public class LayoutService
    {
        public enum EFormat
        {
            BASIC,
            BULLETPOINT,
            NUMBERED
        }
        private EFormat _format = EFormat.BASIC;
        public EFormat Format
        {
            get => _format;
            set => _format = value;
        }
        private int _editNumber = -1;
        public int EditNumber
        {
            get => _editNumber;
            set => _editNumber = value;
        }
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