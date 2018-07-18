using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Model.Users
{
    public class UsersModel
    {
        [PropertyName(Name = "ID")]
        public int Id { get; set; }

        [PropertyName(Name = "USERNAME")]
        public string Username { get; set; }

        [PropertyName(Name = "PASSWORD")]
        public string Password { get; set; }

        [PropertyName(Name = "NAME")]
        public string Name { get; set; }

        [PropertyName(Name = "SEX")]
        public bool Sex { get; set; }

        [PropertyName(Name = "BIRTHOFDATE")]
        public DateTime BirthOfDate { get; set; }

        [PropertyName(Name = "EMAIL")]
        public string Email { get; set; }

        [PropertyName(Name = "PHONENUMBER")]
        public string PhoneNumber { get; set; }

        [PropertyName(Name = "STATUS")]
        public bool Status { get; set; }

        [PropertyName(Name = "CREATEDDATE")]
        public DateTime CreatedDate { get; set; }

        [PropertyName(Name = "CREATEBY")]
        public string CreatedBy { get; set; }

        [PropertyName(Name = "MODIFIEDDATE")]
        public DateTime ModifiedDate { get; set; }

        [PropertyName(Name = "MODIFIEDBY")]
        public string ModifiedBy { get; set; }

        [PropertyName(Name = "IDROLES")]
        public int IdRoles { get; set; }

        [PropertyName(Name = "ROLENAME")]
        public string RoleName { get; set; }
    }
}
