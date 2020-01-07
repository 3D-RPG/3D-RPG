using UnityEngine;
using System.IO;

public class Resolution : MonoBehaviour
{
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
        BackGround.sizeDelta = new Vector2(Width, Height);
    }


    void Update()
    {

    }
}
