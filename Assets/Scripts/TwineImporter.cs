using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class TwineImporter : MonoBehaviour {

	// Use this for initialization
	public bool listedAll;
	public string[] file;
	public List <string> twineInfo;
	
	void Start () 
	{
		listedAll = false;
		string path = Application.dataPath + @"\TwineFiles\simple.txt";
		string temp;
		string [] file;

        try 
        {
        	//create a stream reader
        	//get the data in the text file
        	//close the stream reader
        	StreamReader sr = new StreamReader(path);
        	temp = sr.ReadToEnd();
        	sr.Close();

        	//parse large string by lines into an array
        	file = temp.Split("\n"[0]);
        	foreach(string s in file)
        	{
        		twineInfo.Add(s);
        	}
        } 

        catch (FileNotFoundException e) 
        {
            Debug.Log("The process failed: {0}"+ e.ToString());
        }

        if(listedAll == false)
		{
			for(int i = 0; i < twineInfo.Count; i++)
			{
				if(i == twineInfo.Count)
				{
					listedAll = true;
				}

				Debug.Log(twineInfo[i]);
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

		
	}
}
