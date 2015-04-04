/*
 * Takes the input from a twine file, splits it into pieces and saves it into a linked list
 * This linked list consists of TwineNodes, and is saved inside of TwineData
 *
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class TwineImporter
{

    // Use this for initialization
    List<string> twineDataList = new List<string>();
	TwineData twineData;

    public TwineImporter()
    {
        ReadTwineData();
		ParseTwineData(twineDataList);
    }
    
    // Loads in the data from the Entweedle(Story format used to get correct formatting) File
    public void ReadTwineData()
	{
        string temp;
        string[] file;
		string[] split = {"::"};

		temp = Resources.Load("dialogueNew", typeof(TextAsset)).ToString();

        try
        {
            //parse large string by lines into an list
			file = temp.Split(split, StringSplitOptions.RemoveEmptyEntries);
            // the :: is still needed for splitting in the Node
            foreach (string s in file)
            {
                twineDataList.Add("::" + s);
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
    
    // Create a TwineData object
    // We've used a split to split the speaker off from the rest of the content
	public void ParseTwineData(List<string> data)
    {
    	string[] split = {":","\r\n"};
		twineData = new TwineData(data, split);
    }

	public TwineData TwineData
	{
		get
		{
			return twineData;
		}
	}


}