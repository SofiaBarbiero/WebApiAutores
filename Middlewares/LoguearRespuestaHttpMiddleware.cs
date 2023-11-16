﻿namespace WebAppAutores.Middlewares
{
    public class LoguearRespuestaHttpMiddleware
    {
        private readonly RequestDelegate siguiente;
        private readonly ILogger<LoguearRespuestaHttpMiddleware> logger;

        public LoguearRespuestaHttpMiddleware(RequestDelegate siguiente, 
            ILogger<LoguearRespuestaHttpMiddleware> logger)
        {
            this.siguiente = siguiente;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext contexto)
        {
            using(var ms = new MemoryStream())
            {
                var cuerpoOriginalRta = contexto.Response.Body;
                contexto.Response.Body = ms;

                await siguiente(contexto);
            }
        }
    }
}
