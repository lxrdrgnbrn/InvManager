using System.Globalization;
using System.Windows.Data;
using simple_database.Model;

namespace simple_database.View;

/// <summary>
/// Класс ConditionToStringConverter представляет конвертер, который преобразует значения EquipmentCondition в строки и обратно.
/// </summary>
public class ConditionToStringConverter : IValueConverter
{
    /// <summary>
    /// Преобразует значение EquipmentCondition в строку.
    /// </summary>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        EquipmentCondition condition = (EquipmentCondition)value;
        switch (condition)
        {
            case EquipmentCondition.NoRepairNeeded:
                return "Не требуется ремонт";
            case EquipmentCondition.MaintenanceRequired:
                return "Требуется обслуживание";
            case EquipmentCondition.RepairRequired:
                return "Требуется ремонт";
            case EquipmentCondition.Missing:
                return "Отсутствует";
            default:
                return "Неизвестно";
        }
    }

    /// <summary>
    /// Преобразует строку обратно в значение EquipmentCondition.
    /// </summary>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string conditionString = (string)value;
        switch (conditionString)
        {
            case "Не требуется ремонт":
                return EquipmentCondition.NoRepairNeeded;
            case "Требуется обслуживание":
                return EquipmentCondition.MaintenanceRequired;
            case "Требуется ремонт":
                return EquipmentCondition.RepairRequired;
            case "Отсутствует":
                return EquipmentCondition.Missing;
            default:
                return EquipmentCondition.NoRepairNeeded;
        }
    }
}
