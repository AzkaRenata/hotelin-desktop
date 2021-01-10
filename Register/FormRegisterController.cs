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

namespace Hotelin_Desktop.Register
{
    public class FormRegisterController : MyController
    {
        public FormRegisterController(IMyView _myView) : base(_myView) { }

        public async void addHotel(
            string _hotel_name,
            string _hotel_location,
            string _hotel_desc)
        {
            if (validateAddInput(_hotel_name, _hotel_location, _hotel_desc))
            {
                //string API = "http://localhost:8000/";
                //var client = new ApiClient(API);
                //var request = new ApiRequestBuilder();
                string endPoint = "api/room/create";
                var client = new ApiClient(MyURL.MyURL.baseURL);
                var request = new ApiRequestBuilder();

                string bearerToken = File.ReadAllText(@"userToken.txt");

                var req = request
                    .buildHttpRequest()
                    .addHeaders("Accept", "application/json")
                    .addParameters("nama_hotel_txt", _hotel_name)
                    .addParameters("lokasi_txt", _hotel_location)
                    .addParameters("deskripsi_txt", _hotel_desc)
                    .setEndpoint(endPoint)
                    .setRequestMethod(HttpMethod.Post);
                Console.WriteLine("tes2");
                client.setAuthorizationToken(bearerToken);
                client.setOnSuccessRequest(setViewAddHotelStatus);
                var response = await client.sendRequest(request.getApiRequestBundle());
                Console.WriteLine("tes1");
                Console.WriteLine("tes : " + response.getHttpResponseMessage().StatusCode);
                Console.WriteLine("Tes : " + response.getHttpResponseMessage().ToString());
                Console.WriteLine("tes3 : " + response.getHttpResponseMessage().Headers);
            }
            else
            {
                MessageBox.Show("One of the required field is empty. Please try again.", "Try Again");
                // Console.WriteLine("One of the required field is empty. Please try again.");
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
                //getView().callMethod("setRegisterStatus", status);
            }
        }
    }
}
