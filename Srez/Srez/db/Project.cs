using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Srez.db
{
    [Table("Projects")]
    public class Project
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [Unique]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int User_Id { get; set; }
    }
}
