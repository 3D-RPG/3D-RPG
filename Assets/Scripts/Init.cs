using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Init : MonoBehaviour
{
    private string Default_Settings =
        "{ \"Width\": 800, \"Height\": \"600\", \"FullScreen\": \"false\", \"FrameRate\": \"60\" }";

    private string path;
    private string json;
    private Settings settings;

    void Start()
    {
        Init_Json();

        Screen.SetResolution(settings.Width, settings.Height, settings.FullScreen, settings.FrameRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Init_Json()
    {
        path = Application.dataPath + "/" + "Settings.json";
        settings = JsonUtility.FromJson<Settings>(Default_Settings);
        if (File.Exists(path))
        {
            json = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(json, settings);
        }
        else
        {
            string serialisedSettingsJson = JsonUtility.ToJson(settings);
            var writer = new StreamWriter(path, false);
            writer.WriteLine(serialisedSettingsJson);
            writer.Flush();
            writer.Close();
        }
    }
}