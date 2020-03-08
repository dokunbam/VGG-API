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
using VGG_API.Entities;
using VGG_API.EntityClass;

namespace VGG_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly ProjectClass projectClass;
        private ProjectResponse projectResponse;
        private ProjectsResponse projectsResponse;
        private readonly ActionClass actionClass;
        private ActionResponse actionResponse;

        public ProjectsController(ApiContext context, ProjectClass _projectClass, ActionClass _actionClass)
        {
            _context = context;
            projectClass = _projectClass;
            actionClass = _actionClass;

        }


        //Create project endpoint
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<ProjectResponse>> PostProject(ProjectRequest project)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var projects = await projectClass.CreateProject(project);

                    if(projects == null) 
                    {
                        projectResponse = new ProjectResponse
                        {
                            StatusCode = 400,
                            Message = "Fail to create project"
                        };

                        return BadRequest(projectResponse);
                    }
                    else 
                    {
                        projectResponse = new ProjectResponse
                        {
                            StatusCode = 200,
                            Message = "Successfully Created",
                            ResponseData = projects
                        };
                        return Ok(projectResponse);
                    }
                }
                else 
                {
                    projectResponse = new ProjectResponse
                    {
                        StatusCode = 400,
                        Message = "Invalid input ",
                       
                    };
                    return BadRequest(projectResponse);
                }
             
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // GET: api/Projects
        //Get All project
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<ProjectsResponse>> GetProjects()
        {
            try
            {
                var projects = await projectClass.GetProjects();

                if (projects.Count() == 0)
                {
                    projectsResponse = new ProjectsResponse
                    {
                        StatusCode = 400,
                        Message = "Something went wrong, Try again or List not Available"
                    };

                    return BadRequest(projectsResponse);
                }
                else
                {
                    projectsResponse = new ProjectsResponse
                    {
                        StatusCode = 200,
                        Message = "Successfully Executed",
                        ResponseData = projects
                    };
                    return Ok(projectsResponse);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: api/Projects
        //Get All completed  project
        [HttpGet]
        [Route("completed")]
        public async Task<ActionResult<ProjectsResponse>> GetCompletedProjects(bool completed)
        {
            try
            {
                var projects = await projectClass.GetCompletedProjects(completed);

                if (projects.Count() == 0)
                {
                    projectsResponse = new ProjectsResponse
                    {
                        StatusCode = 400,
                        Message = "Something went wrong, Try again or List not Available"
                    };

                    return NotFound(projectsResponse);
                }
                else
                {
                    projectsResponse = new ProjectsResponse
                    {
                        StatusCode = 200,
                        Message = "Successfully Executed",
                        ResponseData = projects
                    };
                    return Ok(projectsResponse);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: api/Projects/5
        //Get One project by Id
        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<ProjectResponse>> GetProject(int id)
        {
            try
            {
                var project = await projectClass.GetProject(id);

                if (project.Name == null)
                {
                    projectResponse = new ProjectResponse
                    {
                        StatusCode = 400,
                        Message = "Invalid Id",
                    };
                    return Ok(projectResponse);
                }
                else
                {
                    projectResponse = new ProjectResponse
                    {
                        StatusCode = 200,
                        Message = "Successfully Executed",
                        ResponseData = project
                    };
                    return Ok(projectResponse);
                }
            }
            catch (Exception)
            {

                throw;
            }

           
        }

        // PUT: api/Projects/5
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<IActionResult> PutProject(int id, ProjectRequest projectRequest)
        {

            var project = await projectClass.EditProject(id, projectRequest);

            if (project.Name == null)
            {
                projectResponse = new ProjectResponse
                {
                    StatusCode = 400,
                    Message = "Invalid Id",
                };
                return Ok(projectResponse);
            }
            else
            {
                projectResponse = new ProjectResponse
                {
                    StatusCode = 200,
                    Message = "Successfully Updated",
                    ResponseData = project
                };

                return Ok(projectResponse);
            }
        }


        //edit only project that are completed
        [HttpPatch]
        [Route("EditCompleted/{id}")]
        public async Task<ActionResult<ProjectResponse>> PutCompletedProject(int id, bool projectRequest)
        {
            try
            {
                var project = await projectClass.EditCompletedProject(id, projectRequest);

                if (project.Name == null)
                {
                    projectResponse = new ProjectResponse
                    {
                        StatusCode = 400,
                        Message = "Invalid Id",
                    };
                    return Ok(projectResponse);
                }
                else if (project.Completed == false && project.Flag == null) 
                {

                    projectResponse = new ProjectResponse
                    {
                        StatusCode = 400,
                        Message = "Project is not completed yet, Complete the project first",
                        ResponseData = project
                    };
                    return Ok(projectResponse);
                }
                else
                {
                    projectResponse = new ProjectResponse
                    {
                        StatusCode = 200,
                        Message = "Successfully Executed",
                        ResponseData = project
                    };
                    return Ok(projectResponse);
                }
            }
            catch (Exception)
            {

                throw;
            }


        }



      

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return project;
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }


        #region Action
        ///Action
        //api/projects/<projectId>/ actions
        [HttpPost]
        [Route("{projectId}/actions")]
        public async Task<ActionResult<ActionResponse>> PostAction(int projectId, ActionRequest action)
        {
            var RealAction = await actionClass.CreateAction(projectId, action);

            if (!ModelState.IsValid)
            {

                actionResponse = new ActionResponse
                {
                    StatusCode = 400,
                    Message = "Invalid Model"
                };
                return Ok(actionResponse);
            }
            else if (RealAction.Note == null)
            {
                actionResponse = new ActionResponse
                {
                    StatusCode = 400,
                    Message = "Project Not found, Add a valid project"
                };
                return actionResponse;
            }
            actionResponse = new ActionResponse
            {
                StatusCode = 200,
                Message = "Successfully Saved",
                ResponseData = RealAction

            };
            return Ok(actionResponse);
        }

        #endregion Action 
    }
}
