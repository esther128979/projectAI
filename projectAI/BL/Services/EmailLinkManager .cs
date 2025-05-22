using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Api;
using CSharpFunctionalExtensions;
using DAL.Api;
using DAL.Models;
using iText.Layout.Element;

namespace BL.Services
{

        public class EmailLinkManager : IEmailLinkManager
        {
            private readonly IDAL _dal;

            public EmailLinkManager(IDAL dal)
            {
                _dal = dal;
            }

        public async Task<Result<string>> TrackClickAsync(string token, string ipAddress, string userAgent)
        {
            var link = await _dal.EmailLink.GetByTokenWithClicksAndMovieAsync(token);
            if (link == null)
                return Result.Failure<string>("Invalid or expired token");

            if (link.ViewLimit.HasValue && link.ViewCount >= link.ViewLimit)
                return Result.Failure<string>("View limit reached");

            // עדכון ViewCount
            link.ViewCount++;
            await _dal.EmailLink.UpdateAsync(link);

            // רישום קליק
            var click = new EmailLinkClick
            {
                LinkId = link.LinkId,
                ClickDate = DateTime.UtcNow,
                Ipaddress = ipAddress,
                UserAgent = userAgent
            };

            await _dal.EmailLinkClick.AddAsync(click);

            return Result.Success(link.Movie.Link);
        }

        public async Task<EmailLink> GetByTokenAsync(string token)
        {
            return await _dal.EmailLink.GetByTokenAsync(token);

        }

      

    }

}