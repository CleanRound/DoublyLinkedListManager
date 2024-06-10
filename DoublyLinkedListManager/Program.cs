public class DoublyLinkedList<T>
{
    private class Node
    {
        public T Data;
        public Node Next;
        public Node Previous;

        public Node(T data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }
    }

    private Node head;
    private Node tail;
    private int count;

    public DoublyLinkedList()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public void Add(T item)
    {
        Node newNode = new Node(item);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }
        count++;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        Node newNode = new Node(item);

        if (index == 0)
        {
            newNode.Next = head;
            if (head != null)
            {
                head.Previous = newNode;
            }
            head = newNode;
            if (count == 0)
            {
                tail = newNode;
            }
        }
        else if (index == count)
        {
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }
        else
        {
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            newNode.Next = current;
            newNode.Previous = current.Previous;
            current.Previous.Next = newNode;
            current.Previous = newNode;
        }
        count++;
    }

    public bool Remove(T item)
    {
        Node current = head;

        while (current != null)
        {
            if (current.Data.Equals(item))
            {
                if (current.Previous == null)
                {
                    head = current.Next;
                    if (head != null)
                    {
                        head.Previous = null;
                    }
                }
                else
                {
                    current.Previous.Next = current.Next;
                }

                if (current.Next == null)
                {
                    tail = current.Previous;
                    if (tail != null)
                    {
                        tail.Next = null;
                    }
                }
                else
                {
                    current.Next.Previous = current.Previous;
                }

                count--;
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        Node current = head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }

        if (current.Previous == null)
        {
            head = current.Next;
            if (head != null)
            {
                head.Previous = null;
            }
        }
        else
        {
            current.Previous.Next = current.Next;
        }

        if (current.Next == null)
        {
            tail = current.Previous;
            if (tail != null)
            {
                tail.Next = null;
            }
        }
        else
        {
            current.Next.Previous = current.Previous;
        }

        count--;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        Node current = head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }
        return current.Data;
    }

    public int Count
    {
        get { return count; }
    }

    public bool Contains(T item)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.Equals(item))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }
}


class Program
{
    static void Main()
    {
        var list = new DoublyLinkedList<string>();

        list.Add("Item 1");
        list.Add("Item 2");
        list.Add("Item 3");

        Console.WriteLine($"Count: {list.Count}");
        Console.WriteLine($"Item at index 1: {list.Get(1)}");

        list.Insert(1, "New Item");

        Console.WriteLine($"Item at index 1 after insert: {list.Get(1)}");
        Console.WriteLine($"Item at index 2 after insert: {list.Get(2)}");

        list.Remove("Item 2");

        Console.WriteLine($"Count after remove: {list.Count}");
        Console.WriteLine($"Contains 'Item 2': {list.Contains("Item 2")}");

        list.RemoveAt(1);

        Console.WriteLine($"Count after remove at index 1: {list.Count}");

        list.Clear();

        Console.WriteLine($"Count after clear: {list.Count}");
    }
}
