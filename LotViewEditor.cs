using System;
using System.Collections;
using UnityEngine;
using UnityEditor;

namespace Community{
	[CustomEditor(typeof(LotView))]
	[CanEditMultipleObjects]
	public class LotViewEditor : Editor {
		
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();
			GameObject[] monoBehaviour = Selection.gameObjects;

			if(GUILayout.Button("Auto-Assign All"))
			{
				foreach(GameObject lotView in monoBehaviour){
					lotView.GetComponent<LotView>().autoAssignAll();
				}
			}
		}
	}
}