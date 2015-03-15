using System;
using System.Collections.Generic;

namespace GraphExample {
  public class Program {
    public static void DFSVisit (int vtx, bool[] visit, int[,] adjmatrix) {
      int size = adjmatrix.GetLength(0);
      visit[vtx] = true;
      Console.WriteLine("visit vertex: " + vtx);
      for (int i = 0; i < size; i++) {
        if (!visit[i] && adjmatrix[vtx, i] == 1) {
          DFSVisit(i, visit, adjmatrix);
        }
      }
    }

    public static void BFSVisit (int vtx, bool[] visit, int[,] adjmatrix) {
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
      bool[] visitd = new bool[10];
      DFSVisit(0, visitd, adjmatrix);
      Console.WriteLine(new String('-', 20));
      bool[] visitb = new bool[10];
      BFSVisit(0, visitb, adjmatrix);
    }
  }
}
