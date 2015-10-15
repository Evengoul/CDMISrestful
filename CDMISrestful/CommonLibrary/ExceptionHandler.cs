﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using CDMISrestful.DataModels;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace CDMISrestful.CommonLibrary
{
    public class ExceptionHandler
    {
        public HttpResponseMessage IsUserValid(HttpRequestMessage request, string ret)
        {
            Result res = new Result();
            res.result = ret;
            if (ret == "不合法用户")
            {               
                var resp = request.CreateResponse(HttpStatusCode.BadRequest, res);           
                return resp;
            }
            else
            {
                var resp = request.CreateResponse(HttpStatusCode.OK, res);      
                return resp;
            }
        }

        public HttpResponseMessage SetData(HttpRequestMessage request, int operationResult)
        {
            Result res = new Result();
            res.result = "数据库连接失败";
            //2 数据库连接失败
            var resp = request.CreateResponse(HttpStatusCode.InternalServerError,res);
                   
            switch (operationResult)
            {
                case 1:
                    //数据插入成功
                    res.result = "数据插入成功";
                    resp = request.CreateResponse(HttpStatusCode.OK,res);
                    break;
                case 0:
                    //数据插入失败
                    res.result = "数据插入失败";
                    resp = request.CreateResponse(HttpStatusCode.InternalServerError,res);       
                    break;
                default:
                    break;
            }
            return resp;
        }

        public HttpResponseMessage DeleteData(HttpRequestMessage request, int operationResult)
        {
            Result res = new Result();
            res.result = "数据删除失败";
            //3 数据库连接失败  //0 数据删除失败  
            var resp = request.CreateResponse(HttpStatusCode.InternalServerError, res);          
            switch (operationResult)
            {
                case 1:
                    //数据删除成功
                    res.result = "数据删除成功";
                    resp = request.CreateResponse(HttpStatusCode.OK,res);
                    break;
                case 2:
                    //数据未找到
                    res.result = "数据未找到";
                    resp = request.CreateResponse(HttpStatusCode.NotFound, res);
                    break;
                default:
                    break;
            }
            return resp;
        }

        public HttpResponseMessage LogOn(HttpRequestMessage request,int operationResult)
        {
            //return request.CreateResponse(HttpStatusCode.OK, operationResult);
          
            //resultString = Newtonsoft.Json.JsonConvert.SerializeObject(resultData);
            //HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            //response.Content = new StringContent(resultString);
            #region
            Result res = new Result();
            res.result = "登录失败";

            var resp = request.CreateResponse(HttpStatusCode.InternalServerError, res);
           
          
            //resp.Headers = new HttpResponseMessage().Add("Access-Control-Allow-Origin","*");
            switch (operationResult)
            {
                case 1:
                    //"已注册激活且有权限，登陆成功，跳转到主页";
                    res.result = "登陆成功";
                    resp = request.CreateResponse(HttpStatusCode.OK,res);
                   
                    //resultString = Newtonsoft.Json.JsonConvert.SerializeObject("登陆成功");
                    //resp.Content = new StringContent(string.Format("登陆成功"));
                    break;
                case 2:
                    //"已注册激活 但没有权限";
                    res.result = "没有权限";
                    resp = request.CreateResponse(HttpStatusCode.Forbidden,res);
                  
                    //resultString = Newtonsoft.Json.JsonConvert.SerializeObject("没有权限");
                    //resp.Content = new StringContent(string.Format("没有权限"));
                    break;
                case 3:
                    //您的账号对应的角色未激活，需要先激活；界面跳转到游客页面（已注册但未激活）
                    res.result = "暂未激活";
                    resp = request.CreateResponse(HttpStatusCode.Forbidden,res);
      
                    //resultString = Newtonsoft.Json.JsonConvert.SerializeObject("暂未激活");
                    //resp.Content = new StringContent(string.Format("暂未激活"));
                    break;
                case 4:
                    //"用户不存在";
                    res.result = "用户不存在";
                    resp = request.CreateResponse(HttpStatusCode.BadRequest,res);
                 
                    //resultString = Newtonsoft.Json.JsonConvert.SerializeObject("用户不存在");
                    //resp.Content = new StringContent(string.Format("用户不存在"));
                    break;
                case 5:
                    //"密码错误";
                    res.result = "密码错误";
                    resp = request.CreateResponse(HttpStatusCode.BadRequest,res);
                 
                    //resultString = Newtonsoft.Json.JsonConvert.SerializeObject("密码错误");
                    //resp.Content = new StringContent(string.Format("密码错误"));
                    break;                    
                default:
                    break;
            }
   
            return resp;
            #endregion

        }

        public HttpResponseMessage Register(HttpRequestMessage request, int operationResult)
        {

            Result res = new Result();
            res.result = "注册失败";

            var resp = request.CreateResponse(HttpStatusCode.InternalServerError,res);

            switch (operationResult)
            {
                case 1:
                    res.result = "注册成功";
                    resp = request.CreateResponse(HttpStatusCode.OK,res);            
                    break;
                case 2:
                    res.result = "注册失败";
                    resp = request.CreateResponse(HttpStatusCode.InternalServerError,res);
                    break;
                case 3:
                    res.result = "同一用户名的同一角色已经存在";
                    resp = request.CreateResponse(HttpStatusCode.BadRequest,res);
                    break;
                case 4:
                    res.result = "新建角色成功，密码与您已有账号一致";
                    resp = request.CreateResponse(HttpStatusCode.OK,res);
                    break;               
                default:
                    break;
            }
            return resp;
        }

        public HttpResponseMessage Activation(HttpRequestMessage request, int operationResult)
        {
            Result res = new Result();
            res.result = "激活失败";
            var resp = request.CreateResponse(HttpStatusCode.InternalServerError,res);

            switch (operationResult)
            {
                case 1:
                    res.result = "激活成功";
             resp = request.CreateResponse(HttpStatusCode.OK,res);

               
                    break;
                case 2:
                    res.result = "激活失败";
                    resp = request.CreateResponse(HttpStatusCode.InternalServerError, res);


                    break;
                default:
                    break;
            }
            return resp;
        }

        public HttpResponseMessage ChangePassword(HttpRequestMessage request, int operationResult)
        {
            Result res = new Result();
            res.result = "修改密码失败";

            var resp = request.CreateResponse(HttpStatusCode.InternalServerError, res);

            switch (operationResult)
            {
                case 1:
                    res.result = "修改密码成功";
                    resp = request.CreateResponse(HttpStatusCode.OK, res);                 
                    break;
                case 2:
                    res.result = "修改密码失败";
                    resp = request.CreateResponse(HttpStatusCode.InternalServerError, res);     
                    break;
                case 3:
                    res.result = "旧密码错误，请输入正确的旧密码";
                    resp = request.CreateResponse(HttpStatusCode.BadRequest, res);        
                    break;
                case 4:
                    res.result = "密码已过期，请联系管理员重置密码";
                    resp = request.CreateResponse(HttpStatusCode.BadRequest, res); 
                    break;              
                default:
                    break;
            }
            return resp;
        }
        public HttpResponseMessage Verification(HttpRequestMessage request, int operationResult)
        {
            Result res = new Result();
            res.result = "用户名验证失败";

            var resp = request.CreateResponse(HttpStatusCode.InternalServerError, res);

            switch (operationResult)
            {
                case 1:
                    res.result = "用户存在";
                    resp = request.CreateResponse(HttpStatusCode.OK, res);                 
                    break;
                case 2:
                    res.result = "用户不存在";
                    resp = request.CreateResponse(HttpStatusCode.OK, res);                       
                    break;                   
                default:
                    break;
            }
            return resp;
        }
      
        //public HttpResponseMessage Common(SignDetailByP ret)
        //{
        //    var resp = new HttpResponseMessage(HttpStatusCode.OK);
        //    resp.Content = new JsonContent(ret);
        //    return resp;
        //}
    }
}
                       
        