using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ExportData))]
public class ExportDataEditor : Editor
{
    ExportData data;

    private void OnEnable() => data = (ExportData)target;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Space(20);

        EditorGUI.BeginDisabledGroup(data.IsInvalid());

        if(GUILayout.Button($"Export {data.StageName}"))
            ExportUtility.ExportStage(data);

        EditorGUI.EndDisabledGroup();
    }
}
