using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Backend.Models;
using System.Runtime.Serialization.Json;
using System.Net;
namespace Frontend.ApiCalls
{
    public class BedApiCalls
    {
        private readonly string _url = "http://localhost:5000/api/beds";
        public ObservableCollection<BedModel> _beds = new ObservableCollection<BedModel>();
        DataContractJsonSerializer _jsonSerializer;

        public BedApiCalls()
        {
            //GetAllBeds();
        }
        public bool AddBed(BedModel bedModel)
        {
            HttpWebRequest _httpPostReq = WebRequest.CreateHttp(_url+"/"+bedModel.IcuId);
            _httpPostReq.Method = "POST";
            _httpPostReq.ContentType = "application/json";
            DataContractJsonSerializer userDataJsonSerializer =
                new DataContractJsonSerializer(typeof(BedModel));
            userDataJsonSerializer.WriteObject(_httpPostReq.GetRequestStream(), bedModel);
            HttpWebResponse response = _httpPostReq.GetResponse() as HttpWebResponse;
            var result = response.ToString();
            if (result == "true")
            {
                return true;
            }

            return false;
        }
        public bool RemoveBed(string icuId,string bedId)
        {
            HttpWebRequest _httpPostReq = WebRequest.CreateHttp(_url + "/" +icuId+"/"+ bedId);
            _httpPostReq.Method = "DELETE";
            _httpPostReq.ContentType = "application/json";
            HttpWebResponse response = _httpPostReq.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }
        /*public ObservableCollection<BedModel> GetAllBeds()
        {
            HttpWebRequest _httpReq = WebRequest.CreateHttp(_url);
            _httpReq.Method = "GET";
            HttpWebResponse response = _httpReq.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                _jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Backend.Models.BedModel>));
                _beds = _jsonSerializer.ReadObject(response.GetResponseStream()) as ObservableCollection<Backend.Models.BedModel>;
            }
            return _beds;
        }*/
        public BedModel GetAllBedsFromAnIcu(string icuId)
        {

            HttpWebRequest _httpReq = WebRequest.CreateHttp(_url+"/"+icuId);
            _httpReq.Method = "GET";
            HttpWebResponse response = _httpReq.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                _jsonSerializer = new DataContractJsonSerializer(typeof(BedModel));
                var Bed = _jsonSerializer.ReadObject(response.GetResponseStream()) as BedModel;
                return Bed;
            }
            return null;
        }
    }
}
