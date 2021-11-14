using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AnimatedSpriteMask))]
public class AnimatedSpriteMask_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.Space();

        AnimatedSpriteMask animatedSpriteMask = (AnimatedSpriteMask)target;

        animatedSpriteMask._usage = (Usage)EditorGUILayout.EnumPopup("Animation Usage", animatedSpriteMask._usage);

        if (animatedSpriteMask._usage == Usage.OneTime)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_sprites"));
            EditorGUILayout.Space();
            animatedSpriteMask.timeBetweenFrames = EditorGUILayout.Slider("Time Between Frames:", animatedSpriteMask.timeBetweenFrames, .001f, 1f);
            EditorGUILayout.Space();
            animatedSpriteMask.animateOnStart = EditorGUILayout.Toggle("Animate of Start: ", animatedSpriteMask.animateOnStart);
        }
        else
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_multipleUsageSprite"));
            EditorGUILayout.Space();
            animatedSpriteMask.timeBetweenFrames = EditorGUILayout.Slider("Default Time Between Frames:", animatedSpriteMask.timeBetweenFrames, .001f, 1f);
        }

        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Add Sprite Mask"))
        {
            animatedSpriteMask.gameObject.AddComponent<SpriteMask>();
        }
        if (GUILayout.Button("Reset Settings"))
        {
            animatedSpriteMask.ResetComponent();
        }
        GUILayout.EndHorizontal();

        //base.OnInspectorGUI();

        serializedObject.ApplyModifiedProperties();
    }
}
