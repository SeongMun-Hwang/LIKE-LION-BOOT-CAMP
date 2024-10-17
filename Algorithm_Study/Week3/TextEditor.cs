using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{

    internal class TextEditor
    {
        string state;
        Stack<string> redoStack;
        Stack<string> undoStack;

        void Insert(string text)
        {
            undoStack.Push(state);
            state += text;
        }
        void Delete()
        {
            undoStack.Push(state);
            state=state.Substring(0,state.Length-1);
        }
        void Undo()
        {
            if (undoStack.IsEmpty())
            {
                Console.WriteLine("Enable undo");
            }
            else
            {
                redoStack.Push(state);
                state = undoStack.Pop();
            }
        }
        void Redo()
        {
            if (redoStack.IsEmpty())
            {
                Console.WriteLine("Unable Redo");
            }
            else
            {
                undoStack.Push(state);
                state=redoStack.Pop();
            }
        }
        public TextEditor()
        {
            state="";
            redoStack = new Stack<string>();
            undoStack = new Stack<string>();
            while (true){
                Console.WriteLine("명령어 입력 (Insert \"Text\", Delete, Undo, Redo, Exit");
                Console.Write("명령어 : ");
                string command=Console.ReadLine();

                if(command.StartsWith("Insert "))
                {
                    string text = command.Substring(7).Trim('"');
                    Insert(text);
                }
                else if (command == "Exit")
                {
                    break;
                }
                else
                {
                    switch (command)
                    {
                        case "Delete":
                            Delete(); break;
                        case "Undo":
                            Undo(); break;
                        case "Redo":
                            Redo(); break;
                    }
                }
                Console.WriteLine(state);
            }
        }
        public static void Start()
        {
            new TextEditor();
        }
    }
}
