using AutomobileClassification.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileClassification.Core.Application.Common.Interface
{
    public interface IAppDbContext
    {
        DbSet<Category> Categories {get; set;}
        DbSet<Model> Models {get; set;}
        DbSet<Post> Posts {get; set;}
        DbSet<PostComment> PostComments {get; set;}
        DbSet<PostImage> PostImages {get; set;}
        DbSet<PostLike> PostLikes {get; set;} 
        Task<int> SaveChangesAsync();
       
    }
}