using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    internal class TowerOfHanoi
    {
        System.Collections.Generic.Stack<int>[] towers = new System.Collections.Generic.Stack<int>[3];

        public TowerOfHanoi(int n)
        {
            towers[0] = new System.Collections.Generic.Stack<int>(n);
            towers[1] = new System.Collections.Generic.Stack<int>(n);
            towers[2] = new System.Collections.Generic.Stack<int>(n);

            for(int i = n; i >= 1; i--)
            {
                towers[0].Push(i);
            }
        }
        public void Move(int n,int from,int to,int spare)
        {
            if (n == 0) return;

            Move(n - 1, from, spare, to);

            int temp = towers[from].Pop();
            Console.WriteLine(temp +" 원반을 "+from+"에서 "+to+"로 이동");
            towers[to].Push(temp);

            Move(n - 1, spare, to, from);
        }
    }
}
