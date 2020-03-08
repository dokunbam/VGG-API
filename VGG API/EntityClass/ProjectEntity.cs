using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using VGG_API.Data;
using VGG_API.Dtos;
using VGG_API.Entities;

namespace VGG_API.EntityClass
{
    public class ProjectEntity
    {
        private readonly ApiContext apiContext;
        private Project project;
        public ProjectEntity(ApiContext _apiContext)
        {
            apiContext = _apiContext;
        }

        //Create project
        public async Task<Project> CreateProject(ProjectRequest projectRequest) 
        {
            try
            {
                project = new Project
                {
                    Name = projectRequest.Name,
                    Description = projectRequest.Description,
                    Completed = false,
                    DateCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.FFF")
                };

                apiContext.Projects.Add(project);
                await apiContext.SaveChangesAsync();

                return project;
            }
            catch (Exception ex)
            {
                //log to db
                throw;
            }
        }


        //Retrieve all projects.
        public async Task<IEnumerable<Project>> GetProjects() 
        {
            try
            {
                return await apiContext.Projects.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<IEnumerable<Project>> GetCompletedProjects(bool completed)
        {
            try
            {
                return await apiContext.Projects.Where(x =>x.Completed == completed).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Retrieve a single project by ID
        public async Task<Project> GetProject(int id)
        {
            try
            {
                var project = await apiContext.Projects.FirstOrDefaultAsync(x => x.Id == id);

                return project;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Update an existing project
        public async Task<Project> EditProject(int id, ProjectRequest projectRequest) 
        {
            try
            {
                var project = await apiContext.Projects.FirstOrDefaultAsync(x => x.Id == id);

                if(project == null) 
                {
                    project = new Project
                    {
                        Name = null,
                        Description = null,
                    };

                    return project;
                }

                project.Name = projectRequest.Name;
                project.Description = projectRequest.Description;
                project.Completed = projectRequest.Completed;
                project.Flag = "Done";
                project.DateUpdated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.FFF");

                apiContext.Entry(project).State = EntityState.Modified;
                await apiContext.SaveChangesAsync();

                return project;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //editcompleted
        public async Task<Project> EditCompletedProject(int id, bool completed)
        {
            try
            {
                var Completedproject = await apiContext.Projects.FindAsync(id);

                if(Completedproject == null) 
                {
                    project = new Project
                    {
                        Name = null,
                        Description = null,
                    };
                    return project;
                }
                else 
                {
                    if (Completedproject.Completed == false && Completedproject.Flag == null)
                    {
                        project = new Project
                        {
                            Id = Completedproject.Id,
                            Name = Completedproject.Name,
                            Description = Completedproject.Description,
                            Completed = Completedproject.Completed,
                        };
                        return project;

                    } else if(Completedproject.Completed == false && Completedproject.Flag == "Done") 
                    {
                        Completedproject.Completed = completed;
                        Completedproject.Flag = "Done";
                        Completedproject.DateUpdated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.FFF");

                        apiContext.Entry(Completedproject).State = EntityState.Modified;
                        await apiContext.SaveChangesAsync();

                        return Completedproject;
                    }
                    else
                    {
                        Completedproject.Completed = completed;
                        Completedproject.Flag = "Done";
                        Completedproject.DateUpdated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.FFF");
                        
                        apiContext.Entry(Completedproject).State = EntityState.Modified;
                        await apiContext.SaveChangesAsync();
                        
                        return Completedproject;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public async Task<bool> DeletedProject(int id)
        {
            try
            {
                var project = await apiContext.Projects.FindAsync(id);

                if(project == null) 
                {
                    return false;
                }

                apiContext.Projects.Remove(project);
                await apiContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }

            }
        }
}
