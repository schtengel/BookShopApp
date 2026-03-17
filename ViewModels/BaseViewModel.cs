using CommunityToolkit.Mvvm.ComponentModel; // Позволяет не создавать RelayCommand и не реализовывать INotifyPropertyChanged

namespace BookShopApp.ViewModels
{
    public class BaseViewModel : ObservableValidator
    {
    }
}
