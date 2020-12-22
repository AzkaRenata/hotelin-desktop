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
            string API = "http://localhost:8000/";
            string endPoint = "api/hotel/create";
            var client = new ApiClient(API);
            var request = new ApiRequestBuilder();

            string bearerToken = File.ReadAllText(@"userToken.txt");

            var req = request
                .buildHttpRequest()
                .addHeaders("Accept", "application/json")
                .addParameters("hotel_name", _hotelName)
                .addParameters("hotel_location", _hotelLocation)
                .addParameters("hotel_desc", _hotelDescription)
                .addParameters("user_id", Convert.ToString(_userID))
                //.addParameters("hotel_name", "Hotel Cemara")
                //.addParameters("hotel_location", "Surabaya, Jawa Timur")
                //.addParameters("hotel_desc", "mantap")
                //.addParameters("user_id", "3")
                .setEndpoint(endPoint)
                .setRequestMethod(HttpMethod.Post);
            Console.WriteLine("tes2");
            client.setAuthorizationToken(bearerToken); // BEARER TOKEN GOES HERE
            client.setOnSuccessRequest(setViewAddHotelStatus);
            var response = await client.sendRequest(request.getApiRequestBundle());
            Console.WriteLine("tes1");
            //Console.WriteLine(response.getJObject()["user"]);
            Console.WriteLine("tes : " + response.getHttpResponseMessage().StatusCode);
            Console.WriteLine("Tes : " + response.getHttpResponseMessage().ToString());
            Console.WriteLine("tes3 : " + response.getHttpResponseMessage().Headers);

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
