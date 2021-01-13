using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velacro.Basic;
using Velacro.Api;
using System.Net.Http;
using System.IO;
using System.Windows;
using Hotelin_Desktop.Model;

namespace Hotelin_Desktop.Register
{
    public class FormRegisterController : MyController
    {
        public FormRegisterController(IMyView _myView) : base(_myView) { }

        public async void addHotel(Hotel hotel, byte[] fileByte, string fullFileName)
        {
            if (validateAddInput(hotel.hotel_name, hotel.hotel_location, hotel.hotel_desc))
            {
                var client = new ApiClient(MyURL.MyURL.baseURL);
                var request = new ApiRequestBuilder();

                string bearerToken = File.ReadAllText(@"userToken.txt");
                var multiPartContent = new MultipartFormDataContent();
                multiPartContent.Add(new StringContent(hotel.hotel_name), "hotel_name");
                multiPartContent.Add(new StringContent(hotel.hotel_location), "_hotel_location");
                multiPartContent.Add(new StringContent(hotel.hotel_desc), "hotel_desc");
                if (fileByte != null)
                    multiPartContent.Add(new StreamContent(new MemoryStream(fileByte)), "hotel_picture", fullFileName);
                var req = request
                    .buildMultipartRequest(new MultiPartContent(multiPartContent))
                    .setEndpoint(MyURL.MyURL.addHotelURL)
                    .setRequestMethod(HttpMethod.Post);
                client.setAuthorizationToken(bearerToken);
                client.setOnSuccessRequest(setViewAddHotelStatus);
                var response = await client.sendRequest(request.getApiRequestBundle());
            }
            else
            {
                MessageBox.Show("One of the required field is empty. Please try again.", "Try Again");
            }

        }

        private bool validateAddInput(string _hotel_name, string _hotel_location, string _hotel_desc)
        {
            if (_hotel_name.Length == 0) return false;
            if (_hotel_location.Length == 0) return false;
            if (_hotel_desc.Length == 0) return false;
            return true;
        }

        private void setViewAddHotelStatus(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
                getView().callMethod("redirectToDashboard");
            }
        }
    }
}
