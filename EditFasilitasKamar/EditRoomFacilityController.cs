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

namespace Hotelin_Desktop.EditFasilitasKamar
{
    class RoomFacilityController : MyController
    {
        private string bearerToken = File.ReadAllText(@"userToken.txt");
        private int room_id;
        public RoomFacilityController(IMyView _myView, int room_id) : base(_myView)
        {
            this.room_id = room_id;
            setCurrentFacility();
        }

        public async void setCurrentFacility()
        {
            var client = new ApiClient(MyURL.MyURL.baseURL);
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .addHeaders("Accept", "application/json")
                .setEndpoint("room-facility/list/" + room_id)
                .setRequestMethod(HttpMethod.Get);
            client.setAuthorizationToken(bearerToken);
            client.setOnSuccessRequest(setViewSetFacilityStatus);
            var response = await client.sendRequest(request.getApiRequestBundle());

            // Console.WriteLine("tes : " + response.getHttpResponseMessage().StatusCode);
            // Console.WriteLine("Tes : " + response.getHttpResponseMessage().ToString());
            // Console.WriteLine("tes3 : " + response.getHttpResponseMessage().Headers);
        }

        public async void saveRoomFacility(List<string> selectedId, List<string> desc)
        {
            string endPoint = "room-facility/update-many/" + room_id;
            var client = new ApiClient(MyURL.MyURL.baseURL);
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .addHeaders("Accept", "application/json");
            int i = 0;
            foreach (string id in selectedId)
            {
                req.addParameters("facility" + id, id);
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
                getView().callMethod("setFacility", _response.getParsedObject<List<RoomFacilityModel>>());
            }
        }

        public void setSaveRoomFacilityStatus(HttpResponseBundle _response)
        {

        }
    }
}
