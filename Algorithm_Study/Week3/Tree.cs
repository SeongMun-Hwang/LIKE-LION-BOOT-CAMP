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
        public int maxDepth = 0;
        public Tree(T rootData)
        {
            Root = new TreeNode<T>(rootData);
        }
        public void Print()
        {
            Root.PrintTree();
        }
        public void MaxDepth(TreeNode<T> node, int current =1)
        {
            if (node == null) return;
            maxDepth=Math.Max(maxDepth, current);

            foreach(TreeNode<T> child in node.Children)
            {
                MaxDepth(child, current);
            }
        }
        public int Sum(TreeNode<int> node)
        {
            if(node == null) return 0;
            int sum = node.Data;
            foreach(TreeNode<int> child in node.Children)
            {
                sum += Sum(child);
            }
            return sum;
        }
        public void FindTargetSum(TreeNode<int> node, int target, List<int> path, int currentSum)
        {
            if (node == null) return;
            path.Add(node.Data);
            currentSum += node.Data;

            if(node.Children.Count==0 && currentSum == target)
            {
                Console.WriteLine("Path : " + string.Join(", ", path));
            }
            foreach(TreeNode<int> child in node.Children)
            {
                FindTargetSum(child, target, path, currentSum);
            }
            path.RemoveAt(path.Count - 1);
        }
        public bool FindPath(TreeNode<char> node, char target, List<TreeNode<char>> path)
        {
            if(node==null) return false;
            path.Add(node);
            if(node.Data==target) return true;

            foreach(TreeNode<char> child in node.Children){
                if(FindPath(child, target, path)) return true;
            }

            path.RemoveAt(path.Count-1);
            return false;
        }
        public TreeNode<char> FindCLA(char node1, char node2)
        {
            List<TreeNode<char>> path1=new List<TreeNode<char>>();
            List<TreeNode<char>> path2=new List<TreeNode<char>>();

            if (FindPath(Root as TreeNode<char>, node1, path1) || 
                !FindPath(Root as TreeNode<char>, node2,path2))
            {
                Console.WriteLine("Not Found");
                return null;
            }
            int i = 0;
            for(i=0;i<path1.Count && i < path2.Count; i++)
            {
                if (path1[i].Data != path2[i].Data)
                {
                    break;
                }
            }
            return path1[i-1];

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