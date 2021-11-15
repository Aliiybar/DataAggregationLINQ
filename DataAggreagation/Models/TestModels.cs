using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAggreagation.Models
{
    public class Item1
    {
        public Guid id;
        public string first_name;
        public string last_name;
        public string email;
    }

    public class Item2
    {
        public Guid id;
        public string gender;
        public string ip_address;
    }

    public class ItemTotal
    {
        public ItemTotal(Guid _id, string _first_name, string _last_name, string _email, string _gender, string _ip_address)
        {
            id = _id;
            first_name = _first_name;
            last_name = _last_name;
            email = _email;
            gender = _gender;
            ip_address = _ip_address;
        }
        public Guid id;
        public string first_name;
        public string last_name;
        public string email;
        public string gender;
        public string ip_address;
    }
}
