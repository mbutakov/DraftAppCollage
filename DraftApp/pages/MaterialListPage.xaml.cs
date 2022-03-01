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
using DraftApp.database;

namespace DraftApp.pages
{
    /// <summary>
    /// Логика взаимодействия для MaterialListPage.xaml
    /// </summary>
    public partial class MaterialListPage : Page
    {
        public MaterialListPage()
        {
            InitializeComponent();
            updateList(1);
        }


        public void updateList(int page)
        {

           
            List<material> listMaterial = MainWindow.connection.material.ToList();
            for(int i = 15 * (page == 1 ? 0 : page-1); i < 15 &&  i < listMaterial.Count * page; i++)
            {
                material material = listMaterial[i];
                StackPanel sp = new StackPanel();
                Grid grid = new Grid();
                ColumnDefinition columnDefinition = new ColumnDefinition();
                ColumnDefinition columnDefinition2 = new ColumnDefinition();
                ColumnDefinition columnDefinition3 = new ColumnDefinition();
                columnDefinition.Width = new GridLength(0.2, GridUnitType.Star);
                columnDefinition2.Width = new GridLength(1.0, GridUnitType.Star);
                columnDefinition3.Width = new GridLength(0.2, GridUnitType.Star);
                grid.ColumnDefinitions.Add(columnDefinition);
                grid.ColumnDefinitions.Add(columnDefinition2);
                grid.ColumnDefinitions.Add(columnDefinition3);
                grid.Height = 150;
                sp.Height = 155;
                Image image = new Image();
                var uriSource = new Uri(@"/DraftApp;component/images/picture.png", UriKind.Relative);
                if (material.image != null)
                {
                    uriSource = new Uri(@"/DraftApp;component/images/materials/material_" + listMaterial[i].image + ".jpeg", UriKind.Relative);
                }
               // var storageForThisMaterial = MainWindow.connection.storage.Where(o => o.id_material == material.id).FirstOrDefault();

                image.Source = new BitmapImage(uriSource);
                image.Height = Double.NaN;
                image.Width = Double.NaN;
                image.SetValue(Grid.ColumnProperty, 0);
                image.Stretch = Stretch.Fill;
                image.Margin = new Thickness(30, 30, 30, 30);

                Border border = new Border();
                border.BorderBrush = Brushes.Black;
                border.BorderThickness = new Thickness(1, 1, 1, 1);
                border.Child = grid;
                StackPanel stackPanelInfo = new StackPanel();
                stackPanelInfo.SetValue(Grid.ColumnProperty, 1);

                TextBlock typeAndName = new TextBlock();
                typeAndName.FontSize = 30;
                typeAndName.Text = material.type + " | " + material.name;
                stackPanelInfo.Children.Add(typeAndName);

                TextBlock minCount = new TextBlock();
                minCount.FontSize = 15;
                minCount.Text = "Минимальное количество: " +  material.count;
                minCount.Height = 40;
                stackPanelInfo.Children.Add(minCount);

                TextBlock remains = new TextBlock();
                remains.FontSize = 15;
                remains.Text = "Остаток: " + material.min_count;
                remains.SetValue(Grid.ColumnProperty, 2);

                stackPanelInfo.Height = Double.NaN;
                grid.ShowGridLines = true;
                grid.Children.Add(image);
                grid.Children.Add(stackPanelInfo);
                grid.Children.Add(remains);
                sp.Children.Add(border);
                sp.Margin = new Thickness(5, 5, 5, 5);
                StackPanelMaterial.Children.Add(sp);
                
            }
        }
    }
}
