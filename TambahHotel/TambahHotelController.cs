using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velacro.Basic;
using Velacro.Api;
using System.Net.Http;

namespace Hotelin_Desktop.TambahHotel
{
    public class TambahHotelController : MyController
    {
        public TambahHotelController(IMyView _myView) : base(_myView) { }

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
            client.setAuthorizationToken("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9sb2NhbGhvc3Q6ODAwMFwvYXBpXC91c2VyXC9sb2dpbiIsImlhdCI6MTYwNzAxMTc4NywiZXhwIjoxNjA3MDE1Mzg3LCJuYmYiOjE2MDcwMTE3ODcsImp0aSI6ImNpaXljQVhMQ1hsSnN0NnAiLCJzdWIiOjMsInBydiI6IjIzYmQ1Yzg5NDlmNjAwYWRiMzllNzAxYzQwMDg3MmRiN2E1OTc2ZjcifQ.f9VYhQq_5auhSa8yLJgjD77oAerBpUNeHO3K7X-x0hw"); // BEARER TOKEN GOES HERE
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
