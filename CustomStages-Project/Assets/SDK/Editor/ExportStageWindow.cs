using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Nick;
using System.Linq;

public class ExportStageWindow : EditorWindow
{
    private ExportData[] stages;
    private Vector2 scrollPosition;

    [MenuItem("NASB/Stage Exporter")]
    public static void ShowWindow() => GetWindow(typeof(ExportStageWindow), false, "Stage Exporter");

    private void OnGUI()
    {
        GUILayout.Space(20);

        if (stages.Length > 0 && GUILayout.Button("Export all stages!"))
            Debug.Log("Exported all stages!");
        else
            GUILayout.Label("YOU HAVE NO STAGES!");

        GUILayout.Space(20);

        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, false, false);

        foreach(var stage in stages)
        {
            GUILayout.Label("Stage : " + stage.name, EditorStyles.boldLabel);
            stage.StageName = EditorGUILayout.TextField("Stage Name", stage.StageName);
            stage.Author = EditorGUILayout.TextField("Author", stage.Author);
            stage.MusicID = EditorGUILayout.TextField("Music ID", stage.MusicID);

            stage.showBlastzones = EditorGUILayout.Foldout(stage.showBlastzones, "Blastzones");
            if (stage.showBlastzones)
            {
                stage.BlastzoneDistUp = EditorGUILayout.FloatField("Blastzone Dist Up", stage.BlastzoneDistUp);
                stage.BlastzoneDistDown = EditorGUILayout.FloatField("Blastzone Dist Down", stage.BlastzoneDistDown);
                stage.BlastzoneDistLeft = EditorGUILayout.FloatField("Blastzone Dist Left", stage.BlastzoneDistLeft);
                stage.BlastzoneDistRight = EditorGUILayout.FloatField("Blastzone Dist Right", stage.BlastzoneDistRight);
            }

            stage.showCamera = EditorGUILayout.Foldout(stage.showCamera, "Camera");
            if (stage.showCamera)
            {
                stage.CameraDistUp = EditorGUILayout.FloatField("Camera Dist Up", stage.CameraDistUp);
                stage.CameraDistDown = EditorGUILayout.FloatField("Camera Dist Down", stage.CameraDistDown);
                stage.CameraDistLeft = EditorGUILayout.FloatField("Camera Dist Left", stage.CameraDistLeft);
                stage.CameraDistRight = EditorGUILayout.FloatField("Camera Dist Right", stage.CameraDistRight);
                stage.CameraMinDist = EditorGUILayout.FloatField("Camera Min Dist", stage.CameraMinDist);
            }

            stage.showStageObjects = EditorGUILayout.Foldout(stage.showStageObjects, "Stage Objects");
            if (stage.showStageObjects)
            {
                stage.stage = (GameAgent)EditorGUILayout.ObjectField("Stage", stage.stage, typeof(GameAgent), allowSceneObjects:false);
                stage.portrait = (Texture2D)EditorGUILayout.ObjectField("Portrait", stage.portrait, typeof(Texture2D), allowSceneObjects: false);
            }

            EditorGUI.BeginDisabledGroup(stage.IsInvalid());

            if (GUILayout.Button($"Export {stage.StageName}"))
            {
                Debug.Log($"Export {stage.StageName}!");
                ExportUtility.ExportStage(stage);
            }

            EditorGUI.EndDisabledGroup();

            GUILayout.Space(20);
        }

        EditorGUILayout.EndScrollView();
    }

    private void OnFocus()
    {
        stages = Resources.FindObjectsOfTypeAll<ExportData>();
    }
}
