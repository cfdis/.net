using System;
using System.IO;
using System.Net;
using System.Text;


class Request {
    string endpoint;
    string apiId;
    string apiSecret;
    public Request(string apiId, string apiSecret,bool production = false){

        this.apiId=apiId;
        this.apiSecret=apiSecret;
        if(production){
            endpoint="https://backend.facturabilidad.com/api";
        }else{
            endpoint="http://backend.demo.facturabilidad.com/api";
            //endpoint="http://local.backend.facturabilidad.com/api";
        }
    }
    public string timbrar(string json){
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(endpoint+"/Cfdi33/timbrar");
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "POST";

        String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(apiId + ":" + apiSecret));
        httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            streamWriter.Write(json);
        }

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            return result;
        }
    }
}
