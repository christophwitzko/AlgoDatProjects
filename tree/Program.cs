using System;
using System.Collections;

namespace BinaryTreeExample {
  public class User: IComparable {
    public string FirstName;
    public string LastName;

    public int CompareTo(object obj) {
      User otherUser = (User) obj;
      if (otherUser == null) {
        throw new ArgumentException("Object is not a User");
      }
      string tstr = this.LastName + this.FirstName;
      string ostr = otherUser.LastName + otherUser.FirstName;
      return String.Compare(tstr, ostr); 
    }

    public User (string first, string last) {
      this.FirstName = first;
      this.LastName = last;
    }

    public override string ToString () {
      return this.FirstName + " " + this.LastName;
    }
  }
  public class Program {
    public static void Main(string[] args) {
      BinaryTree<User> btree = new BinaryTree<User>();
      btree.Insert(new User("Eric", "Smith"));
      btree.Insert(new User("Chris", "Johnson"));
      btree.Insert(new User("Paul", "Williams"));
      btree.Insert(new User("Michael", "Jones"));
      btree.Insert(new User("Sarah", "Jones"));
      btree.Insert(new User("Christina", "Jones"));
      btree.Insert(new User("A", "B"));
      btree.Insert(new User("A", "C"));
      Console.WriteLine(btree);
      Console.WriteLine("------ Inorder ------");
      btree.TraverseInorder(btree.Root, (value, owner) => {
        Console.WriteLine(value);
      });
      Console.WriteLine("------ Postorder ------");
      btree.TraversePostorder(btree.Root, (value, owner) => {
        Console.WriteLine(value);
      });
      Console.WriteLine("------ Preorder ------");
      btree.TraversePreorder(btree.Root, (value, owner) => {
        Console.WriteLine(value);
      });
      btree.Clear();
    }
  }
}
