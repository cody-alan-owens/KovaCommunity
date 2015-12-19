using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

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

		public Lot(){

		}

		public void updateView(){
			if(LotView!=null){
				LotView.updateView(this);
			}
		}


    }
}