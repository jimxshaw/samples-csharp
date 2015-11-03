using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SimpleBlogMVC.Models;

namespace SimpleBlogMVC.Areas.Admin.ViewModels
{
    public class UsersIndex
    {
        // A collection of users that can be presented on
        // the admin form.
        public IEnumerable<User> Users { get; set; }
    }

    public class UsersNew
    {
        [Required, MaxLength(128)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, MaxLength(128), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}