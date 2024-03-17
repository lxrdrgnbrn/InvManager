using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using simple_database.Model;

namespace simple_database.View;

public partial class AddModelView : Window
{
    private ConditionToStringConverter _converter = new ConditionToStringConverter();
    private DataManager _dataManager;
    private DataModel _data = new DataModel(); // формат элемента данных
    /// <summary>
    ///  Инициализация Окна добавления элементов
    /// </summary>
    /// <param name="dataManager">Объект типа DataManager хранящий коллекцию данных</param>
    public AddModelView(DataManager dataManager)
    {
        InitializeComponent();
        _dataManager = dataManager;
        ConditionBox.DataContext = _data; // Установление контекста для Комбобокса
    }
    /// <summary>
    ///  Метод для реализации перетаскивания окна
    /// </summary>
    private void AddView_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if(e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }
    /// <summary>
    /// Обработчик нажатия кнопки добавления
    /// </summary>

    private void AddBtn_OnClick(object sender, RoutedEventArgs e)
    {
        
        if (NameBox.Text != "")
        {
            _data.Name = NameBox.Text;
            if (DescriptionBox.Text != "")
            {
                _data.Description = DescriptionBox.Text;
                if (CategoryBox.Text != "")
                {
                    _data.Category = CategoryBox.Text;
                    if (InvNumberBox.Text != "")
                    {
                        _data.InventoryNumber = InvNumberBox.Text;
                        if (DataBox.Text != "")
                        {
                            _data.PurchaseDate = DataBox.SelectedDate.Value;
                            if (ConditionBox.SelectedItem != null)
                            {
                                _dataManager.Add(_data);
                                this.Close();
                            }
                            else
                            {
                                ConditionBox.BorderBrush = Brushes.Tomato;
                            }
                        }
                        else
                        {
                            DataBox.BorderBrush = Brushes.Tomato;
                        }
                    }
                    else
                    {
                        InvNumberBox.BorderBrush = Brushes.Tomato;
                    }
                }
                else
                {
                    CategoryBox.BorderBrush = Brushes.Tomato;
                }
            }
            else
            {
                DescriptionBox.BorderBrush = Brushes.Tomato;
            }
        }
        else
        {
            NameBox.BorderBrush = Brushes.Tomato;
        }
    }

    /// <summary>
    /// Обработчик нажатия кнопки отмены
    /// </summary>
    private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}