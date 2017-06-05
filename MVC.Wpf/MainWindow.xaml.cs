using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using MVC.Wpf.Converters;
using MVC.Wpf.Views;

namespace MVC.Wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CommonView _commonView;
        private readonly IntToVisibilityConverter _intToVisibilityConverter = new IntToVisibilityConverter();

        public MainWindow()
        {
            InitializeComponent();
            ViewsGrid.Children.Clear();
            _commonView = (CommonView)DataContext;
            _commonView.Computations.ForEach(computation => AddView((ICalculationViewModel)computation.View));
        }
        
        private void AddView(ICalculationViewModel view)
        {
            var controlView = (Control)Activator.CreateInstance(view.ViewControlType);
            controlView.DataContext = view;
            ViewsGrid.Children.Add(controlView);
            controlView.SetBinding(VisibilityProperty, new Binding("SelectedIndex")
            {
                ElementName = ComputationsList.Name,
                Converter = _intToVisibilityConverter,
                ConverterParameter = view.ViewNumber,
            });
        }

        private void ButtonRun_Click(object sender, RoutedEventArgs e)
        {
            _commonView.Run();
        }
    }
}
