using DPMOPS.Services.ReportRequest.Dtos;

namespace DPMOPS.Services.ReportRequest
{
    public interface IReportRequestService
    {
        Task<IList<ReportRequestDto>> GetAllReportRequestsAsync();
        Task<ReportRequestDto> GetReportRequestByIdAsync(Guid id);
        Task<bool> CreateReportRequestAsync(CreateReportRequestDto srDto);
        Task<bool> UpdateReportRequestAsync(UpdateReportRequestDto srDto);
        Task<bool> DeleteReportRequestAsync(Guid id);
    }
}
