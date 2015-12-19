using System;
using System.Collections;
using System.Collections.Generic;

namespace Community{

	class Model : IKovaObject
    {
        public string Name{ get; set; }
		public string WebGroupName{ get; set; }
        public string ModelRID{ get; set; }
        public string ObjectRID{ get; set; }
        public string ModelID{ get; set; }
        public string Description{ get; set; }
        public string Type{ get; set; }
        public string Style{ get; set; }
        public string NumBedrooms{ get; set; }
        public string NumBaths{ get; set; }
        public string GarageHanding{ get; set; }
        public string Status{ get; set; }
        public string DescrBedrooms{ get; set; }
        public string DescrBaths{ get; set; }
        public string DescrGarage{ get; set; }
        public string DescrSqf{ get; set; }
        public string MarketingName{ get; set; }
        public string CommunityModelName{ get; set; }
        public string BasePrice{ get; set; }
		public string ModelYear{ get; set; }
		public string PresentationImageURL{ get; set; }
		public string PerspectiveImageURL{ get; set; }
		public string BrochureImageURL{ get; set; }
		public ModelView ModelView{ get; set; }

		public Model(){

		}
    }
}