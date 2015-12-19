using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Community{
	public class UnityUtilities : MonoBehaviour {

		public Transform TargetTransform;

		void Start () {
		
		}

		void Update () {
		
		}

		public void swapTransforms(Transform transform){
			//store child node world position
			Vector3 childPosition = transform.position;
			Quaternion childRotation = transform.rotation;


			//move root node to child node position
			gameObject.transform.position = transform.position;

			//move child node back to original world position
			transform.localPosition = new Vector3(0,0,0);
		}

	}
}