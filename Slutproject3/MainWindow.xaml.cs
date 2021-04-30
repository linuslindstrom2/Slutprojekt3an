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

        public void MyGrid_Loaded(object sender, EventArgs e)
        {
            
            for (int i = 0; i < 13; i++)
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
                for (int j = 1; j < 12; j++)
                {
                    Ellipse rec = new Ellipse()
                    {
                        Fill = Brushes.White,
                        Stroke = Brushes.Black,
                        Width = 58,
                        Height = 58,
                    };

                    Grid.SetRow(rec, i);
                    Grid.SetColumn(rec, j);
                    MyGrid.Children.Add(rec);
                }
            }

            for (int i = 1; i < 12; i++)
            {
                for (int j = 5; j < 8; j++)
                {
                    Ellipse rec = new Ellipse()
                    {
                        Fill = Brushes.White,
                        Stroke = Brushes.Black,
                        Width = 58,
                        Height = 58,
                    };

                    Grid.SetRow(rec, i);
                    Grid.SetColumn(rec, j);
                    MyGrid.Children.Add(rec);
                }
            }

            for (int i = 2; i < 6; i++)
			{
                Ellipse BlåMålgång = new Ellipse()
                {
                    Fill = Brushes.Blue,
                    Stroke = Brushes.Black,
                    Width = 58,
                    Height = 58,
                };
                Grid.SetRow(BlåMålgång, 6);
                Grid.SetColumn(BlåMålgång, i);
                MyGrid.Children.Add(BlåMålgång);      
			}

            for (int i = 2; i < 6; i++)
			{
                Ellipse RödMålgång = new Ellipse()
                {
                    Fill = Brushes.Red,
                    Stroke = Brushes.Black,
                    Width = 58,
                    Height = 58,
                };
                Grid.SetRow(RödMålgång, i);
                Grid.SetColumn(RödMålgång, 6);
                MyGrid.Children.Add(RödMålgång);      
			}
            
            for (int i = 7; i < 11; i++)
			{
                Ellipse GrönMålgång = new Ellipse()
                {
                    Fill = Brushes.Green,
                    Stroke = Brushes.Black,
                    Width = 58,
                    Height = 58,
                };
                Grid.SetRow(GrönMålgång, 6);
                Grid.SetColumn(GrönMålgång, i);
                MyGrid.Children.Add(GrönMålgång);      
			}
            
            for (int i = 7; i < 11; i++)
			{
                Ellipse GulMålgång = new Ellipse()
                {
                    Fill = Brushes.Yellow,
                    Stroke = Brushes.Black,
                    Width = 58,
                    Height = 58,
                };
                Grid.SetRow(GulMålgång, i);
                Grid.SetColumn(GulMålgång, 6);
                MyGrid.Children.Add(GulMålgång);      
			}

            Ellipse FörstaBlå = new Ellipse()
            {
                Fill = Brushes.Blue,
                Stroke = Brushes.Black,
                Width = 58,
                Height = 58,
            };
            Grid.SetRow(FörstaBlå, 5);
            Grid.SetColumn(FörstaBlå, 1);
            MyGrid.Children.Add(FörstaBlå);            
            
            Ellipse FörstaRöd = new Ellipse()
            {
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
                Width = 58,
                Height = 58,
            };
            Grid.SetRow(FörstaRöd, 1);
            Grid.SetColumn(FörstaRöd, 7);
            MyGrid.Children.Add(FörstaRöd);
            
            Ellipse FörstaGrön = new Ellipse()
            {
                Fill = Brushes.Green,
                Stroke = Brushes.Black,
                Width = 58,
                Height = 58,
            };
            Grid.SetRow(FörstaGrön, 7);
            Grid.SetColumn(FörstaGrön, 11);
            MyGrid.Children.Add(FörstaGrön);
            
            Ellipse FörstaGul = new Ellipse()
            {
                Fill = Brushes.Yellow,
                Stroke = Brushes.Black,
                Width = 58,
                Height = 58,
            };
            Grid.SetRow(FörstaGul, 11);
            Grid.SetColumn(FörstaGul, 5);
            MyGrid.Children.Add(FörstaGul);

            Ellipse Goal = new Ellipse()
            {
                Fill = Brushes.Green,
                Stroke = Brushes.Black,
                Width = 58,
                Height = 58,
            };
            Grid.SetRow(Goal, 6);
            Grid.SetColumn(Goal, 6);
            MyGrid.Children.Add(Goal);
           
            
            Ellipse BlueStart = new Ellipse()
            {
                Fill = Brushes.Blue,
                Stroke = Brushes.Black,
                Width = 130,
                Height = 130,
            };
            Grid.SetRow(BlueStart, 1);
            Grid.SetColumn(BlueStart, 1);
            MyGrid.Children.Add(BlueStart);
            Grid.SetColumnSpan(BlueStart , 3);
            Grid.SetRowSpan(BlueStart, 3);

            Ellipse RedStart = new Ellipse()
            {
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
                Width = 130,
                Height = 130,
            };
            Grid.SetRow(RedStart, 1);
            Grid.SetColumn(RedStart, 9);
            MyGrid.Children.Add(RedStart);
            Grid.SetColumnSpan(RedStart , 3);
            Grid.SetRowSpan(RedStart, 3);
            
            Ellipse GreenStart = new Ellipse()
            {
                Fill = Brushes.Green,
                Stroke = Brushes.Black,
                Width = 130,
                Height = 130,
            };
            Grid.SetRow(GreenStart, 9);
            Grid.SetColumn(GreenStart, 9);
            MyGrid.Children.Add(GreenStart);
            Grid.SetColumnSpan(GreenStart , 3);
            Grid.SetRowSpan(GreenStart, 3);

            Ellipse YellowStart = new Ellipse()
            {
                Fill = Brushes.Yellow,
                Stroke = Brushes.Black,
                Width = 130,
                Height = 130,
            };
            Grid.SetRow(YellowStart, 9);
            Grid.SetColumn(YellowStart, 1);
            MyGrid.Children.Add(YellowStart);
            Grid.SetColumnSpan(YellowStart , 3);
            Grid.SetRowSpan(YellowStart, 3);

           
        }
    }
}
