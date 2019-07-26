using Firebase.Database;
using Firebase.Database.Query;
using R.FirebaseDatabase;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R.Helpers
{
    public class FirebaseHelper
    {
        private readonly FirebaseClient firebase = new FirebaseClient(UserSettings.FirebaseDB);
        public async Task<List<Room>> GetAllRooms()
        {
            var allRooms=(await firebase
              .Child("Rooms")
              .OnceAsync<Room>()).Select(item => new Room
              {
                  RoomName = item.Object.RoomName,
                  RoomId = item.Object.RoomId
              }).ToList();
            return allRooms;
        }
        public async Task<FirebaseObject<Room>> AddRoom(int roomId, string roomName)
        {
            var room= await firebase
              .Child("Rooms")
              .PostAsync(new Room() { RoomId = roomId, RoomName = roomName });
            return room;
        }
        public async Task<Room> GetRoom(int roomId)
        {
            var allRooms = await GetAllRooms();
            await firebase
              .Child("Rooms")
              .OnceAsync<Room>();
            var room= allRooms.Where(a => a.RoomId == roomId).FirstOrDefault();
            return room;
        }
        public async Task UpdateRoom(int roomId, string roomName)
        {
            var toUpdateRoom = (await firebase
              .Child("Rooms")
              .OnceAsync<Room>()).Where(a => a.Object.RoomId == roomId).FirstOrDefault();

            await firebase
              .Child("Rooms")
              .Child(toUpdateRoom.Key)
              .PutAsync(new Room() { RoomId = roomId, RoomName = roomName });
        }
        public async Task DeleteRoom(int roomId)
        {
            var toDeleteRoom = (await firebase
              .Child("Rooms")
              .OnceAsync<Room>()).Where(a => a.Object.RoomId == roomId).FirstOrDefault();
            await firebase.Child("Rooms").Child(toDeleteRoom.Key).DeleteAsync();

        }
    }
}

