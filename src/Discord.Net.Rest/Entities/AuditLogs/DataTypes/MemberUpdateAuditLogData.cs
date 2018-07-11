using System.Linq;

using Model = Discord.API.AuditLog;
using EntryModel = Discord.API.AuditLogEntry;

namespace Discord.Rest
{
    /// <summary>
    ///     Contains audit log data related to a change in a guild member.
    /// </summary>
    public class MemberUpdateAuditLogData : IAuditLogData
    {
        private MemberUpdateAuditLogData(IUser target, string newNick, string oldNick)
        {
            Target = target;
            NewNick = newNick;
            OldNick = oldNick;
        }

        internal static MemberUpdateAuditLogData Create(BaseDiscordClient discord, Model log, EntryModel entry)
        {
            var changes = entry.Changes.FirstOrDefault(x => x.ChangedProperty == "nick");

            var newNick = changes.NewValue?.ToObject<string>();
            var oldNick = changes.OldValue?.ToObject<string>();

            var targetInfo = log.Users.FirstOrDefault(x => x.Id == entry.TargetId);
            var user = RestUser.Create(discord, targetInfo);

            return new MemberUpdateAuditLogData(user, newNick, oldNick);
        }

        public IUser Target { get; }
        public string NewNick { get; }
        public string OldNick { get; }
    }
}
