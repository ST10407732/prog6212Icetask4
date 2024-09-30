using PROG2BIceTask4.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using PROG2BIceTask4.Models;
using PROG2BIceTask4.Data;

namespace IceTask1.Models;

public static class Data
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new PROG2BICETask4(
            serviceProvider.GetRequiredService<
                DbContextOptions<PROG2BICETask4>>()))
        {
            // Look for any task.
            if (context.TaskManager.Any())
            {
                return;   // DB has been seeded
            }
            context.TaskManager.AddRange(
                new TaskManager
                {
                    TaskName = "CLDV- Ice task 1",
                    Taskdetails = "Create web app",
                    Deadline = DateTime.Parse("2024-5-12"),
                    Status = "Completed"

                },
                new TaskManager
                {
                    TaskName = "CLDV- Ice task 1",
                    Taskdetails = "Create web app",
                    Deadline = DateTime.Parse("2024-5-12"),
                    Status = "Completed"
                },
                new TaskManager
                {
                    TaskName = "CLDV- Ice task 1",
                    Taskdetails = "Create web app",
                    Deadline = DateTime.Parse("2024-5-12"),
                    Status = "Completed"
                },
                new TaskManager
                {
                    TaskName = "CLDV- Ice task 1",
                    Taskdetails = "Create web app",
                    Deadline = DateTime.Parse("2024-5-12"),
                    Status = "Completed"
                }
            );
            context.SaveChanges();
        }
    }
}
