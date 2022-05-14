using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Srez.db
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [Unique]
        public string Login { get; set; }
        public string Password { get; set; }
        public long PhoneNum { get; set; }
        public string Email { get; set; }
    }
}
