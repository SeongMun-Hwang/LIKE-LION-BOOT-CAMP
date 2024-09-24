using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day2_Practice : MonoBehaviour
{
    void Start()
    {
        //#2
        List<List<int>> l = new List<List<int>>();
        for(int i = 0; i < 5; i++)
        {
            l.Add(new List<int>());
            for(int j=0; j < 5; j++)
            {
                l[i].Add(Random.Range(0, 20));
                if (l[i][j] > 10)
                {
                    Debug.Log(l[i][j]+"\t");
                }
                else Debug.Log("Null\t");
            }
        }

        //#5
        for(int i = 50; i <= 1000; i += 5)
        {

        }

        //#6
        Dictionary<string,int> dic = new Dictionary<string,int>();
        dic.Add("½½¶óÀÓ", 1);
        dic.Add("´ÞÆØÀÌ", 2);
        dic.Add("ÁÖÈ²¹ö¼¸", 3);
        dic.Add("¿¢½ºÅÒÇÁ", 4);
        dic.Add("½ºÅæ°ñ·½", 5);

        int sum = 0;
        foreach(var i in dic)
        {
            sum += i.Value;
        }
        Debug.Log("Æò±º : " + sum / dic.Count);

        //#7
        Dictionary<string,string> dicA= new Dictionary<string, string>();
        dicA.Add("»ç°ú", "Apple");
        dicA.Add("¹Ù³ª³ª", "Banana");
        dicA.Add("¼ö¹Ú", "Watermelon");
        dicA.Add("º¹¼þ¾Æ", "Peach");
        dicA.Add("Æ÷µµ", "Grape");

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
        foreach(var v in dicA)
        {
            Debug.Log("Key : " + v.Key + " Value : " + v.Value);
        }

    }
    void func(int num)
    {

        if (num / 10 > 10)
        {

        }
    }
}
