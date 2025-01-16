class Program
{
    static void Main()
    {
        // Создаем фонтан и техника
        var fountain = new Fountain();
        var technician = new Technician();

        // Подписываемся на событие переполнения фонтана
        fountain.OnWaterOverflow += technician.HandleWaterOverflow;

        // Моделируем процесс на несколько дней
        for (int day = 1; day <= 10; day++)
        {
            Console.WriteLine($"День {day}:");
            fountain.SimulateDay(); // Симуляция дня
            Console.WriteLine();
        }
    }
}