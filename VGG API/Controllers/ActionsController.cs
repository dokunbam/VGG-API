using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VGG_API.BusinessLayer;
using VGG_API.Data;
using VGG_API.Dtos;
using Action = VGG_API.Entities.Action;


namespace VGG_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly ActionClass actionClass;
        private ActionResponse actionResponse;

        public ActionsController(ApiContext context, ActionClass _actionClass)
        {
            _context = context;
            actionClass = _actionClass;
        }

        // GET: api/Actions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Action>>> GetActions()
        {
            return await _context.Actions.ToListAsync();
        }

        // GET: api/Actions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Action>> GetAction(int id)
        {
            var action = await _context.Actions.FindAsync(id);

            if (action == null)
            {
                return NotFound();
            }

            return action;
        }

        // PUT: api/Actions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAction(int id, Action action)
        {
            if (id != action.Id)
            {
                return BadRequest();
            }

            _context.Entry(action).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

     

        // DELETE: api/Actions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Action>> DeleteAction(int id)
        {
            var action = await _context.Actions.FindAsync(id);
            if (action == null)
            {
                return NotFound();
            }

            _context.Actions.Remove(action);
            await _context.SaveChangesAsync();

            return action;
        }

        private bool ActionExists(int id)
        {
            return _context.Actions.Any(e => e.Id == id);
        }



        #region Action
        ///Action
        //api/projects/<projectId>/ actions

        #endregion Action 

    }
}
