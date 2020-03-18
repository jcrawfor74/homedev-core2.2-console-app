using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyMd.PasswordDecrypt.App.Config;
using MyMd.PasswordDecrypt.App.DataAccess.Entities;
using MyMd.PasswordDecrypt.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMd.PasswordDecrypt.App
{
    public class ConsoleApp : IConsoleApp
    {
        private ILogger<ConsoleApp> _logger;
        private AppSettings _settings;
        private readonly IMemberRepository _memberRepository;
        private readonly IEncryptionService _encryptionService;

        public ConsoleApp(
            ILogger<ConsoleApp> logger,
            IOptions<AppSettings> config,
            IMemberRepository memberRepository,
            IEncryptionService encryptionService
        )
        {
            _logger = logger;
            _settings = config.Value;
            _memberRepository = memberRepository;
            _encryptionService = encryptionService;
        }

        public async Task Run()
        {
            _logger.LogInformation("Starting Password Decryption");

            _logger.LogInformation("Getting members to convert");

            var members = await _memberRepository.GetAllMembers();

            _logger.LogInformation($"Processing {members.Count} members");

            await RunInBatches(members);
        }

        private async Task RunInBatches(IList<Member> members)
        {
            int batch = Constants.BatchSize;

            int processed = 0;
            int total = members.Count;
            if (total > 0)
            {
                do
                {
                    var tasksToProcess = members.Skip(processed).Take(batch).Select(async item =>
                    {
                        try
                        {
                            await ProcessMember(item);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex.Message);
                        }
                    });
                    await Task.WhenAll(tasksToProcess);

                    processed += batch;
                    if (processed > total)
                    {
                        processed = total;
                    }
                } while (processed < total);
            }
        }

        private async Task ProcessMember(Member member)
        {
            if (string.IsNullOrWhiteSpace(member.Password))
            {
                _logger.LogWarning($"Member {member.MemberId} has no password and so is skipped");
            }

            var decryptedPassword = _encryptionService.Decrypt(member.Password);
            member.PasswordDecrypted = decryptedPassword;

            var hashedPassword = _encryptionService.HashPassword(decryptedPassword);
            member.HashedPassword = hashedPassword;

            await _memberRepository.UpdateMember(member);

            _logger.LogInformation($"Member {member.MemberId} updated successfully.");
        }
    }
}