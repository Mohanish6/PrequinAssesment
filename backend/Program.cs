using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Security.Cryptography.X509Certificates;

namespace InvestorCommitments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureKestrel(options =>
                    {
                        // Specify the certificate to use
                        options.ConfigureHttpsDefaults(httpsOptions =>
                        {
                            httpsOptions.ServerCertificate = new X509Certificate2("path_to_your_cert.pfx", "your_cert_password");
                        });
                    });
                });
    }
}