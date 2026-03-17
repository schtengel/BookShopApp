using BookShopApp;
using BookShopApp.Models;
using BookShopApp.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace shoesAppClone.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {

        [ObservableProperty] // Автоматически создает геттер-сеттер
        private string? _login;

        [ObservableProperty]
        private string? _password;

        public LoginViewModel()
        {

        }


        [RelayCommand] // Автоматический создает команду для реализации этого метода
        private void LoginUser()
        {
            var user = Db.Context.Users
                .FirstOrDefault(u => u.Login == Login && u.Password == Password);

            if (user == null)
            {
                MessageBox.Show("Неверный пароль");
                return;
            }

            OpenProductWindow(user);
        }

        [RelayCommand]
        private static void EnterGuest()
        {
            OpenProductWindow(null);
        }

        private static void OpenProductWindow(User? user)
        {
            new MainWindow(new MainViewModel(user)).Show();

            Application.Current.Windows
                .OfType<BookShopApp.Views.LoginWindow>()
                .First()
                .Close();
        }

    }
}
