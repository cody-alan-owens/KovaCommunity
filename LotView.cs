using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;


namespace Community{
    
    class LotView : MonoBehaviour
    {
        public GameObject ButtonObj;
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
			NumberObj.text = setDisplayName(lot);
			StatusObj.text = setDisplayStatus(lot);
			if(lot.Model!=null){
				if(lot.Model.ModelView!=null){
					buildModelObj (lot.Model.ModelView.getCopy ());
				}
			}
			ButtonObj.GetComponent<MeshRenderer>().material.SetColor("_Color", LotStatusColorManager.getColorByDisplayType(lot.getDisplayType()));
		}

		private string setDisplayName(Lot lot){
			if(lot.Model!=null){
				if(lot.Model.MarketingName.IndexOf("(")==-1){
					return lot.Model.MarketingName;
				}
				return lot.Model.MarketingName.Substring(0,lot.Model.MarketingName.IndexOf("("));
			}
			return "";
		}

		private string setDisplayStatus(Lot lot){
			switch(lot.getDisplayType()){
			case Lot.DisplayType.SOLD:
				return "Sold";
			case Lot.DisplayType.SPEC:
				return "Spec";
			case Lot.DisplayType.MODEL:
				return "Model";
			case Lot.DisplayType.NEW:
				Debug.Log("Lot name:"+lot.Name);
                Match match = Regex.Match(lot.Name, @"(?i)Lot (\d+)");
                if (match.Success)
                {
                    return match.Captures[0].Value;
                } else
                {
                    return lot.Name;
                }
			}
			return lot.Name;
		}

		public void changeCamera(){
			Camera.main.transform.Translate (CameraAnchor.transform.position);
			Camera.main.transform.Rotate (CameraAnchor.transform.eulerAngles);
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
			gameObject.transform.position = gameObject.transform.FindChild ("Space").transform.position;
			gameObject.transform.FindChild ("Space").transform.localPosition = new Vector3(0,0,0);
		}

		public sealed class LotStatusColorManager{

			//Singleton
			private static readonly LotStatusColorManager manager = new LotStatusColorManager();
			static LotStatusColorManager(){}
			private LotStatusColorManager(){}

			static Dictionary<string, Color> PaletteDict = new Dictionary<string, Color>(){
				//Dividing by 255.0F to convert from 255RGB to Unity Color RGB 0-1
				{"Blue", new Color(13/255.0F,159/255.0F,255/255.0F, 128/255.0F)},
				{"Red", new Color(130/255.0F,130/255.0F,130/255.0F,255/255.0F)},
				{"Orange", new Color(255/255.0F,120/255.0F,120/255.0F,255/255.0F)},
				{"Green", new Color(12/255.0F,232/255.0F,105/255.0F,128/255.0F)}
			};

			public static LotStatusColorManager Instance{
				get{
					return Instance;
				}
			}

			public static Color getColorByDisplayType(Lot.DisplayType displayType){
				switch(displayType){
				case Lot.DisplayType.SOLD:
					return PaletteDict["Red"];
				case Lot.DisplayType.MODEL:
					return PaletteDict["Blue"];
				case Lot.DisplayType.NEW:
					return PaletteDict["Green"];
				case Lot.DisplayType.SPEC:
					return PaletteDict["Orange"];
				}
				return PaletteDict["Green"];
			}
		}
	}		
}