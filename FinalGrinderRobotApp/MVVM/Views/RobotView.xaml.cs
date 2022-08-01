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

namespace FinalGrinderRobotApp.MVVM.Views
{
    /// <summary>
    /// Interaction logic for RobotView.xaml
    /// </summary>
    public partial class RobotView : UserControl
    {
        public RobotView()
        {
            InitializeComponent();
            this.DataContext = new FinalGrinderRobotApp.MVVM.ViewModel.RobotViewModel();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
