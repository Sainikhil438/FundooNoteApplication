using BusinessLayer.Interface;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Context;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace FundooNoteApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteBusiness _noteBusiness;
        private readonly FundooContext _fundooContext;

        public NoteController(INoteBusiness noteBusiness, FundooContext fundooContext)
        {
            _noteBusiness = noteBusiness;
            _fundooContext = fundooContext;
        }

        [Authorize]
        [HttpPost]
        [Route("Notemaking")]
        public IActionResult NoteRegistration(NoteModel noteModel)
        {
            long userId = Convert.ToInt64(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
            var result = _noteBusiness.CreateNote(noteModel, userId);
            if (result != null)
            {
                return this.Ok(new { success = true, message = "Note Created Successfully", data = result });

            }
            else
            {
                return this.BadRequest(new { success = false, message = "Note Creation UnSuccessful", data = result });
            }
        }

        [HttpPatch]
        [Route("ByID")]
        public IActionResult UpdateNoteByIdData(long id, string Takenote)
        {
            var result = _noteBusiness.UpdateNoteById(id, Takenote);
            if (result != null)
            {
                return this.Ok(new { success = true, message = "Note Data Updated Successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Note Data Update Unsuccessful", data = result });
            }
        }

        [HttpDelete]
        [Route("ByID")]
        public IActionResult DeleteNoteByIdData(long id)
        {
            var result = _noteBusiness.DeleteNote(id);
            if (result != 0)
            {
                return this.Ok(new { success = true, message = "Data Deleted Successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Data Deletion Unsuccessful", data = result });
            }

        }

        [Authorize]
        [HttpGet]
        [Route("ParticularUserId")]
        public IActionResult GetParticularUserNotes()
        {
            var userClaim = User.Claims.FirstOrDefault(claims => claims.Type == "UserId").Value;
            int userId = int.Parse(userClaim);
            var result = _noteBusiness.GetParticularUser(userId);
            if (result != null)
            {
                return this.Ok(new { success = true, message = "User data retrieved", data = result });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "User not found", data = result });
            }
        }

        [Authorize]
        [HttpPatch]
        [Route("Colour")]
        public IActionResult UpdateColour(long Noteid, string colour)
        {
            var userClaim = User.Claims.FirstOrDefault(claims => claims.Type == "UserId").Value;
            int userId = int.Parse(userClaim);
            var result = _noteBusiness.UpdateColour(Noteid, colour, userId);
            if (result != null)
            {
                return this.Ok(new { success = true, message = "Colour Updated Successfully with " + result + " colour" });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Colour Update Failed" });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("Archive")]
        public IActionResult IsArchiveData(long Noteid)
        {
            var userIdClaim = User.Claims.FirstOrDefault(claim => claim.Type == "UserId").Value;
            int userId = int.Parse(userIdClaim);
            var result = _noteBusiness.ArchiveByNoteId(Noteid, userId);
            if (result == true)
            {
                return this.Ok(new { success = true, message = "Note Archived Successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Note Archive Unsuccessful", data = result });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("Pin")]
        public IActionResult IsPinData(long Noteid)
        {
            var userClaim = User.Claims.FirstOrDefault(claim => claim.Type == "UserId").Value;
            int userId = int.Parse(userClaim);
            var result = _noteBusiness.PinByNoteId(Noteid, userId);
            if (result == true)
            {
                return this.Ok(new { success = true, message = "Pin Updated Successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Pin Update Unsuccessful", data = result });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("Trash")]
        public IActionResult IsTrashData(long Noteid)
        {
            var userClaim = User.Claims.FirstOrDefault(claims => claims.Type == "UserId").Value;
            int userId = int.Parse(userClaim);
            var result = _noteBusiness.TrashByNoteId(Noteid, userId);
            if (result == true)
            {
                return this.Ok(new { success = true, message = "Trash Updated Successfully", data = result });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Trash Update Unsuccessful", data = result });
            }
        }

        
    }
}
