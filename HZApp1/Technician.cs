public class Technician
{
    public void HandleWaterOverflow(object sender, EventArgs e)
    {
        // Когда вода переполняется, откачиваем до уровня 350 литров
        var fountain = sender as Fountain;
        if (fountain != null)
        {
            Console.WriteLine("Техник: Откачка воды...");
            while (fountain.WaterLevel > 350)
            {
                fountain.EvaporateWater(1); // По одному литру до 350 литров
            }
            Console.WriteLine("Техник: Уровень воды нормализован до 350 литров.");

            // Сбрасываем флаг переполнения
            fountain.ResetOverflowFlag();
        }
    }
}