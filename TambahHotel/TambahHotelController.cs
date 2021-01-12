using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velacro.Basic;
using Velacro.Api;
using System.Net.Http;
using System.IO;

namespace Hotelin_Desktop.TambahHotel
{
    public class TambahHotelController : MyController
    {
        public TambahHotelController(IMyView _myView) : base(_myView) { }

        public TambahHotelPage TambahHotelPage { get; }

        public async void addHotel(
            string _hotelName,
            string _hotelLocation,
            string _hotelDescription,
            int _userID)
        {
            
            var client = new ApiClient(MyURL.MyURL.baseURL);
            var request = new ApiRequestBuilder();

            string bearerToken = File.ReadAllText(@"userToken.txt");

            var req = request
                .buildHttpRequest()
                .addHeaders("Accept", "application/json")
                .addParameters("hotel_name", _hotelName)
                .addParameters("hotel_location", _hotelLocation)
                .addParameters("hotel_desc", _hotelDescription)
                .addParameters("user_id", Convert.ToString(_userID))
                .setEndpoint(MyURL.MyURL.addHotelURL)
                .setRequestMethod(HttpMethod.Post);
            Console.WriteLine("tes2");
            client.setAuthorizationToken(bearerToken); // BEARER TOKEN GOES HERE
            client.setOnSuccessRequest(setViewAddHotelStatus);
            var response = await client.sendRequest(request.getApiRequestBundle());
        }

        private void setViewAddHotelStatus(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
            }
        }
    }
}
