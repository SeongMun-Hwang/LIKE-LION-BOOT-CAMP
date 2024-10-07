using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject Prefab;
    public int InitialObjectNumber = 30;

    List<GameObject> objs;

    private void Start()
    {
        objs=new List<GameObject>();
        for(int i=0;i<InitialObjectNumber; i++)
        {
            GameObject go=Instantiate(Prefab,transform);
            go.SetActive(false);
        }
    }
    public GameObject GetObject()
    {
        foreach(GameObject go in objs)
        {
            if (!go.activeSelf)
            {
                go.SetActive(true);
                return go;
            }
        }

        GameObject obj=Instantiate(Prefab,transform);
        objs.Add(obj);
        return obj;
    }
}
