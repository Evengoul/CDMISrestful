﻿using CDMISrestful.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDMISrestful.Models
{
    public interface IRiskInfoRepository
    {
        string GetValueByPlanNoAndId(string PlanNo, string Id);

        string GetDescription(int SBP);
        int SetRiskResult(string UserId, string AssessmentType, string AssessmentName, DateTime AssessmentTime, string Result, string revUserId, string TerminalName, string TerminalIP, int DeviceType);

        string GetRiskResult(string UserId);
        RiskInput GetRiskInput(string UserId);
    }
}