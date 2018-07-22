namespace P09.CollectionHierarchy
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main()
        {
            var elements = Console.ReadLine().Split();

            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            var addCollectionIndices = new List<int>();
            var removableCollectionsIndices = new List<int>();

            foreach (var element in elements)
            {
                addCollectionIndices.Add(addCollection.Add(element));

                addRemoveCollection.Add(element);
                myList.Add(element);

                removableCollectionsIndices.Add(0);
            }

            var countOfRemoveOperations = int.Parse(Console.ReadLine());

            var addRemoveCollectionRemovedElements = new List<string>();
            var myListRemovedElements = new List<string>();

            for (int counter = 0; counter < countOfRemoveOperations; counter++)
            {
                addRemoveCollectionRemovedElements.Add(addRemoveCollection.Remove());
                myListRemovedElements.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(' ', addCollectionIndices));
            Console.WriteLine(string.Join(' ', removableCollectionsIndices));
            Console.WriteLine(string.Join(' ', removableCollectionsIndices));
            Console.WriteLine(string.Join(' ', addRemoveCollectionRemovedElements));
            Console.WriteLine(string.Join(' ', myListRemovedElements));
        }
    }
}