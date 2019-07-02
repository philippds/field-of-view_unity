﻿using UnityEngine;
using UnityEditor;
using System.IO;

public class HandleTextFile : MonoBehaviour
{
    public static string data;

    void Start()
    {
        //WriteString();
        ReadString();
    }

    [MenuItem("Tools/Write file")]
    static void WriteString()
    {
        string path = "Assets/Resources/test.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Test");
        writer.Close();

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
        TextAsset asset = Resources.Load<TextAsset>("test");

        //Print the text from the file
        Debug.Log(asset.text);
    }

    [MenuItem("Tools/Read file")]
    static void ReadString()
    {
        string path = "Assets/Resources/test_data.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        data = reader.ReadToEnd();
        Debug.Log(data);
        reader.Close();
    }
}