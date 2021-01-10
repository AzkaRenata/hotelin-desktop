using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velacro.Basic;
using Velacro.Api;
using System.Net.Http;
using System.IO;
using Hotelin_Desktop.Model;

namespace Hotelin_Desktop.AddHotel
{
    public class AddHotelController : MyController
    {
        public AddHotelController(IMyView _myView) : base(_myView) { }

        public async void addHotel(HotelModel hotel, byte[] fileByte, string fullFileName)
        {
            var client = new ApiClient(MyURL.MyURL.baseURL);
            var request = new ApiRequestBuilder();

            string bearerToken = File.ReadAllText(@"userToken.txt");
            var multiPartContent = new MultipartFormDataContent();
            multiPartContent.Add(new StringContent(hotel.hotel_name), "hotel_name");
            multiPartContent.Add(new StringContent(hotel.hotel_location), "hotel_location");
            multiPartContent.Add(new StringContent(hotel.hotel_desc), "hotel_desc");
            if (fileByte != null)
                multiPartContent.Add(new StreamContent(new MemoryStream(fileByte)), "hotel_picture", fullFileName);
            var req = request
                .buildMultipartRequest(new MultiPartContent(multiPartContent))
                .addHeaders("Accept", "application/json")
                .setEndpoint("hotel/create")
                .setRequestMethod(HttpMethod.Post);
            Console.WriteLine("tes2");
            client.setAuthorizationToken(bearerToken);
            client.setOnSuccessRequest(setViewAddHotelStatus);
            var response = await client.sendRequest(request.getApiRequestBundle());

            Console.WriteLine("Tes : " + response.getHttpResponseMessage().ToString());

        }

        private void setViewAddHotelStatus(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
                //getView().callMethod("setRegisterStatus", status);
            }
        }
    }
}
