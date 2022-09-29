using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Service.Clients
{
    public class UserApiService
    {
        private readonly HttpClient _httpClient;

        public UserApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<UserDto> CreateUserAsync(UserDto newUserDto)
        {
            var response = await _httpClient.PostAsJsonAsync("users", newUserDto);
            if (!response.IsSuccessStatusCode) return null;
                
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<UserDto>>();
            return responseBody.Data;
            
        }
        public async Task<UserDto> GetUser()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<UserDto>>("users/GetUser");
            return response.Data;
        } 

    }
}
