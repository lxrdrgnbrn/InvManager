namespace simple_database.Model;

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
    private int _id;
    private string _name;
    private string _description;
    private string _category;
    private DateTime _purchaseDate;
    private EquipmentCondition _condition;
    private string _inventoryNumber;

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
    /// Название оборудования.
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
    /// Описание оборудования.
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
    /// Категория оборудования.
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
    /// Дата покупки оборудования.
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
    /// Состояние оборудования.
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
    /// Инвентарный номер оборудования.
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
