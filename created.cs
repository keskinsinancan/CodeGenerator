using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using RestSharp;
using Newtonsoft.Json;
using RestClient.Models;

// -------------------------------- //
// IMPORTANT!!!!!!                  //
// Import RestSharp from NUGET!!!   //
// Import Newtonsoft from NUGET!!!  //
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

            // Add a new pet to the store
            public void addPet(Pet pet){ 
                var request = new RestRequest(Method.POST); 
                request.Resource = "/pet";
                request.AddHeader("Accept", "application/json");
                request.AddBody(pet);
                
            }

            // Update an existing pet
            public void updatePet(Pet pet){ 
                var request = new RestRequest(Method.PUT); 
                request.Resource = "/pet";
                request.AddHeader("Accept", "application/json");
                request.AddBody(pet);
                
            }

            // Finds Pets by status
            public List<Pet> findPetsByStatus(string[] status){ 
                var request = new RestRequest(Method.GET); 
                request.Resource = "/pet/findByStatus";
                request.AddHeader("Accept", "application/json");
                foreach( var p in status){ request.AddQueryParameter("status", p);  } 
                return JsonConvert.DeserializeObject<List<Pet>>(_restClient.Execute(request).Content);
            }

            // Finds Pets by tags
            public List<Pet> findPetsByTags(string[] tags){ 
                var request = new RestRequest(Method.GET); 
                request.Resource = "/pet/findByTags";
                request.AddHeader("Accept", "application/json");
                foreach( var p in tags){ request.AddQueryParameter("tags", p);  } 
                return JsonConvert.DeserializeObject<List<Pet>>(_restClient.Execute(request).Content);
            }

            // Find pet by ID
            public Pet getPetById(long petId){ 
                var request = new RestRequest(Method.GET); 
                request.Resource = "/pet/{petId}";
                request.AddHeader("Accept", "application/json");
                request.AddUrlSegment("petId",petId);
                return JsonConvert.DeserializeObject<Pet>(_restClient.Execute(request).Content);
            }

            // Updates a pet in the store with form data
            public void updatePetWithForm(long petId, string name = null, string status = null){ 
                var request = new RestRequest(Method.POST); 
                request.Resource = "/pet/{petId}";
                request.AddHeader("Accept", "application/json");
                request.AddUrlSegment("petId",petId);
                if(name != null) { request.AddParameter("name",name); }
                if(status != null) { request.AddParameter("status",status); }
                
            }

            // Deletes a pet
            public void deletePet(long petId, string api_key = null){ 
                var request = new RestRequest(Method.DELETE); 
                request.Resource = "/pet/{petId}";
                request.AddHeader("Accept", "application/json");
                if(api_key != null) { request.AddHeader("api_key",api_key); }
                request.AddUrlSegment("petId",petId);
                
            }

            // uploads an image
            public ApiResponse uploadFile(long petId, string additionalMetadata = null, File file = null){ 
                var request = new RestRequest(Method.POST); 
                request.Resource = "/pet/{petId}/uploadImage";
                request.AddHeader("Accept", "application/json");
                request.AddUrlSegment("petId",petId);
                if(additionalMetadata != null) { request.AddParameter("additionalMetadata",additionalMetadata); }
                if(file != null) { request.AddParameter("file",file); }
                return JsonConvert.DeserializeObject<ApiResponse>(_restClient.Execute(request).Content);
            }

        }
        public class storeRestClient{
            private readonly RestSharp.RestClient _restClient;

            public storeRestClient()
            {
                this._restClient = new RestSharp.RestClient("http://petstore.swagger.io/v2");
            }

            // Returns pet inventories by status
            public Object getInventory(){ 
                var request = new RestRequest(Method.GET); 
                request.Resource = "/store/inventory";
                request.AddHeader("Accept", "application/json");
                return _restClient.Execute(request).Content;
            }

            // Place an order for a pet
            public Order placeOrder(Order order){ 
                var request = new RestRequest(Method.POST); 
                request.Resource = "/store/order";
                request.AddHeader("Accept", "application/json");
                request.AddBody(order);
                return JsonConvert.DeserializeObject<Order>(_restClient.Execute(request).Content);
            }

            // Find purchase order by ID
            public Order getOrderById(long orderId){ 
                var request = new RestRequest(Method.GET); 
                request.Resource = "/store/order/{orderId}";
                request.AddHeader("Accept", "application/json");
                request.AddUrlSegment("orderId",orderId);
                return JsonConvert.DeserializeObject<Order>(_restClient.Execute(request).Content);
            }

            // Delete purchase order by ID
            public void deleteOrder(long orderId){ 
                var request = new RestRequest(Method.DELETE); 
                request.Resource = "/store/order/{orderId}";
                request.AddHeader("Accept", "application/json");
                request.AddUrlSegment("orderId",orderId);
                
            }

        }
        public class userRestClient{
            private readonly RestSharp.RestClient _restClient;

            public userRestClient()
            {
                this._restClient = new RestSharp.RestClient("http://petstore.swagger.io/v2");
            }

            // Create user
            public void createUser(User user){ 
                var request = new RestRequest(Method.POST); 
                request.Resource = "/user";
                request.AddHeader("Accept", "application/json");
                request.AddBody(user);
                
            }

            // Creates list of users with given input array
            public void createUsersWithArrayInput(User[] user){ 
                var request = new RestRequest(Method.POST); 
                request.Resource = "/user/createWithArray";
                request.AddHeader("Accept", "application/json");
                request.AddBody(user);
                
            }

            // Creates list of users with given input array
            public void createUsersWithListInput(User[] user){ 
                var request = new RestRequest(Method.POST); 
                request.Resource = "/user/createWithList";
                request.AddHeader("Accept", "application/json");
                request.AddBody(user);
                
            }

            // Logs user into the system
            public string loginUser(string username, string password){ 
                var request = new RestRequest(Method.GET); 
                request.Resource = "/user/login";
                request.AddHeader("Accept", "application/json");
                request.AddQueryParameter("username",username);
                request.AddQueryParameter("password",password);
                return _restClient.Execute(request).Content;
            }

            // Logs out current logged in user session
            public void logoutUser(){ 
                var request = new RestRequest(Method.GET); 
                request.Resource = "/user/logout";
                request.AddHeader("Accept", "application/json");
                
            }

            // Get user by user name
            public User getUserByName(string username){ 
                var request = new RestRequest(Method.GET); 
                request.Resource = "/user/{username}";
                request.AddHeader("Accept", "application/json");
                request.AddUrlSegment("username",username);
                return JsonConvert.DeserializeObject<User>(_restClient.Execute(request).Content);
            }

            // Updated user
            public void updateUser(string username, User user){ 
                var request = new RestRequest(Method.PUT); 
                request.Resource = "/user/{username}";
                request.AddHeader("Accept", "application/json");
                request.AddUrlSegment("username",username);
                request.AddBody(user);
                
            }

            // Delete user
            public void deleteUser(string username){ 
                var request = new RestRequest(Method.DELETE); 
                request.Resource = "/user/{username}";
                request.AddHeader("Accept", "application/json");
                request.AddUrlSegment("username",username);
                
            }

        }
    }

    namespace Models{
        public class Order{

            public Order() {

            }

            public long id { get; set; }

            public long petId { get; set; }

            public int quantity { get; set; }

            public DateTime shipDate { get; set; }

            public string status { get; set; }

            public bool complete { get; set; }

           
        }

        public class User{

            public User() {

            }

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

            public Category() {

            }

            public long id { get; set; }

            public string name { get; set; }

           
        }

        public class Tag{

            public Tag() {

            }

            public long id { get; set; }

            public string name { get; set; }

           
        }

        public class Pet{

            public Pet() {

            }

            public long id { get; set; }

            public Category category { get; set; }

            public string name { get; set; }

            public string[] photoUrls { get; set; }

            public Tag[] tags { get; set; }

            public string status { get; set; }

           
        }

        public class ApiResponse{

            public ApiResponse() {

            }

            public int code { get; set; }

            public string type { get; set; }

            public string message { get; set; }

           
        }

    }

}


