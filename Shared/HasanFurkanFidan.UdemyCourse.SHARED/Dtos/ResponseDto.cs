using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.SHARED.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public List<string> Errors { get; set; }
        public static ResponseDto<T> Success(T data, int statusCode)
        {
            return new ResponseDto<T>
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccessful = true
            };
        }
        public static ResponseDto<T> Success(int statusCode,bool isSuccessful)
        {
            return new ResponseDto<T>
            {
                Data = default(T),
                StatusCode = statusCode,
                IsSuccessful = true
            };
        }
        public static ResponseDto<T>Fail(List<string>errors,int statusCode)
        {
            return new ResponseDto<T>
            {
                Errors = errors,
                IsSuccessful = false,
                StatusCode = statusCode
            };
        }
        public static ResponseDto<T>Fail(string error,int statusCode)
        {
            return new ResponseDto<T>
            {
                Errors = new List<string> { error },
                IsSuccessful = false,
                StatusCode = statusCode
            };
        }
    }
}
