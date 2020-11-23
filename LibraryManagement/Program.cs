using LibraryManagement.Data.Entities;
using LibraryManagement.Data.Repositories;
using LibraryManagement.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = new HostBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddDbContext<LibraryContext>(options => options.UseSqlite("Data Source=database.db"));

                services.AddScoped<MainForm>();
                services.AddScoped<FrmBooks>();
                services.AddScoped<FrmAuthors>();
                services.AddScoped<FrmPublishers>();                

                services.AddScoped<IBookRepository, BookRepository>();
            });

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var mainForm = services.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }
    }
}