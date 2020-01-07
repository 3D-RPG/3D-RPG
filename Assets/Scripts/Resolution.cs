using UnityEngine;
using System.IO;

public class Resolution : MonoBehaviour
{
    private Debug_Manager debug;
    
    private int Width;
    private int Height;
    
    public GameObject Image;
    private RectTransform BackGround;
    
    private string path;
    private string json;
    private Settings settings;

    void Start()
    {
        path = Application.dataPath + "/" + "Settings.json";
        json = File.ReadAllText(path);
        settings = JsonUtility.FromJson<Settings>(json);
        JsonUtility.FromJsonOverwrite(json, settings);
        Width = settings.Width;
        Height = settings.Height;

        BackGround = Image.GetComponent<RectTransform>();
        
#if UNITY_EDITOR
        GameObject gameobject = GameObject.Find("Init");
        debug = gameobject.GetComponent<Debug_Manager>();

        BackGround.sizeDelta = new Vector2(debug.Width, debug.Height);
        Debug.Log("UNITY_EDITOR");
#else
        BackGround.sizeDelta = new Vector2(Width, Height);
        Debug.Log("UNITY_STANDALONE_WIN");
#endif
    }


    void Update()
    {

    }
}
