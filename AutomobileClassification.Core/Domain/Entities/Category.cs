using System;
namespace AutomobileClassification.Core.Domain.Entities
{
    public partial class Category
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string Slug {get; set;}
    }
}