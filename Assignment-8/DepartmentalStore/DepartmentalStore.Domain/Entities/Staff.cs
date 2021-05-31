using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Domain
{
    public class Staff
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public char Gender { get; set; }
        public string Email { get; set; }
        public int AddressID { get; set; }
        public int DesignationID { get; set; }
        public Address Address { get; set; }
        public Designation Designation { get; set; }
    }
}
