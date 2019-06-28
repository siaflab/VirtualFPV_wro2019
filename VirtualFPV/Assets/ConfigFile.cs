using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigFile
{
    string configfile;
    static List<string> stat = new List<string>();
    Dictionary<string, string> data = new Dictionary<string, string>();
    
    static ConfigFile instance;

    public static ConfigFile GetInstance() {
        if (instance == null) {
            instance = new ConfigFile();
            instance.ReadConfigfile();
        }
        return instance;
    }

    public static List<string> SelfCheck()
    {
        return stat;
    }

    public string GetStringValue(string key)
    {
        return data[key];
    }

    public int GetIntValue(string key)
    {
        return int.Parse(data[key]);
    }

    public float GetFloatValue(string key)
    {
        return float.Parse(data[key]);
    }
    public double GetDoubleValue(string key)
    {
        return double.Parse(data[key]);
    }

    void ReadConfigfile()
    {
        try
        {
#if UNITY_EDITOR
            configfile = Application.dataPath + "/config.txt";
#else
#if UNITY_STANDALONE_OSX
            configfile = Application.dataPath + "/../../config.txt";
#else
            configfile = Application.dataPath + "/../config.txt";
#endif
#endif
            Debug.Log(configfile);
            using (var sr = new System.IO.StreamReader(configfile))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    string[] arr = line.Split('=');
                    if (arr.Length == 2) {
                      data[arr[0].Trim()] = arr[1].Trim();
                    }
                }
            }
            stat.Add("OK");
        }
        catch (System.Exception e)
        {
            stat.Add("NG");
            stat.Add(e.Message);
        }
    }

}
