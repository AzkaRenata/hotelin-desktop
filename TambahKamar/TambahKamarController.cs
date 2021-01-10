﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velacro.Basic;
using Velacro.Api;
using System.Net.Http;
using System.IO;
using System.Windows;

namespace Hotelin_Desktop.TambahKamar
{
    public class TambahKamarController : MyController
    {
        public TambahKamarController(IMyView _myView) : base(_myView) { }

        public async void addKamar(
            string _hotelID,
            string _roomType,
            string _bedType,
            string _roomPrice,
            string _guestCapacity)
        {
            if (validateAddInput(_hotelID, _roomType, _bedType, _roomPrice, _guestCapacity))
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
                    .addParameters("hotel_id", Convert.ToString(_hotelID))
                    .addParameters("room_type", _roomType)
                    .addParameters("bed_type", _bedType)
                    .addParameters("room_price", Convert.ToString(_roomPrice))
                    .addParameters("guest_capacity", Convert.ToString(_guestCapacity))
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
                MessageBox.Show("One of the required field is empty. Please try again.", "Failed");
                // Console.WriteLine("One of the required field is empty. Please try again.");
            }

        }

        private bool validateAddInput(string _hotelID, string _roomType, string _bedType, string _roomPrice, string _guestCapacity)
        {
            if (_hotelID.Length == 0) return false;
            if (_roomType.Length == 0) return false;
            if (_bedType.Length == 0) return false;
            if (_roomPrice.Length == 0) return false;
            if (_guestCapacity.Length == 0) return false;
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
