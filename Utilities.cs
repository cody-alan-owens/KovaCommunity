using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Community
{
	class Utilities
	{
		static public string getIfExists(Dictionary<string, string> dictParam, string fieldParam){
			string val;
			if(dictParam.TryGetValue(fieldParam, out val)){
				return val;
			} else {
				return "";
			}
		}
		static public string dump(object obj){
			string dataDump = "";
			foreach(PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
			{
				string name=descriptor.Name;
				object value=descriptor.GetValue (obj);
				dataDump+=name+": "+value+"\n";
			}
			return dataDump;
		}
	}
}

