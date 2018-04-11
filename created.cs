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

            var response = _restClient.Execute(request);
        }

        public void updatePet(Pet pet){
            var request = new RestRequest(Method.PUT);
            request.Resource = "/pet";
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void findPetsByStatus(string[] status){
            var request = new RestRequest(Method.GET);
            request.Resource = "/pet/findByStatus";
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void findPetsByTags(string[] tags){
            var request = new RestRequest(Method.GET);
            request.Resource = "/pet/findByTags";
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void getPetById(Int64 petId){
            var request = new RestRequest(Method.GET);
            request.Resource = "/pet/{petId}";
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void updatePetWithForm(Int64 petId, string? name, string? status){
            var request = new RestRequest(Method.POST);
            request.Resource = "/pet/{petId}";
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void deletePet(string? api_key, Int64 petId){
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/pet/{petId}";
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void uploadFile(Int64 petId, string? additionalMetadata, file? file){
            var request = new RestRequest(Method.POST);
            request.Resource = "/pet/{petId}/uploadImage";
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }
    }

    public class storeRestClient{
        private readonly RestSharp.RestClient _restClient;

        public storeRestClient(){
            this._restClient = new RestSharp.RestClient("http://petstore.swagger.io/v2");
        }

        public void getInventory(){
            var request = new RestRequest(Method.GET);
            request.Resource = "/store/inventory";
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void placeOrder(Order order){
            var request = new RestRequest(Method.POST);
            request.Resource = "/store/order";
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void getOrderById(Int64 orderId){
            var request = new RestRequest(Method.GET);
            request.Resource = "/store/order/{orderId}";
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void deleteOrder(Int64 orderId){
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/store/order/{orderId}";
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
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

            var response = _restClient.Execute(request);
        }

        public void createUsersWithArrayInput(undefined undefined){
            var request = new RestRequest(Method.POST);
            request.Resource = "/user/createWithArray";
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void createUsersWithListInput(undefined undefined){
            var request = new RestRequest(Method.POST);
            request.Resource = "/user/createWithList";
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void loginUser(string username, string password){
            var request = new RestRequest(Method.GET);
            request.Resource = "/user/login";
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void logoutUser(){
            var request = new RestRequest(Method.GET);
            request.Resource = "/user/logout";
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void getUserByName(string username){
            var request = new RestRequest(Method.GET);
            request.Resource = "/user/{username}";
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void updateUser(string username, User user){
            var request = new RestRequest(Method.PUT);
            request.Resource = "/user/{username}";
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void deleteUser(string username){
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/user/{username}";
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }
    }
}