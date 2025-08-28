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
    private HashSet<int> _idIndices;

    public StudentSinglyLikedList()
    {
        _idIndices = new HashSet<int>();
    }

    public void Append(Student data)
    {
        if (_head == null)
        {
            _head = new StudentSinglyNode(data);
            _idIndices.Add(data.Id);
        }
        else
        {
            StudentSinglyNode curNode = _head;
            if (_idIndices.Contains(data.Id))
            {
                Console.WriteLine($"student with id = {data.Id} already in LL");
                return;
            }
            while (curNode.Next != null)
            {
                _idIndices.Add(data.Id);
                curNode = curNode.Next;
            }
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
            StudentSinglyNode? prevNode = null;
            StudentSinglyNode? curNode = _head;
            while (curNode != null)
            {
                if (curNode.EqId(id))
                {
                    if (prevNode == null)
                    {
                        _head = curNode.Next;
                    }
                    else
                    {
                        prevNode.Next = curNode.Next;
                    }

                    return true;
                }

                prevNode = curNode;
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
        StudentSinglyLikedList studentLL = new StudentSinglyLikedList();
        Console.WriteLine("> help");

        while (true)
        {
            string? command = null;
            while (command == null)
            {
                Console.Write("> ");
                command = Console.ReadLine();
            }

            switch (command)
            {
                case "add":
                    Console.WriteLine("Appending to student LL:");
                    bool idConvErr = false;
                    int id = 0;
                    while (!idConvErr)
                    {
                        string? idStr = null;
                        while (idStr == null)
                        {
                            Console.Write("ID: ");
                            idStr = Console.ReadLine();
                        }

                        try
                        {
                            id = Convert.ToInt32(idStr);
                            idConvErr = true;
                        }
                        catch
                        {
                        }
                    }

                    string? nameStr = null;
                    while (nameStr == null)
                    {
                        Console.Write("Name: ");
                        nameStr = Console.ReadLine();
                    }

                    bool ageConvErr = false;
                    int age = 0;
                    while (!ageConvErr)
                    {
                        string? ageStr = null;
                        while (ageStr == null)
                        {
                            Console.Write("Age: ");
                            ageStr = Console.ReadLine();
                        }

                        try
                        {
                            age = Convert.ToInt32(ageStr);
                            ageConvErr = true;
                        }
                        catch
                        {
                        }
                    }

                    string? courseStr = null;
                    while (courseStr == null)
                    {
                        Console.Write("Course: ");
                        courseStr = Console.ReadLine();
                    }

                    bool yearLevelConvErr = false;
                    int yearLevel = 0;
                    while (!yearLevelConvErr)
                    {
                        string? yearLevelStr = null;
                        while (yearLevelStr == null)
                        {
                            Console.Write("Year Level: ");
                            yearLevelStr = Console.ReadLine();
                        }

                        try
                        {
                            yearLevel = Convert.ToInt32(yearLevelStr);
                            yearLevelConvErr = true;
                        }
                        catch
                        {
                        }
                    }

                    studentLL.Append(new Student(id, nameStr, age, courseStr, yearLevel));
                    studentLL.Print();
                    break;
                case "get":
                    Console.WriteLine("Print specific student:");
                    string? studentToGetStr = null;
                    while (studentToGetStr == null)
                    {
                        Console.Write("Student ID to delete: ");
                        studentToGetStr = Console.ReadLine();
                    }

                    int studentIdToGet = Convert.ToInt32(studentToGetStr);
                    StudentSinglyNode? studentLLNode = studentLL.GetId(studentIdToGet);
                    if (studentLLNode == null)
                    {
                        Console.WriteLine($"student with id = {studentIdToGet} wasn't found");
                    }
                    else
                    {
                        studentLLNode.Print();
                    }

                    break;
                case "delete":
                    Console.Write("Deleting specific student:");
                    string? studentToDeleteStr = null;
                    while (studentToDeleteStr == null)
                    {
                        Console.WriteLine("Student ID to delete: ");
                        studentToDeleteStr = Console.ReadLine();
                    }

                    int studentToDelete = Convert.ToInt32(studentToDeleteStr);
                    bool stat = studentLL.RemoveId(studentToDelete);
                    if (stat)
                    {
                        Console.WriteLine($"Student with id = {studentToDelete} successfuly deleted");
                    }
                    else
                    {
                        Console.WriteLine($"Couldn't find student with id = {studentToDelete}");
                    }

                    Console.WriteLine("New student LL without the deleted student:");
                    studentLL.Print();
                    break;
                case "exit":
                    goto exited;
                case "print":
                    studentLL.Print();
                    break;
                case "help":
                    Console.WriteLine("Commands:");
                    Console.WriteLine("add");
                    Console.WriteLine("get");
                    Console.WriteLine("delete");
                    Console.WriteLine("exit");
                    Console.WriteLine("print");
                    Console.WriteLine("help");
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }

        exited: ;
        Console.WriteLine("Goodbye!");
    }
}
