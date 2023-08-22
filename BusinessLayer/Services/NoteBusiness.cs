using BusinessLayer.Interface;
using CommonLayer.Models;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class NoteBusiness : INoteBusiness
    {
        private readonly INoteRepo NoteRepo;
        public NoteBusiness(INoteRepo NoteRepo)
        {
            this.NoteRepo = NoteRepo;
        }

        public NoteEntity CreateNote(NoteModel noteModel, long userID)
        {
            try
            {
                return NoteRepo.CreateNote(noteModel, userID);
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
                return NoteRepo.UpdateNoteById(Notesid, Takenote);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public long DeleteNote(long Noteid)
        {
            try
            {
                return NoteRepo.DeleteNote(Noteid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NoteEntity> GetParticularUser(long UserId)
        {
            try
            {
                return NoteRepo.GetParticularUser(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
