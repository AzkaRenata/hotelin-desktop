using Hotelin_Desktop.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Velacro.Api;
using Velacro.Basic;

namespace Hotelin_Desktop.FasilitasKamar
{
    class RoomFacilityController : MyController
    {
        private string bearerToken = File.ReadAllText(@"userToken.txt");
        public RoomFacilityController(IMyView _myView) : base(_myView) {
            //getFacility();
        }

        public async void getFacility()
        {
            var client = new ApiClient(MyURL.MyURL.baseURL);
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .addHeaders("Accept", "application/json")
                .setEndpoint("facility-category")
                .setRequestMethod(HttpMethod.Get);
            client.setAuthorizationToken(bearerToken);
            client.setOnSuccessRequest(setViewSetFacilityStatus);
            var response = await client.sendRequest(request.getApiRequestBundle());

            // Console.WriteLine("tes : " + response.getHttpResponseMessage().StatusCode);
            // Console.WriteLine("Tes : " + response.getHttpResponseMessage().ToString());
            // Console.WriteLine("tes3 : " + response.getHttpResponseMessage().Headers);
        }

        public async void saveRoomFacility(int room_id, List<string> selectedId, List<string> desc)
        {
            string endPoint = "room-facility/create-many/"+room_id;
            var client = new ApiClient(MyURL.MyURL.baseURL);
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .addHeaders("Accept", "application/json");
            int i = 0;
            foreach(string id in selectedId)
            {
                req.addParameters("facility"+id, id );
                req.addParameters("desc" + id, desc[i]);
                i++;
            }
                
            req.setEndpoint(endPoint)
            .setRequestMethod(HttpMethod.Post);
            
            client.setAuthorizationToken(bearerToken);
            client.setOnSuccessRequest(setSaveRoomFacilityStatus);
            var response = await client.sendRequest(request.getApiRequestBundle());
        }

        private void setViewSetFacilityStatus(HttpResponseBundle _response)
        {
            if (_response.getHttpResponseMessage().Content != null)
            {
                getView().callMethod("setFacility", _response.getParsedObject<List<FacilityCategory>>());
            }
        }

        public void setSaveRoomFacilityStatus(HttpResponseBundle _response)
        {

        }
    }
}
