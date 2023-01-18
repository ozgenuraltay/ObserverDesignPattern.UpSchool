using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ObserverDesignPattern.Upschool.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObserverDesignPattern.Upschool.ObserverDesignPattern
{
    public class UserObserverWriteToConsole : IUserObserver
    {
        private IServiceProvider _serviceProvider;

        public UserObserverWriteToConsole(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateUser(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverWriteToConsole>>();
            logger.LogInformation($"{appUser.Name + " " + appUser.Surname} isimli kulllanıcı sisteme koydoldu.");

        }
    }
}
