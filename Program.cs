//Вычисление индекса массы тела BMI

var data = ReadingValues();
var bmi = СalculationBMI(data);
var bmiClass = BMIClassification(bmi);

Console.WriteLine($"BMI = {bmi} - {bmiClass}");

static Parameters ReadingValues() => new()
{
    Height = SecureReadingValues(nameof(data.Height)),
    Weigth = SecureReadingValues(nameof(data.Weigth))
};

static decimal SecureReadingValues(string dataString)
{
    decimal value;

    Console.Write($"Enter {dataString} : ");
    decimal.TryParse(Console.ReadLine(), out value);
    if (value <= 0)
    {
        Console.WriteLine($"Error! Incorrect number entered\n");
        value = SecureReadingValues(dataString);
    }
    
    return value;
}

static decimal СalculationBMI(Parameters data)
{
    var bmi = data.Weigth / (data.Height * data.Height);
    return bmi;
}

static string BMIClassification(decimal bmi)
{
    var bmiClass = "";
    if (bmi < 18.5m)
        bmiClass = "Underweight";
    else if (bmi < 25m)
        bmiClass = "Normal weight";
    else
        bmiClass = "Overweight";
    return bmiClass;
}

record Parameters
{
    public decimal Height { get; set; }
    public decimal Weigth { get; set; }
}
