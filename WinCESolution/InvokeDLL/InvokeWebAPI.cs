using System;
using System.Text;
using System.Net;
using System.IO;

namespace InvokeDLL
{
    public class InvokeWebAPI
    {
        // POST
        public string CreatePostHttpResponse(string url, string json)
        {
            // ��ʼ��HttpWebRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            if (request == null)
            {
                throw new ApplicationException(string.Format("Invalid url string: {0}", url));
            }

            // ���httpWebRequest�Ļ�����Ϣ
            request.UserAgent = ".NET Framework Test Client";
            request.ContentType = "application/json;charset=UTF-8"; // application/json
            request.Method = "POST";

            // ���Ҫpost������
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            request.ContentLength = bytes.Length;
            Stream requestStream;
            try
            {
                requestStream = request.GetRequestStream();
            }
            catch (Exception e)
            {
                // log error
                Console.WriteLine(string.Format("POST���������쳣��{0}", e.Message));
                throw e;
            }
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();

            // ����post���󵽷���������ȡ������������Ϣ
            Stream responseStream;
            try
            {
                responseStream = request.GetResponse().GetResponseStream();
            }
            catch (Exception e)
            {
                // log error
                Console.WriteLine(string.Format("POST���������쳣��{0}", e.Message));
                throw e;
            }

            // ��ȡ������������Ϣ
            string stringResponse = string.Empty;
            Encoding encoding = Encoding.UTF8;
            using (StreamReader responseReader = new StreamReader(responseStream, encoding))
            {
                stringResponse = responseReader.ReadToEnd();
            }
            responseStream.Close();

            // ����ֵ
            return stringResponse;
        }
    }
}
