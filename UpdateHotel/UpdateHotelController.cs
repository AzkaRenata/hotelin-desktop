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

namespace Hotelin_Desktop.UpdateHotel
{
    public class EditHotelController : MyController
    {
        private Hotel currentHotel;
        string bearerToken = File.ReadAllText(@"userToken.txt");


        public EditHotelController(IMyView _myView, int _hotelID) : base(_myView) 
        {
            getCurrentHotelDetail(_hotelID);
        }

        public async void getCurrentHotelDetail(int _hotelID)
        {


            var client = new ApiClient(MyURL.MyURL.baseURL);
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .addHeaders("Accept", "application/json")
                .setEndpoint(MyURL.MyURL.detailHotelURL+ _hotelID)
                .setRequestMethod(HttpMethod.Get);
                client.setAuthorizationToken(bearerToken);
                client.setOnSuccessRequest(setViewAddHotelStatus);
                var response = await client.sendRequest(request.getApiRequestBundle());

            string anotherResponse = await response.getHttpResponseMessage().Content.ReadAsStringAsync();
            currentHotel = JsonConvert.DeserializeObject<List<Hotel>>(anotherResponse)[0];

            getView().callMethod("setCurrentHotelValue", currentHotel.hotel_name, currentHotel.hotel_location, currentHotel.hotel_desc);            
        }



        public async void updateHotel(
            string _hotelName,
            string _hotelLocation,
            string _hotelDescription)
        {
            
            var client = new ApiClient(MyURL.MyURL.baseURL);
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
                .setEndpoint(MyURL.MyURL.updateHotelURL)
                .setRequestMethod(HttpMethod.Post);
                client.setAuthorizationToken(bearerToken);
                var response = await client.sendRequest(request.getApiRequestBundle());
            }
            else // HANDLING IF USER DIDN'T CHANGE ANYTHING
            {
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
            }
        }
    }
}
