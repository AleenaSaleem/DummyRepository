using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using System.Linq;

namespace BackendApiTests
{
    public class BedControllerTests
    {
        private readonly MockServer _mockServer;
        private static readonly string _url = "http://localhost:5000/api/beds";
        public BedControllerTests()
        {
            _mockServer = new MockServer();
        }
       
        [Fact]
        public async Task TestExpectingNewBedToBeAddedIfItIsValid()
        {
            var response = await _mockServer.Client.PostAsync(_url+"/IC1/FirstFromTop", new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));
            var jsonString = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            await _mockServer.Client.DeleteAsync(_url + "/IC1/IC1L1"); 
        }
        [Fact]
        public async Task TestExpectingFalseForBedToBeAddedIfItIsInValid()
        {
            var response = await _mockServer.Client.PostAsync(_url+"/random_id", new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));
            var jsonString = await response.Content.ReadAsStringAsync();
            Assert.Equal("false", JsonConvert.DeserializeObject<string>(jsonString));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //await _mockServer.Client.DeleteAsync(_url + "/" + );
        }
        [Fact]
        public async Task TestExpectingListOfAllBedsWhenCalled()
        {
            await _mockServer.Client.PostAsync(_url + "/IC1/FirstFromTop", new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));
            var response = await _mockServer.Client.GetAsync(_url);
            var jsonString = await response.Content.ReadAsStringAsync();
            Assert.Contains("IC1", jsonString);
            await _mockServer.Client.DeleteAsync(_url + "/IC1/IC1L1");
        }
        [Fact]
        public async Task TestExpectingListOfAllBedsFromOneIcuWhenCalledWithIcuId()
        {
            await _mockServer.Client.PostAsync(_url + "/IC1/FirstFromTop", new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));
            var response = await _mockServer.Client.GetAsync(_url+"/IC1");
            var jsonString = await response.Content.ReadAsStringAsync();
            var beds = JsonConvert.DeserializeObject<List<Backend.Models.BedModel>>(jsonString);
            Assert.True(beds.Count == 1);
            Assert.Equal("IC1", beds[0].IcuId);
            Assert.Equal("IC1L1", beds[0].BedId);
            await _mockServer.Client.DeleteAsync(_url + "/IC1/IC1L1");
        }
       /* [Fact]
        public async Task TestExpectingABedWhenCalledWithAnBedId()
        {
            var response = await _mockServer.Client.GetAsync(_url + "/IC1L1");
            var jsonString = await response.Content.ReadAsStringAsync();
            var bed = JsonConvert.DeserializeObject<Backend.Models.BedModel>(jsonString);
            Assert.Equal("IC1", bed.IcuId);
            Assert.Equal("IC1L1", bed.BedId);
        }*/
        [Fact]
        public async Task TestExpectingEmptyListForBedsWhenIcuDoesNotExistWhenCalledWithAnInvalidIcuId()
        {
            var response = await _mockServer.Client.GetAsync(_url + "/random_id");
            var jsonString = await response.Content.ReadAsStringAsync();
            var beds = JsonConvert.DeserializeObject<List<Backend.Models.BedModel>>(jsonString);
            Assert.False(beds.Any());
        }
        [Fact]
        public async Task TestExpectingBedToBeRemovedIfItIsFreeWhenCalledWithValidId()
        {
            await _mockServer.Client.PostAsync(_url + "/IC1/SecondFromTop", new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json"));
            var response = await _mockServer.Client.DeleteAsync(_url + "/IC1/IC1L1");
            var jsonString = await response.Content.ReadAsStringAsync();
            Assert.Equal("true", JsonConvert.DeserializeObject<string>(jsonString));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task TestExpectingFalseForBedToBeRemovedWhenCalledWithInValidId()
        {
            var response = await _mockServer.Client.DeleteAsync(_url + "/IC1/IC1U1");
            var jsonString = await response.Content.ReadAsStringAsync();
            Assert.Equal("false", JsonConvert.DeserializeObject<string>(jsonString));
        }
    }
}
