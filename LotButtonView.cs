using System;
using UnityEngine;

namespace Community{
    
    class LotButtonView : MonoBehaviour, IClickable{
        
		public LotView LotView;

        void Start(){
            
        }
        
        void Update(){
            
        }
        
        public void Click(){
			Debug.Log ("Lot clicked!");
			LotView.changeCamera();
        }
        
        public void autoAssignLotViews(){
            this.LotView = gameObject.transform.parent.GetComponent<LotView>();            
        }
    }
}