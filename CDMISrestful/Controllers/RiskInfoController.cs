﻿using CDMISrestful.CommonLibrary;
using CDMISrestful.DataModels;
using CDMISrestful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CDMISrestful.Controllers
{
    public class RiskInfoController : ApiController
    {
        static readonly IRiskInfoRepository repository = new RiskInfoRepository();
        /// <summary>
        /// 获取某计划下某任务的目标值 LY 2015-10-13
        /// </summary>
        /// <param name="PlanNo"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("Api/v1/RiskInfo/Plan/{PlanNo}/Task/{Id}")]
        public HttpResponseMessage GetValueByPlanNoAndId(string PlanNo, string Id)
        {
            string ret = repository.GetValueByPlanNoAndId(PlanNo, Id);
            return new ExceptionHandler().Common(Request, ret);
        }


        /// <summary>
        /// 根据收缩压获取血压等级说明 LY 2015-10-13
        /// </summary>
        /// <param name="SBP"></param>
        /// <returns></returns>
        [Route("Api/v1/RiskInfo/GetDescription")]
        public HttpResponseMessage GetDescription(int SBP)
        {
            string ret = repository.GetDescription(SBP);
            return new ExceptionHandler().Common(Request, ret);
        }

        /// <summary>
        /// 插入风险评估结果 LY 2015-10-13
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="AssessmentType"></param>
        /// <param name="AssessmentName"></param>
        /// <param name="AssessmentTime"></param>
        /// <param name="Result"></param>
        /// <param name="revUserId"></param>
        /// <param name="TerminalName"></param>
        /// <param name="TerminalIP"></param>
        /// <param name="DeviceType"></param>
        /// <returns></returns>

        [Route("Api/v1/RiskInfo/RiskResult")]
        [ModelValidationFilter]
        public HttpResponseMessage PostRiskResult(RiskResult Item)
        {
            int ret = repository.SetRiskResult(Item.UserId, Item.AssessmentType, Item.AssessmentName, Item.AssessmentTime, Item.Result, Item.revUserId, Item.TerminalName, Item.TerminalIP, Item.DeviceType);
            return new ExceptionHandler().SetData(Request, ret);
        }

     

        /// <summary>
        /// 根据UserId获取最新风险评估结果 LY 2015-10-13
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [Route("Api/v1/RiskInfo/RiskResult")]
        public HttpResponseMessage GetRiskResult(string UserId)
        {
            string ret = repository.GetRiskResult(UserId);
            return new ExceptionHandler().Common(Request, ret);
        }

        /// <summary>
        /// 获取风险评估所需输入 LY 2015-10-13
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [Route("Api/v1/RiskInfo/RiskInput")]
        public RiskInput GetRiskInput(string UserId)
        {
            return repository.GetRiskInput(UserId);
        }
    }
}
