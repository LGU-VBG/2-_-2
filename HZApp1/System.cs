using System;

public class Fountain
{
    public delegate void WaterOverflowHandler(object sender, EventArgs e); // Собственный делегат для события
    public event WaterOverflowHandler OnWaterOverflow;

    private int _waterLevel;
    private const int MaxCapacity = 500;
    private const int InitialWaterLevel = 350;

    public int WaterLevel
    {
        get { return _waterLevel; }
        private set
        {
            _waterLevel = value;
            // Проверка переполнения только один раз, если вода превысила максимально допустимый уровень
            if (_waterLevel > MaxCapacity && !_isOverflowing)
            {
                _isOverflowing = true;
                OnWaterOverflow?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    private bool _isOverflowing = false; // Флаг, который предотвращает многократное срабатывание события

    public Fountain()
    {
        _waterLevel = InitialWaterLevel;
    }

    public void AddWater(int amount)
    {
        WaterLevel += amount;
    }

    public void EvaporateWater(int amount)
    {
        WaterLevel -= amount;
    }

    public void SimulateDay()
    {
        // Добавляем 100 литров
        AddWater(100);

        // Испаряем случайное количество воды (от 10 до 50 литров)
        Random rand = new Random();
        EvaporateWater(rand.Next(10, 51));

        // Вывод состояния воды
        Console.WriteLine($"Уровень воды: {WaterLevel} литров");
    }

    public void ResetOverflowFlag()
    {
        _isOverflowing = false;
    }
}
