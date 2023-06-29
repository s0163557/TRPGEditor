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
using TRPGEditor.Base;
using TRPGEditor.GUI;

namespace TRPGEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            List<SimpleBase> baseObjectList = new List<SimpleBase>();
            List<DockPanel> dockPanels = new List<DockPanel>();
            InitializeComponent();
        }

        private void btnBaseAddClick(object sender, RoutedEventArgs e)
        {
            BaseDockPanel baseDockPanel = new BaseDockPanel();
            spBase.Children.Add(baseDockPanel);
        }
    }
}
