using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Community{
    
    class ModelView : MonoBehaviour
    {
        public GameObject ModelObj;
		public string ModelRID;

        void Start()
        {

        }

        void Update()
        {

        }

		public GameObject getCopy(){
			Debug.Log ("Instanting "+ModelRID+" object...");
			return Instantiate(ModelObj);
		}
    }
}