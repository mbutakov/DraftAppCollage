using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public static List<material> materialSearchList = new List<material>();
        public static int thisPage = 1;
        public MaterialListPage()
        {
            InitializeComponent();
            updateList();
        }

        public void updateList()
        {
            if(NextButton != null && BackButton != null)
            {
                NextButton.IsEnabled = true;
                BackButton.IsEnabled = true;
            }
            clearElelemnts();
            if (StackPanelMaterial != null)
            {
               updateListObject(materialSearchList);
            }

            }

            public void clearElelemnts()
        {
            if(StackPanelMaterial != null)
            {
                if(StackPanelMaterial.Children != null)
                {
                    StackPanelMaterial.Children.Clear();
                }
            }
        }

        public void updateListObject(List<material> listMaterial)
        {

            List<material> trimmedList = new List<material>();
            foreach(material m in materialSearchList)
            {
                trimmedList.Add(m);
            }


           
            trimmedList.RemoveRange(0, (thisPage-1) * 15);

         
         
            for(int i = 0; i <  15 && i < trimmedList.Count; i++)
            {
                material material = trimmedList[i];
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
                    uriSource = new Uri(@"/DraftApp;component/images/materials/material_" + trimmedList[i].image + ".jpeg", UriKind.Relative);
                }
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
                minCount.Text = "Минимальное количество: " +  material.count + "  " + material.price;
                minCount.Height = 40;
                stackPanelInfo.Children.Add(minCount);
                TextBlock remains = new TextBlock();
                remains.FontSize = 15;
                remains.Text = "Остаток: " + material.count;
                remains.SetValue(Grid.ColumnProperty, 2);
                stackPanelInfo.Height = Double.NaN;
               // grid.ShowGridLines = true;
                grid.Children.Add(image);
                grid.Children.Add(stackPanelInfo);
                grid.Children.Add(remains);
                sp.Children.Add(border);
                sp.Margin = new Thickness(5, 5, 5, 5);
                StackPanelMaterial.Children.Add(sp);
                
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                filter.SelectedIndex = 0;
                reorganizeList(TextBoxName.Text);
                thisPage = 1;
                LabelNumberPage.Content = thisPage;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
         
        }


        public void reorganizeList(string text)
        {
            if(text.Length > 0)
            {
                materialSearchList = null;
                materialSearchList = (MainWindow.connection.material.Where(o => DbFunctions.Like(o.name, "%" +text+"%")).ToList());
                updateList();
            }
            else
            {
                materialSearchList = MainWindow.connection.material.ToList();
                updateList();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if(thisPage > 1)
            {
                thisPage--;
                updateList();
                LabelNumberPage.Content = thisPage;
                NextButton.IsEnabled = true;
                if(thisPage == 1)
                {
                    BackButton.IsEnabled = false;
                }
            }

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
           
            float x = (float)materialSearchList.Count / (float)15;
            if (x > thisPage)
            {
                thisPage++;
                updateList();
                LabelNumberPage.Content = thisPage;
                BackButton.IsEnabled = true;
                if(x > thisPage)
                {
                }
                else
                {
                    NextButton.IsEnabled = false;
                }
            }
           

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(materialSearchList != null)
            {

                if(filter.SelectedIndex == 1)
                {
                    materialSearchList = materialSearchList.OrderByDescending(o => o.count).ToList();
                    updateList();
                }else if(filter.SelectedIndex == 2){

                }
                else
                {
                    reorganizeList(TextBoxName.Text);
                }
            
            }
            
            
        }
    }
}
