using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

// -------------------------------- //
// IMPORTANT!!!!!!                  //
// Import RestSharp from NUGET!!!   //
// -------------------------------- //
    false
    false
    false
    false
    false
    true
    false
    false
    true
    false
    false
    false
    false
    false


namespace RestClient
{
    public class petRestClient{
        private readonly RestSharp.RestClient _restClient;

        public petRestClient(){
            this._restClient = new RestSharp.RestClient("http://petstore.swagger.io/v2");
        }

        public void addPet(){
            var request = new RestRequest("/pet", Method.POST);
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void updatePet(){
            var request = new RestRequest("/pet", Method.PUT);
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void findPetsByStatus(){
            var request = new RestRequest("/pet/findByStatus", Method.GET);
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void findPetsByTags(){
            var request = new RestRequest("/pet/findByTags", Method.GET);
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void getPetById(){
            var request = new RestRequest("/pet/{petId}", Method.GET);
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void updatePetWithForm(){
            var request = new RestRequest("/pet/{petId}", Method.POST);
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void deletePet(){
            var request = new RestRequest("/pet/{petId}", Method.DELETE);
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void uploadFile(){
            var request = new RestRequest("/pet/{petId}/uploadImage", Method.POST);
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }
    } true -- /store/inventory
    
    public class storeRestClient{
        private readonly RestSharp.RestClient _restClient;

        public storeRestClient(){
            this._restClient = new RestSharp.RestClient("http://petstore.swagger.io/v2");
        }

        public void getInventory(){
            var request = new RestRequest("/store/inventory", Method.GET);
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void placeOrder(){
            var request = new RestRequest("/store/order", Method.POST);
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void getOrderById(){
            var request = new RestRequest("/store/order/{orderId}", Method.GET);
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void deleteOrder(){
            var request = new RestRequest("/store/order/{orderId}", Method.DELETE);
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }
    } true -- /user
    
    public class userRestClient{
        private readonly RestSharp.RestClient _restClient;

        public userRestClient(){
            this._restClient = new RestSharp.RestClient("http://petstore.swagger.io/v2");
        }

        public void createUser(){
            var request = new RestRequest("/user", Method.POST);
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void createUsersWithArrayInput(){
            var request = new RestRequest("/user/createWithArray", Method.POST);
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void createUsersWithListInput(){
            var request = new RestRequest("/user/createWithList", Method.POST);
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void loginUser(){
            var request = new RestRequest("/user/login", Method.GET);
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void logoutUser(){
            var request = new RestRequest("/user/logout", Method.GET);
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void getUserByName(){
            var request = new RestRequest("/user/{username}", Method.GET);
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void updateUser(){
            var request = new RestRequest("/user/{username}", Method.PUT);
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }

        public void deleteUser(){
            var request = new RestRequest("/user/{username}", Method.DELETE);
            request.AddHeader("Accept", "application/json");

            var response = _restClient.Execute(request);
        }
    }
}