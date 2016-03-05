using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Community{
    
    class ModelView : MonoBehaviour
    {

        void Start()
        {

        }

        void Update()
        {

        }

		public GameObject getCopy(){
			Debug.Log ("Instanting "+gameObject.name+" object...");
			return Instantiate(gameObject);
		}
    }
}