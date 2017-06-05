using System.Windows;
using System.Windows.Controls;

namespace MVC.Wpf.Controls
{
    /// <summary>
    /// Логика взаимодействия для ListStatisticView.xaml
    /// </summary>
    public partial class ListStatisticView : UserControl
    {
        private Views.ListStatisticView _view;
        private Views.ListStatisticView View
        {
            get { return _view ?? (_view = (Views.ListStatisticView)DataContext); }
        }

        public ListStatisticView()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            double number;
            if (double.TryParse(NewNumberText.Text, out number))
            {
                View.List.Add(number);
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var number = (double)(sender as Button).Tag;
            View.List.Remove(number);
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            View.List.Clear();
        }
    }
}
