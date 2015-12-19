using System;
using UnityEngine;


namespace Community{
	class InputController : MonoBehaviour{

		public Camera OverviewCamera;

		void Start(){

		}

		void Update(){
			if (Input.GetMouseButtonDown(0)){
				tryClick();
			}
		}

		void tryClick(){
			Ray ray = OverviewCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit[] hits = Physics.RaycastAll(ray);
			foreach(RaycastHit hit in hits){
				IClickable[] clickableComponents = hit.transform.GetComponents<IClickable>();
				foreach(IClickable component in clickableComponents){
					component.Click ();
				}
			}
		}
	}
}