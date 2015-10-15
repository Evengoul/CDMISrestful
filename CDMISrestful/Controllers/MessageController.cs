﻿using CDMISrestful.DataModels;
using CDMISrestful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CDMISrestful.CommonLibrary;
using System.Web.Http.OData;

namespace CDMISrestful.Controllers
{
    public class MessageController : ApiController
    {
        static readonly IMessageRepository repository = new MessageRepository();
        /// <summary>
        /// GetSMSDialogue 获取消息对话 GL 2015-10-10
        /// </summary>
        /// <param name="Reciever"></param>
        /// <param name="SendBy"></param>
        /// <returns></returns>
        
        [Route("Api/v1/MessageInfo/messages")]
        [EnableQuery]
        public List<Message> GetSMSDialogue(string Reciever, string SendBy)
        {
            return repository.GetSMSDialogue(Reciever, SendBy);
        }

        /// <summary>
        /// SetSMS 将消息写入数据库或将多条消息设为已读 GL 2015-10-10
        /// </summary>
        /// <param name="SendBy"></param>
        /// <param name="Reciever"></param>
        /// <param name="Content"></param>
        /// <param name="piUserId"></param>
        /// <param name="piTerminalName"></param>
        /// <param name="piTerminalIP"></param>
        /// <param name="piDeviceType"></param>
        /// <returns></returns>
        [Route("Api/v1/MessageInfo/message")]
        public HttpResponseMessage PostSMS(Message item)
        {
            int ret = 0;
            if (item.Content == "") //设为已读
            {
                ret= repository.SetSMSRead(item.Receiver, item.SendBy, item.piUserId, item.piTerminalName, item.piTerminalIP, item.piDeviceType);
            }
            else //写入数据库
            {
                ret= repository.SetSMS(item.SendBy, item.Receiver, item.Content, item.piUserId, item.piTerminalName, item.piTerminalIP, item.piDeviceType);
            }
            return new ExceptionHandler().SetData(Request,ret);
        }

        /// <summary>
        /// GetLatestSMS 获取最新一条消息 GL 2015-10-10
        /// </summary>
        /// <param name="DoctorId"></param>
        /// <param name="PatientId"></param>
        /// <returns></returns>
        [Route("Api/v1/MessageInfo/message")]
        public Message GetLatestSMS(string DoctorId, string PatientId)
        {
            return repository.GetLatestSMS(DoctorId, PatientId);
        }

        /// <summary>
        /// GetSMSCount 获取未读消息数 GL 2015-10-10
        /// </summary>
        /// <param name="Reciever"></param>
        /// <param name="SendBy"></param>
        /// <returns></returns>
        [Route("Api/v1/MessageInfo/messageNum")]
        public HttpResponseMessage GetSMSCount(string Reciever, string SendBy)
        {
            string ret = "0";
            if (SendBy == "")
            {
                ret = repository.GetSMSCountForAll(Reciever).ToString();
            }
            else
            {
                ret =  repository.GetSMSCountForOne(Reciever, SendBy).ToString();
            }
            return new ExceptionHandler().Common(Request, ret);
        }

        /// <summary>
        /// GetSMSList 获取消息联系人列表 GL 2015-10-10
        /// </summary>
        /// <param name="DoctorId"></param>
        /// <param name="CategoryCode"></param>
        /// <returns></returns>
        [Route("Api/v1/MessageInfo/messageContact")]
        [EnableQuery]
        public List<Message> GetSMSList(string DoctorId, string CategoryCode)
        {
            return repository.GetSMSList(DoctorId, CategoryCode);
        }

    }
}
