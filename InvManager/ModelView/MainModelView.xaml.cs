using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using simple_database.Model;
using System.IO;
using System.Windows.Data;
using MaterialDesignThemes.Wpf;
using System.Timers;
using Timer = System.Timers.Timer;

namespace simple_database.View;

public partial class MainModelView : Window
{
    public static RoutedCommand SaveCommand = new RoutedCommand();
    public static RoutedCommand LoadCommand = new RoutedCommand();
    private string _fileName;
    private DataManager _dataManager;
    ICollectionView _dataView;
    private Timer _timer;

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
        
        // Получаем представление по умолчанию для источника данных элемента управления DataGrid.
        // CollectionViewSource.GetDefaultView возвращает объект CollectionView, который можно использовать для сортировки, фильтрации и навигации.
        // Это представление обеспечивает уровень абстракции между элементом управления пользовательского интерфейса и данными.
        _dataView = CollectionViewSource.GetDefaultView(DataGrid.ItemsSource);

        // Устанавливаем свойство Filter представления данных.
        // Filter - это делегат, который каждый раз вызывается при обновлении представления. 
        // Он получает каждый элемент данных и должен возвращать true, если элемент должен быть включен в представление, и false в противном случае.
        _dataView.Filter = FilterDataGrid;
        
        _timer = new Timer(60000); // Устанавливаем интервал в 1 минуту (60000 миллисекунд)
        // Добавляем обработчик событий к событию Elapsed таймера.
        // Каждый раз, когда проходит интервал времени, заданный для таймера, вызывается метод OnTimedEvent.
        _timer.Elapsed += OnTimedEvent;

        // Устанавливаем свойство AutoReset в true.
        // Это означает, что таймер будет автоматически сбрасываться и снова начинать отсчет после каждого срабатывания.
        // Если AutoReset установлено в false, таймер сработает только один раз.
        _timer.AutoReset = true;

        // Устанавливаем свойство Enabled в true.
        // Это означает, что таймер начинает работать немедленно после его создания.
        _timer.Enabled = true;
    }
    /// <summary>
    /// Обработчик событий для таймера.
    /// Этот метод вызывается каждый раз, когда проходит интервал времени, заданный для таймера.
    /// </summary>
    /// <param name="source">Источник события. В данном случае это таймер.</param>
    /// <param name="e">Аргументы события, содержащие информацию о времени срабатывания таймера.</param>
    private void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        // Вызов метода SaveData(), который сохраняет данные.
        SaveData();
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
    // Метод для фильтрации данных в DataGrid
    private bool FilterDataGrid(object item)
    {
        // Если текст в поле поиска пуст, то все строки отображаются (фильтр не применяется)
        if (String.IsNullOrEmpty(SearchBox.Text))
            return true;
        else
        {
            // Приводим объект item к типу DataModel
            var data = item as DataModel;
            // Проверяем, содержит ли дата покупки текст, введенный в поле поиска
            var purchaseDateText = data.PurchaseDate.ToString("dd.MM.yy");
            var isPurchaseDateMatch = purchaseDateText.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0;
            
            // Добавляем проверку состояния оборудования
            var converter = new ConditionToStringConverter();
            var conditionText =converter.Convert(data.Condition, null, null, null) as string;
            var isConditionMatch = conditionText.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0;

            // Проверяем, содержит ли какое-либо из полей текст, введенный в поле поиска
            // Метод IndexOf возвращает индекс первого вхождения подстроки в строку, если подстрока не найдена, возвращается -1
            // StringComparison.OrdinalIgnoreCase обеспечивает нечувствительность к регистру при сравнении строк
            return data.Name.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0
                   || data.Description.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0
                   || data.Category.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0
                   || data.InventoryNumber.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0
                   || isPurchaseDateMatch
                   || isConditionMatch;
            // Если хотя бы одно из полей содержит текст из поля поиска, строка отображается
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
                // Nullable - переопределение типа bool для того чтобы он смог принимать значения null
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
            UpdateTableItemSource();
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
        addModelView.ShowDialog();
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
            // Установка MainWindow в качестве владельца UpdateWindow
            updateModelView.Owner = this;
            updateModelView.ShowDialog();
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

    /// <summary>
    /// Метод обновления привязки данных
    /// </summary>
    public void UpdateTableItemSource()
    {
        DataGrid.ItemsSource = null;
        DataGrid.ItemsSource = _dataManager.Data;
    }

    private void SearchBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        _dataView.Refresh();
    }

    private void AboutItem_OnClick(object sender, RoutedEventArgs e)
    {
        var aboutView = new AboutView();
        aboutView.ShowDialog();
    }
    
    
    // Метод для сохраенния данных в существующий файл
    private void SaveData()
    {
        if (_dataManager.Data.Count != 0)
        {
            // Если файл существует то записываем в него
            if (File.Exists(_fileName))
            {
                _dataManager.SaveData(_fileName);
            }
        }
    }
}