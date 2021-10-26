using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace endpoints
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/headers", async context =>
                {
                    var headers = context.Request.Headers;
                    var headerKeys = context.Request.Headers.Keys;
                    foreach (var key in headerKeys)
                    {
                        await context.Response.WriteAsync($"{key} : {headers[key]}\n");
                    }
                });

                endpoints.MapGet("plural", async context =>
                {
                    string forms = context.Request.Query["forms"];
                    int number = int.Parse(context.Request.Query["number"]);
                    context.Response.Headers.Add("Content-Type", "text/plai; charset=utf-8");
                    await context.Response.WriteAsync($"Your plural: {number}-{Pluralization.PolirazationWord(number, forms.Split(','))}");
                });

                endpoints.MapPost("frequency", async context =>
                {
                    string bodyStr = await new StreamReader(context.Request.Body).ReadToEndAsync();

                    var freqWords = FrequencyWord.GetInfoAboutWords(bodyStr);

                    context.Response.Headers.Add("Context-Type", "aplication/json");
                    context.Response.Headers.Add("Words-Count", freqWords.Count.ToString());
                    context.Response.Headers.Add("Most-Frequent-Word", FrequencyWord.GetMostFreqWord(freqWords));

                    string json = JsonSerializer.Serialize(freqWords);
                    await context.Response.WriteAsync(json);

                    System.Console.WriteLine(json);
                });
            });
        }
    }
}
