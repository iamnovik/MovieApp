using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.DAL.Context.Models;

namespace MovieApp.DAL.Context.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id); 

        builder.Property(r => r.Content)
            .IsRequired() 
            .HasMaxLength(1000); 

        builder.Property(r => r.UserId)
            .IsRequired(); 

        builder.Property(r => r.MovieId)
            .IsRequired(); 
        
        builder.HasOne(r => r.AppUser)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId)
            .IsRequired();
    }
}