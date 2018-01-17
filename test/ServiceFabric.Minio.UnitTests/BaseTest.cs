using Minio;
using System;
using System.Text;

namespace ServiceFabric.Minio.UnitTest
{
    public class BaseTest
    {
        private const string _endPoint = "localhost:9000";
        private const string _accessKey = "";
        private const string _secretKey = "";

        protected MinioClient _minioClient = null;

        /// <summary>
        /// 
        /// </summary>
        public BaseTest()
        {
            _minioClient = new MinioClient(_endPoint, _accessKey, _secretKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String GetRandomName()
        {
            Random rnd = new Random();
            string characters = "0123456789abcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(32);

            for (int i = 0; i < 32; i++)
            {
                if (i == 16)
                {
                    result.Append("-");
                }
                else
                {
                    result.Append(characters[rnd.Next(characters.Length)]);
                }
            }

            return result.ToString();
        }
    }
}
