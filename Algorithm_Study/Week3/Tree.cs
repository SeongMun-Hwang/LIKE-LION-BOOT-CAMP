using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace C_
{
    internal class Tree<T>
    {
        public TreeNode<T> Root;
        public Tree(T rootData)
        {
            Root = new TreeNode<T>(rootData);
        }
        public void Print()
        {
            Root.PrintTree();
        }
    }
    public class TreeNode<T>
    {
        public T Data;
        public List<TreeNode<T>> Children;

        public TreeNode(T data)
        {
            Data = data;
            Children = new List<TreeNode<T>>();
        }
        public TreeNode<T> AddChild(TreeNode<T> child)
        {
            Children.Add(child);
            return child;
        }
        public void PrintTree(string indent = "")
        {
            Console.WriteLine(indent + Data.ToString());
            foreach (TreeNode<T> child in Children)
            {
                child.PrintTree(indent + " ");
            }
        }
        public TreeNode<T> FindChild(T data)
        {
            foreach (TreeNode<T> child in Children)
            {
                if (child.Data.Equals(data))
                {
                    return child;
                }
            }
            return null;
        }
        public void PrintChildren()
        {
            foreach (TreeNode<T> child in Children)
            {
                Console.WriteLine(child.Data.ToString());
            }
        }
        public TreeNode<T> FindParent(TreeNode<T> current)
        {
            foreach (TreeNode<T> child in current.Children)
            {
                if (child == this)
                {
                    return current;
                }
                TreeNode<T> result = FindParent(child);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }
        public string FindPath(TreeNode<T> current, string path = "")
        {
            if (current == this)
            {
                return path + "/" + current.Data;
            }
            foreach (TreeNode<T> child in current.Children)
            {
                string p = FindPath(child, path + "/" + current.Data);
                if (p != null)
                {
                    return p;
                }
            }
            return null;
        }
    }
}