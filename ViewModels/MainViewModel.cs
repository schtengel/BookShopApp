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
            MessageBox.Show("Вы вышли из учетной записи.", "Выход", MessageBoxButton.OK, MessageBoxImage.Information);
            new LoginWindow().Show();

            Application.Current.Windows
                .OfType<MainWindow>()
                .First()
                .Close();
        }

        [RelayCommand]
        private void OrderOpen()
        {
            MessageBox.Show("Открыт список заказов.", "Заказы", MessageBoxButton.OK, MessageBoxImage.Information);
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

        // Команда добавления товара
        [RelayCommand]
        private void AddProduct()
        {
            // Пример: создаём пустой объект для заполнения (можно заменить на отдельное окно или форму)
            var newProduct = new Product
            {
                Title = "Новый товар",
                Price = 0,
                Count = 0
            };

            // Проверка обязательных полей
            if (string.IsNullOrWhiteSpace(newProduct.Title) || newProduct.Price <= 0)
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля: название и цену товара.",
                                "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Db.Context.Products.Add(newProduct);
            Db.Context.SaveChanges();
            Products.Add(newProduct);

            MessageBox.Show($"Товар '{newProduct.Title}' успешно добавлен.",
                            "Добавление товара", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Команда удаления товара
        [RelayCommand]
        private void DeleteProduct(Product? selectedProduct)
        {
            if (selectedProduct == null)
            {
                MessageBox.Show("Выберите товар для удаления.",
                                "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show($"Вы уверены, что хотите удалить товар '{selectedProduct.Title}'?",
                                         "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Db.Context.Products.Remove(selectedProduct);
                Db.Context.SaveChanges();
                Products.Remove(selectedProduct);

                MessageBox.Show($"Товар '{selectedProduct.Title}' удалён.",
                                "Удаление товара", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
