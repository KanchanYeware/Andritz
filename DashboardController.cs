using Andritz.RTP.Utilities;
using Andritz.RTP.Utilities.Common;
using Andritz.RTP.Utilities.Resources;
using Andritz.RTPApplication.Core;
using Andritz.RTPApplication.Entities;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Web.Http;

namespace Andritz.RTPApplication.WebApi.Controllers
{
    public class DashboardController : ApiController
    {
        private readonly IDashboardService _dashboardService;
        private readonly ICommonUtils _commonUtils;
        #region Region for Authentication Request Token variables      
        private IEnumerable<string> headerValues;
        #endregion
        public DashboardController(IDashboardService dashboardService, ICommonUtils commonUtils)
        {
            _dashboardService = dashboardService;
            _commonUtils = commonUtils;
        }


        /// <summary>
        /// get operator dashboard
        /// </summary>
        /// <param name="request"></param>
        /// <param name="areaId">area Id</param>
        /// <param name="startDate">date rage - start date</param>
        /// <param name="endDate">date rage - end date</param>
        /// <param name="operatorIds">comma seperated operatorId's </param>
        /// <returns></returns>
        [HttpGet]
        public ApiResponse GetOperatorDashboard(HttpRequestMessage request, int areaId, string startDate, string endDate, string operatorIds)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                var operatorDashboard = _dashboardService.GetOperatorDashboard(areaId,startDate,endDate,operatorIds);
                return operatorDashboard;
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotgetOperatorDashboard, null, 0);
        }

        /// <summary>
        /// Get dashboard test status entity only for dashboard report
        /// </summary>
        /// <param name="request"></param>
        /// <param name="areaId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="operatorIds"></param>
        /// <param name="courseName"></param>
        /// <param name="testName"></param>
        /// <param name="statusName"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiResponse GetOperatorTestStatusEntity(HttpRequestMessage request, int areaId, string startDate, string endDate, string operatorIds, string courseName = "", string testName = "", string statusName = "")
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                courseName = string.IsNullOrEmpty(courseName) ? string.Empty : courseName;
                testName = string.IsNullOrEmpty(testName) ? string.Empty : testName;
                statusName = string.IsNullOrEmpty(statusName) ? string.Empty : statusName;

                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                var operatorTestStatusDashboard = _dashboardService.GetOperatorTestStatusEntity(areaId, startDate, endDate, operatorIds, courseName, testName, statusName);
                return operatorTestStatusDashboard;
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotgetOperatorDashboard, null, 0);
        }

        /// <summary>
        /// get operator dashboard filter by course name
        /// </summary>
        /// <param name="request"></param>
        /// <param name="areaId">area Id</param>
        /// <param name="startDate">date rage - start date</param>
        /// <param name="endDate">date rage - end date</param>
        /// <param name="operatorIds">comma seperated operatorId's </param>
        /// <param name="courseName">Course Name </param>
        /// <returns></returns>
        [HttpGet]
        public ApiResponse GetOperatorDashboardFilterByCourseName(HttpRequestMessage request, int areaId, string startDate, string endDate, string operatorIds,string courseName)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                var operatorDashboard = _dashboardService.GetOperatorDashboardFilterByCourseName(areaId, startDate, endDate, operatorIds,courseName);
                return operatorDashboard;
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotgetOperatorDashboard, null, 0);
        }

        /// <summary>
        /// get operator dashboard filter by test name
        /// </summary>
        /// <param name="request"></param>
        /// <param name="areaId">area Id</param>
        /// <param name="startDate">date rage - start date</param>
        /// <param name="endDate">date rage - end date</param>
        /// <param name="operatorIds">comma seperated operatorId's </param>
        /// <param name="testName">Test Name </param>
        /// <returns></returns>
        [HttpGet]
        public ApiResponse GetOperatorDashboardFilterByTestName(HttpRequestMessage request, int areaId, string startDate, string endDate, string operatorIds,string testName)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                var operatorDashboard = _dashboardService.GetOperatorDashboardFilterByTestName(areaId, startDate, endDate, operatorIds,testName);
                return operatorDashboard;
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotgetOperatorDashboard, null, 0);
        }

        /// <summary>
        /// get operator dashboard filter by status
        /// </summary>
        /// <param name="request"></param>
        /// <param name="areaId">area Id</param>
        /// <param name="startDate">date rage - start date</param>
        /// <param name="endDate">date rage - end date</param>
        /// <param name="operatorIds">comma seperated operatorId's </param>
        /// <param name="status">Status</param>
        /// <returns></returns>
        [HttpGet]
        public ApiResponse GetOperatorDashboardFilterByStatus(HttpRequestMessage request, int areaId, string startDate, string endDate, string operatorIds,string status)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                var operatorDashboard = _dashboardService.GetOperatorDashboardFilterByStatus(areaId, startDate, endDate, operatorIds,status);
                return operatorDashboard;
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotgetOperatorDashboard, null, 0);
        }

        /// <summary>
        /// get trainer daashboard
        /// </summary>
        /// <param name="request"></param>
        /// <param name="areaId">area Id</param>
        /// <param name="startDate">date rage - start date</param>
        /// <param name="endDate">date rage - end date</param>
        /// <param name="trainerIds">comma seperated trainerId's </param>
        /// <param name="operatorIds">comma seperated operatorId's </param>
        /// <returns></returns>
        [HttpGet]
        public ApiResponse GetTrainerDashboard(HttpRequestMessage request, int areaId, string startDate, string endDate, string trainerIds, string operatorIds)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                var trainerDashboard = _dashboardService.GetTrainerDashbaord(areaId, startDate, endDate, trainerIds, operatorIds);
                return trainerDashboard;
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotgetTrainerDashbaord, null, 0);
        }

        /// <summary>
        /// get trainer daashboard filter by Course Name
        /// </summary>
        /// <param name="request"></param>
        /// <param name="areaId">area Id</param>
        /// <param name="startDate">date rage - start date</param>
        /// <param name="endDate">date rage - end date</param>
        /// <param name="trainerIds">comma seperated trainerId's </param>
        /// <param name="operatorIds">comma seperated operatorId's </param>
        /// <param name="courseName">Course Name </param>
        /// <returns></returns>
        [HttpGet]
        public ApiResponse GetTrainerDashboardFilterByCourseName(HttpRequestMessage request, int areaId, string startDate, string endDate, string trainerIds, string operatorIds,string courseName)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                var trainerDashboard = _dashboardService.GetTrainerDashbaordFilterByCourseName(areaId, startDate, endDate, trainerIds, operatorIds,courseName);
                return trainerDashboard;
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotgetTrainerDashbaord, null, 0);
        }

        /// <summary>
        /// get trainer daashboard filter by Status
        /// </summary>
        /// <param name="request"></param>
        /// <param name="areaId">area Id</param>
        /// <param name="startDate">date rage - start date</param>
        /// <param name="endDate">date rage - end date</param>
        /// <param name="trainerIds">comma seperated trainerId's </param>
        /// <param name="operatorIds">comma seperated operatorId's </param>
        /// <param name="status">status </param>
        /// <returns></returns>
        [HttpGet]
        public ApiResponse GetTrainerDashboardFilterByStatus(HttpRequestMessage request, int areaId, string startDate, string endDate, string trainerIds, string operatorIds, string status)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                var trainerDashboard = _dashboardService.GetTrainerDashbaordFilterByStatus(areaId, startDate, endDate, trainerIds, operatorIds, status);
                return trainerDashboard;
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotgetTrainerDashbaord, null, 0);
        }

        /// <summary>
        /// get trainer daashboard filter by Test Name
        /// </summary>
        /// <param name="request"></param>
        /// <param name="areaId">area Id</param>
        /// <param name="startDate">date rage - start date</param>
        /// <param name="endDate">date rage - end date</param>
        /// <param name="trainerIds">comma seperated trainerId's </param>
        /// <param name="operatorIds">comma seperated operatorId's </param>
        /// <param name="testName">Test Name </param>
        /// <returns></returns>
        [HttpGet]
        public ApiResponse GetTrainerDashboardFilterByTestName(HttpRequestMessage request, int areaId, string startDate, string endDate, string trainerIds, string operatorIds, string testName)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                var trainerDashboard = _dashboardService.GetTrainerDashbaordFilterByTestName(areaId, startDate, endDate, trainerIds, operatorIds, testName);
                return trainerDashboard;
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotgetTrainerDashbaord, null, 0);
        }

        /// <summary>
        /// get list of trainer and operator from TestAllocation table
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetTrainerOperatorList(HttpRequestMessage request)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                var trainerOperatorList = _dashboardService.GetTrainerOperatorList();
                return trainerOperatorList;
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetTrainerOperatorList, null, 0);
        }

        /// <summary>
        /// Get operator list
        /// </summary>
        /// <param name="request"></param>
        /// <returns>list of operators</returns>
        [HttpGet]
        public ApiResponse GetOperatorList(HttpRequestMessage request)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                var operatorList = _dashboardService.GetOperatorList();
                return operatorList;
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetTrainerOperatorList, null, 0);
        }

        /// <summary>
        ///  Get list of heartbeat data
        /// </summary>
        /// <param name="request"></param>
        /// <returns>list of heartbeat</returns>
        [HttpGet]
        public ApiResponse GetHeartBeat(HttpRequestMessage request)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                var heartbeatList = _dashboardService.GetHeartBeat();
                HeartBeatMessagesRepository obj = new HeartBeatMessagesRepository();
                obj.GetAllHeartBeatNotifications();
                return heartbeatList;
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_GetTrainerOperatorList, null, 0);
        }
    }

    public class HeartBeatMessagesRepository
    {
        readonly string _connString = ConfigurationManager.ConnectionStrings["AndritzRTPDbContextForNotification"].ConnectionString;
        internal static SqlCommand command = null;
        internal static SqlDependency dependency = null;
        public IEnumerable<HeartBeatEntity> GetAllHeartBeatNotifications()
        {
            var messages = new List<HeartBeatEntity>();
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                using (command = new SqlCommand(@"SELECT [Id], [ProcessName], [ProcessID], [HeartBeatProcessTypeId], [ProcessStatusId], [AreaID], [ProcessData]
                                                      FROM  [dbo].[Heartbeat]", connection))
                {
                    command.Notification = null;
                    if (dependency == null)
                    {
                        dependency = new SqlDependency(command);
                        dependency.OnChange += new OnChangeEventHandler(heartbeatDependency_OnChange);
                    }
                    if (connection.State == System.Data.ConnectionState.Closed)
                        connection.Open();

                    var reader = command.ExecuteReader();

                    /*while (reader.Read())
                    {
                        messages.Add(item: new HeartBeatEntity
                        {
                            Id = (int)reader["Id"],
                            ProcessName = reader["ProcessName"]== DBNull.Value ?"":(string)reader["ProcessName"],
                            ProcessID = reader["ProcessID"] == DBNull.Value ? -1 : (int)reader["ProcessID"],
                            HeartBeatProcessTypeId = (int)reader["HeartBeatProcessTypeId"],
                            ProcessStatusId = reader["ProcessStatusId"] == DBNull.Value ? -1 : (int)reader["ProcessStatusId"],
                            AreaID = reader["AreaID"] == DBNull.Value ? -1 : (int)reader["AreaID"],
                            ProcessData = reader["ProcessData"] == DBNull.Value ? "" : (string)reader["ProcessData"],
                        });
                    //EmptyMessage = reader["EmptyMessage"] != DBNull.Value ? (string)reader["EmptyMessage"] : "", MessageDate = Convert.ToDateTime(reader["Date"]) });
                    }*/
                }

            }
            return messages;


        }

        private void heartbeatDependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (dependency != null)
            {
                dependency.OnChange -= heartbeatDependency_OnChange;
                dependency = null;
            }
            if (e.Info == SqlNotificationInfo.Insert || e.Info==SqlNotificationInfo.Update)//e.Info==SqlNotificationInfo.Insert //&& e.Type == SqlNotificationType.Change
            {
                //MessagesHub.SendMessages();
                CallSignalRToUpdateHeartBeatDashboard();                
            }
           
        }
       private static IHubProxy messageHub;
        private static HubConnection connection;
        private static string WebApplicationURL = System.Configuration.ConfigurationManager.AppSettings["WebApplicationURL"].ToString();
        private void CallSignalRToUpdateHeartBeatDashboard()
        {
            try
            {
                connection = new HubConnection(WebApplicationURL);
                messageHub = connection.CreateHubProxy("MessageHub");
                connection.Start().Wait();
                if (messageHub != null)
                {
                    messageHub.Invoke("HandleUpdateHeartBeatDashboard","");
                }
                connection.Stop();
            }
            catch (Exception ex)
            {

            }
        } /**/
    }
}
