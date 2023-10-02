using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace TestBackend
{
    public abstract class  TestBuilder : IDisposable
    {
        protected HttpClient testClient;
        private bool disposed;


        protected TestBuilder(){
            BootstrapTestingSuite();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                testClient.Dispose();
            }

            disposed = true;
        }

        protected void BootstrapTestingSuite()
        {
            disposed = false;
            var appFactory = new WebApplicationFactory<Backend.Startup>();
            testClient = appFactory.CreateClient();

        }

    }

}
