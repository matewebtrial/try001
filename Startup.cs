using Castle.Core.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NLua;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Data;

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

            int i = 0;
            var stopwatch = Stopwatch.StartNew();
            var backgroundTask = Task.Run(() => WebTask(app, state, i));
        }

        private static int WebTask(IApplicationBuilder app, Lua state, int i)
        {
            app.Run(context => GetString(context, state, ref i));
            return i;
        }

        private static System.Threading.Tasks.Task GetString(HttpContext context, Lua state, ref int i)
        {
            return context.Response.WriteAsync((++i).ToString() + " " + ReadFromLua(state, i));
        }

        private static string ReadFromLua(Lua state, int i)
        {
            return state.DoFile("test.lua")[0].ToString();
        }
        public string[] Query(string DB, string query)
        {
            string[] res= new string[Int16.MaxValue];
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = DB;
            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                Int16 i = 0;
                while (reader.Read())
                {
                    res[i] = reader.GetString(i++);
                }
                dbCon.Close();
            }
            return res;
        }
    }
}   