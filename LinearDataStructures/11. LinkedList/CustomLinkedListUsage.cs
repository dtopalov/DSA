// 11. Implement the data structure linked list.

//Define a class ListItem<T> that has two fields: value(of type T) and NextItem(of type ListItem<T>).
//Define additionally a class LinkedList<T> with a single field FirstElement(of type ListItem<T>).

namespace _11.LinkedList
{
    using System;

    using _11.LinkedList.LinkedListImplementation;

    public class CustomLinkedListUsage
    {
        static void Main()
        {
            var testList = new CustomLinkedList<string>();
            testList.Add("First");
            testList.Add("Last");
            testList.AddFirst("New first");
            testList.AddLast("New last");

            Console.WriteLine("Linked list contents: {0}\n", string.Join(" --> ", testList));

            testList.RemoveFirst();
            testList.RemoveLast();

            Console.WriteLine("After removing New First and New Last: ");
            Console.WriteLine("Linked list contents: {0}\n", string.Join(" --> ", testList));

            testList.Add("Some value");
            testList.Remove("Last");

            Console.WriteLine("After adding Some value and removing Last by value: ");
            Console.WriteLine("Linked list contents: {0}\n", string.Join(" --> ", testList));
        }
    }
}
