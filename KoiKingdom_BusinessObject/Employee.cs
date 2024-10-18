using System;
using System.Collections.Generic;

namespace KoiKingdom_BusinessObject
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? Address { get; set; }
        public bool? Status { get; set; }
    }
}
