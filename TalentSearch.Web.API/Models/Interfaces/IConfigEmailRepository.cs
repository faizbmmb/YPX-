using Microsoft.AspNet.Identity;
using TalentSearch.Core.Configurations;

namespace TalentSearch.Web.API.Models.Interfaces
{
    public interface IConfigEmailRepository
    {
        Task<(string message, bool success, ConfigEmail data)> SendEmail(IdentityMessage message);
    }
}
