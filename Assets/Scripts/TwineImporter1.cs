using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class TwineImporter1 : MonoBehaviour
{

    // Use this for initialization
    List<string> twineData = new List<string>();
    TwineData1 twineInfo;
    string path =  "/TwineFiles/dialogue.txt";

    public void Start()
    {
        path = Application.dataPath + path; // path = "your file path"
        ReadTwineData(path);
        twineInfo = new TwineData1(twineData);
        //ShowTwineData(twineData);
    }

    public TwineImporter1()
    {
        
    }

    public void ReadTwineData(string path)
    {
        string temp;
        string[] file;
		string[] split = {"::"};

        try
        {
            //create a stream reader
            //get the data in the text file
            //close the stream reader
            StreamReader sr = new StreamReader(path);
            temp = sr.ReadToEnd();
            sr.Close();

            //parse large string by lines into an list
            file = temp.Split(split, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in file)
            {
                twineData.Add(s);
            }
        }

        catch (FileNotFoundException e)
        {
            Debug.Log("The process failed: {0}" + e.ToString());
			return;
        }
    }

    void ShowTwineData(List <string> data)
    {
        for (int i = 0; i < data.Count; i++)
        {
            Debug.Log("Data Set "+i+": "+ data[i]);
        }
    }

	/*
    public void ParseTwineData(List<string> data)
    {
    	twineInfo = new TwineData1(data);
    }
	*/

    // Update is called once per frame
    void Update()
    {


    }


}