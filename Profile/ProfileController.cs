using Hotelin_Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Velacro.Api;
using Velacro.Basic;

namespace Hotelin_Desktop.Profile
{
    class ProfileController : MyController
    {
        public ProfileController(IMyView _myView) : base(_myView)
        {

        }

        public async void requestProfile(string token)
        {
            var client = new ApiClient(MyURL.MyURL.baseURL);
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .setEndpoint(MyURL.MyURL.hotelDetailURL)
                .setRequestMethod(HttpMethod.Get);
            client.setAuthorizationToken(token);
            client.setOnSuccessRequest(setItem);
            var response = await client.sendRequest(request.getApiRequestBundle());
            Console.WriteLine("Masukk Profile");
            //Console.WriteLine(response.getJObject()["token"]);
            //client.setAuthorizationToken(response.getJObject()["access_token"].ToString());
        }

        private void setItem(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
                Console.WriteLine("COBA");
                //JArray json = JArray.Parse(_response.getJObject().ToString());
                //string json = _response.getJArray
                //Console.WriteLine(json);
                //var model = JsonConvert.DeserializeObject<BookingList>(JArray.Parse(_response.getJObject().Value));
                //Console.WriteLine(model);
                //Console.WriteLine("HAYO : " + _response.getParsedObject<BookingList>().booking.Count());
                
                getView().callMethod("setProfile", _response.getParsedObject<HotelProfile>());
            }
        }
    }
}
