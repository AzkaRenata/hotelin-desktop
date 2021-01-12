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
        private Hotel currentHotel;
        private HotelProfile hotel;
        private string bearerToken = File.ReadAllText(@"userToken.txt"); // BEARER TOKEN GOES HERE

        public EditHotelController(IMyView _myView) : base(_myView)
        {
            getCurrentHotelDetail();
        }

        public async void getCurrentHotelDetail()
        {
            var client = new ApiClient(MyURL.MyURL.baseURL);
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .addHeaders("Accept", "application/json")
                .setEndpoint(MyURL.MyURL.profileHotelURL)
                .setRequestMethod(HttpMethod.Get);
            client.setAuthorizationToken(bearerToken);
            client.setOnSuccessRequest(setViewAddHotelStatus);
            var response = await client.sendRequest(request.getApiRequestBundle());

            string anotherResponse = await response.getHttpResponseMessage().Content.ReadAsStringAsync();

            hotel = response.getParsedObject<HotelProfile>();
            getView().callMethod("setCurrentHotelValue", hotel);


        }

        private void setItem(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;

            }
        }

        public async void updateHotel(Hotel hotel, byte[] fileByte, string fullFileName)
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
                .setEndpoint(MyURL.MyURL.updateHotelURL)
                .setRequestMethod(HttpMethod.Post);
            client.setAuthorizationToken(bearerToken);
            client.setOnSuccessRequest(setViewAddHotelStatus);
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
            }
        }
    }
}
