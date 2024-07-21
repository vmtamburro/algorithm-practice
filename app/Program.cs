using System;  
namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            //BigONotationPactice();
            //HashTablePractice();
            //ArrayPractice();
            //LinkedListPractice();
            //LowestCommonAncestor.Main(["8", "8 4 9 1 2 3 6 5", "1 2"]);
            //var test = CountingInversions.CountInversions(new int[] { 38, 27, 43, 3, 9, 82, 10 });
            //PrimsAlgorithm();
            // var minMaxRiddle = new MinMaxRiddle();
            // minMaxRiddle.MinMaxRiddle2();

            var _plantService = new PoisonousPlants();
            _plantService.PoisonousPlants1();
            _plantService.PoisonousPlants2();
        }

        private static void PrimsAlgorithm()
        {
            WeightedGraphPractice.DirectedWeightedGraph directedGraph = new WeightedGraphPractice.DirectedWeightedGraph();
            directedGraph.AddEdge(0, 1, 5);
            directedGraph.AddEdge(0, 2, 3);
            directedGraph.AddEdge(1, 3, 6);
            directedGraph.AddEdge(1, 2, 2);
            directedGraph.AddEdge(2, 4, 4);
            directedGraph.AddEdge(2, 5, 2);

            directedGraph.PrimsAlgorithm_FindMinimumSpanningTree();
        }


        private static void LinkedListPractice()
        {
            //Example();
            //DoublelinkedListInsert();
            DoubleLinkedListReverse();
            GetHeight();

            //FindMergedNodee();
        }

        private static void GetHeight()
        {
            var root = new TreeHeight.Node(4);
            root.Left = new TreeHeight.Node(2);
            root.Right = new TreeHeight.Node(6);
            root.Left.Left = new TreeHeight.Node(1);
            root.Left.Right = new TreeHeight.Node(3);
            root.Right.Left = new TreeHeight.Node(5);
            root.Right.Right = new TreeHeight.Node(7);

            int height = TreeHeight.Program.getHeight(root);
        }

        // private static void FindMergedNodee()
        // {
        //     SinglyLinkedListExample.SinglyLinkedList list1 = new SinglyLinkedListExample.SinglyLinkedList();
        //     list1.InsertNode(1);
        //     list1.InsertNode(2);
        //     list1.InsertNode(3);
        //     SinglyLinkedListExample.SinglyLinkedList list2 = new SinglyLinkedListExample.SinglyLinkedList();
        //     list2.InsertNode(1);
        //     list2.InsertNode(3);

        //     int output = SinglyLinkedLstExample.findMergeNode(list1, list2);
        // }

        private static void DoublelinkedListInsert()
        {
            DoublyLinkedList llist = new DoublyLinkedList();

            llist.InsertNode(2);
            llist.InsertNode(3);
            llist.InsertNode(4);

            DoublyLinkedListNode node = DoublyLinkedListExample.sortedInsert(llist.head, 1);
            llist.PrintDoublyLinkedList(node, " ");
        }

          private static void DoubleLinkedListReverse()
        {
            DoublyLinkedList llist = new DoublyLinkedList();

            llist.InsertNode(2);
            llist.InsertNode(3);
            llist.InsertNode(4);

            DoublyLinkedListNode node = DoublyLinkedListExample.reverse(llist.head);
            llist.PrintDoublyLinkedList(node, " ");
        }


        // private static void Example()
        // {
        //     LinkedList list = new LinkedList();

        //     // Inserting elements
        //     list.InsertAtBeginning(3);   // List: 3
        //     list.InsertAtBeginning(1);   // List: 1 -> 3
        //     list.InsertAtEnd(5);         // List: 1 -> 3 -> 5
        //     list.InsertAfterNode(list.head.next, 2); // List: 1 -> 3 -> 2 -> 5

        //     // Printing the linked list
        //     Console.WriteLine("Linked List:");
        //     list.PrintList();

        //     // Deleting an element
        //     list.DeleteNode(2);          // List: 1 -> 3 -> 5

        //     // Printing the linked list after deletion
        //     Console.WriteLine("Linked List after deletion:");
        //     list.PrintList();

        //     // Searching for an element
        //     int searchValue = 3;
        //     bool found = list.Search(searchValue);
        //     if (found)
        //     {
        //         Console.WriteLine($"Element {searchValue} found in the list");
        //     }
        //     else
        //     {
        //         Console.WriteLine($"Element {searchValue} not found in the list");
        //     }
        // }

        private static void ArrayPractice()
        {
            HourGlassSum();
            RotateLeft();
            MinimumBribes();
            MinimumSwaps();
            ArrayManipulations();
        }

        private static void ArrayManipulations()
        {
            int n = 10;
            List<List<int>> queries = new List<List<int>>
            {
            new List<int> { 2, 6, 8 },
            new List<int> { 3, 5, 7 },
            new List<int> { 1, 8, 1 },
            new List<int> { 5, 9, 15 }
            };

            long result = ArrayManipulation.arrayManipulation(n, queries);
        }

        private static void MinimumSwaps()
        {
            int[] arr = [4, 3, 1, 2];
            var numSwaps = MinSwaps.minimumSwaps(arr);
        }

        private static void MinimumBribes()
        {
            // var arr = new List<int> {4, 1, 2, 3};
            // var arr = new List<int> {1, 2, 3, 5, 4, 6, 7, 8};
            //var arr = new List<int>{2, 5, 1, 3, 4};

            var arr = new List<int> { 2, 1, 5, 3, 4 };
            MinBribes.minimumBribes(arr);
        }

        private static void RotateLeft()
        {
            List<int> arr = new List<int> { 1, 2, 3, 4, 5 };
            var newArr = LeftRotation.rotLeft(arr, 4);
        }

        private static void HourGlassSum()
        {
            List<List<int>> arr = new List<List<int>>
            {
                new List<int>{ 1, 1, 1, 0, 0, 0 },
                new List<int>{ 0, 1, 0, 0, 0, 0 },
                new List<int>{ 1, 1, 1, 0, 0, 0 },
                new List<int>{ 0, 0, 2, 4, 4, 0 },
                new List<int>{ 0, 0, 0, 2, 0, 0 },
                new List<int>{ 0, 0, 1, 2, 4, 0 }
            };

            int maxHourglassSum = global::HourGlassSum.hourglassSum(arr);
            Console.WriteLine("Maximum hourglass sum is: " + maxHourglassSum);
        }

        public static void HashTablePractice()
        {
            var HashTableExample = new HashTableExample();
            HashTableExample.Test();
        }

        public static void BigONotationPactice()
        {
            ConstantTime();
            ExponentialTime();
            LogarithmicTime();
            LinearithmicTime();
            FactorialTime();
        }

        private static void FactorialTime()
        {
            int[] arr = [10, 9, 8, 7, 6, 5, 4, 3, 2, 1];

            var FactorialTime = new FactorialTime();
            FactorialTime.GeneratePermutations(arr.ToList(), 1, 10);
        }

        private static void LinearithmicTime()
        {
            int[] arr = [10, 9, 8, 7, 6, 5, 4, 3, 2, 1];

            var LinearithmicTime = new LinearithmicTime();
            LinearithmicTime.MergeSort(arr);
        }

        private static void LogarithmicTime()
        {
            int[] arr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            var LogarithmicTime = new LogarithmicTime();
            LogarithmicTime.BinarySearch(arr, 3);
        }


        private static void ConstantTime()
        {
            int[] arr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            var constantTime = new ConstantTime();
            constantTime.GetFirstElement(arr);
        }

        private static void ExponentialTime()
        {
            var exponentialTime = new ExponentialTime();
            exponentialTime.Fibonacci(10);
        }
    }
}