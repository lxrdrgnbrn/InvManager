namespace simple_database.Model;


/// <summary>
///  Перечисление для свойства Condition(Состояние)
/// </summary>
public enum EquipmentCondition
{
    NoRepairNeeded,
    MaintenanceRequired,
    RepairRequired,
    Missing
}

/// <summary>
/// Класс DataModel представляет модель данных для инвентаризации оборудования.
/// </summary>
public class DataModel
{
    private int _id; // Идентификатор оборудования.
    private string _name; // Название оборудования
    private string _description; // Описание оборудования
    private string _category; // Категория оборудования
    private DateTime _purchaseDate; // Дата покупки оборудования
    private EquipmentCondition _condition;// Состояние оборудования
    private string _inventoryNumber;// Инвентарный номер оборудования

    /// <summary>
    /// Идентификатор оборудования.
    /// </summary>
    public int Id 
    { 
        get { return _id; } 
        set 
        {
            if (value < 0)
                throw new ArgumentException("Id cannot be negative.");
            _id = value; 
        } 
    }

    /// <summary>
    /// Название оборудования
    /// </summary>
    public string Name 
    { 
        get { return _name; } 
        set 
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Name cannot be null or empty.");
            _name = value; 
        } 
    }

    /// <summary>
    /// Описание оборудования
    /// </summary>
    public string Description 
    { 
        get { return _description; } 
        set 
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Description cannot be null or empty.");
            _description = value; 
        } 
    }

    /// <summary>
    /// Категория оборудования
    /// </summary>
    public string Category 
    { 
        get { return _category; } 
        set 
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Category cannot be null or empty.");
            _category = value; 
        } 
    }

    /// <summary>
    /// Дата покупки оборудования
    /// </summary>
    public DateTime PurchaseDate 
    { 
        get { return _purchaseDate; } 
        set 
        {
            _purchaseDate = value; 
        } 
    }

    /// <summary>
    /// Состояние оборудования
    /// </summary>
    public EquipmentCondition Condition 
    { 
        get { return _condition; } 
        set 
        {
            _condition = value; 
        } 
    }

    /// <summary>
    /// Инвентарный номер оборудования
    /// </summary>
    public string InventoryNumber 
    { 
        get { return _inventoryNumber; } 
        set 
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Inventory number cannot be null or empty.");
            _inventoryNumber = value; 
        } 
    }
}
