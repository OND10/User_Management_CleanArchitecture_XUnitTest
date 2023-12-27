using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement_Application.Utly
{
    public class Response : IResponse
    {
        public string Status { get; set; }=string.Empty;
        public string Message { get; set; } = null!;
        public bool IsSuccess { get; set; }


        public static IResponse Success()
        {
            return new Response { IsSuccess = true };
        }

        public static async Task<IResponse> SuccessAsync()
        {
            return await Task.FromResult<Response>(new Response { IsSuccess = true });
;        }


    }

    public class Response<T> : IResponse<T>
    {

        public string Status { get; set; } = string.Empty;
        public string Message { get; set; } = null!;

        public bool IsSuccess { get; set; }

        public T Data { get; set; }=default!;

        public static Response<T> Fail()
        {
            return new Response<T> { IsSuccess = false };
        }

        public static Response<T> Fail(string Message)
        {
            return new Response<T> { IsSuccess = false, Message = Message };
        }

        //public static Response<T> Success()
        //{
        //    return new Response<T> { Successed = true };
        //}
        //public static Response<T> Success(string Message)
        //{
        //    return new Response<T> { Successed = true, Message = Message };
        //}

        public static Response<T> Success(T Data)
        {
            return new Response<T> { IsSuccess = true, Data=Data };
        }

        public static Response<T> Success(T data, string Message)
        {
            return new Response<T> { Data = data, Message = Message, IsSuccess = true };
        }
        public static async Task<Response<T>> SuccessAsync(T data)
        {
            var result = await Task.FromResult<Response<T>>(new Response<T> { IsSuccess=true,Data=data});
            return result;
        }
        public static async Task<Response<T>> SuccessAsync(T data, string Message)
        {
            var result = await Task.FromResult<Response<T>>(new Response<T> { IsSuccess = true, Data = data,Message=Message});
            return result;
        }

    }
}
