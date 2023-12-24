using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Models;
using Newtonsoft.Json;
using System.Security.Claims;
using TutorPins_Client.Extensions;

namespace TutorPins_Client.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage) 
        { 
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSession = await _sessionStorage.ReadEncryptedItemAsync<UserSession>("UserSession");
                if(userSession == null) 
                {
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                }
                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name,userSession.UserName),
                    new Claim(ClaimTypes.Role,userSession.Role)
                }, "JwtAuth"));
                return await Task.FromResult(new AuthenticationState(claimsPrincipal)); 
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }
        public async Task UpdateAuthenticationState(Task<UserSession> userSession)
        {
            
            ClaimsPrincipal claimsPrincipal;
            if(userSession != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    //new Claim(ClaimTypes.PrimarySid,userSession.Result.UserId),
                    new Claim(ClaimTypes.Name,userSession.Result.UserName),
                    new Claim(ClaimTypes.Role, userSession.Result.Role)

                }));
                userSession.Result.ExpiryTimeStamp = DateTime.Now.AddSeconds(userSession.Result.ExpiresIn);
                string json = JsonConvert.SerializeObject(userSession.Result);
                await _sessionStorage.SetItemAsync<string>("userinfo", json);
               // await _sessionStorage.SaveItemEncryptedAsync("UserSession", Task.FromResult(userSession.Result));
                
            }
            else
            {
                claimsPrincipal = _anonymous;
                await _sessionStorage.RemoveItemAsync("UserSession");
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));    
        }
        public async Task<string> GetToken()
        {
            var result = string.Empty;
            try
            {
                var userSession = await _sessionStorage.ReadEncryptedItemAsync<UserSession>("UserSession");
                if (userSession != null && DateTime.Now < userSession.ExpiryTimeStamp)
                    result = userSession.Token;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public async Task<UserSession> GetSessionUser()
        {
            var result = string.Empty;
            try
            {
                string json = await _sessionStorage.GetItemAsync<string>("userinfo");                
               
                UserSession myCustomObject = JsonConvert.DeserializeObject<UserSession>(json);
                //var userSession = await _sessionStorage.ReadEncryptedItemAsync<UserSession>("UserSession");
                if (myCustomObject != null && DateTime.Now < myCustomObject.ExpiryTimeStamp)
                    return myCustomObject;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
