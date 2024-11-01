using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.DAL.Context.Models;

namespace MovieApp.DAL.Context.Configurations;

public class WatchListConfiguration : IEntityTypeConfiguration<WatchList>
{
    public void Configure(EntityTypeBuilder<WatchList> builder)
    {
        builder.HasKey(w => w.Id);

        builder.Property(w => w.UserId)
            .IsRequired();

        builder.Property(w => w.MovieId)
            .IsRequired();

        builder.HasOne(w => w.User)
            .WithMany(u => u.WatchList)
            .HasForeignKey(w => w.UserId);
    }
}