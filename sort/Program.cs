using LinkedListExample;
using System;
using System.Diagnostics;

namespace SortExample {
  public class Program {

    public static LinkedList<int> genArray (ulong length = 10) {
      LinkedList<int> ilist = new LinkedList<int>(length);
      Random rnd = new Random();
      for (ulong i = 0; i < length; i++) {
        ilist[i] = rnd.Next(0, 10 * (int)length);
      }
      return ilist;
    }

    public static bool check (LinkedList<int> a, LinkedList<int> b) {
      if (a.Count != b.Count) {
        return false;
      }
      for (ulong i = 0; i < a.Count; i++) {
        if (System.Collections.Generic.Comparer<int>.Default.Compare(a[i], b[i]) != 0) {
          return false;
        }
      }
      return true;
    }

    public delegate LinkedList<int> Sort (LinkedList<int> arr);

    public static long benchmark (LinkedList<int> arr, LinkedList<int> comp, Sort fn) {
      Stopwatch stopWatch = new Stopwatch();
      stopWatch.Start();
      LinkedList<int> aout = fn(arr);
      stopWatch.Stop();
      bool ok = check(comp, aout);
      if (!ok) {
        Console.WriteLine("ERROR: array not sorted correctly");
      }
      return stopWatch.ElapsedMilliseconds;
    }

    public class DataPoint {
      public string Name;
      public long Time;
      public ulong Size;

      public DataPoint (string name, long time, ulong size) {
        this.Name = name;
        this.Time = time;
        this.Size = size;
      }

      public override string ToString () {
        return this.Name + "@" + this.Size + "(" + this.Time + ")";
      }
    }

    public static LinkedList<DataPoint> benchmarkSort (ulong max) {
      Console.WriteLine("Running for size=" + max);
      LinkedList<int> sarr = genArray(max);
      Sort qsort = new QuickSort<int>().Sort;
      LinkedList<int> comp = qsort(sarr);
      LinkedList<DataPoint> res = new LinkedList<DataPoint>();
      res.AddLast(new DataPoint("BubbleSort", benchmark(sarr, comp, new BubbleSort<int>().Sort), max));
      res.AddLast(new DataPoint("SelectionSort", benchmark(sarr, comp, new SelectionSort<int>().Sort), max));
      res.AddLast(new DataPoint("InsertionSort", benchmark(sarr, comp, new InsertionSort<int>().Sort), max));
      res.AddLast(new DataPoint("MergeSort", benchmark(sarr, comp, new MergeSort<int>().Sort), max));
      res.AddLast(new DataPoint("QuickSort", benchmark(sarr, comp, qsort), max));
      return res;
    }

    public static void Main(string[] args) {
      LinkedList<LinkedList<DataPoint>> rows = new LinkedList<LinkedList<DataPoint>>();
      for (ulong i = 100; i < 1000; i+= 100) {
        LinkedList<DataPoint> res = benchmarkSort(i);
        rows.AddLast(res);
      }
      Console.WriteLine("------------------------------------------------");
      Console.WriteLine("Size\t| BS\tSS\tIS\tMS\tQS");
      rows.Traverse(rows.First, (dps, odps) => {
        Console.Write(dps[0].Size + "\t| ");
        dps.Traverse(dps.First, (dp, odp) => {
          Console.Write(dp.Time + "\t");
        });
        Console.WriteLine();
      });
      Console.WriteLine("------------------------------------------------");
    }
  }
}
