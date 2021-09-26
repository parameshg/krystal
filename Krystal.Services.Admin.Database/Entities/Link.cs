using System;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Krystal.Services.Admin.Database.Entities
{
    [Table("Links", Schema = "Admin")]
    [Index(nameof(Slug), IsUnique = true)]
    [AutoMap(typeof(Domain.Entities.Link))]
    public class Link
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public bool Enabled { get; set; }

        public string Slug { get; set; }

        public string Url { get; set; }

        public DateTime? Expiry { get; set; }
    }
}