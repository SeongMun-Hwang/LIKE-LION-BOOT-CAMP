using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    internal class CommandLine
    {
        Tree<string> tree;
        TreeNode<string> root;
        TreeNode<string> current;

        public CommandLine()
        {
            tree = new Tree<string>("root");
            root = tree.Root;
            current = root;

            while (true)
            {
                Console.Write(current.Data + " > ");
                string cmd = Console.ReadLine();

                string[] parts = cmd.Split(' ');
                switch (parts[0])
                {
                    case "mk":
                        current.AddChild(new TreeNode<string>(parts[1]));
                        break;
                    case "print":
                        tree.Print();
                        break;
                    case "cd":
                        TreeNode<string> child = current.FindChild(parts[1]);
                        if (parts[1] == "..")
                        {
                            TreeNode<string> parent = current.FindParent(root);
                            if (parent == null)
                            {
                                Console.WriteLine("Already root dic");
                            }
                            else
                            {
                                current = parent;
                            }
                        }
                        else
                        {
                            if (child != null)
                            {
                                current = child;
                            }
                            else
                            {
                                Console.WriteLine("Directory not found.");
                            }
                        }
                        break;
                    case "ls":
                        current.PrintChildren();
                        break;
                    case "rm":
                        TreeNode<string> child2 = current.FindChild(parts[1]);
                        if(child2 != null)
                        {
                            current.Children.Remove(child2);
                            Console.WriteLine("Delete Success");
                        }
                        else
                        {
                            Console.WriteLine("There's no Data");
                        }
                        break;
                    case "pwd":
                        Console.WriteLine(current.FindPath(root));
                        break;
                }
                if (parts[0] == "exit")
                {
                    break;
                }
            }
        }
        public static void Start()
        {
            new CommandLine();
        }
    }
}
