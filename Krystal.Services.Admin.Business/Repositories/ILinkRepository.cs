using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Krystal.Services.Admin.Domain.Entities;

namespace Krystal.Services.Admin.Business.Repositories
{
    public interface ILinkRepository
    {
        Task<List<Link>> GetLinks(Guid userId);

        Task<Link> GetLinkById(Guid id);

        Task<Guid> CreateLink(bool enabled, string slug, string url, DateTime? expiry);

        Task<bool> UpdateLink(Guid id, bool enabled, string slug, string url, DateTime? expiry);

        Task<bool> DeleteLink(Guid id);
    }
}