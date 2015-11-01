using System.Collections;
using System.Collections.Generic;
using SimpleBlogMVC.Models;

namespace SimpleBlogMVC.Areas.Admin.ViewModels
{
    public class UsersIndex
    {
        // A collection of users that can be presented on
        // the admin form.
        public IEnumerable<User> Users { get; set; }
    }
}