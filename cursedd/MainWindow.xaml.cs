using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using cursedd.Database;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace cursedd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = Navigation.GetInstance();
            InitializeComponent();

            //DB.GetInstance().TestConnection();
        }

        private void clickopenclientslist(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().CurrentPage = new list.clientslist();
        }

        private void clickopenrieltorlist(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().CurrentPage = new list.rieltorlist();
        }

        private void clickopenrealtylist(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().CurrentPage = new list.realtylist();
        }

        private void clickopendogovoralist(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().CurrentPage = new list.dogovoralist();
        }
    }
    }

