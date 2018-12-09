﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.ShoppingCart.Norms.Validations.Rules
{
    using Api;

    public class RequisitionsSurveysValidationRule
    {

        public delegate string RequisitionsSurveysValidationCallback(DateTime expiresOn, string surveyId, string entityId);

        public RequisitionsSurveysValidationCallback RequisitionsSurveysCheck;

        public void ActionRequisitionsValidationWorker(IValidationCallbackContainer callback, DateTime expiresOn, string surveyId, string entityId, out string output)
        {
            RequisitionsSurveysCheck = callback.RequisitionsSurveysExpiryDateValidationCallback;
            output = RequisitionsSurveysCheck(expiresOn, surveyId , entityId);
        }
    }
}