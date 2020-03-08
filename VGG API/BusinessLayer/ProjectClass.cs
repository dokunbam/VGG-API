using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VGG_API.Data;
using VGG_API.Dtos;
using VGG_API.EntityClass;

namespace VGG_API.BusinessLayer
{
    public class ProjectClass
    {
        private readonly ProjectEntity projectEntity;
        private ProjectResponseData projectResponseData;
        private readonly ApiContext apiContext;
        public ProjectClass(ProjectEntity _projectEntity, ApiContext _apiContext)
        {
            projectEntity = _projectEntity;
            apiContext = _apiContext;

        }

        //create project
        public async Task<ProjectResponseData> CreateProject(ProjectRequest project) 
        {
            try
            {
                var created = await projectEntity.CreateProject(project);

                projectResponseData = new ProjectResponseData
                {
                    Id = created.Id,
                    Name = created.Name,
                    Completed = created.Completed,
                    Description = created.Description
                };

                return projectResponseData;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        //Get all projects
        public async Task <IEnumerable<ProjectResponseData>> GetProjects() 
        {
            var projects = await projectEntity.GetProjects();

            List<ProjectResponseData> List = new List<ProjectResponseData>();

            foreach (var item in projects)
            {
                projectResponseData = new ProjectResponseData
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Completed = item.Completed
                };

                List.Add(projectResponseData);
            }
            return List;
        }


        //Get all Completed projects
        public async Task<IEnumerable<ProjectResponseData>> GetCompletedProjects(bool project)
        {
            var projects = await projectEntity.GetCompletedProjects(project);

            List<ProjectResponseData> List = new List<ProjectResponseData>();

            foreach (var item in projects)
            {
                projectResponseData = new ProjectResponseData
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Completed = item.Completed
                };

                List.Add(projectResponseData);
            }
            return List;
        }

        //Get one project
        public async Task<ProjectResponseData> GetProject(int id)
        {
            try
            {
                var project = await projectEntity.GetProject(id);

                if (project == null)
                {
                    projectResponseData = new ProjectResponseData
                    {
                        Name = null,
                        Description = null,
                    };

                    return projectResponseData;
                }
                else
                {
                    projectResponseData = new ProjectResponseData
                    {
                        Id = project.Id,
                        Name = project.Name,
                        Completed = project.Completed,
                        Description = project.Description
                    };

                    return projectResponseData;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        //Edit one project
        public async Task<ProjectResponseData> EditProject(int id, ProjectRequest projectRequest)
        {
            try
            {
                var project = await projectEntity.EditProject(id, projectRequest);

                if (project.Name == null)
                {
                    projectResponseData = new ProjectResponseData
                    {
                        Name = null,
                        Description = null,
                    };

                    return projectResponseData;
                }
                else
                {
                    projectResponseData = new ProjectResponseData
                    {
                        Id = project.Id,
                        Name = project.Name,
                        Description = project.Description,
                        Completed = project.Completed
                    };

                    return projectResponseData;
                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        //Get one project
        public async Task<ProjectResponseData> EditCompletedProject(int id, bool Completed)
        {
            try
            {

                //var current = apiContext.Projects.FindAsync(id);
                var project = await projectEntity.EditCompletedProject(id, Completed);

                if (project.Name == null)
                {
                    projectResponseData = new ProjectResponseData
                    {
                        Name = null,
                        Description = null,
                    };

                    return projectResponseData;
                }
                else if(project.Completed == false && project.Flag == null) 
                {
                    projectResponseData = new ProjectResponseData
                    {
                        Id = project.Id,
                        Name = project.Name,
                        Completed = project.Completed,
                        Description = project.Description
                    };

                    return projectResponseData;
                }
                else if(project.Flag == "Done")
                {
                    projectResponseData = new ProjectResponseData
                    {
                        Id = project.Id,
                        Name = project.Name,
                        Completed = project.Completed,
                        Description = project.Description,
                        //Flag = project.Flag
                    };

                    return projectResponseData;
                }
                    return projectResponseData;
                

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        //public async Task<bool> EditCompletedProject(int id, bool Completed) 
        //{

        //}


    }
}
