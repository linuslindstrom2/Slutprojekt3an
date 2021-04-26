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

namespace Slutproject3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();


            
        }


        private void MyGrid_Loaded_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                var row = new RowDefinition();
                row.Height = new GridLength(45);
                MyGrid.RowDefinitions.Add(row);
                var col = new ColumnDefinition();
                col.Width = new GridLength(50);
                MyGrid.ColumnDefinitions.Add(col);

            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var temp = new Button();
                    temp.Click += new RoutedEventHandler((sender, e) =>
                    {
                        //Det som ska hända
                    });
                    Grid.SetRow(temp, i);
                    Grid.SetColumn(temp, j);
                    MyGrid.Children.Add(temp);
                }
            }
        }
    }
}
