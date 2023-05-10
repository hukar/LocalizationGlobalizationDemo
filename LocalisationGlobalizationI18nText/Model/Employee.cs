namespace LocalisationGlobalizationI18nText.Model;

public class Employee
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public bool HaveChildren { get; set; }
    public int NumberOfChildren { get; set; }
    public string EmployeeType { get; set; } = string.Empty; // validation asynchrone
}