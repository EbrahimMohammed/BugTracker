using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BugTracker.Core.Domain;
using BugTracker.Dtos;
using BugTracker.Models;
using BugTracker.Persistance;

namespace BugTracker.Controllers.Api
{
    public class CommentsController : ApiController
    {
        private ApplicationDbContext _context;

        public CommentsController()
        {
            _context = new ApplicationDbContext();
        }




        public IHttpActionResult GetComments(int id)
        {

            var commentsDtos = _context.Comments
                .Include(c => c.CreatedByTable)
                .Where(c => c.TicketId == id)
                .ToList()
                .Select(Mapper.Map<Comments, CommentsDto>);


            return Ok(commentsDtos);

        }


        [HttpPut]
        [Route("api/comments/AddComment")]
        public IHttpActionResult AddComment(CreateCommentModel model)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var comment = new Comments
            {
                Comment = model.Comment,
                TicketId = model.TicketId
            };


            _context.Tickets.Include(t => t.Comments)
                                            .Single(t => t.Id == model.TicketId)
                                            .Comments.Add(comment);

            _context.SaveChanges();
            
            return Ok();
        }


    }
}
