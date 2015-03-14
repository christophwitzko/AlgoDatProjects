using LinkedListExample;
using System;

namespace SortExample {
  public class Program {
    public static LinkedList<int> genArray () {
      LinkedList<int> ilist = new LinkedList<int>();
      ilist.AddLast(3);
      ilist.AddLast(9);
      ilist.AddLast(1);
      ilist.AddLast(6);
      ilist.AddLast(4);
      ilist.AddLast(7);
      ilist.AddLast(10);
      ilist.AddLast(8);
      ilist.AddLast(2);
      ilist.AddLast(5);
      return ilist;
    }
    public static void Main(string[] args) {
      Console.WriteLine("BubbleSort:");
      BubbleSort<int> bsort = new BubbleSort<int>();
      Console.WriteLine(bsort.Sort(genArray()));
      Console.WriteLine("--------------");
      Console.WriteLine("SelectionSort:");
      SelectionSort<int> ssort = new SelectionSort<int>();
      Console.WriteLine(ssort.Sort(genArray()));
      Console.WriteLine("--------------");
      Console.WriteLine("InsertionSort:");
      InsertionSort<int> isort = new InsertionSort<int>();
      Console.WriteLine(isort.Sort(genArray()));
      Console.WriteLine("--------------");
      Console.WriteLine("MergeSort:");
      MergeSort<int> msort = new MergeSort<int>();
      Console.WriteLine(msort.Sort(genArray()));
      Console.WriteLine("--------------");
      Console.WriteLine("QuickSort:");
      QuickSort<int> qsort = new QuickSort<int>();
      Console.WriteLine(qsort.Sort(genArray()));
      Console.WriteLine("--------------");
    }
  }
}
