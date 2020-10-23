using System.Collections.ObjectModel;
using System.Runtime.Serialization.Json;
using System.Net;
using Backend.Models;
using System;
namespace Frontend.ApiCalls
{
    public class IcuApiCalls
    {
        private readonly string _url ="http://localhost:5000/api/icus";
        public ObservableCollection<IcuModel> _icus = new ObservableCollection<Backend.Models.IcuModel>();
        DataContractJsonSerializer _jsonSerializer;

        public IcuApiCalls()
        {
            GetAllIcus();
        }
        public bool AddIcu(IcuModel icuModel)
        {
            HttpWebRequest _httpPostReq =WebRequest.CreateHttp(_url);
            _httpPostReq.Method = "POST";
            _httpPostReq.ContentType = "application/json";
            DataContractJsonSerializer userDataJsonSerializer =
                new DataContractJsonSerializer(typeof(IcuModel));
            userDataJsonSerializer.WriteObject(_httpPostReq.GetRequestStream(), icuModel);
            HttpWebResponse response = _httpPostReq.GetResponse() as HttpWebResponse;
            var result = response.ToString();
            if(result == "true")
            {
                return true;
            }
           
            return false;
        }
        public bool RemoveIcu(string icuId)
        {
            HttpWebRequest _httpPostReq = WebRequest.CreateHttp(_url+"/"+icuId);
            _httpPostReq.Method = "DELETE";
            _httpPostReq.ContentType = "application/json";
            HttpWebResponse response = _httpPostReq.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }
        public void GetAllIcus()
        {
            HttpWebRequest _httpReq = WebRequest.CreateHttp(_url);
            _httpReq.Method = "GET";
            HttpWebResponse response = _httpReq.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                _jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Backend.Models.IcuModel>));
                _icus = _jsonSerializer.ReadObject(response.GetResponseStream()) as ObservableCollection<Backend.Models.IcuModel>;
            }
        }
        public IcuModel GetIcu()
        {

            HttpWebRequest _httpReq = WebRequest.CreateHttp(_url);
            _httpReq.Method = "GET";
            HttpWebResponse response = _httpReq.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                _jsonSerializer = new DataContractJsonSerializer(typeof(IcuModel));
                var icu = _jsonSerializer.ReadObject(response.GetResponseStream()) as IcuModel;
                return icu;
            }
            return null;
        }
    }
}
