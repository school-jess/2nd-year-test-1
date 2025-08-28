namespace Students;

public class Student
{
    public int Id { get; set; }
    private string _name;
    private int _age;
    private string _course;
    private int _yearLevel;

    public Student(int id, string name, int age, string course, int yearLevel)
    {
        Id = id;
        _name = name;
        _age = age;
        _course = course;
        _yearLevel = yearLevel;
    }

    public override string ToString()
    {
        return $"id: {Id}, name: {_name}, age: {_age}, course: {_course}, year level: {_yearLevel}";
    }
}
