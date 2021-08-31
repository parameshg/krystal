using System;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;

namespace Krystal.Services.Admin.Database.Entities
{
    [Table("Links", Schema = "Admin")]
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