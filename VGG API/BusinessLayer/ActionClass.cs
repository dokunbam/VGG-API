using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VGG_API.Data;
using VGG_API.Dtos;
using VGG_API.EntityClass;
using Action = VGG_API.Entities.Action;

namespace VGG_API.BusinessLayer
{
    
    public class ActionClass
    {
       
        private ActionEntity actionEntity;
        private ActionResponseData actionResponseData;
        public ActionClass(ActionEntity _actionEntity)
        {
            actionEntity = _actionEntity;
        }

        public async Task<ActionResponseData> CreateAction(int projectId, ActionRequest actions)
        {
            try
            {
                
                var RealActions = await actionEntity.CreateAction(projectId, actions);

                if(RealActions.Id == 0) 
                {
                    actionResponseData = new ActionResponseData
                    {
                        Note = null,
                        Description = null
                    };

                    return actionResponseData;
                }
                else 
                {
                    actionResponseData = new ActionResponseData
                    {
                        Note = RealActions.Note,
                        Description = RealActions.Description
                    };
                    return actionResponseData;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //Get all actions
        public async Task<IEnumerable<ActionResponseData>> GetActions() 
        {
            try
            {
                var RealActions = await actionEntity.GetActions();


                List<ActionResponseData> List = new List<ActionResponseData>();

                foreach (var item in RealActions)
                {
                    actionResponseData = new ActionResponseData
                    {
                        Note = item.Note,
                        Description = item.Description
                    };

                    List.Add(actionResponseData);
                }
                return List;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
