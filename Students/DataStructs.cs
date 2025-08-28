namespace Students;

//class StudentSinglyNode
//{
//    public StudentSinglyNode? Next { get; set; }
//    private Student _data;
//
//    public StudentSinglyNode(Student data)
//    {
//        _data = data;
//    }
//
//    public void Append(Student data)
//    {
//        Next = new StudentSinglyNode(data);
//    }
//
//    public void Print()
//    {
//        Console.WriteLine(_data.ToString());
//    }
//
//    public bool EqId(int other) => _data.Id == other;
//}
//
//class StudentSinglyLikedList
//{
//    private StudentSinglyNode? _head;
//    private HashSet<int> _idIndices;
//
//    public StudentSinglyLikedList()
//    {
//        _idIndices = new HashSet<int>();
//    }
//
//    public void Append(Student data)
//    {
//        if (_head == null)
//        {
//            _head = new StudentSinglyNode(data);
//            _idIndices.Add(data.Id);
//        }
//        else
//        {
//            StudentSinglyNode curNode = _head;
//            if (_idIndices.Contains(data.Id))
//            {
//                Console.WriteLine($"student with id = {data.Id} already in LL");
//                return;
//            }
//            while (curNode.Next != null)
//            {
//                _idIndices.Add(data.Id);
//                curNode = curNode.Next;
//            }
//            curNode.Append(data);
//        }
//    }
//
//    public void Print()
//    {
//        if (_head == null)
//        {
//            Console.WriteLine("No elements in LL");
//        }
//        else
//        {
//            StudentSinglyNode? curNode = _head;
//            while (curNode != null)
//            {
//                curNode.Print();
//                curNode = curNode.Next;
//            }
//        }
//    }
//
//    public StudentSinglyNode? GetId(int id)
//    {
//        if (_head != null)
//        {
//            StudentSinglyNode? curNode = _head;
//            while (curNode != null)
//            {
//                if (curNode.EqId(id)) return curNode;
//                curNode = curNode.Next;
//            }
//        }
//
//        return null;
//    }
//
//    public bool RemoveId(int id)
//    {
//        if (_head != null)
//        {
//            StudentSinglyNode? prevNode = null;
//            StudentSinglyNode? curNode = _head;
//            while (curNode != null)
//            {
//                if (curNode.EqId(id))
//                {
//                    if (prevNode == null)
//                    {
//                        _head = curNode.Next;
//                    }
//                    else
//                    {
//                        prevNode.Next = curNode.Next;
//                    }
//
//                    return true;
//                }
//
//                prevNode = curNode;
//                curNode = curNode.Next;
//            }
//        }
//
//        return false;
//    }
//}
interface IId
{
    public int Id { get; set; }
}

class SinglyNode<T> where T : class, IId
{
    public SinglyNode<T>? Next { get; set; }
    private T _data;

    public SinglyNode(T data)
    {
        _data = data;
    }

    public void Append(T data)
    {
        Next = new SinglyNode<T>(data);
    }

    public void Print()
    {
        Console.WriteLine(_data.ToString());
    }

    public bool EqId(int other) => _data.Id == other;
}

class SinglyLikedList<T> where T: class, IId
{
    private SinglyNode<T>? _head;
    private HashSet<int> _idIndices;

    public SinglyLikedList()
    {
        _idIndices = new HashSet<int>();
    }

    public void Append(T data)
    {
        if (_head == null)
        {
            _head = new SinglyNode<T>(data);
            _idIndices.Add(data.Id);
        }
        else
        {
            SinglyNode<T> curNode = _head;
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
            SinglyNode<T>? curNode = _head;
            while (curNode != null)
            {
                curNode.Print();
                curNode = curNode.Next;
            }
        }
    }

    public SinglyNode<T>? GetId(int id)
    {
        if (_head != null)
        {
            SinglyNode<T>? curNode = _head;
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
            SinglyNode<T>? prevNode = null;
            SinglyNode<T>? curNode = _head;
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
