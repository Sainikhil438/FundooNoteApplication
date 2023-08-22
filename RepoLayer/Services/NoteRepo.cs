using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoLayer.Services
{
    public class NoteRepo : INoteRepo
    {
        private readonly FundooContext _fundooContext;
        private readonly IConfiguration configuration;

        public NoteRepo(FundooContext fundooContext, IConfiguration configuration)
        {
            this._fundooContext = fundooContext;
            this.configuration = configuration;
        }

        public NoteEntity CreateNote(NoteModel noteModel, long userID)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();
                noteEntity.Title = noteModel.Title;
                noteEntity.TakeNote = noteModel.TakeNote;
                noteEntity.UserID = userID;
                _fundooContext.NotesTable.Add(noteEntity);
                _fundooContext.SaveChanges();
                if (noteModel != null)
                {
                    return noteEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateNoteById(long Notesid, string Takenote)
        {
            try
            {
                var noteData = _fundooContext.NotesTable.FirstOrDefault(x => x.NoteID == Notesid);
                if (noteData != null)
                {
                    noteData.TakeNote = noteData.TakeNote + Takenote;
                    _fundooContext.NotesTable.Update(noteData);
                    _fundooContext.SaveChanges();
                    return noteData.TakeNote;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public long DeleteNote(long Noteid)
        {
            try
            {
                var result = _fundooContext.NotesTable.FirstOrDefault(x => x.NoteID == Noteid);
                if (result != null)
                {
                    _fundooContext.NotesTable.Remove(result);
                    _fundooContext.SaveChanges();
                    return result.NoteID;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<NoteEntity> GetParticularUser(long UserId)
        {
            return _fundooContext.NotesTable.Where(user => user.UserID == UserId).ToList();
        }

        public string UpdateColour(long Noteid, string colour, long Userid)
        {
            try
            {
                var existingNote = _fundooContext.NotesTable.FirstOrDefault(x => x.NoteID == Noteid && x.UserID == Userid);
                if (existingNote != null)
                {
                    existingNote.Colour = colour;
                    _fundooContext.NotesTable.Update(existingNote);
                    _fundooContext.SaveChanges();
                    return existingNote.Colour;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ArchiveByNoteId(long Noteid, long Userid)
        {
            try
            {
                var result = _fundooContext.NotesTable.FirstOrDefault(x => x.NoteID == Noteid && x.UserID == Userid);

                if (result != null)
                {
                    result.IsArchive = true;
                    _fundooContext.NotesTable.Update(result);
                    _fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool PinByNoteId(long Noteid, long Userid)
        {
            try
            {
                var result = _fundooContext.NotesTable.FirstOrDefault(x => x.NoteID == Noteid && x.UserID == Userid);

                if (result != null)
                {
                    result.IsPin = true;
                    _fundooContext.NotesTable.Update(result);
                    _fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool TrashByNoteId(long Noteid, long Userid)
        {
            try
            {
                var existingNote = _fundooContext.NotesTable.FirstOrDefault(x => x.NoteID == Noteid && x.UserID == Userid);
                if (existingNote != null)
                {
                    existingNote.IsTrash = true;
                    _fundooContext.NotesTable.Update(existingNote);
                    _fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
