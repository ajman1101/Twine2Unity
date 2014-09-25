using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TwineData{

	public TwineNode current = new TwineNode();
	public List<TwineNode> Data = new List<TwineNode>();
	// Use this for initialization
 	public TwineData(List <string> rawData)
	{
		for (int i = 0; i < rawData.Count; i++)
        {
        	TwineNode twineNode = new TwineNode();
        	Data.Add(twineNode.Parse(rawData[i]));
        }
        current = Data[0];

	}

	 void ShowTwineData(List <string> data)
    {
        bool listedAll = false;

        if (listedAll == false)
        {
            for (int i = 0; i < Data.Count; i++)
            {
                if (i == Data.Count)
                {
                    listedAll = true;
                }

                Debug.Log(Data[i]);
            }
        }
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
