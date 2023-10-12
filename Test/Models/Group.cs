using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test.Models
{
    [Table(Name = "tb_group")]
    internal class Group
    {
        [Key]
        [Column(IsPrimary = true, IsIdentity = true)]
        public int GourpId { get; set; }
        [Column(DbType = "varchar(128) NOT NULL")]

        public string GourpName { get; set; }
        [Navigate(nameof(User.GroupId))]
        public List<User> Users { get; set; }
        //在 User 查找 GroupId 属性，与 本实体.主键 关联
        public int ParentId { get; set; }
        [Navigate(nameof(ParentId))]
        public List<Group> Childs { get; set; }
    }
}
