using ObserverDesignPattern.Upschool.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObserverDesignPattern.Upschool.ObserverDesignPattern
{
    public interface IUserObserver
    {
        void CreateUser(AppUser appUser);
    }
}
