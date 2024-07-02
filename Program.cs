int[] times = { 800, 1200, 1600, 2000 };
int diff = 0;
MedicineSchduler();
Console.ReadKey();
void MedicineSchduler()
{
    Console.WriteLine("Enter current GMT");
    int currentGMT = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Current Medicine Schedule:");
    DisplayMedicineTime(times);

    Console.WriteLine();

    Console.WriteLine("Enter new GMT");
    int newGMT = Convert.ToInt32(Console.ReadLine());

    if (Math.Abs(newGMT) > 12 || Math.Abs(currentGMT) > 12)
    {
        Console.WriteLine("Invalid GMT");
    }
    else if (newGMT <= 0 && currentGMT <= 0 || newGMT >= 0 && currentGMT >= 0)
    {
        diff = 100 * (Math.Abs(newGMT) - Math.Abs(currentGMT));
        AdjustTimes();
    }
    else
    {
        diff = 100 * (Math.Abs(newGMT) + Math.Abs(currentGMT));
        AdjustTimes();
    }

    Console.WriteLine("New Medicine Schedule:");
    DisplayMedicineTime(times);

    Console.WriteLine();

}

void DisplayMedicineTime(int[] timeInts)
{
    /* Format and display medicine times */
    foreach (int val in timeInts)
    {
        string time = val.ToString();
        int len = time.Length;

        if (len >= 3)
        {
            time = time.Insert(len - 2, ":");
        }
        else if (len == 2)
        {
            time = time.Insert(0, "0:");
        }
        else
        {
            time = time.Insert(0, "0:0");
        }

        Console.Write($"{time} ");
    }
}

void AdjustTimes()
{
    for (int i = 0; i < times.Length; i++)
    {
        times[i] = ((times[i] + diff)) % 2400;
    }
}