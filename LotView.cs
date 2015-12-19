using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace Community{
    
    class LotView : MonoBehaviour
    {
		public string LotRID;
        public Button ButtonObj;
        public TextMesh NumberObj;
		public TextMesh StatusObj;
        public Transform CameraAnchor;
		public Transform ModelAnchor;

        void Start()
        {

        }

        void Update()
        {

        }

		public void updateView(Lot lot)
		{
			clearLot ();
			NumberObj.text = lot.LotRID;
			StatusObj.text = lot.Status;
			Debug.Log (Utilities.dump (lot.Model));
			if(lot.Model!=null){
				if(lot.Model.ModelView!=null){
					buildModelObj (lot.Model.ModelView.getCopy ());
				}
			}
		}

		public void clearLot(){
			NumberObj.text = "";
			StatusObj.text = "";
			foreach(Transform child in ModelAnchor.transform){
				Destroy (child.gameObject);
			}
		}

		private void buildModelObj(GameObject obj){
			obj.transform.parent=(ModelAnchor.transform);
			obj.transform.position = ModelAnchor.transform.position;
			obj.transform.rotation = ModelAnchor.transform.rotation;
			obj.SetActive (true);
		}

		//Custom Editor Utility Commands

		public void autoAssignAll(){
			this.NumberObj = gameObject.transform.FindChild ("Labels").FindChild ("DisplayName").GetComponent<TextMesh>();
			this.StatusObj = gameObject.transform.FindChild ("Labels").FindChild ("Status").GetComponent<TextMesh>();
			this.CameraAnchor = gameObject.transform.FindChild ("CameraAnchor").transform;
			this.ModelAnchor = gameObject.transform.FindChild ("ModelAnchor").transform;
			this.LotRID = gameObject.name;
			gameObject.transform.position = gameObject.transform.FindChild ("Space").transform.position;
			gameObject.transform.FindChild ("Space").transform.localPosition = new Vector3(0,0,0);
		}


    }
}