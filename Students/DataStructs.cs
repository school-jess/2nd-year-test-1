namespace Students;

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
            if (_idIndices.Contains(data.Id))
            {
                Console.WriteLine($"student with id = {data.Id} already in LL");
                return;
            }
            SinglyNode<T> curNode = _head;
            _idIndices.Add(data.Id);
            while (curNode.Next != null)
            {
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
