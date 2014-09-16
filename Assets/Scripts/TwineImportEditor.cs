using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using System.IO;

public class TwineImportEditor : EditorWindow
{
    // Constant values for GUI objects
    const float BUTTON_WIDTH = 75.0f;
    const float TEXT_FIELD_WIDTH = 300.0f;

    string filePath = "";
    bool displayFileContents = false;
    IEnumerable<string> fileContents;

    [MenuItem("Custom/Import...")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(TwineImportEditor));
    }

    void Start()
    {
        fileContents = Enumerable.Empty<string>();
    }

    void OnGUI()
    {
        // Create an area to import a file
        GUILayout.Label("File Path", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();

        filePath = GUILayout.TextField(filePath, GUILayout.MaxWidth(TEXT_FIELD_WIDTH));
        if (GUILayout.Button("Import", GUILayout.MaxWidth(BUTTON_WIDTH)))
        {
            // Create a local path based on the file path given
            string localPath = Application.dataPath + @"\" + filePath;

            // Try to locate the given file path
            try
            {
                // Holds all the file lines within the given file path
                List<string> tempFileContents = new List<string>();

                // Create a stream and read all of the contents within the file
                StreamReader stream = new StreamReader(localPath);
                string currentLine = stream.ReadLine();
                while (currentLine != null)
                {
                    if (!currentLine.Equals(""))
                        tempFileContents.Add(currentLine);
                    currentLine = stream.ReadLine();
                }
                stream.Close();
                fileContents = tempFileContents.ToArray();
                Debug.Log("Success importing!");
            }

            // Dispaly an error message if the file could not be found
            catch (FileNotFoundException e)
            {
                Debug.Log("Unable to import the given file.\n" + e.ToString());
                fileContents = Enumerable.Empty<string>();
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.Label("");

        // Create an area to display the contents within the imported file
        GUILayout.Label("File Contents Display", EditorStyles.boldLabel);

        string fileDisplayButtonName = displayFileContents ? "Hide" : "Show";
        if (GUILayout.Button(fileDisplayButtonName, GUILayout.MaxWidth(BUTTON_WIDTH)))
            displayFileContents = !displayFileContents;

        string fileDisplayContents = "";
        if (displayFileContents && fileContents != null)
        {
            string[] contents = fileContents.ToArray();
            for (int line = 0; line < contents.Length; line++)
            {
                string lineContent = contents[line];
                string stringToAdd = line != contents.Length - 1 ? lineContent + "\n" : lineContent;
                fileDisplayContents += stringToAdd;
            }
        }
        GUILayout.Label(fileDisplayContents);
    }
}