using BeautyMakers.API.Helpers;
using BeautyMakers.Services.Exceptions;

namespace BeautyMakers.API.MiddleWares
{
    public class ExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate _next;

        public  ExceptionHandlerMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomException ex)
            {
                context.Response.StatusCode = ex.StatusCode;
                await context.Response.WriteAsJsonAsync(new Response
                {
                    Code = ex.StatusCode,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new Response
                {
                    Code = 500,
                    Message = ex.Message
                });
            }
        }
    }
}
