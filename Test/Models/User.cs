using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models
{
    [Table(Name = "tb_user")]
    internal class User
    {
        [Key]
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
        public string UserName { get; set; }
        [Column(DbType = "varchar(128)")]
        public string UserEmail { get; set; }
        = string.Empty;
        [Column(DbType = "varchar(128)")]
        public string Password { get; set; }
        [Navigate(nameof(Id))]
        public UserExt UserExt { get; set; }
        public int GroupId { get; set; }
        [Navigate(nameof(GroupId))]
        public Group Group { get; set; }
    }
}
