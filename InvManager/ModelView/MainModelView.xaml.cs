using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using simple_database.Model;
using System.IO;
namespace simple_database.View;

public partial class MainModelView : Window
{
    private string _fileName;
    private DataManager _dataManager;

    public MainModelView(string FileName, DataManager DataManager)
    {
        InitializeComponent();
        this.SizeChanged += MainWindow_SizeChanged;
        _fileName = FileName;
        _dataManager = DataManager;
        // Привязка данных
        DataGrid.ItemsSource = _dataManager.Data;
        NameBlock.Text = _fileName;
    }

    private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (this.WindowState == WindowState.Maximized)
        {
            // Окно на весь экран, измените изображение кнопки
            BtnImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/minimize.png"));
        }
        else
        {
            // Окно не на весь экран, измените изображение кнопки
            BtnImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/maximize.png"));
        }
    }

    private void MinimizeBtn_OnClick(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }


    private void TopGrid_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }

    private void MaximizeBtn_OnClick(object sender, RoutedEventArgs e)
    {
        if (this.WindowState == WindowState.Maximized)
        {
            WindowState = WindowState.Normal;
        }
        else
        {
            WindowState = WindowState.Maximized;
        }
    }

    private void SaveBtn_OnClick(object sender, RoutedEventArgs e)
    {
        if (_dataManager.Data.Count != 0)
        {
            if (File.Exists(_fileName))
            {
                _dataManager.SaveData(_fileName);
            }
            else
            {
                Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
                dialog.FileName = _fileName;
                dialog.Filter = "InvManager file (*.json)|*.json";
                dialog.FilterIndex = 2;
                Nullable<bool> result = dialog.ShowDialog();
                if (result == true)
                {
                    // Сохранить файл
                    _fileName = dialog.FileName;
                    _dataManager.SaveData(_fileName);
                    NameBlock.Text = System.IO.Path.GetFileName(_fileName);
                }
            }
        }
        else
        {
            MessageBox.Show("Таблица не может быть пустой", "Ошибка");
        }
    }

    private void LoadBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
        dialog.Filter = "InvManager file (*.json)|*.json";
        dialog.FilterIndex = 2;
        Nullable<bool> result = dialog.ShowDialog();
        if (result == true)
        {
            // Открыть документ
            _fileName = dialog.FileName;
            _dataManager.LoadData(_fileName);
            // Обновление привязки данных
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = _dataManager.Data;
            NameBlock.Text = System.IO.Path.GetFileName(_fileName);
        }
        
    }
    

    private void DeleteBtn_OnClick(object sender, RoutedEventArgs e)
    {
        // Получаем выделенный элемент
        DataModel selectedData = (DataModel)DataGrid.SelectedItem;

        // Удаляем выделенный элемент
        if (selectedData != null)
        {
            _dataManager.Remove(selectedData);
        }
    }

    private void AddBtn_OnClick(object sender, RoutedEventArgs e)
    {
        AddModelView addModelView = new AddModelView(_dataManager);
        addModelView.Show();
    }

    private void UpdateBtn_OnClick(object sender, RoutedEventArgs e)
    {
        
        DataModel selectedData = (DataModel)DataGrid.SelectedItem;
        if (selectedData != null)
        {
            UpdateModelView updateModelView = new UpdateModelView(_dataManager, selectedData);
            updateModelView.Show();
        }
    }

    private void SaveAsBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
        dialog.Filter = "InvManager file (*.json)|*.json";
        dialog.FilterIndex = 2;
        Nullable<bool> result = dialog.ShowDialog();
        if (result == true)
        {
            // Сохранить файл
            _fileName = dialog.FileName;
            _dataManager.SaveData(_fileName);
            NameBlock.Text = System.IO.Path.GetFileName(_fileName);
        }
    }
}