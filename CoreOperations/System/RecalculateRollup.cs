﻿using System.Activities;
using Microsoft.Xrm.Sdk.Workflow;
using Microsoft.Crm.Sdk.Messages;
using UltimateWorkflowToolkit.Common;

namespace UltimateWorkflowToolkit.CoreOperations.System
{
    public class RecalculateRollup : CrmWorkflowBase
    {
        #region Input/Output Arguments

        [Input("Record Reference")]
        [RequiredArgument]
        public InArgument<string> Record { get; set; }

        [Input("Rollup Field Name")]
        [RequiredArgument]
        public InArgument<string> FieldName { get; set; }

        #endregion Input/Output Arguments

        protected override void ExecuteWorkflowLogic()
        {
            var target = ConvertToEntityReference(Record.Get(Context.ExecutionContext));

            Context.SystemService.Execute(new CalculateRollupFieldRequest()
            {
                FieldName = FieldName.Get(Context.ExecutionContext),
                Target = target
            });
        }
    }
}
