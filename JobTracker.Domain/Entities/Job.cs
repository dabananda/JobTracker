using JobTracker.Domain.Common;
using JobTracker.Domain.Enums;

namespace JobTracker.Domain.Entities
{
    public class Job : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? JobUrl { get; set; }
        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }
        public JobStatus Status { get; set; } = JobStatus.Wishlist;
        public DateTime? AppliedDate { get; set; }
        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
