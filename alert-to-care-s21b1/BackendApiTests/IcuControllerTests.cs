using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BackendApiTests
{
    public class IcuControllerTests
    {
        private readonly MockServer _mockServer;
        private static readonly string _url = "http://localhost:5000/api/icus";
        public IcuControllerTests()
        {
            _mockServer = new MockServer();
        }
        Backend.Models.IcuModel _icu = new Backend.Models.IcuModel()
        {
            IcuId = "IC3",
            Layout = "U",
            NoOfBeds = 0,
            MaxBeds = 10
        };

        [Fact]
        public async Task TestExpectingNewIcuToBeAddedIfItIsValid()
        {
            var response = await _mockServer.Client.PostAsync(_url, new StringContent(JsonConvert.SerializeObject(_icu), Encoding.UTF8, "application/json"));
            var jsonString = await response.Content.ReadAsStringAsync();
            Assert.Equal("true", JsonConvert.DeserializeObject<string>(jsonString));
            await _mockServer.Client.DeleteAsync(_url + "/" + _icu.IcuId);
        }
        [Fact]
        public async Task TestExpectingFalseForIcuToBeAddedIfItIsInValid()
        {
            await _mockServer.Client.PostAsync(_url, new StringContent(JsonConvert.SerializeObject(_icu), Encoding.UTF8, "application/json"));
            var response = await _mockServer.Client.PostAsync(_url, new StringContent(JsonConvert.SerializeObject(_icu), Encoding.UTF8, "application/json"));
            var jsonString = await response.Content.ReadAsStringAsync();
            Assert.Equal("false", JsonConvert.DeserializeObject<string>(jsonString));
            await _mockServer.Client.DeleteAsync(_url + "/" + _icu.IcuId);
        }
        [Fact]
        public async Task TestExpectingListOfAllIcusWhenCalled()
        {
            var response = await _mockServer.Client.GetAsync(_url);
            var jsonString = await response.Content.ReadAsStringAsync();
            var icus = JsonConvert.DeserializeObject<List<Backend.Models.IcuModel>>(jsonString);
            Assert.True(icus.Count == 2);
            Assert.Contains("IC1", jsonString);
            Assert.Contains("IC2", jsonString);
            //Assert.Equal("IC2", icus[0].IcuId);
            //Assert.Equal("IC1", icus[1].IcuId);
        }
        [Fact]
        public async Task TestExpectingAnIcuWhenCalledWithAnIcuId()
        {
            var response = await _mockServer.Client.GetAsync(_url+"/IC1");
            var jsonString = await response.Content.ReadAsStringAsync();
            var icu = JsonConvert.DeserializeObject<Backend.Models.IcuModel>(jsonString);
            Assert.Equal("IC1", icu.IcuId);
            Assert.Equal("L", icu.Layout);
        }
        [Fact]
        public async Task TestExpectingFalseWhenIcuDoesNotExistWhenCalledWithAnInvalidIcuId()
        {
            var response = await _mockServer.Client.GetAsync(_url + "/random_id");
            var jsonString = await response.Content.ReadAsStringAsync();
            var icu = JsonConvert.DeserializeObject<Backend.Models.IcuModel>(jsonString);
            Assert.Null(icu);
        }
        [Fact]
        public async Task TestExpectingIcuToBeRemovedWhenCalledWithValidId()
        {
            await _mockServer.Client.PostAsync(_url, new StringContent(JsonConvert.SerializeObject(_icu), Encoding.UTF8, "application/json"));
            var response = await _mockServer.Client.DeleteAsync(_url + "/" + _icu.IcuId);
            var jsonString = await response.Content.ReadAsStringAsync();
            Assert.Equal("true", JsonConvert.DeserializeObject<string>(jsonString));
        }
        [Fact]
        public async Task TestExpectingFalseForIcuToBeRemovedWhenCalledWithInValidId()
        {
            var response = await _mockServer.Client.DeleteAsync(_url + "/" + _icu.IcuId);
            var jsonString = await response.Content.ReadAsStringAsync();
            Assert.Equal("false", JsonConvert.DeserializeObject<string>(jsonString));
        }

    }
}
