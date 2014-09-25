using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class TwineImporter : MonoBehaviour
{

    // Use this for initialization
    public List<string> twineInfo;

    List<TwineNode> twineData = new List<TwineNode>();

    public TwineData data;

    void Start()
    {
        string path = Application.dataPath + @"\TwineFiles\simple.txt";

        twineInfo = ReadTwineData(path);

        data = new TwineData(twineInfo);
        //ShowTwineData(twineInfo);

        //ParseTwineData(twineInfo);
    }

    List<string> ReadTwineData(string path)
    {
        string temp;
        string[] file;

        try
        {
            //create a stream reader
            //get the data in the text file
            //close the stream reader
            StreamReader sr = new StreamReader(path);
            temp = sr.ReadToEnd();
            sr.Close();

            //parse large string by lines into an list
            file = temp.Split("\n"[0]);
            foreach (string s in file)
            {
                twineInfo.Add(s);
            }
            return twineInfo;
        }

        catch (FileNotFoundException e)
        {
            Debug.Log("The process failed: {0}" + e.ToString());
            return null;
        }
    }

    void ShowTwineData(List <string> data)
    {
        bool listedAll = false;

        if (listedAll == false)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (i == data.Count)
                {
                    listedAll = true;
                }

                Debug.Log(data[i]);
            }
        }
    }

    void ParseTwineData(List<string> data)
    {
    	TwineData allData = new TwineData(data);
    }

    // Update is called once per frame
    void Update()
    {


    }


}