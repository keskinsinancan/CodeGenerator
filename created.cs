using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

// -------------------------------- //
// IMPORTANT!!!!!!                  //
// Import RestSharp from NUGET!!!   //
// -------------------------------- //

namespace RestClient
{
    public class petRestClient{
        private readonly RestSharp.RestClient _restClient;

        public petRestClient(){
            this._restClient = new RestSharp.RestClient("http://petstore.swagger.io/v2");
        }

        public void addPet(Pet pet){
            var request = new RestRequest(Method.POST);
            request.Resource = "/pet";
            request.AddHeader("Accept", "application/json");
            request.AddBody(pet); //Body parameter

        }

        public void updatePet(Pet pet){
            var request = new RestRequest(Method.PUT);
            request.Resource = "/pet";
            request.AddHeader("Accept", "application/json");
            request.AddBody(pet); //Body parameter

        }

        public List<Pet> findPetsByStatus(string[] status){
            var request = new RestRequest(Method.GET);
            request.Resource = "/pet/findByStatus";
            request.AddHeader("Accept", "application/json");
            foreach(var parameter in status){
                request.AddQueryParameter("status",parameter); //Query parameter
            }

            return _restClient.Execute<List<Pet>>(request);
        }

        public List<Pet> findPetsByTags(string[] tags){
            var request = new RestRequest(Method.GET);
            request.Resource = "/pet/findByTags";
            request.AddHeader("Accept", "application/json");
            foreach(var parameter in tags){
                request.AddQueryParameter("tags",parameter); //Query parameter
            }

            return _restClient.Execute<List<Pet>>(request);
        }

        public Pet getPetById(Int64 petId){
            var request = new RestRequest(Method.GET);
            request.Resource = "/pet/{petId}";
            request.AddHeader("Accept", "application/json");
            request.AddParameter("petId",petId,ParameterType.UrlSegment); //Path parameter

            return _restClient.Execute<Pet>(request);
        }

        public void updatePetWithForm(Int64 petId, string? name, string? status){
            var request = new RestRequest(Method.POST);
            request.Resource = "/pet/{petId}";
            request.AddHeader("Accept", "application/json");
            request.AddParameter("petId",petId,ParameterType.UrlSegment); //Path parameter

        }

        public void deletePet(string? api_key, Int64 petId){
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/pet/{petId}";
            request.AddHeader("Accept", "application/json");
            request.AddParameter("petId",petId,ParameterType.UrlSegment); //Path parameter

        }

        public ApiResponse uploadFile(Int64 petId, string? additionalMetadata, file? file){
            var request = new RestRequest(Method.POST);
            request.Resource = "/pet/{petId}/uploadImage";
            request.AddHeader("Accept", "application/json");
            request.AddParameter("petId",petId,ParameterType.UrlSegment); //Path parameter

            return _restClient.Execute<ApiResponse>(request);
        }
    }

    public class storeRestClient{
        private readonly RestSharp.RestClient _restClient;

        public storeRestClient(){
            this._restClient = new RestSharp.RestClient("http://petstore.swagger.io/v2");
        }

        public Object getInventory(){
            var request = new RestRequest(Method.GET);
            request.Resource = "/store/inventory";
            request.AddHeader("Accept", "application/json");

            return _restClient.Execute<Object>(request);
        }

        public Order placeOrder(Order order){
            var request = new RestRequest(Method.POST);
            request.Resource = "/store/order";
            request.AddHeader("Accept", "application/json");
            request.AddBody(order); //Body parameter

            return _restClient.Execute<Order>(request);
        }

        public Order getOrderById(Int64 orderId){
            var request = new RestRequest(Method.GET);
            request.Resource = "/store/order/{orderId}";
            request.AddHeader("Accept", "application/json");
            request.AddParameter("orderId",orderId,ParameterType.UrlSegment); //Path parameter

            return _restClient.Execute<Order>(request);
        }

        public void deleteOrder(Int64 orderId){
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/store/order/{orderId}";
            request.AddHeader("Accept", "application/json");
            request.AddParameter("orderId",orderId,ParameterType.UrlSegment); //Path parameter

        }
    }

    public class userRestClient{
        private readonly RestSharp.RestClient _restClient;

        public userRestClient(){
            this._restClient = new RestSharp.RestClient("http://petstore.swagger.io/v2");
        }

        public void createUser(User user){
            var request = new RestRequest(Method.POST);
            request.Resource = "/user";
            request.AddHeader("Accept", "application/json");
            request.AddBody(user); //Body parameter

        }

        public void createUsersWithArrayInput(User[] users){
            var request = new RestRequest(Method.POST);
            request.Resource = "/user/createWithArray";
            request.AddHeader("Accept", "application/json");
            request.AddBody(undefined); //Body parameter

        }

        public void createUsersWithListInput(User[] users){
            var request = new RestRequest(Method.POST);
            request.Resource = "/user/createWithList";
            request.AddHeader("Accept", "application/json");
            request.AddBody(undefined); //Body parameter

        }

        public string loginUser(string username, string password){
            var request = new RestRequest(Method.GET);
            request.Resource = "/user/login";
            request.AddHeader("Accept", "application/json");
            request.AddQueryParameter("username",parameter); //Query parameter
            request.AddQueryParameter("password",parameter); //Query parameter

            return _restClient.Execute<string>(request);
        }

        public void logoutUser(){
            var request = new RestRequest(Method.GET);
            request.Resource = "/user/logout";
            request.AddHeader("Accept", "application/json");

        }

        public User getUserByName(string username){
            var request = new RestRequest(Method.GET);
            request.Resource = "/user/{username}";
            request.AddHeader("Accept", "application/json");
            request.AddParameter("username",username,ParameterType.UrlSegment); //Path parameter

            return _restClient.Execute<User>(request);
        }

        public void updateUser(string username, User user){
            var request = new RestRequest(Method.PUT);
            request.Resource = "/user/{username}";
            request.AddHeader("Accept", "application/json");
            request.AddParameter("username",username,ParameterType.UrlSegment); //Path parameter
            request.AddBody(user); //Body parameter

        }

        public void deleteUser(string username){
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/user/{username}";
            request.AddHeader("Accept", "application/json");
            request.AddParameter("username",username,ParameterType.UrlSegment); //Path parameter

        }
    }
}