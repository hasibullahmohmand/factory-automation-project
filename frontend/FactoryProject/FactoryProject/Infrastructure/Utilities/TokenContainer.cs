using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FactoryProject.Infrastructure.Utilities
{
    public class TokenContainer: INotifyPropertyChanged
    {
        private string? _token;

        public string Token
        {
            get => _token!;
            set
            {
                _token = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}