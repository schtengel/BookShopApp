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


        [RelayCommand]
        private void LoginUser()
        {
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля для входа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var user = Db.Context.Users
                .FirstOrDefault(u => u.Login == Login && u.Password == Password);

            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show($"Добро пожаловать, {user.Fio}!", "Успешный вход", MessageBoxButton.OK, MessageBoxImage.Information);
            OpenProductWindow(user);
        }

        [RelayCommand]
        private static void EnterGuest()
        {
            MessageBox.Show("Вы вошли как гость. Доступ к управлению товарами ограничен.", "Вход как гость", MessageBoxButton.OK, MessageBoxImage.Information);
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
