using System;
using System.Collections.Generic;

namespace BinaryTreeExample {

  public class BinaryTreeNode<T> {
    public T Data;
    public BinaryTreeNode<T> Left;
    public BinaryTreeNode<T> Right;

    public BinaryTreeNode (T value) {
      this.Data = value;
    }

    public override string ToString () {
      return this.Data.ToString();
    }
  }

  public class BinaryTree<T> {
    private BinaryTreeNode<T> root;
    private ulong count;

    private readonly IComparer<T> comparer;

    public BinaryTreeNode<T> Root {
      get {
        return this.root;
      }
    }

    public ulong Count {
      get {
        return this.count;
      }
    }

    public BinaryTree () {
      this.root = null;
      this.count = 0;
      this.comparer = Comparer<T>.Default;
    }

    private void add (ref BinaryTreeNode<T> tree, BinaryTreeNode<T> node) {
      if (tree == null) {
        tree = node;
      } else {
        int comp = this.comparer.Compare(node.Data, tree.Data);
        if (comp == 0) {
          throw new Exception("node already exists");
        }
        if (comp > 0 ) {
          add(ref tree.Left, node);
        } else {
          add(ref tree.Right, node);
        }
      }
    }

    public BinaryTreeNode<T> Insert (T value) {
      BinaryTreeNode<T> node = new BinaryTreeNode<T>(value);
      if (root == null) {
        root = node;
      } else {
        add(ref root, node);
      }
      this.count++;
      return node;
    }

    public string Print(string initial, BinaryTreeNode<T> root, string prefix = "") {
      if (root == null) {
        initial += prefix + "+- <null>\n";
      } else {
        initial += prefix + "+- " + root.ToString() + "\n";
        initial = Print(initial, root.Left, prefix + "|  ");
        initial = Print(initial, root.Right, prefix + "|  ");
      }
      return initial;
    }

    public override string ToString () {
      return Print("BinaryTree(" + this.count + ")\n", this.root);
    }
  }
}
