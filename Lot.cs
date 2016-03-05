using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Community{
    
    class Lot : IKovaObject
    {
        public string Name{ get; set; }
		public string LotRID{ get; set; }
		public string ObjectRID{ get; set; }
		public string LotID{ get; private set; }
		public string Description{ get; set; }
		public string Type{ get; set; }
		public string Status{ get; set; }
		public string StreetAddress{ get; set; }
		public string City{ get; set; }
		public string Zipcode{ get; set; }
		public string LotPremium{ get; set; }
		public Model[] AvailableModels { get; set; }
		public Model Model { get; set; }
		public LotView LotView;
		public enum DisplayType{
			MODEL,
			SOLD,
			SPEC,
			NEW
		}

		public Lot(){

		}

		public void updateView(){
			if(LotView!=null){
				LotView.updateView(this);
			}
		}

		public DisplayType getDisplayType(){
			switch(this.Status){
			case "Sold":
				return DisplayType.SOLD;
			case "Hold":
				return DisplayType.SPEC;
			case "Void":
				return DisplayType.NEW;
			case "Closed":
				return DisplayType.SPEC;
			case "New":
				if(this.Type == "Model"){
					return DisplayType.MODEL;
				}
				return DisplayType.NEW;
			case "Released":
				return DisplayType.NEW;
			}
			return DisplayType.NEW;
		}			
    }
}