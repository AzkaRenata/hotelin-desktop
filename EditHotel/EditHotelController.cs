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
        private string bearerToken = File.ReadAllText(@"userToken.txt"); // BEARER TOKEN GOES HERE

        public EditHotelController(IMyView _myView, int _hotelID) : base(_myView) 
        {
            getCurrentHotelDetail(_hotelID);
        }

        public async void getCurrentHotelDetail(int _hotelID)
        {
            string API = "http://localhost:8000/";
            string endPoint = "api/hotel/detail/" + _hotelID;
            var client = new ApiClient(API);
            var request = new ApiRequestBuilder();

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

            Console.WriteLine(anotherResponse);

            currentHotel = JsonConvert.DeserializeObject<List<HotelModel>>(anotherResponse)[0];

            getView().callMethod("setCurrentHotelValue", currentHotel.hotel_name, currentHotel.hotel_location, currentHotel.hotel_desc);            

            // Console.WriteLine("tes : " + response.getHttpResponseMessage().StatusCode);
            // Console.WriteLine("Tes : " + response.getHttpResponseMessage().ToString());
            // Console.WriteLine("tes3 : " + response.getHttpResponseMessage().Headers);
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

            if (hasUserEdited(_hotelName, _hotelLocation, _hotelDescription) == true) // HANDLING IF USER DID CHANGE SOMETHING
            {
                var req = request
                .buildHttpRequest()
                .addHeaders("Accept", "application/json")
                .addParameters("hotel_name", _hotelName)
                .addParameters("hotel_location", _hotelLocation)
                .addParameters("hotel_desc", _hotelDescription)
                .addParameters("user_id", currentHotel.user_id.ToString())
                .setEndpoint(endPoint)
                .setRequestMethod(HttpMethod.Post);
                Console.WriteLine("tes2");
                client.setAuthorizationToken(bearerToken);
                var response = await client.sendRequest(request.getApiRequestBundle());

                Console.WriteLine("tes1");
                //Console.WriteLine(response.getJObject()["user"]);
                Console.WriteLine("tes : " + response.getHttpResponseMessage().StatusCode);
                Console.WriteLine("Tes : " + response.getHttpResponseMessage().ToString());
                Console.WriteLine("tes3 : " + response.getHttpResponseMessage().Headers);
            }
            else // HANDLING IF USER DIDN'T CHANGE ANYTHING
            {
                Console.WriteLine("Gaada yg diganti om.");
            }
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
