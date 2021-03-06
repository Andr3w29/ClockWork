﻿using Clockwork.API.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Clockwork.API.Extensions
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IServiceLoggingRepository serviceLoggingRepository)
        {
            var request = await FormatRequest(context.Request);

            if (!string.IsNullOrEmpty(request))
            {
              await  serviceLoggingRepository.Add(new Models.ServiceLogging()
                {
                    CreatedOn = DateTime.UtcNow,
                    Message = request,
                    Type = Enum.LogType.Request,
                    User = "testUser",
                    Domain = context.Request.Host.ToString(),
                    WorkStation = context.Connection.RemoteIpAddress.ToString()
                });
            }
                
            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {

                context.Response.Body = responseBody;

                await _next(context);
                var response = await FormatResponse(context.Response);
                if (!string.IsNullOrEmpty(response))
                {
                  await  serviceLoggingRepository.Add(new Models.ServiceLogging()
                    {
                        CreatedOn = DateTime.UtcNow,
                        Message = response,
                        Type = Enum.LogType.Response,
                        User = "testUser",
                        Domain = context.Request.Host.ToString(),
                        WorkStation = context.Connection.RemoteIpAddress.ToString()
                    });
                }


                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            var body = request.Body;

        
            request.EnableRewind();

           
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

          
            await request.Body.ReadAsync(buffer, 0, buffer.Length);

           
            var bodyAsText = Encoding.UTF8.GetString(buffer);

          
            request.Body = body;

            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
          
            response.Body.Seek(0, SeekOrigin.Begin);

            string text = await new StreamReader(response.Body).ReadToEndAsync();

            response.Body.Seek(0, SeekOrigin.Begin);

         
            return $"{response.StatusCode}: {text}";
        }
    }
}
