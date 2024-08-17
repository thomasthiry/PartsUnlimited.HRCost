using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using PartsUnlimited.HRCost.Application.Services;
using PartsUnlimited.HRCost.Infrastructure.Repositories;
using PartsUnlimited.HRCost.Web.Controllers;

namespace PartsUnlimited.HRCost.Web
{
    public class CompositionRoot : IControllerActivator
    {
        public object Create(ControllerContext context)
        {
            var loggerFactory = (ILoggerFactory)new LoggerFactory();
            if (context.ActionDescriptor.ControllerTypeInfo == typeof(HomeController))
            {
                return new HomeController(loggerFactory.CreateLogger(nameof(HomeController)));
            }
            if (context.ActionDescriptor.ControllerTypeInfo == typeof(EmployeeController))
            {
                return new EmployeeController(new EmployeeService(new EmployeeFileRepository("employees.json")));
            }
 
            return null;
        }

        public void Release(ControllerContext context, object controller)
        {
            
        }
    }}