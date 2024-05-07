using Nick;
using UnityEngine;

[CreateAssetMenu(fileName = "New Export Data", menuName = "ScriptableObjects/Stage Export Data", order = 5)]
public class ExportData : ScriptableObject
{
    public string StageName;
    public string Author;
    public string MusicID;

    [Header("Blastzones")]
    public float BlastzoneDistUp = 28;
    public float BlastzoneDistDown = 25;
    public float BlastzoneDistLeft = 24;
    public float BlastzoneDistRight = 24;

    [Header("Camera")]
    public float CameraDistUp = 18;
    public float CameraDistDown = 15;
    public float CameraDistLeft = 18;
    public float CameraDistRight = 18;
    public float CameraMinDist = 7;

    [Header("Stage Objects")]
    public GameAgent stage;
    public Texture2D portrait;

    [HideInInspector]
    public bool showBlastzones = false;
    [HideInInspector]
    public bool showCamera = false;
    [HideInInspector]
    public bool showStageObjects = false;

    public bool IsInvalid()
    {
        if (string.IsNullOrEmpty(StageName)) return true;
        if (stage == null) return true;
        if (portrait == null) return true;

        return false;
    }
}
