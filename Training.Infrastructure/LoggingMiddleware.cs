//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;
//using TrainingProject.tables;

//namespace Training.Infrastructure
//{
//    public class LoggingMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private readonly ILogger _logger;

//        public LoggingMiddleware(RequestDelegate next, ILogger logger)
//        {
//            _next = next;
//            _logger = logger;
//        }

//        public async Task Invoke(HttpContext context, ApplicationContext dbcontext)
//        {
//            if (context != null && context.Request.Path.ToString().ToLower().StartsWith("/api"))
//            {
//                using (var loggableResponseStream = new MemoryStream())
//                {
//                    var originalResponseStream = context.Response.Body;
//                    context.Response.Body = loggableResponseStream;

//                    try
//                    {
//                        var request = await FormatRequest(context.Request);
//                        await _next(context);

//                        var response = await FormatResponse(loggableResponseStream);

//                        loggableResponseStream.Seek(0, SeekOrigin.Begin);

//                        var newLog = new Log
//                        {
//                            Path = HttpUtility.UrlDecode(context.Request.Path + context.Request.QueryString),
//                            UtcTime = DateTime.UtcNow,
//                            Data = request,
//                            Response = response,
//                            StatusCode = context.Response.StatusCode,
//                        };

//                        await loggableResponseStream.CopyToAsync(originalResponseStream);

//                        await dbcontext.Logs.AddAsync(newLog);
//                        dbcontext.SaveChanges();
//                    }
//                    catch (Exception ex)
//                    {
//                        //Здесь можно добавить логирование ошибок
//                        throw;
//                    }
//                    finally
//                    {
//                        context.Response.Body = originalResponseStream;
//                    }
//                }
//            }
//        }

//        private static async Task FormatRequest(HttpRequest request)
//        {
//            request.EnableRewind();
//            string responseBody = new StreamReader(request.Body).ReadToEnd();
//            request.Body.Position = 0;
//            return responseBody;
//        }

//        private static async Task FormatResponse(Stream loggableResponseStream)
//        {
//            loggableResponseStream.Position = 0;
//            var buffer = new byte[loggableResponseStream.Length];

//            await loggableResponseStream.ReadAsync(buffer, 0, buffer.Length);

//            return JsonConvert.SerializeObject(Encoding.UTF8.GetString(buffer));
//        }
//    }
//}