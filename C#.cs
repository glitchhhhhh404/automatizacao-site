using System;

using System.Net;

using System.IO;

class Program

{

    static void Main(string[] args)

    {

        var request = WebRequest.Create("https://www.example.com/checkout");

        request.Method = "POST";

        string postData = "item=1234&quantity=2";

        byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(postData);

        request.ContentType = "application/x-www-form-urlencoded";

        request.ContentLength = byteArray.Length;

        Stream dataStream = request.GetRequestStream();

        dataStream.Write(byteArray, 0, byteArray.Length);

        dataStream.Close();

        WebResponse response = request.GetResponse();

        Console.WriteLine(((HttpWebResponse)response).StatusDescription);

        dataStream = response.GetResponseStream();

        StreamReader reader = new StreamReader(dataStream);

        string responseFromServer = reader.ReadToEnd();

        Console.WriteLine(responseFromServer);

        reader.Close();

        dataStream.Close();

        response.Close();

    }

}

