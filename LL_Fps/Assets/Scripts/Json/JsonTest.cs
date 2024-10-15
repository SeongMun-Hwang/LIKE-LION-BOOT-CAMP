using UnityEngine;
using System.Collections.Generic;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using System;

public class Data
{
    public string Name;
    public float Height;
    [JsonProperty]
    private string secret;

    public Data(string name, float height, string secret)
    {
        Name = name;
        Height = height;
        this.secret = secret;
    }
    public override string ToString()
    {
        return Name + " " + Height + " " + secret;
    }

}



public class JsonTest : MonoBehaviour
{
    void Start()
    {
        Data charles = new Data("Kim", 198, "secret");

        string json1 = JsonConvert.SerializeObject(charles);

        Debug.Log(json1);

        Data amen = JsonConvert.DeserializeObject<Data>(json1);
        Debug.Log(amen);

        Save(amen, "save.txt");

        Data secondMan = Load("save.txt");
        Debug.Log(secondMan);
    }
    void Save(Data data, string filename)
    {
        string path = Path.Combine(Application.persistentDataPath, filename); //persistentDataPath
        Debug.Log(path);

        try
        {
            string json = JsonConvert.SerializeObject(data);
            json=SimpleEncryptionUtility.Encrypt(json);
            File.WriteAllText(path, json);
        }
        catch(Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    Data Load(string filename)
    {
        string path = Path.Combine(Application.persistentDataPath, filename); //persistentDataPath

        try
        {
            if(File.Exists(path))
            {
                string json=File.ReadAllText(path);
                json=SimpleEncryptionUtility.Decrypt(json);
                return JsonConvert.DeserializeObject<Data>(json);
            }
            else
            {
                Debug.Log("There's no file");
                return null;
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
            return null;
        }
    }
}
