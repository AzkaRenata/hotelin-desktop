﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velacro.Basic;
using Velacro.Api;
using System.Net.Http;

namespace Hotelin_Desktop.TambahKamar
{
    public class TambahKamarController : MyController
    {
        public TambahKamarController(IMyView _myView) : base(_myView) { }

        public async void addKamar(
            int _hotelID,
            string _roomType,
            string _bedType,
            long _roomPrice,
            int _guestCapacity)
        {
            string API = "http://localhost:8000/";
            string endPoint = "api/room/create";
            var client = new ApiClient(API);
            var request = new ApiRequestBuilder();

            string bearerToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9sb2NhbGhvc3Q6ODAwMFwvYXBpXC91c2VyXC9sb2dpbiIsImlhdCI6MTYwNzYwNjQ5MCwiZXhwIjoxNjA3NjEwMDkwLCJuYmYiOjE2MDc2MDY0OTAsImp0aSI6Ik1FRWR1TWU2bVU3Z0lWQkIiLCJzdWIiOjMsInBydiI6IjIzYmQ1Yzg5NDlmNjAwYWRiMzllNzAxYzQwMDg3MmRiN2E1OTc2ZjcifQ.DjNwcrJbhratfEfo6zygB6YsERIolS_xfZ8xw5gnrQE";

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