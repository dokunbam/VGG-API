using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VGG_API.Data;
using VGG_API.Dtos;
using Action = VGG_API.Entities.Action;

namespace VGG_API.EntityClass
{
    public class ActionEntity
    {
        private readonly ApiContext apiContext;
        private Action action;
        public ActionEntity(ApiContext _apiContext)
        {
            apiContext = _apiContext;
        }

        public async Task<Action> CreateAction(int projectId, ActionRequest actions) 
        {
            try
            {
                var project = await apiContext.Projects.FindAsync(projectId);
                if(project == null) 
                {
                    action = new Action
                    {
                        Id = 0
                    };

                    return action;
                }

                action = new Action 
                {
                    Note = actions.Note,
                    Description = actions.Description,
                    ProjectId = projectId,
                    CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.FFF")
                };

                apiContext.Actions.Add(action);
                await apiContext.SaveChangesAsync();

                return action;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //all actions
        //public async Task<IEnumerable<Project>> GetProjects()
        public async Task<IEnumerable<Action>> GetActions() 
        {
            try
            {
                return await apiContext.Actions.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
