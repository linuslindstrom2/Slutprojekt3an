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
    public partial class MainWindow : Window 
    {
        public MainWindow()
        {
            InitializeComponent();
            
        } 

        public void MyGrid_Loaded_1(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                var row = new RowDefinition();
                row.Height = new GridLength(60);
                MyGrid.RowDefinitions.Add(row);
                var col = new ColumnDefinition();
                col.Width = new GridLength(60);
                MyGrid.ColumnDefinitions.Add(col);
            }

            for (int i = 5; i < 8; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Ellipse rec = new Ellipse()
                    {
                        Fill = Brushes.Blue,
                        Stroke = Brushes.Black,
                        Width = 59,
                        Height = 59,
                    };

                    Grid.SetRow(rec, i);
                    Grid.SetColumn(rec, j);
                    MyGrid.Children.Add(rec);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 5; j < 8; j++)
                {
                    Ellipse rec = new Ellipse()
                    {
                        Fill = Brushes.Red,
                        Stroke = Brushes.Black,
                        Width = 59,
                        Height = 59,
                    };

                    Grid.SetRow(rec, i);
                    Grid.SetColumn(rec, j);
                    MyGrid.Children.Add(rec);
                }
            }

            for (int i = 5; i < 8; i++)
            {
                for (int j = 8; j < 13; j++)
                {
                    Ellipse rec = new Ellipse()
                    {
                        Fill = Brushes.Green,
                        Stroke = Brushes.Black,
                        Width = 59,
                        Height = 59,
                    };

                    Grid.SetRow(rec, i);
                    Grid.SetColumn(rec, j);
                    MyGrid.Children.Add(rec);
                }
            }

            for (int i = 8; i < 13; i++)
            {
                for (int j = 5; j < 8; j++)
                {
                    Ellipse rec = new Ellipse()
                    {
                        Fill = Brushes.Yellow,
                        Stroke = Brushes.Black,
                        Width = 59,
                        Height = 59,
                    };

                    Grid.SetRow(rec, i);
                    Grid.SetColumn(rec, j);
                    MyGrid.Children.Add(rec);
                }
            }

            Ellipse Goal = new Ellipse()
            {
                Fill = Brushes.Purple,
                Stroke = Brushes.Black,
                Width = 170,
                Height = 170,
            };
            Grid.SetRow(Goal, 5);
            Grid.SetColumn(Goal, 5);
            MyGrid.Children.Add(Goal);
        }
    }
}