using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using simple_database.Model;

namespace simple_database.View;

public partial class AddModelView : Window
{
    private ConditionToStringConverter _converter = new ConditionToStringConverter();
    private DataManager _dataManager;
    private DataModel _data = new DataModel();
    public AddModelView(DataManager dataManager)
    {
        InitializeComponent();
        _dataManager = dataManager;
        ConditionBox.DataContext = _data;
    }

    private void AddView_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if(e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }

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

    private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}