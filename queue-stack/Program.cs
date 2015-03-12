using QueueExample;
using StackExample;
using System;

namespace QueueStackExample {
  public class Program {
    public static void Main(string[] args) {
      Queue queue = new Queue();
      Stack stack = new Stack();
      for (int i = 0; i < 5; i++) {
        queue.Enqueue(i);
        stack.Push(i);
      }
      Console.WriteLine("Queue:");
      for (int i = 0; i < 5; i++) {
        Console.WriteLine(queue.Dequeue());

      }
      Console.WriteLine("Stack:");
      for (int i = 0; i < 5; i++) {
        Console.WriteLine(stack.Pop());
      }
    }
  }
}
