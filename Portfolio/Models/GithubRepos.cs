﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using RestSharp.Authenticators;


namespace Portfolio.Models
{
    public class GithubRepos
    {
        public string Name { get; set; }
        public string Html_Url { get; set; }
        public string Description { get; set; }


        public static List<GithubRepos> GetStarredRepos()
        {

            var client = new RestClient("https://api.github.com");           
            var request = new RestRequest("users/rpgandhi/starred", Method.GET);       
            //var request = new RestRequest("/search/users?q=rpgandhi&sort=stars&order=asc", Method.GET);   
            //var request = new RestRequest("/search/repositories", Method.GET); 

            request.AddHeader("Accept", "application/vnd.github.v3.full+json");
            request.AddHeader("User-Agent", "");           
            //request.AddParameter("order", "asc");
            //request.AddParameter("q", "user:rpgandi");    
            //request.AddParameter("sort", "stars");
            request.AddParameter("order", "asc");                 


            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            List<GithubRepos> projectList = JsonConvert.DeserializeObject<List<GithubRepos>>(jsonResponse.ToString());
            Console.WriteLine("#################" + projectList);
            List<GithubRepos> top3Repos = projectList.Take(3).ToList();
            return top3Repos;     
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            TaskCompletionSource<IRestResponse> tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}

         
 