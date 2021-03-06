﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DateMePlease.Data;

namespace DateMePlease.Controllers
{
  [Authorize]
  public class MemberController : Controller
  {
    private IDateMePleaseRepository _repository;
    public MemberController(IDateMePleaseRepository repository)
    {
      _repository = repository;
    }

    public ActionResult EditProfile()
    {
      return View();
    }

    [HttpPost]
    public ActionResult SaveProfile()
    {
      return View();
    }

    [AllowAnonymous]
    public ActionResult ShowProfile(string id)
    {
      DateMePlease.Entities.Profile theProfile;

      if (string.IsNullOrWhiteSpace(id))
      {
        if (!User.Identity.IsAuthenticated)
        {
          return RedirectToAction("Index", "Home");
        }

        // Get the current user's profile
        theProfile = _repository.GetProfileByUserName(User.Identity.Name);
      }
      else
      {
        theProfile = _repository.GetProfile(id);
      }

      return View(theProfile);
    }

    public ActionResult EditPhotos()
    {
      return View();
    }

  }
}