using System;
using System.Web.Script.Serialization;
using System.Collections;
using System.Collections.Generic;


public class Test{
    public static void Main(string[] args){
        Request r = new Request("uq4ZWSWme1m6LwoDO3KuCXkM0tlNCuoW","crkQ0FZTkAtqcy4zqRrWlIpMv2nbuJRz");
        //Request r = new Request("StWJNHkw8JrPTPJ2aBfV2DeOtoE0KR4x","7CU/1sZhUkosm39pF+2Qs3mPrVH9l04i");
        string jsonCfdi = System.IO.File.ReadAllText(@"test.json");
       string response = r.timbrar(jsonCfdi);
       Console.WriteLine(response);
       //Console.WriteLine(new JavaScriptSerializer().Deserialize<Dictionary<string,object>>(response));
    }
    
} 
