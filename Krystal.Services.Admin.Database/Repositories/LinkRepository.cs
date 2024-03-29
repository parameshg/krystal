﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Krystal.Services.Admin.Business.Repositories;
using Krystal.Services.Admin.Domain.Entities;

namespace Krystal.Services.Admin.Database
{
    public class LinkRepository : ILinkRepository
    {
        private DatabaseContext Database { get; }

        private Mapper Mapper { get; } = new Mapper(new MapperConfiguration(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly())));

        public LinkRepository(DatabaseContext database)
        {
            if (database is null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            Database = database;
        }

        public Task<List<Link>> GetLinks(Guid userId)
        {
            var result = new List<Link>();

            var entities = Database.Links.Where(i => i.UserId == userId).ToList();

            foreach(var entity in entities)
            {
                result.Add(new Link
                {
                    Id = entity.Id,
                    Enabled = entity.Enabled,
                    Slug = entity.Slug,
                    Url = entity.Url,
                    Expiry = entity.Expiry
                });
            }

            return Task.FromResult(result);
        }

        public Task<Link> GetLinkById(Guid id)
        {
            Link result = null;

            var entity = Database.Links.FirstOrDefault(i => i.Id == id);

            if (entity != null)
            {
                result = new Link
                {
                    Id = entity.Id,
                    Enabled = entity.Enabled,
                    Slug = entity.Slug,
                    Url = entity.Url,
                    Expiry = entity.Expiry
                };
            }

            return Task.FromResult(result);
        }

        public async Task<Guid> CreateLink(Guid userId, bool enabled, string slug, string url, DateTime? expiry)
        {
            var result = Guid.Empty;

            var id = Guid.NewGuid();

            if (Database.Links.Count(i => i.Slug == slug).Equals(0))
            {
                Database.Links.Add(new Entities.Link
                {
                    Id = id,
                    UserId = userId,
                    Enabled = enabled,
                    Slug = slug,
                    Url = url,
                    Expiry = expiry
                });

                if (await Database.SaveChangesAsync() != 0)
                {
                    result = id;
                }
            }
            else
            {
                throw new Exception("slug not available");
            }

            return result;
        }

        public async Task<bool> UpdateLink(Guid id, bool enabled, string slug, string url, DateTime? expiry)
        {
            var result = false;

            var entity = Database.Links.FirstOrDefault(i => i.Id == id);

            if (entity != null)
            {
                entity.Enabled = enabled;
                entity.Slug = slug;
                entity.Url = url;
                entity.Expiry = expiry;

                Database.Links.Update(entity);

                if (await Database.SaveChangesAsync() != 0)
                {
                    result = true;
                }
            }

            return result;
        }

        public async Task<bool> DeleteLink(Guid id)
        {
            var result = false;

            var entity = Database.Links.FirstOrDefault(i => i.Id == id);

            if (entity != null)
            {
                Database.Links.Remove(entity);

                if (await Database.SaveChangesAsync() != 0)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}