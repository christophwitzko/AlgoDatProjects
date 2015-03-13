using System;
using System.Collections.Generic;

namespace BinaryTreeExample {

  public class BinaryTreeNode<T> {
    public T Value;
    public BinaryTreeNode<T> Left;
    public BinaryTreeNode<T> Right;

    public BinaryTreeNode (T value) {
      this.Value = value;
    }

    public override string ToString () {
      return this.Value.ToString();
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

    public delegate void BinaryTreeNodeVisitor(T value, BinaryTreeNode<T> node);

    public BinaryTree () {
      this.root = null;
      this.count = 0;
      this.comparer = Comparer<T>.Default;
    }

    private void add (ref BinaryTreeNode<T> tree, BinaryTreeNode<T> node) {
      if (tree == null) {
        tree = node;
      } else {
        int comp = this.comparer.Compare(node.Value, tree.Value);
        if (comp == 0) {
          throw new Exception("node already exists");
        }
        if (comp < 0 ) {
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

    private BinaryTreeNode<T> search (BinaryTreeNode<T> tree, T value) {
      if (tree == null) {
        return null;
      }
      int comp = this.comparer.Compare(value, tree.Value);
      if (comp == 0) {
        return tree;
      }
      if (comp < 0) {
        return search(tree.Left, value);
      }
      return search(tree.Right, value);
    }

    public BinaryTreeNode<T> Search (T value) {
      return search(this.root, value);
    }

    public BinaryTreeNode<T> Delete (T value) {
      // TODO
      return null;
    }

    private void traversalClear (ref BinaryTreeNode<T> tree) {
      if (tree != null) {
        traversalClear(ref tree.Left);
        traversalClear(ref tree.Right);
        tree = null;
      }
    }

    public void Clear () {
      traversalClear(ref this.root);
      this.count = 0;
    }

    public ulong Height (BinaryTreeNode<T> node) {
      if (node == null) {
        return 0;
      }
      ulong lheight = Height(node.Left);
      ulong rheight = Height(node.Right);
      if (lheight > rheight) {
        return lheight + 1;
      }
      return rheight + 1;
    }

    public void TraverseInorder (BinaryTreeNode<T> node, BinaryTreeNodeVisitor visitor) {
      if (node != null) {
        TraverseInorder(node.Left, visitor);
        visitor(node.Value, node);
        TraverseInorder(node.Right, visitor);
      }
    }

    public void TraversePostorder (BinaryTreeNode<T> node, BinaryTreeNodeVisitor visitor) {
      if (node != null) {
        TraverseInorder(node.Left, visitor);
        TraverseInorder(node.Right, visitor);
        visitor(node.Value, node);
      }
    }

    public void TraversePreorder (BinaryTreeNode<T> node, BinaryTreeNodeVisitor visitor) {
      if (node != null) {
        visitor(node.Value, node);
        TraverseInorder(node.Left, visitor);
        TraverseInorder(node.Right, visitor);
      }
    }

    public void TraverseLevel (BinaryTreeNode<T> node, ulong level, BinaryTreeNodeVisitor visitor) {
      if (node != null) {
        if (level == 1) {
          visitor(node.Value, node);
        } else if (level > 1) {
          TraverseLevel(node.Left, level - 1, visitor);
          TraverseLevel(node.Right, level - 1, visitor);
        }
      }
    }

    public void TraverseLevelOrder (BinaryTreeNode<T> node, BinaryTreeNodeVisitor visitor) {
      for (ulong i = 1; i <= Height(node); i++) {
        TraverseLevel(node, i, visitor);
      }
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
