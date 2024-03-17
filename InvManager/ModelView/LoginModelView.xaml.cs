using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using simple_database.Model;
using System.IO;

namespace simple_database.View;

public partial class LoginView : Window
{
    public string FileName;
    public DataManager DataManager;
    
    /// <summary>
    /// Инициализация стартового окна
    /// </summary>
    public LoginView()
    {
        DataManager = new DataManager();
        InitializeComponent();
    }

    /// <summary>
    /// Метод для реализации перетаскивания окна
    /// </summary>
    private void Login_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
       if(e.LeftButton == MouseButtonState.Pressed)
           DragMove();
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
    /// Обработчик кнопки создания таблицы
    /// </summary>
    private void CreateBtn_OnClick(object sender, RoutedEventArgs e)
    {
        if (NameBox.Text != "")
        {
            FileName = NameBox.Text;
            MainModelView mainModelView = new MainModelView(FileName, DataManager);
            mainModelView.Show();
            this.Hide();
        }
        else
        {
            NameBox.BorderBrush = Brushes.Tomato;
        }
    }
    

    /// <summary>
    /// Метод возвращение исходного цвета обводки текст бокса
    /// </summary>
    private void NameBox_OnGotFocus(object sender, RoutedEventArgs e)
    {
        NameBox.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#252422"));
    }

    /// <summary>
    /// Обработчик кнопки загрузки таблицы
    /// </summary>
    private void LoadBtn_OnClick(object sender, RoutedEventArgs e)
    {
        // Открываем диалогове окно с открытием файла
        Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
        // Устанавливаем расширения файла в диалоговом окне
        dialog.Filter = "InvManager file (*.json)|*.json";
        dialog.FilterIndex = 2;
        Nullable<bool> result = dialog.ShowDialog();
        if (result == true)
        {
            // Открыть документ
            FileName = dialog.FileName;
            DataManager.LoadData(FileName);
            FileName = System.IO.Path.GetFileName(FileName); // нужно для отображения названия таблицы в основном окне
            MainModelView mainModelView = new MainModelView(FileName, DataManager);
            mainModelView.Show();
            this.Hide();
        }
    }
}