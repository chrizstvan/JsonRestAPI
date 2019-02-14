using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class JsonFileUtility 
{
    public static string LoadJsonFromFile(string path, bool isResource)
    {
        if (isResource)
        {
            return LoadJsonAsResource(path);
        }
        else
            return LoadJsonAsExternalResource(path);
    }

    //example external path Levels/Level1/level.json
    public static string LoadJsonAsResource(string path)
    {
        string jsonFilePath = path.Replace(".json", "");
        TextAsset loadJsonFile = Resources.Load<TextAsset>(jsonFilePath);

        return loadJsonFile.text;
    }

    //example external path Levels/Level1/level.json
    public static string LoadJsonAsExternalResource(string path)
    {
        path = Application.persistentDataPath + "/" + path;
        if (!File.Exists(path))
        {
            return null;
        }

        StreamReader reader = new StreamReader(path);
        string response = string.Empty;
        while (!reader.EndOfStream)
        {
            response += reader.ReadLine();
        }
        return response;
    }

    public static void WriteJsonToExternalResource(string path, string content)
    {
        path = Application.persistentDataPath + "/" + path;
        FileStream stream = File.Create(path);
        byte[] contentByte = new UTF8Encoding(true).GetBytes(content);

        stream.Write(contentByte, 0, contentByte.Length);
    }
}