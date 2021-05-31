using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Domain.Models
{
    public class StaffModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public char Gender { get; set; }
        public string Email { get; set; }
        public int AddressID { get; set; }
        public int DesignationID { get; set; }
        public AddressModel Address { get; set; }
        public DesignationModel Designation { get; set; }
    }
}
