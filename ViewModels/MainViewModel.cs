using BookShopApp;
using BookShopApp.Models;
using BookShopApp.ViewModels;
using BookShopApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;

namespace BookShopApp.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        public bool IsManager { get; }
        public bool IsAdmin { get; }

        [ObservableProperty]
        private User? _user;

        public ObservableCollection<Product> Products { get; }
        public ObservableCollection<Order> Orders { get; }
        public MainViewModel(User? user)
        {
            _user = user;

            IsAdmin = user?.Role == "Администратор";
            IsManager = user?.Role == "Менеджер" || IsAdmin;

            Products = new([.. Db.Context.Products]);
            Orders = new([.. Db.Context.Orders]);
        }

        [RelayCommand]
        private static void Logout()
        {
            new LoginWindow().Show();

            Application.Current.Windows // Закрывает первое текущее окно товаров
                .OfType<MainWindow>()
                .First()
                .Close();
        }

        [RelayCommand]
        private void OrderOpen()
        {
            new OrderWindow(new MainViewModel(User)).Show();

            Application.Current.Windows
                .OfType<MainWindow>()
                .First()
                .Close();
        }

        [RelayCommand]
        private void Back()
        {
            new MainWindow(new MainViewModel(User)).Show();

            Application.Current.Windows
                .OfType<OrderWindow>()
                .First()
                .Close();
        }
    }
}
