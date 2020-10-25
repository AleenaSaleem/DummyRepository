﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Backend.Models;
using System.Runtime.Serialization.Json;
using System.Net;
using System.IO;
using Newtonsoft.Json;

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
        public bool AddBed(string icuId)
        {
            HttpWebRequest _httpPostReq = WebRequest.CreateHttp(_url+"/"+icuId);
            _httpPostReq.Method = "POST";
            _httpPostReq.ContentType = "application/json";
            
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
        public ObservableCollection<BedModel> GetAllBedsFromAnIcu(string icuId)
        {

            HttpWebRequest _httpReq = WebRequest.CreateHttp(_url+"/"+icuId);
            _httpReq.Method = "GET";
            HttpWebResponse response = _httpReq.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                var result = reader.ReadToEnd();
                var beds = JsonConvert.DeserializeObject<ObservableCollection<BedModel>>(result);
                return beds;
            }
            return null;
        }

        public ObservableCollection<BedModel> GetAllBeds()
        {

            HttpWebRequest _httpReq = WebRequest.CreateHttp(_url);
            _httpReq.Method = "GET";
            HttpWebResponse response = _httpReq.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                var result = reader.ReadToEnd();
                var beds = JsonConvert.DeserializeObject<ObservableCollection<BedModel>>(result);
                return beds;
            }
            return null;
        }

    }
}
