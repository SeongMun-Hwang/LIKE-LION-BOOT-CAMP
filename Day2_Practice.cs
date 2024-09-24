using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day2_Practice : MonoBehaviour
{
    struct Char
    {
        public string name;
        public int atk;
        public Char(string name,int atk)
        {
            this.name = name;
            this.atk = atk;
        }
    }
    //#12
    class MyStack
    {
        Stack<int> stack = new Stack<int>();

        public void push(int num)
        {
            stack.Push(num);
        }
        public void pop()
        {
            Debug.Log(stack.Pop());
        }
    }
    //#13
    class MyQueue
    {
        Queue<int> queue = new Queue<int>();

        public void push(int num)
        {
            queue.Enqueue(num);
        }
        public void pop()
        {
            Debug.Log(queue.Dequeue());
        }
    }
    void Start()
    {
        //#2
        List<List<int>> l = new List<List<int>>();
        for (int i = 0; i < 5; i++)
        {
            l.Add(new List<int>());
            for (int j = 0; j < 5; j++)
            {
                l[i].Add(Random.Range(0, 20));
                if (l[i][j] > 10)
                {
                    Debug.Log(l[i][j] + "\t");
                }
                else Debug.Log("Null\t");
            }
        }

        //#5
        for (int i = 1; i <= 1000; i += 5)
        {
            if (func(i + ""))
            {
                Debug.Log(i);
            }
        }

        //#6
        Dictionary<string, int> dic = new Dictionary<string, int>();
        dic.Add("슬라임", 1);
        dic.Add("달팽이", 2);
        dic.Add("주황버섯", 3);
        dic.Add("엑스텀프", 4);
        dic.Add("스톤골렘", 5);

        int sum = 0;
        foreach (var i in dic)
        {
            sum += i.Value;
        }
        Debug.Log("평군 : " + sum / dic.Count);

        //#7
        Dictionary<string, string> dicA = new Dictionary<string, string>();
        dicA.Add("사과", "Apple");
        dicA.Add("바나나", "Banana");
        dicA.Add("수박", "Watermelon");
        dicA.Add("복숭아", "Peach");
        dicA.Add("포도", "Grape");

        Dictionary<string, string> dicB = new Dictionary<string, string>();

        foreach (var v in dicA)
        {
            Debug.Log("Key : " + v.Key + " Value : " + v.Value);
        }
        foreach (var v in dicA)
        {
            dicB.Add(v.Value, v.Key);
        }

        dicA = dicB;
        foreach (var v in dicA)
        {
            Debug.Log("Key : " + v.Key + " Value : " + v.Value);
        }

        //#11
        List<Char> list = new List<Char>();
        list.Add(new Char("지존검사", 5));
        list.Add(new Char("검사", 2));
        list.Add(new Char("모험가", 1));
        list.Add(new Char("궁수", 3));
        list.Add(new Char("성검사", 4));

        float atk_sum = 0;
        float atk_num = 0;
        foreach (Char c in list)
        {
            if (c.name.Contains("검사"))
            {
                atk_num++;
                atk_sum += c.atk;
            }
        }
        Debug.Log("avg of 검사 : " + atk_sum / atk_num);
    }
    bool func(string num)
    {
        int number_of_0 = 0;
        int number_of_5 = 0;
        for(int i = 0; i < num.Length; i++)
        {
            if (num[i] == '0')
            {
                number_of_0++;
            }
            else if (num[i] == '5')
            {
                number_of_5++;
            }
            else return false;
        }
        if (number_of_0 != 0 && number_of_5 != 0) return true;
        else return false;
    }
}
