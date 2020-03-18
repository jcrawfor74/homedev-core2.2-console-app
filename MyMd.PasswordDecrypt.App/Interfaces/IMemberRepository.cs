using MyMd.PasswordDecrypt.App.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMd.PasswordDecrypt.App.Interfaces
{
    public interface IMemberRepository
    {
        Task<IList<Member>> GetAllMembers();

        Task UpdateMember(Member member);
    }
}
