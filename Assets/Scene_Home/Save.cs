using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class SaveStatus
{
    public float x;
    public float y;
}

public class Save : MonoBehaviour {

    public void Save_Status()
    {
        var data = new SaveStatus();
        data.x = 1.0f;
        data.y = 2.5f;

        var json = JsonUtility.ToJson(data);
        var path = Application.dataPath + "/" + "SaveData.json";
        var writer = new StreamWriter(path, false);
        writer.WriteLine(json);
        writer.Flush();
        writer.Close();
        //確認用にtxtファイルでも出力
        path = Application.dataPath + "/" + "SaveData.txt";
        writer = new StreamWriter(path, false);// 上書き
        writer.WriteLine(json);
        writer.Flush();
        writer.Close();
    }
    public void Load_Status()
    {
        var info = new FileInfo(Application.dataPath + "/" + "SaveData.txt");
        var reader = new StreamReader(info.OpenRead());
        var json = reader.ReadToEnd();
        var data = JsonUtility.FromJson<SaveStatus>(json);

        Debug.Log(data.x);
        Debug.Log(data.y);
    }
}
