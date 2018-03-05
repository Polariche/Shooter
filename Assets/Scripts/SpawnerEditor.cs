using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Spawner))]
[CanEditMultipleObjects]
public class SpanwerEditor : Editor {

	SerializedProperty mode;
	SerializedProperty spawnTime;
	SerializedProperty spawnPoint;

	SerializedProperty speed;
	SerializedProperty angle;

	SerializedProperty initialSpeed;
	SerializedProperty initialAngle;

	SerializedProperty time;

	void OnEnable() {
		mode = serializedObject.FindProperty("mode");
		spawnTime = serializedObject.FindProperty("spawnTime");
		spawnPoint = serializedObject.FindProperty("spawnPoint");
		speed = serializedObject.FindProperty("speedCurve");
		angle = serializedObject.FindProperty("angleCurve");
		
		initialSpeed = serializedObject.FindProperty("initialSpeed");
		initialAngle = serializedObject.FindProperty("initialAngle");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.PropertyField(mode, new GUIContent("Mode"));

		if (mode.intValue == 0) 
			EditorGUILayout.PropertyField(spawnTime, new GUIContent("Spawn Time")); //simple
		else 
			CurveGui("Spawn Point", spawnPoint); //advanced

		EditorGUILayout.Separator();

		EditorGUILayout.PropertyField(initialSpeed, new GUIContent("Spawn Time"));
		CurveGui("Speed Curve", speed);

		EditorGUILayout.Separator();

		EditorGUILayout.PropertyField(initialAngle, new GUIContent("Spawn Time"));
		CurveGui("Angle Curve", angle);


		serializedObject.ApplyModifiedProperties();
	}

	void CurveGui(string name, SerializedProperty animationCurve)
	{
		EditorGUILayout.PropertyField(animationCurve, new GUIContent(name));
	}
}
