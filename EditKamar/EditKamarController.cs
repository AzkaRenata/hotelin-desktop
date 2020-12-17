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

namespace Hotelin_Desktop.EditKamar
{
    public class EditKamarController : MyController
    {
        private RoomModel currentRoom;
        private string bearerToken = File.ReadAllText(@"userToken.txt"); // BEARER TOKEN GOES HERE

        public EditKamarController(IMyView _myView, int _roomID) : base(_myView) 
        {
            getCurrentRoomDetail(_roomID);
        }

        public async void getCurrentRoomDetail(int _roomID)
        {
            string API = "http://localhost:8000/";
            string endPoint = "api/room/detail/" + _roomID;
            var client = new ApiClient(API);
            var request = new ApiRequestBuilder();

            var req = request
                .buildHttpRequest()
                .addHeaders("Accept", "application/json")
                .setEndpoint(endPoint)
                .setRequestMethod(HttpMethod.Get);
                Console.WriteLine("tes2");
                client.setAuthorizationToken(bearerToken);
                client.setOnSuccessRequest(setViewAddHotelStatus);
                var response = await client.sendRequest(request.getApiRequestBundle());
                Console.WriteLine("tes1");
            //var hotelData = response.getParsedObject<HotelList>().hotels;

            string anotherResponse = await response.getHttpResponseMessage().Content.ReadAsStringAsync();
                

            Console.WriteLine(anotherResponse);

            currentRoom = JsonConvert.DeserializeObject<RoomResponse>(anotherResponse).room;

            // Console.WriteLine(currentRoom.room_type);

            getView().callMethod("setCurrentRoomValue", currentRoom.room_type, currentRoom.bed_type, currentRoom.room_price, currentRoom.guest_capacity);            

            // Console.WriteLine("tes : " + response.getHttpResponseMessage().StatusCode);
            // Console.WriteLine("Tes : " + response.getHttpResponseMessage().ToString());
            // Console.WriteLine("tes3 : " + response.getHttpResponseMessage().Headers);
        }

        public async void updateKamar(
            string _roomType,
            string _bedType,
            long _roomPrice,
            int _guestCapacity
            )
        {
            string API = "http://localhost:8000/";
            string endPoint = "api/room/update/" + currentRoom.id;
            var client = new ApiClient(API);
            var request = new ApiRequestBuilder();

            if (hasUserEdited(_roomType, _bedType, _roomPrice, _guestCapacity) == true) // HANDLING IF USER DID CHANGE SOMETHING
            {
                var req = request
                .buildHttpRequest()
                .addHeaders("Accept", "application/json")
                .addParameters("hotel_id", Convert.ToString(currentRoom.hotel_id))
                .addParameters("room_type", _roomType)
                .addParameters("bed_type", _bedType)
                .addParameters("room_price", Convert.ToString(_roomPrice))
                .addParameters("guest_capacity", Convert.ToString(_guestCapacity))
                .setEndpoint(endPoint)
                .setRequestMethod(HttpMethod.Post);
                Console.WriteLine("tes2");
                client.setAuthorizationToken(bearerToken);
                var response = await client.sendRequest(request.getApiRequestBundle());

                Console.WriteLine("tes1");
                //Console.WriteLine(response.getJObject()["user"]);
                Console.WriteLine("tes : " + response.getHttpResponseMessage().StatusCode);
                Console.WriteLine("Tes : " + response.getHttpResponseMessage().ToString());
                Console.WriteLine("tes3 : " + response.getHttpResponseMessage().Headers);
            }
            else // HANDLING IF USER DIDN'T CHANGE ANYTHING
            {
                Console.WriteLine("Gaada yg diganti om.");
            }
        }

        private Boolean hasUserEdited(
            string _roomType,
            string _bedType,
            long _roomPrice,
            int _guestCapacity
            )
        {
            if (String.Compare(_roomType, currentRoom.room_type) != 0) return true;
            if (String.Compare(_bedType, currentRoom.bed_type) != 0) return true;
            if (_roomPrice - currentRoom.room_price != 0) return true;
            if (_guestCapacity - currentRoom.guest_capacity != 0) return true;

            return false;
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
