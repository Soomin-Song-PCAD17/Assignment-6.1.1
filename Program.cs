/// 1. Implement a single linked list with each next representing a house. You may add data in it like house houseNumber, brief address, type of house ( like Ranch, Colonial) . each house (next) will be linked to next .Give facility to the user to search a house by its houseNumber and then display the details. ( Windows / Console)
/// 
HouseData House1 = new HouseData(123, "123 Maria Road", "3 story apartment");
HouseData House2 = new HouseData(130, "130 Maria Road", "5 story apartment");
HouseData House3 = new HouseData(135, "135 Palisade Street", "Ranch");
HouseData House4 = new HouseData(158, "158 Swancreek Avenue", "Colonial");
HouseData House5 = new HouseData(1711, "1711 Maria Road", "5 story apartment");

var LList = new HouseLinkedList(new HouseNode(House1));
LList.DisplayAll();
Console.WriteLine();

LList.AddAfter(0, House2);
LList.DisplayAll();
Console.WriteLine();

LList.AddHead(House3);
LList.DisplayAll();
Console.WriteLine();

LList.AddTail(House4);
LList.DisplayAll();
Console.WriteLine();

LList.Search(1711);
Console.WriteLine();

LList.Search(123);
Console.WriteLine();

LList.AddAfter(2, House5);
LList.DisplayAll();
Console.WriteLine();

LList.RemoveAt(1);
LList.DisplayAll();
Console.WriteLine();

Console.ReadKey();

class HouseLinkedList
{
    HouseNode headHouse;
    int Length;
    public HouseLinkedList(HouseNode houseNode)
    {
        headHouse = houseNode;
        Length = 0;

        // determine length in case houseNode.next!=null
        HouseNode pointer = headHouse;
        while (pointer != null)
        {
            pointer = pointer.Next;
            Length++;
        }
    }

    public void DisplayAll()
    {
        Console.WriteLine($"Linked List of size {Length}:");
        HouseNode pointer = headHouse;
        pointer.HouseData.DisplayData();

        while (pointer.Next != null)
        {
            Console.WriteLine(" --> ");
            pointer.Next.HouseData.DisplayData();
            pointer = pointer.Next;
        }
        Console.WriteLine();
    }

    public void AddHead(HouseData data)
    {
        headHouse = new HouseNode(data, headHouse);
        Length++;
    }

    public void AddAfter(int index, HouseData data)
    {
        HouseNode pointer = Get(index);

        pointer.Next = new HouseNode(data, pointer.Next);
        Length++;
    }

    public void AddTail(HouseData data)
    {
        AddAfter(Length - 1, data);
    }

    public void RemoveAt(int index)
    {
        HouseNode pointer = Get(index - 1);

        if (pointer == null || pointer.Next == null)
        {
            return;
        }
        pointer.Next = pointer.Next.Next;
        Length--;
    }

    public HouseNode Get(int index)
    {
        HouseNode pointer = headHouse;
        // traverse to index
        for (int i = 0; i < index - 1; i++)
        {
            pointer = pointer.Next;
        }
        return pointer;
    }

    public HouseNode Search(int houseId)
    {
        HouseNode pointer = headHouse;
        while (true)
        {
            if(pointer==null) { Console.WriteLine($"House ID {houseId} not found.");  return null; }
            if(pointer.HouseData.HouseId == houseId) { Console.WriteLine(pointer);  return pointer; }
            pointer = pointer.Next;
        }
    }
}

class HouseNode
{
    public HouseData HouseData;
    public HouseNode Next;

    public HouseNode(HouseData data,HouseNode next)
    {
        HouseData = data;
        Next = next;
    }
    public HouseNode(HouseData data)
    {
        HouseData = data;
        Next = null;
    }

    public override string ToString()
    {
        return $"{HouseData}";
    }
}

class HouseData
{
    public int HouseId;
    public string HouseNumber;
    public string HouseType;

    public HouseData(int houseId, string houseNumber, string houseType)
    {
        HouseId = houseId;
        HouseNumber = houseNumber;
        HouseType = houseType;
    }

    public void DisplayData()
    {
        Console.Write($"{HouseNumber}: {HouseType}");
    }

    public override string ToString()
    {
        return $"{HouseNumber}: {HouseType}";
    }
}