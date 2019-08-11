﻿using Castle.Core.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NLua;
using System;
using System.Diagnostics;
using System.Threading;

namespace ConsoleAppCoreWeb
{
    public class Startup
    {
        public Startup()
        {
        }

        public IConfiguration Configuration { get; }
        public static DateTime Now { get; }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Lua state = new Lua();
            app.UseStatusCodePages();

            //string res = (state.DoFile(@"C:\test.lua")[0]).ToString();
            //System.Console.Write(res);
            int i = 0;
            var stopwatch = Stopwatch.StartNew();
            app.Run(context => GetString(context, state, ref i));

        }

        private static System.Threading.Tasks.Task GetString(HttpContext context, Lua state, ref int i)
        {
            return context.Response.WriteAsync((++i).ToString() + " " + ReadFromLua(state, i));
        }

        private static string ReadFromLua(Lua state,int i)
        {
            return state.DoFile("C:\\test.lua")[0].ToString();
        }
    }
}   