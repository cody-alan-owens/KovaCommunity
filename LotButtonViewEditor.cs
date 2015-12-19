using System;
using System.Collections;
using UnityEngine;
using UnityEditor;

namespace Community{
	[CustomEditor(typeof(LotButtonView))]
	[CanEditMultipleObjects]
	public class LotButtonViewEditor : Editor {
		
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();
			GameObject[] monoBehaviour = Selection.gameObjects;

			if(GUILayout.Button("Auto-Assign LotViews"))
			{
				foreach(GameObject lotButtonView in monoBehaviour){
					lotButtonView.GetComponent<LotButtonView>().autoAssignLotViews();
				}
			}
		}
	}
}