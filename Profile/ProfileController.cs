﻿using Hotelin_Desktop.Model;
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
                .setEndpoint(MyURL.MyURL.profileHotelURL)
                .setRequestMethod(HttpMethod.Get);
            client.setAuthorizationToken(token);
            client.setOnSuccessRequest(setItem);
            var response = await client.sendRequest(request.getApiRequestBundle());
        }

        private void setItem(HttpResponseBundle _response)
        {
            HotelProfile hotel = _response.getParsedObject<HotelProfile>();
            if (hotel.error != true)
            {
                string status = _response.getHttpResponseMessage().ReasonPhrase;
                if(!_response.getJObject().ContainsKey("error")){
                    getView().callMethod("setProfile", _response.getParsedObject<HotelProfile>());
                }
            }
            else {
                getView().callMethod("redirectToAddHotel");
            }
        }
    }
}
