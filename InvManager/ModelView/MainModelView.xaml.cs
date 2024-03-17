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

    /// <summary>
    ///  Инициализация основного окна
    /// </summary>
    /// <param name="FileName">Имя таблицы</param>
    /// <param name="DataManager">Дата Менеджер</param>
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

    /// <summary>
    /// Метод для изменения значка кнопки по изменению размера окна
    /// </summary>
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

    /// <summary>
    /// Обработчик кнопки сворачивания окна
    /// </summary>
    private void MinimizeBtn_OnClick(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }
    
    
    /// <summary>
    /// Обработчик кнопки закрытия окна
    /// </summary>
    private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }


    /// <summary>
    /// Метод для реализации перетаскивания окна
    /// </summary>
    private void TopGrid_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }

    /// <summary>
    /// Обработчик кнопки расширения окна
    /// </summary>
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

    /// <summary>
    /// Обработчик кнопки сохранения
    /// </summary>
    private void SaveBtn_OnClick(object sender, RoutedEventArgs e)
    {
        if (_dataManager.Data.Count != 0)
        {
            // Если файл существует то записываем в него
            if (File.Exists(_fileName))
            {
                _dataManager.SaveData(_fileName);
            }
            else
            {
                // Если файла не существует открывается диалогове окно для сохранения
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
    
    /// <summary>
    /// Обработчик кнопки загрузки таблицы
    /// </summary>
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
    

    /// <summary>
    /// Обработчик кнопки удаления элемента
    /// </summary>
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

    /// <summary>
    /// Обработчик кнопки добавления элемента
    /// </summary>
    private void AddBtn_OnClick(object sender, RoutedEventArgs e)
    {
        AddModelView addModelView = new AddModelView(_dataManager);
        addModelView.Show();
    }

    /// <summary>
    /// Обработчик кнопки обновления элемента
    /// </summary>
    private void UpdateBtn_OnClick(object sender, RoutedEventArgs e)
    {
        
        DataModel selectedData = (DataModel)DataGrid.SelectedItem;
        if (selectedData != null)
        {
            UpdateModelView updateModelView = new UpdateModelView(_dataManager, selectedData);
            updateModelView.Show();
        }
    }

    /// <summary>
    /// Обработчик кнопки сохранения как
    /// </summary>
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