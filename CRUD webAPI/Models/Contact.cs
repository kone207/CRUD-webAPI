﻿namespace CRUD_webAPI.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public long PhoneNo { get; set; }
        public string Address { get; set; }

    }
}