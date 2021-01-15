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
using System.Windows.Navigation;
using Hotelin_Desktop.TambahKamar;
using Hotelin_Desktop.Dashboard;
using System.Windows;

namespace Hotelin_Desktop.AddHotel
{
    public class AddHotelController : MyController
    {
        public AddHotelController(IMyView _myView) : base(_myView) { }

        public async void addHotel(Hotel hotel, byte[] fileByte, string fullFileName)
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
                .setEndpoint(MyURL.MyURL.addHotelURL)
                .setRequestMethod(HttpMethod.Post);
            client.setAuthorizationToken(bearerToken);
            client.setOnSuccessRequest(setViewAddHotelStatus);
            var response = await client.sendRequest(request.getApiRequestBundle());


        }

        private void setViewAddHotelStatus(HttpResponseBundle _response)
        {
               string status = _response.getHttpResponseMessage().ReasonPhrase;
        }

    }
}
