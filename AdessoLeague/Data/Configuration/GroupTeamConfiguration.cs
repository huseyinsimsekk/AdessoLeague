using AdessoLeague.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdessoLeague.Data.Configuration
{
    public class GroupTeamConfiguration : IEntityTypeConfiguration<GroupTeam>
    {
        public void Configure(EntityTypeBuilder<GroupTeam> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseIdentityColumn();
            builder.Property(m => m.GroupName).IsRequired();
            builder.Property(m => m.TeamId).IsRequired();
            builder.Property(m => m.CreatorId).IsRequired();
            builder.Property(m => m.CreateTime).IsRequired();
            builder.Property(m => m.Hash).IsRequired();

            builder.ToTable("GroupTeams");

        }
    }
}
