using QLHV_BackEnd.Models;

namespace QLHV_BackEnd.Repositories
{
    public interface IIncomingDocumentRepository
    {
        Task<IList<IncomingDocumentModel>> GetIncomingDocuments();
        Task<int> CreateIncomingDocument(CreateIncomingDocumentModel createIncomingDocumentModel);
        Task<int> UpdateIncomingDocument(int incomingDocumentId, UpdateIncomingDocumentModel updateIncomingDocumentModel);
        Task<int> DeleteIncomingDocument(int incomingDocumentId);
        Task<IncomingDocumentModel> GetIncomingDocumentByTitle(string title);
        //Task<IncomingDocumentModel> GetIncomingDocumentByReceivedDate(DateTime receivedDate);
        Task<IncomingDocumentModel> GetIncomingDocumentBySender(string sender);
        Task<IList<IncomingDocumentModel>> Pagination(int pageSize, int pageNumber);
    }
}
