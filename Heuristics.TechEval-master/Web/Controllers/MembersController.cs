using System.Linq;
using System.Web.Mvc;
using Heuristics.TechEval.Core;
using Heuristics.TechEval.Web.Models;
using Heuristics.TechEval.Core.Models;
using Newtonsoft.Json;
using System.Data.Common;
using System.Collections.Generic;

namespace Heuristics.TechEval.Web.Controllers {

	public class MembersController : Controller {

		private readonly DataContext _context;

		public MembersController() {
			_context = new DataContext();
		}

		public ActionResult List() {
            var allMembers = _context.Members.ToList();
            var allCategories = _context.Categories.ToList();

            ViewData["Categories"] = allCategories;

                return View(allMembers);
		}

        [HttpPost]
		public ActionResult New(NewMember data) {

			var newMember = new Member {
				Name = data.Name,
				Email = data.Email,
                CategoryId=data.CategoryId
			};

			_context.Members.Add(newMember);
			_context.SaveChanges();

            return Json(JsonConvert.SerializeObject(newMember));
		}

        public ActionResult Edit(EditMember data)
        {
            var editMember = new Member
            {
                Id = data.Id,
                Name = data.Name,
                Email = data.Email,
                CategoryId = data.CategoryId
            };

            var myCurrentRecord = _context.Members.SingleOrDefault(b => b.Id == editMember.Id);

            if (myCurrentRecord != null)
            {
                myCurrentRecord.Email = editMember.Email;
                myCurrentRecord.Name = editMember.Name;
                myCurrentRecord.CategoryId = editMember.CategoryId;
            }

            _context.SaveChanges();

            return Json(JsonConvert.SerializeObject(editMember));

        }

	}
}