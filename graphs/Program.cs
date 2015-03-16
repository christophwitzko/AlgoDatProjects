using LinkedListExample;
using QueueExample;
using System;

namespace GraphExample {
  public class Program {
    public static void DFSVisitMatrix (int vtx, bool[] visit, int[,] adjmatrix) {
      int size = adjmatrix.GetLength(0);
      visit[vtx] = true;
      Console.WriteLine("visit vertex: " + vtx);
      for (int i = 0; i < size; i++) {
        if (!visit[i] && adjmatrix[vtx, i] == 1) {
          DFSVisitMatrix(i, visit, adjmatrix);
        }
      }
    }

    public static void DFSVisitList (int vtx, bool[] visit, LinkedList<int>[] adjlist) {
      int size = adjlist.Length;
      visit[vtx] = true;
      Console.WriteLine("visit vertex: " + vtx);
      adjlist[vtx].Traverse(adjlist[vtx].First, (val, node) => {
        if (!visit[val]) {
          DFSVisitList(val, visit, adjlist);
        }
      });
    }

    public static void BFSVisitMatrix (int vtx, bool[] visit, int[,] adjmatrix) {
      int size = adjmatrix.GetLength(0);
      Queue<int> todo = new Queue<int>();
      todo.Enqueue(vtx);
      while(todo.Count > 0) {
        int curr = todo.Dequeue();
        if (!visit[curr]) {
          visit[curr] = true;
          Console.WriteLine("visit vertex: " + curr);
          for (int i = 0; i < size; i++) {
            if (!visit[i] && adjmatrix[curr, i] == 1) {
              todo.Enqueue(i);
            }
          }
        }
      }
    }

    public static void BFSVisitList (int vtx, bool[] visit, LinkedList<int>[] adjlist) {
      int size = adjlist.Length;
      Queue<int> todo = new Queue<int>();
      todo.Enqueue(vtx);
      while(todo.Count > 0) {
        int curr = todo.Dequeue();
        if (!visit[curr]) {
          visit[curr] = true;
          Console.WriteLine("visit vertex: " + curr);
          adjlist[curr].Traverse(adjlist[curr].First, (val, node) => {
            if (!visit[val]) {
              todo.Enqueue(val);
            }
          });
        }
      }
    }

    public static LinkedList<int>[] ToAdjList (int[,] adjmatrix) {
      int size = adjmatrix.GetLength(0);
      LinkedList<int>[] list = new LinkedList<int>[size];
      for (int i = 0; i < size; i++) {
        list[i] = new LinkedList<int>();
        for (int j = 0; j < size; j++) {
          if (adjmatrix[i, j] == 1) {
            list[i].AddLast(j);
          }
        }
      }
      return list;
    }

    public static void Main(string[] args) {
      int[,] adjmatrix = new int[,] {
        //1  2  3  4  5  6  7  8  9  10
        { 0, 1, 1, 1, 1, 0, 0, 0, 0, 0},
        { 1, 0, 0, 0, 1, 1, 1, 0, 0, 0},
        { 1, 0, 0, 1, 0, 0, 0, 0, 0, 0},
        { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0},
        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1},
        { 0, 1, 0, 0, 0, 0, 1, 1, 0, 0},
        { 0, 1, 0, 0, 0, 1, 0, 1, 0, 0},
        { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0},
        { 0, 0, 0, 0, 1, 0, 0, 0, 0, 1},
        { 0, 0, 0, 0, 1, 0, 0, 0, 1, 0}
      };
      LinkedList<int>[] adjlist = ToAdjList(adjmatrix);
      Console.WriteLine("Depth First Search (Matrix):");
      bool[] visitd = new bool[10];
      DFSVisitMatrix(0, visitd, adjmatrix);
      Console.WriteLine("Depth First Search (List):");
      bool[] visitdl = new bool[10];
      DFSVisitList(0, visitdl, adjlist);
      Console.WriteLine(new String('-', 30));
      Console.WriteLine("Breadth First Search (Matrix):");
      bool[] visitb = new bool[10];
      BFSVisitMatrix(0, visitb, adjmatrix);
      Console.WriteLine("Breadth First Search (List):");
      bool[] visitbl = new bool[10];
      BFSVisitList(0, visitbl, adjlist);
    }
  }
}
