using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TankStudios.Interfaces
{
    public interface IContactService
    {
        Task<bool> SendContactMessage(string fName, string lName, string email, string message);
    }
}