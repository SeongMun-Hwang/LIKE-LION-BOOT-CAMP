using System;
using static System.Console;

namespace Program
{
    class MainApp
    {
        abstract class Shape
        {
            public abstract void Area();
        }
        class Circle : Shape
        {
            int r;
            public Circle(int r)
            {
                this.r = r;
            }
            public override void Area()
            {
                WriteLine(r * r * 3.14);
            }
        }
        class Rectangle : Shape
        {
            int w, h;
            public Rectangle(int w, int h)
            {
                this.w = w;
                this.h = h;
            }
            public override void Area()
            {
                WriteLine(w * h);
            }
        }
        //#2
        static void Main(string[] args)
        {
            Circle c = new Circle(5);
            Rectangle r = new Rectangle(3, 4);

            c.Area();
            r.Area();
        }
    }
}