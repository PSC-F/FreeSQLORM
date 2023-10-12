using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models
{
    [Table(Name = "tb_user_ext")]
    internal class UserExt
    {

        [Column(IsPrimary = true)]
        public int UserId { get; set; }
        [Column(DbType = "varchar(128) NOT NULL")]
        public string Home { get; set; }
        [Column(DbType = "varchar(128) NOT NULL")]
        public string Card { get; set; }
        [Navigate(nameof(UserId))]
        public User user { get; set; }
    }
}
