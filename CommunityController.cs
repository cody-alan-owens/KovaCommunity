using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Newtonsoft.Json;


namespace Community{
    
    class CommunityController : MonoBehaviour
    {
		private Community Community;
		public string CommunityRID;
		public GameObject Models;
        public string AuthToken;

        void Start()
        {
			string GetCommunityURL = "http://oakwoodfindahome.com/WebConfigurator/api/v2/Communities/GetDetails/"+CommunityRID;
            if(AuthToken!=String.Empty){GetCommunityURL = GetCommunityURL+"?auth="+AuthToken;}
			string GetLotsURL = "http://oakwoodfindahome.com/WebConfigurator/api/v2/Communities/GetLots/"+CommunityRID;
            if(AuthToken!=String.Empty){GetLotsURL = GetLotsURL+"?auth="+AuthToken;}
			string GetModelsURL = "http://oakwoodfindahome.com/WebConfigurator/api/v2/Communities/GetModels/"+CommunityRID;
            if(AuthToken!=String.Empty){GetModelsURL = GetModelsURL+"?auth="+AuthToken;}

			Debug.Log ("Community URL: "+GetCommunityURL);
			Debug.Log ("Lots URL: "+GetLotsURL);
			Debug.Log ("Models URL: "+GetModelsURL);

			var wwwRequests = Observable.WhenAll(
				ObservableWWW.Get(GetCommunityURL),
				ObservableWWW.Get(GetLotsURL),
				ObservableWWW.Get(GetModelsURL));

			wwwRequests.CatchIgnore((WWWErrorException ex) =>
			                        {
				Debug.Log(ex.RawErrorMessage);
				if (ex.HasResponse)
				{
					Debug.Log(ex.StatusCode);
				}
				foreach (var item in ex.ResponseHeaders)
				{
					Debug.Log(item.Key + ":" + item.Value);
				}
			})
				.Subscribe();

			wwwRequests.Subscribe(x =>
               	{
				convertResponses(x[0], x[1], x[2]);
			});


		}
		
		void Update()
		{
			
		}
		
		private void convertResponses(string community, string lotArr, string modelArr){
            Debug.Log("Community JSON: "+community);
            Debug.Log("Lot JSON: "+lotArr);
            Debug.Log("Model JSON: "+modelArr);
			Community communityTemp = JsonConvert.DeserializeObject<Community>(community);
			Lot[] lotArrTemp = JsonConvert.DeserializeObject<Lot[]>(lotArr);
			Model[] modelArrTemp = JsonConvert.DeserializeObject<Model[]>(modelArr);
			buildCommunity (communityTemp, lotArrTemp, modelArrTemp);
		}

		 private void buildCommunity(Community community, Lot[] lots, Model[] models){
			foreach(Model model in models){
				if(transform.Find("Models").transform.Find (model.ModelRID)!=null){
					model.ModelView = transform.FindChild("Models").transform.FindChild (model.ModelRID).GetComponent<ModelView>();
				}
			}

			foreach(Lot lot in lots){
				if(lot.AvailableModels == null){
					lot.AvailableModels = models;
				}
				if(transform.Find("Lots").transform.Find (lot.LotRID)!=null){
					lot.LotView = transform.FindChild("Lots").transform.FindChild (lot.LotRID).GetComponent<LotView>();
				}
				if(lot.Model!=null){
					if(Models.transform.FindChild (lot.Model.ModelRID)!=null){
						lot.Model.ModelView = Models.transform.FindChild (lot.Model.ModelRID).GetComponent<ModelView>();
					}
				}
			}
			community.Lots = lots;
			community.updateView ();
		}

		Dictionary<int, Lot> getLotDict(Lot[] lots){
			Dictionary<int, Lot> lotDict = new Dictionary<int, Lot>();
			for(int i = 0;i<lots.Length;i++){
				lotDict.Add (int.Parse(lots[i].LotRID), lots[i]);
			}
			return lotDict;
		}

		/*
		private Dictionary<string, HouseModel> buildHouseDict(Dictionary<string,string>[] housesDictArr){
			Dictionary<string, HouseModel> houseModelsDict = new Dictionary<string, HouseModel>();
			foreach(Dictionary<string, string> houseModelDict in housesDictArr){
                HouseModelGUI  houseModelGUI = houseModels.transform.Find (houseModelDict["modelRID"]).GetComponent<HouseModelGUI>();
				houseModelsDict.Add (houseModelDict["modelRID"], new HouseModel(houseModelDict, houseModelGUI));
			}
			return houseModelsDict;
		}
		*/
    }
}