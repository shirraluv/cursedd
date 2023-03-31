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
using System.Windows.Shapes;

namespace cursedd.list
{
    /// <summary>
    /// Логика взаимодействия для dogovoralist.xaml
    /// </summary>
    public partial class dogovoralist : Page
    {
        public dogovoralist()
        {
            DataContext = Navigation.GetInstance();
            InitializeComponent();

            //DB.GetInstance().TestConnection();
        }

        private void clickopendogovoraedit(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().CurrentPage = new edit.dogovoraedit();
        }
    }
}
