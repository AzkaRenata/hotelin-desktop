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
        public RoomFacilityController(IMyView _myView) : base(_myView)
        {
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
        }

        public async void saveRoomFacility(int room_id, List<string> selectedId, List<string> desc)
        {
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

            req.setEndpoint(MyURL.MyURL.addFacilitiesURL + room_id)
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
