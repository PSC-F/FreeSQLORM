// See https://aka.ms/new-console-template for more information

using FreeSql.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Xml.Linq;
using Test.Models;

var connectionString = "Data Source=127.0.0.1;Port=3306;User ID=root;Password=123456;" +
    "Initial Catalog=test;Charset=utf8;SslMode=none;Max pool size=10";

IFreeSql fsql = new FreeSql.FreeSqlBuilder()
   .UseConnectionString(FreeSql.DataType.MySql, connectionString)
   .UseAutoSyncStructure(true) //自动同步实体结构到数据库
   .Build(); //请务必定义成 Singleton 单例模式

// one to one
// 导航属性各自指向自己,nameof指向当前的id
var repo = fsql.GetRepository<User>();
var repoEXT = fsql.GetRepository<UserExt>();
var user = new User()
{
    Id = 7,
    GroupId = 1,
    Password = "password",
    UserName = "USER",
    UserEmail = "s",
};
repo.InsertOrUpdate(user);
var ext = new UserExt()
{
    Card = "1",
    Home = "2xxxxxxx",
    UserId = user.Id
};
repoEXT.InsertOrUpdate(ext);

// one to many

var repoGroup = fsql.GetGuidRepository<Group>();
var g = new Group()
{
    GourpId = 3,
    GourpName = "goup1",
    Users = new List<User>()
    {
        new User()
        {
              Password = "password23",
              UserName = "USER23",
              UserEmail = "2222222222222",
        },
        new User()
        {
              Password = "password23",
              UserName = "USER23",
              UserEmail = "s2222222",
        }
    }
};
repoGroup.InsertOrUpdate(g);
repoGroup.SaveMany(g, "Users");
// one to many 追加保存
var p = new Group()
{
    GourpId = 4,
    GourpName = "goupspakcage",
    Users = new List<User>()
    {
        new User()
        {
              Password = "password23",
              UserName = "USER23",
              UserEmail = "2222222222222",
        },
        new User()
        {
              Password = "password23",
              UserName = "USER23",
              UserEmail = "s2222222",
        }
    },
    Childs = new List<Group>(){
        new Group() {
    GourpName = "goup23",
    Users = new List<User>()
    {
        new User()
        {
              Password = "123",
              UserName = "123",
              UserEmail = "4",
        },
        new User()
        {
              Password = "123",
              UserName = "123",
              UserEmail = "123",
        }
    }
        }
    }
};
repoGroup.DbContextOptions.EnableCascadeSave = true;
repoGroup.InsertOrUpdate(p);
repoGroup.SaveMany(p, "Childs");



