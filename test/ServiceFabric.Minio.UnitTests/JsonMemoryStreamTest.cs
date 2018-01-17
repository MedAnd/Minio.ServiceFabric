using System.IO;
using System.Threading.Tasks;
using Utf8Json;
using Xunit;

namespace ServiceFabric.Minio.UnitTest
{
    /// <summary>
    /// 
    /// </summary>
    public class JsonMemoryStreamTest : BaseTest
    {
        public class Address
        {
            public string Street { get; set; }
        }

        public class Person
        {
            public string Name { get; set; }
            public Address[] Addresses { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public async Task PutObjectAsync_GetObjectAsync_Test()
        {
            Person pActual = null;
            Person pExpected = new Person
            {
                Name = "John",
                Addresses = new[]
                {
                        new Address { Street = "St." },
                        new Address { Street = "Ave." }
                    }
            };

            var bucketName = GetRandomName();
            var objectName = GetRandomName() + ".json";

            bool found = await _minioClient.BucketExistsAsync(bucketName);
            if (!found)
            {
                await _minioClient.MakeBucketAsync(bucketName);
            }

            using (var stream = new MemoryStream(JsonSerializer.Serialize<Person>(pExpected)))
            {
                await _minioClient.PutObjectAsync(bucketName, objectName, stream, stream.Length, "application/json");
            }

            await _minioClient.GetObjectAsync(bucketName, objectName, (stream) =>
            {
                pActual = JsonSerializer.Deserialize<Person>(stream);
            });

            Assert.Equal(pExpected.Name, pActual.Name);
            Assert.Equal(pExpected.Addresses[0].Street, pActual.Addresses[0].Street);
            Assert.Equal(pExpected.Addresses[1].Street, pActual.Addresses[1].Street);
        }
    }
}
