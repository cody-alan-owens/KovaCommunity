using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UniRx;

namespace Community{

	class Community : IKovaObject
    {
		public string Name{get; set;}
		public string BUnitRID{get; set;}
		public string Status{get; set;}
		public string CommunityID{get; set;}
		public string CommunityRID{get; set;}
		public string ObjectRID{get; set;}
		public string Description{get; set;}
		public string City{get; set;}
		public string ZipCode{get; set;}
		public string State{get; set;}
		public string SalesOfficeStreet{get; set;}
		public string SalesOfficeCity{get; set;}
		public string SalesOfficeZip{get; set;}
		public string SalesOfficeCounty{get; set;}
		public string SalesOfficeState{get; set;}
		public string SalesOfficePhone1{get; set;}
		public string SalesOfficePhone2{get; set;}
		public string SalesOfficeFax{get; set;}
		public string SalesOfficeEmail{get; set;}
		public string CommunityMapUrl{get; set;}
		public string CommunityImageHotSpots{get; set;}
		public Lot[] Lots{get; set;}

		public Community(){

		}

		public void updateView(){
			foreach(Lot lot in Lots){
				lot.updateView ();
			}
		}
    }
}