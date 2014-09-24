using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TwineNode{

	string title;
	string passage; 
	string link;
	string content;


	public string Title { get{return title;} set{title = value;}}
	public string Passage {get{return passage;} set{passage = value;}}
	public string Link {get{return link;} set{link = value;}}
	public string Content {get{return content;} set{content = value;}}

	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public TwineNode Parse(string data)
	{
		if (data.IndexOf("[[") != -1)
            {
                int startTitle = data.IndexOf("[[") + 2;
                int endTitle = data.IndexOf("|");
                title = data.Substring(startTitle, endTitle - startTitle);
                int startLink = data.IndexOf("|") + 1;
                int endLink = data.IndexOf("]]");
                link = data.Substring(startLink, endLink - startLink);
                Debug.Log("Title: " + title + "\n Link: " + link);
                Debug.Log("Link: "+data);
            }
            if (data.Length == 0)
            {
                Debug.Log("Blank: " + data);
            }
            if (data.IndexOf("::") != -1)
            {
                int startPassage = data.IndexOf("::") + 2;
                passage = data.Substring(startPassage);
                Debug.Log("Start of Passage: " + passage);
            }
            else
            {
                content = data;
            }
            return  this;
	}
}
