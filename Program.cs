// See https://aka.ms/new-console-template for more information

namespace _2nd_sem_test_1;

class Student
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

class StudentSinglyNode
{
    public StudentSinglyNode? Next { get; set; }
    private Student _data;

    public StudentSinglyNode(Student data)
    {
        _data = data;
    }

    public void Append(Student data)
    {
        Next = new StudentSinglyNode(data);
    }

    public void Print()
    {
        Console.WriteLine(_data.ToString());
    }

    public bool EqId(int other) => _data.Id == other;
}

class StudentSinglyLikedList
{
    private StudentSinglyNode? _head;

    public void Append(Student data)
    {
        if (_head == null)
        {
            _head = new StudentSinglyNode(data);
        }
        else
        {
            StudentSinglyNode curNode = _head;
            while (curNode.Next != null) curNode = curNode.Next;
            curNode.Append(data);
        }
    }

    public void Print()
    {
        if (_head == null)
        {
            Console.WriteLine("No elements in LL");
        }
        else
        {
            StudentSinglyNode? curNode = _head;
            while (curNode != null)
            {
                curNode.Print();
                curNode = curNode.Next;
            }
        }
    }

    public StudentSinglyNode? GetId(int id)
    {
        if (_head != null)
        {
            StudentSinglyNode? curNode = _head;
            while (curNode != null)
            {
                if (curNode.EqId(id)) return curNode;
                curNode = curNode.Next;
            }
        }
        return null;
    }

    public bool RemoveId(int id)
    {
        if (_head != null)
        {
            StudentSinglyNode? curNode = _head;
            while (curNode != null)
            {
                if (curNode.EqId(id))
                curNode = curNode.Next;
            }
        }
        return false;
    }
}

class Program
{
    static void Main()
    {
        int[] ids = new int[] { 1, 5, 10, 15, 20 };
        string[] names = new string[] { "A", "B", "C", "D", "E" };
        int[] ages = new int[] { 20, 21, 22, 23, 24 };
        string[] courses = new string[] { "IT", "IT", "ME", "ME", "IT" };
        int[] yearLevels = new int[] { 1, 1, 3, 4, 2 };
        StudentSinglyLikedList studentLL = new StudentSinglyLikedList();
        for (int i = 0; i < ids.Length; i++)
        {
            studentLL.Append(new Student(ids[i], names[i], ages[i], courses[i], yearLevels[i]));
        }
        studentLL.Print();
    }
}
