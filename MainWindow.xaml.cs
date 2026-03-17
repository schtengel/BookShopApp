using BookShopApp.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Azure.Core.HttpHeader;

namespace BookShopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            Text1.Visibility = viewModel.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
            Text2.Visibility = viewModel.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
            Text3.Visibility = viewModel.IsManager ? Visibility.Visible : Visibility.Collapsed;
            Text4.Visibility = viewModel.IsManager ? Visibility.Visible : Visibility.Collapsed;
            Combo1.Visibility = viewModel.IsManager ? Visibility.Visible : Visibility.Collapsed;
            Button1.Visibility = viewModel.IsManager ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}