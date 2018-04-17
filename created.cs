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
                request.AddQueryParameter("status",status); // Array geldiginde sorun!!!!!!
                return _restClient.Execute<List<Pet>>(request).Data;
            }

            // Finds Pets by tags
            public List<Pet> findPetsByTags(string[] tags){ 
                var request = new RestRequest(Method.GET); 
                request.Resource = "/pet/findByTags";
                request.AddHeader("Accept", "application/json");
                request.AddQueryParameter("tags",tags); // Array geldiginde sorun!!!!!!
                return _restClient.Execute<List<Pet>>(request).Data;
            }

            // Find pet by ID
            public Pet getPetById(long petId){ 
                var request = new RestRequest(Method.GET); 
                request.Resource = "/pet/{petId}";
                request.AddHeader("Accept", "application/json");
                request.AddParameter("petId",petId);
                return _restClient.Execute<Pet>(request).Data;
            }

            // Updates a pet in the store with form data
            public void updatePetWithForm(long petId, string name, string status){ 
                var request = new RestRequest(Method.POST); 
                request.Resource = "/pet/{petId}";
                request.AddHeader("Accept", "application/json");
                request.AddParameter("petId",petId);
                request.AddParameter("name",name);//????????
                request.AddParameter("status",status);//????????
                
            }

            // Deletes a pet
            public void deletePet(string api_key, long petId){ 
                var request = new RestRequest(Method.DELETE); 
                request.Resource = "/pet/{petId}";
                request.AddHeader("Accept", "application/json");
                request.AddHeader("api_key",api_key);
                request.AddParameter("petId",petId);
                
            }

            // uploads an image
            public ApiResponse uploadFile(long petId, string additionalMetadata, File file){ 
                var request = new RestRequest(Method.POST); 
                request.Resource = "/pet/{petId}/uploadImage";
                request.AddHeader("Accept", "application/json");
                request.AddParameter("petId",petId);
                request.AddParameter("additionalMetadata",additionalMetadata);//????????
                request.AddParameter("file",file);//????????
                return _restClient.Execute<ApiResponse>(request).Data;
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
                return _restClient.Execute<Order>(request).Data;
            }

            // Find purchase order by ID
            public Order getOrderById(long orderId){ 
                var request = new RestRequest(Method.GET); 
                request.Resource = "/store/order/{orderId}";
                request.AddHeader("Accept", "application/json");
                request.AddParameter("orderId",orderId);
                return _restClient.Execute<Order>(request).Data;
            }

            // Delete purchase order by ID
            public void deleteOrder(long orderId){ 
                var request = new RestRequest(Method.DELETE); 
                request.Resource = "/store/order/{orderId}";
                request.AddHeader("Accept", "application/json");
                request.AddParameter("orderId",orderId);
                
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
                request.AddQueryParameter("username",username); // Array geldiginde sorun!!!!!!
                request.AddQueryParameter("password",password); // Array geldiginde sorun!!!!!!
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
                request.AddParameter("username",username);
                return _restClient.Execute<User>(request).Data;
            }

            // Updated user
            public void updateUser(string username, User user){ 
                var request = new RestRequest(Method.PUT); 
                request.Resource = "/user/{username}";
                request.AddHeader("Accept", "application/json");
                request.AddParameter("username",username);
                request.AddBody(user);
                
            }

            // Delete user
            public void deleteUser(string username){ 
                var request = new RestRequest(Method.DELETE); 
                request.Resource = "/user/{username}";
                request.AddHeader("Accept", "application/json");
                request.AddParameter("username",username);
                
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


