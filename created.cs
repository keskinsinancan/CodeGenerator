using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using RestSharp;

// -------------------------------- //
// IMPORTANT!!!!!!                  //
// Import RestSharp from NUGET!!!   //
// -------------------------------- //

namespace RestClient
{
    namespace Services{
        public class petRestClient{
            private readonly RestSharp.RestClient _restClient;

            public petRestClient()
            {
                this._restClient = new RestSharp.RestClient("http://petstore.swagger.io/v2");
            }

            public void addPet(Pet body){ 
                var request = new RestRequest(Method.POST); 
                request.Resource = "/pet";
                request.AddHeader("Accept", "application/json");

            }

            public void updatePet(Pet body){ 
                var request = new RestRequest(Method.PUT); 
                request.Resource = "/pet";
                request.AddHeader("Accept", "application/json");

            }

            public void findPetsByStatus(string[] status){ 
                var request = new RestRequest(Method.GET); 
                request.Resource = "/pet/findByStatus";
                request.AddHeader("Accept", "application/json");

            }

            public void findPetsByTags(string[] tags){ 
                var request = new RestRequest(Method.GET); 
                request.Resource = "/pet/findByTags";
                request.AddHeader("Accept", "application/json");

            }

            public void getPetById(long petId){ 
                var request = new RestRequest(Method.GET); 
                request.Resource = "/pet/{petId}";
                request.AddHeader("Accept", "application/json");

            }

            public void updatePetWithForm(long petId, string name, string status){ 
                var request = new RestRequest(Method.POST); 
                request.Resource = "/pet/{petId}";
                request.AddHeader("Accept", "application/json");

            }

            public void deletePet(string api_key, long petId){ 
                var request = new RestRequest(Method.DELETE); 
                request.Resource = "/pet/{petId}";
                request.AddHeader("Accept", "application/json");

            }

            public void uploadFile(long petId, string additionalMetadata, File file){ 
                var request = new RestRequest(Method.POST); 
                request.Resource = "/pet/{petId}/uploadImage";
                request.AddHeader("Accept", "application/json");

            }

        }
        public class storeRestClient{
            private readonly RestSharp.RestClient _restClient;

            public storeRestClient()
            {
                this._restClient = new RestSharp.RestClient("http://petstore.swagger.io/v2");
            }

            public void getInventory(){ 
                var request = new RestRequest(Method.GET); 
                request.Resource = "/store/inventory";
                request.AddHeader("Accept", "application/json");

            }

            public void placeOrder(Order body){ 
                var request = new RestRequest(Method.POST); 
                request.Resource = "/store/order";
                request.AddHeader("Accept", "application/json");

            }

            public void getOrderById(long orderId){ 
                var request = new RestRequest(Method.GET); 
                request.Resource = "/store/order/{orderId}";
                request.AddHeader("Accept", "application/json");

            }

            public void deleteOrder(long orderId){ 
                var request = new RestRequest(Method.DELETE); 
                request.Resource = "/store/order/{orderId}";
                request.AddHeader("Accept", "application/json");

            }

        }
        public class userRestClient{
            private readonly RestSharp.RestClient _restClient;

            public userRestClient()
            {
                this._restClient = new RestSharp.RestClient("http://petstore.swagger.io/v2");
            }

            public void createUser(User body){ 
                var request = new RestRequest(Method.POST); 
                request.Resource = "/user";
                request.AddHeader("Accept", "application/json");

            }

            public void createUsersWithArrayInput(User[] body){ 
                var request = new RestRequest(Method.POST); 
                request.Resource = "/user/createWithArray";
                request.AddHeader("Accept", "application/json");

            }

            public void createUsersWithListInput(User[] body){ 
                var request = new RestRequest(Method.POST); 
                request.Resource = "/user/createWithList";
                request.AddHeader("Accept", "application/json");

            }

            public void loginUser(string username, string password){ 
                var request = new RestRequest(Method.GET); 
                request.Resource = "/user/login";
                request.AddHeader("Accept", "application/json");

            }

            public void logoutUser(){ 
                var request = new RestRequest(Method.GET); 
                request.Resource = "/user/logout";
                request.AddHeader("Accept", "application/json");

            }

            public void getUserByName(string username){ 
                var request = new RestRequest(Method.GET); 
                request.Resource = "/user/{username}";
                request.AddHeader("Accept", "application/json");

            }

            public void updateUser(string username, User body){ 
                var request = new RestRequest(Method.PUT); 
                request.Resource = "/user/{username}";
                request.AddHeader("Accept", "application/json");

            }

            public void deleteUser(string username){ 
                var request = new RestRequest(Method.DELETE); 
                request.Resource = "/user/{username}";
                request.AddHeader("Accept", "application/json");

            }

        }
    }

    namespace Models{
        public class Order{
            public long id { get; set; }

            public long petId { get; set; }

            public int quantity { get; set; }

            public DateTime shipDate { get; set; }

            public string status { get; set; }

            public bool complete { get; set; }

        }

        public class User{
            public long id { get; set; }

            public string username { get; set; }

            public string firstName { get; set; }

            public string lastName { get; set; }

            public string email { get; set; }

            public string password { get; set; }

            public string phone { get; set; }

            public int userStatus { get; set; }

        }

        public class Category{
            public long id { get; set; }

            public string name { get; set; }

        }

        public class Tag{
            public long id { get; set; }

            public string name { get; set; }

        }

        public class Pet{
            public long id { get; set; }

            public Category category { get; set; }

            public string name { get; set; }

            public string[] photoUrls { get; set; }

            public Tag[] tags { get; set; }

            public string status { get; set; }

        }

        public class ApiResponse{
            public int code { get; set; }

            public string type { get; set; }

            public string message { get; set; }

        }

    }

}


