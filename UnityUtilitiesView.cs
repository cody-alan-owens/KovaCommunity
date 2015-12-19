using System;
using System.Collections;
using UnityEngine;
using UnityEditor;

namespace Community{
	[CustomEditor(typeof(UnityUtilities))]
	public class UnityUtilitiesView : Editor {
		
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();
			
			UnityUtilities monoBehaviour = (UnityUtilities)target;
			if(GUILayout.Button("Swap Transform With..."))
			{
				monoBehaviour.swapTransforms(monoBehaviour.TargetTransform.transform);
			}
		}
	}
}