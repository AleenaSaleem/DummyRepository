using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Net;
using System.Collections.ObjectModel;
using Backend.Models;

namespace Frontend.ApiCalls
{
    public class PatientApiCalls
    {
        private readonly string _url = "http://localhost:5000/api/patients";
        public ObservableCollection<PatientModel> _patients = new ObservableCollection<PatientModel>();
        DataContractJsonSerializer _jsonSerializer;

        public PatientApiCalls()
        {
            //GetAllPatients();
        }
        public bool AddPatient(PatientModel patientModel)
        {
            HttpWebRequest _httpPostReq = WebRequest.CreateHttp(_url);
            _httpPostReq.Method = "POST";
            _httpPostReq.ContentType = "application/json";
            DataContractJsonSerializer userDataJsonSerializer =
                new DataContractJsonSerializer(typeof(PatientModel));
            userDataJsonSerializer.WriteObject(_httpPostReq.GetRequestStream(), patientModel);
            HttpWebResponse response = _httpPostReq.GetResponse() as HttpWebResponse;
            var result = response.ToString();
            if (result == "true")
            {
                return true;
            }

            return false;
        }
        public bool RemovePatient(string PatientId)
        {
            HttpWebRequest _httpPostReq = WebRequest.CreateHttp(_url + "/" + PatientId);
            _httpPostReq.Method = "DELETE";
            _httpPostReq.ContentType = "application/json";
            HttpWebResponse response = _httpPostReq.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }
        public ObservableCollection<PatientModel> GetAllPatients()
        {
            HttpWebRequest _httpReq = WebRequest.CreateHttp(_url);
            _httpReq.Method = "GET";
            HttpWebResponse response = _httpReq.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                _jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Backend.Models.PatientModel>));
                _patients = _jsonSerializer.ReadObject(response.GetResponseStream()) as ObservableCollection<Backend.Models.PatientModel>;
            }
            return _patients;
        }
        public PatientModel GetPatient(string patientId)
        {

            HttpWebRequest _httpReq = WebRequest.CreateHttp(_url+"/"+patientId);
            _httpReq.Method = "GET";
            HttpWebResponse response = _httpReq.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                _jsonSerializer = new DataContractJsonSerializer(typeof(PatientModel));
                var Patient = _jsonSerializer.ReadObject(response.GetResponseStream()) as PatientModel;
                return Patient;
            }
            return null;
        }
    }
}
