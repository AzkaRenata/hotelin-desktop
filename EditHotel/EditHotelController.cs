using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velacro.Basic;
using Velacro.Api;
using System.Net.Http;
using Hotelin_Desktop.Model;
using Newtonsoft.Json;
using System.IO;

namespace Hotelin_Desktop.EditHotel
{
    public class EditHotelController : MyController
    {
        private HotelModel currentHotel;
        private HotelProfile hotel;
        private string bearerToken = File.ReadAllText(@"userToken.txt"); // BEARER TOKEN GOES HERE

        public EditHotelController(IMyView _myView, int _hotelID) : base(_myView) 
        {
            getCurrentHotelDetail();
        }

        public async void getCurrentHotelDetail()
        {
            var client = new ApiClient(MyURL.MyURL.baseURL);
            var request = new ApiRequestBuilder();
            string endPoint = "hotel/profile";

            var req = request
                .buildHttpRequest()
                .addHeaders("Accept", "application/json")
                .setEndpoint(endPoint)
                .setRequestMethod(HttpMethod.Get);
            Console.WriteLine("tes2");
            client.setAuthorizationToken(bearerToken);
            client.setOnSuccessRequest(setViewAddHotelStatus);
            var response = await client.sendRequest(request.getApiRequestBundle());
            Console.WriteLine("tes1");
            //Console.WriteLine(bearerToken);

            string anotherResponse = await response.getHttpResponseMessage().Content.ReadAsStringAsync();

            hotel = response.getParsedObject<HotelProfile>();
            getView().callMethod("setCurrentHotelValue", hotel);


            // Console.WriteLine("tes : " + response.getHttpResponseMessage().StatusCode);
            // Console.WriteLine("Tes : " + response.getHttpResponseMessage().ToString());
            // Console.WriteLine("tes3 : " + response.getHttpResponseMessage().Headers);
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
                //getView().callMethod("setPembatalan", _response.getParsedObject<BookingList>().booking);
                
            }
        }

        public async void updateHotel(
            string _hotelName,
            string _hotelLocation,
            string _hotelDescription)
        {
            string API = "http://localhost:8000/";
            string endPoint = "api/hotel/update";
            var client = new ApiClient(API);
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .addHeaders("Accept", "application/json")
                .addParameters("hotel_name", _hotelName)
                .addParameters("hotel_location", _hotelLocation)
                .addParameters("hotel_desc", _hotelDescription)
                .setEndpoint(endPoint)
                .setRequestMethod(HttpMethod.Post);
            Console.WriteLine("tes2");
            client.setAuthorizationToken(bearerToken);
            var response = await client.sendRequest(request.getApiRequestBundle());
        }

        private Boolean hasUserEdited(
            string _hotelName,
            string _hotelLocation,
            string _hotelDescription) 
        {
            if (String.Compare(_hotelName, currentHotel.hotel_name) != 0) return true;
            if (String.Compare(_hotelLocation, currentHotel.hotel_location) != 0) return true;
            if (String.Compare(_hotelDescription, currentHotel.hotel_desc) != 0) return true;

            return false;
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
