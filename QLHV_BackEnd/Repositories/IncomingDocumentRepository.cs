using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLHV_BackEnd.Data;
using QLHV_BackEnd.Data.Entities;
using QLHV_BackEnd.Models;
using System.Drawing.Printing;

namespace QLHV_BackEnd.Repositories
{
    public class IncomingDocumentRepository : IIncomingDocumentRepository
    {
        public readonly DBContext _context;
        public readonly UserManager<ApplicationUser> _userManager;
        public IncomingDocumentRepository(DBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IList<IncomingDocumentModel>> GetIncomingDocuments()
        {
            return await _context.IncomingDocuments
                .Select(i => new IncomingDocumentModel
                {
                    IncomingDocumentsId = i.IncomingDocumentsId,
                    Title = i.Title,
                    Content = i.Content,
                    ReceivedDate = i.ReceivedDate,
                    Sender = i.Sender,
                    Status = i.Status,
                    PersonInCharge = i.PersonInCharge
                }).ToListAsync();
        }
        public async Task<IncomingDocumentModel> GetIncomingDocumentByTitle(string title)
        {
            return await _context.IncomingDocuments.Where(i => i.Title.ToLower().Contains(title.ToLower()))
                .Select(i => new IncomingDocumentModel
                {
                    IncomingDocumentsId = i.IncomingDocumentsId,
                    Title = i.Title,
                    Content = i.Content,
                    ReceivedDate = i.ReceivedDate,
                    Sender = i.Sender,
                    Status = i.Status,
                    PersonInCharge = i.PersonInCharge
                }).FirstOrDefaultAsync();
        }
        //public async Task<IncomingDocumentModel> GetIncomingDocumentByReceivedDate(DateTime receivedDate)
        //{
        //    return await _context.IncomingDocuments.Where(i => i.ReceivedDate == receivedDate)
        //        .Select(i => new IncomingDocumentModel
        //        {
        //            IncomingDocumentsId = i.IncomingDocumentsId,
        //            Title = i.Title,
        //            Content = i.Content,
        //            ReceivedDate = i.ReceivedDate,
        //            Sender = i.Sender,
        //            Status = i.Status,
        //            PersonInCharge = i.PersonInCharge
        //        }).FirstOrDefaultAsync();
        //}
        public async Task<IncomingDocumentModel> GetIncomingDocumentBySender(string sender)
        {
            return await _context.IncomingDocuments.Where(i => i.Sender.ToLower().Contains(sender.ToLower()))
                .Select(i => new IncomingDocumentModel
                {
                    IncomingDocumentsId = i.IncomingDocumentsId,
                    Title = i.Title,
                    Content = i.Content,
                    ReceivedDate = i.ReceivedDate,
                    Sender = i.Sender,
                    Status = i.Status,
                    PersonInCharge = i.PersonInCharge
                }).FirstOrDefaultAsync();
        }
        public async Task<IList<IncomingDocumentModel>> Pagination(int pageSize, int pageNumber)
        {
            var skip = (pageNumber - 1) * pageSize;
            return await _context.IncomingDocuments.Skip(skip).Take(pageSize)
                .Select(i => new IncomingDocumentModel
                {
                  IncomingDocumentsId = i.IncomingDocumentsId,
                  Title = i.Title,
                  Content = i.Content,
                  ReceivedDate = i.ReceivedDate,
                  Sender = i.Sender,
                  Status = i.Status,
                  PersonInCharge = i.PersonInCharge
                }).ToListAsync();
        }
        public async Task<int> CreateIncomingDocument(CreateIncomingDocumentModel createIncomingDocumentModel)
        {
            IncomingDocuments incomingDocument = new IncomingDocuments
            {
                Title = createIncomingDocumentModel.Title,
                Content = createIncomingDocumentModel.Content,
                ReceivedDate = createIncomingDocumentModel.ReceivedDate,
                Sender = createIncomingDocumentModel.Sender,
                Status = createIncomingDocumentModel.Status,
                PersonInCharge= createIncomingDocumentModel.PersonInCharge
            };
            await _context.IncomingDocuments.AddAsync(incomingDocument);
            int rowChange = await _context.SaveChangesAsync();
            return rowChange;
        }
        public async Task<int> UpdateIncomingDocument(int incomingDocumentId, UpdateIncomingDocumentModel updateIncomingDocumentModel)
        {
            var incomingDocument = await _context.IncomingDocuments.FindAsync(incomingDocumentId);
            if (incomingDocument == null)
            {
                return 0;
            }
            incomingDocument.Status = updateIncomingDocumentModel.Status;
            incomingDocument.PersonInCharge = updateIncomingDocumentModel.PersonInCharge;
            _context.IncomingDocuments.Update(incomingDocument);
            int rowChange = await _context.SaveChangesAsync();
            return rowChange;
        }
        public async Task<int> DeleteIncomingDocument(int incomingDocumentId)
        {
            var incomingDocument = await _context.IncomingDocuments.FindAsync(incomingDocumentId);
            if (incomingDocument == null)
            {
                return 0;
            }
            _context.IncomingDocuments.Remove(incomingDocument);
            int rowChange = await _context.SaveChangesAsync();
            return rowChange;
        }
    }
}
