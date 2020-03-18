using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyMd.PasswordDecrypt.App.Config;
using MyMd.PasswordDecrypt.App.DataAccess.Entities;
using MyMd.PasswordDecrypt.App.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMd.PasswordDecrypt.App.DataAccess.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppSettings _appSettings;

        public MemberRepository(
            IOptions<AppSettings> options
        )
        {
            _appSettings = options.Value;
        }

        public async Task<IList<Member>> GetAllMembers()
        {
            using (var dbContext = new MyDbContext(_appSettings))
            {
                return await dbContext.Members.ToListAsync();
            }
        }

        public async Task UpdateMember(Member member)
        {
            using (var dbContext = new MyDbContext(_appSettings))
            {
                dbContext.Members.Attach(member);
                dbContext.Entry(member).Property("PasswordDecrypted").IsModified = true;
                dbContext.Entry(member).Property("HashedPassword").IsModified = true;

                await dbContext.SaveChangesAsync();
            }
        }
    }
}