using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using CrmEarlyBound;

namespace CrmPackage.Common.Business
{
    #region
    #endregion

   public class AccountService
    {

        private readonly IOrganizationService service;
        private readonly ITracingService tracing;
        private readonly CrmServiceContext serviceContext;
        private readonly Account sourceAccount;

        public AccountService(IOrganizationService service,ITracingService tracing , Guid sourceRecordId)
        {
            this.service = service;
            this.tracing = tracing;
            serviceContext = new CrmServiceContext(service);
            sourceAccount = service.Retrieve(Account.EntityLogicalName,sourceRecordId, new ColumnSet(true)).ToEntity<Account>();
        }


        public void CreateTask(String primaryEntityName)
        {

            tracing.Trace("entered Create Task");
            Entity followup = new Entity("task");

            followup["subject"] = "Send e-mail to the new customer.";
            followup["description"] =
                "Follow up with the customer. Check if there are any new issues that need resolution.";
            followup["scheduledstart"] = DateTime.Now.AddDays(7);
            followup["scheduledend"] = DateTime.Now.AddDays(7);
            followup["category"] = primaryEntityName;

            // Refer to the account in the task activity.
          //  if (localContext.PluginExecutionContext.OutputParameters.Contains("id"))
            {
                Guid regardingobjectid = new Guid(sourceAccount.Id.ToString());
                string regardingobjectidType = "account";

                followup["regardingobjectid"] =
                new EntityReference(regardingobjectidType, regardingobjectid);
            }

            // Create the task in Microsoft Dynamics CRM.
            tracing.Trace("FollowupPlugin: Creating the task activity.");
            service.Create(followup);

        }




    }
}
