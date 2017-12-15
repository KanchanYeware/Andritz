using Andritz.RTP.Utilities;
using Andritz.RTP.Utilities.Common;
using Andritz.RTP.Utilities.Extensions;
using Andritz.RTP.Utilities.Resources;
using Andritz.RTPApplication.Core;
using Andritz.RTPApplication.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace Andritz.RTPApplication.WebApi.Controllers
{
    public class TestController : ApiController
    {
        #region Variable Declarations
        private readonly ITestService _testService;
        private readonly ICommonUtils _commonUtils; 
        #endregion

        #region Region for Authentication Request Token variables      
        private IEnumerable<string> headerValues;
        #endregion

        #region Consructor
        public TestController(ITestService testService, ICommonUtils commonUtils)
        {
            _testService = testService;
            _commonUtils = commonUtils;
        }
        #endregion

        #region Get Webapi
        /// <summary>
        /// get list for test
        /// </summary>
        /// <param name="request"></param>
        /// <param name="trainerId"></param>
        /// <param name="areaId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetTestList(HttpRequestMessage request, int trainerId, int areaId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.GetTestList(trainerId, areaId);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetTestList, null, 0);
        }

        /// <summary>
        /// get list for all snapshot list by areaId
        /// </summary>
        /// <param name="request"></param>
        /// <param name="areaId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetSnapshotList(HttpRequestMessage request, int areaId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.GetSnapshotList(areaId);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetSnapList, null, 0);
        }

        /// <summary>
        /// get list for all malfunction list by areaId
        /// </summary>
        /// <param name="request"></param>
        /// <param name="areaId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetMalfunctionList(HttpRequestMessage request, int areaId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.GetMalfunctionList(areaId);              
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetMalfunList, null, 0);
        }

        /// <summary>
        /// get list for all course and lessons by passing areaId to it.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="areaId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetCoursesAndLessons(HttpRequestMessage request, int areaId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.GetCoursesAndLessons(areaId);                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetCourseLessonByAreaId, null, 0);
        }

        /// <summary>
        /// Get TagEvaluationMethod list for test
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetTagEvaluationMethodList(HttpRequestMessage request)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.GetTagEvaluationMethodList();                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetTagEvalMethodList, null, 0);
        }

        /// <summary>
        /// get list of trainer and operator
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetTrainerOperatorList(HttpRequestMessage request)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.GetTrainerOperatorList();               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetTrainerOperatorList, null, 0);
        }
        /// <summary>
        /// get value of test by Id - For Update Test
        /// </summary>
        /// <param name="request"></param>
        /// <param name="testId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetTestById(HttpRequestMessage request, int testId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.GetTestById(testId);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetTestList, null, 0);
        }

        /// <summary>
        /// Get list of Grading Tags
        /// </summary>
        /// <param name="request"></param>     
        /// <param name="tagList"> get tagList response from bridgeX</param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse GetGradingTags(HttpRequestMessage request, ApiResponse tagList)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.GetGradingTags(tagList);                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetGradingTagList, null, 0);
        }

        /// <summary>
        /// Test execute assigned to operators List
        /// </summary>
        /// <param name="request"></param>
        /// <param name="testIds"></param>
        /// <param name="trainerId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetTestExecuteAssignToOpearotrsList(HttpRequestMessage request, string testIds, string trainerId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                List<int> testId = new List<int>(System.Array.ConvertAll(testIds.Split(','), int.Parse));

                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.GetTestExecuteAssignToOpearotrsList(testId, int.Parse(trainerId));               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetTestExecuteList, null, 0);
        }

        /// <summary>
        /// get test with assigned trianer list with OperatorCount
        /// </summary>
        /// <param name="request"></param>
        /// <param name="testId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetTestWithAssignedTrainers(HttpRequestMessage request, int testId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.GetTestWithAssignedTrainers(testId);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetTrainerOperatorList, null, 0);
        }

        /// <summary>
        /// Get all testdescription detail List
        /// </summary>
        /// <param name="request"></param>
        /// <param name="testId"></param>
        /// <param name="LoginUserId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetTestDetails(HttpRequestMessage request, int testId, int LoginUserId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.GetTestDetails(testId, LoginUserId);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetTestDetails, null, 0);
        }
        /// <summary>
        /// get list of test assigned trainer and operator
        /// </summary>
        /// <param name="testId"></param>
        /// <param name="request"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetTestAssignedTrainerOperatorList(HttpRequestMessage request, int testId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.GetTestAssignedTrainerOperatorList(testId);                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetTrainerOperatorList, null, 0);
        }

        /// <summary>
        /// gel list of all tests by operator Id(s)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="operatorIds"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetAllTestsByOperatorId(HttpRequestMessage request, string operatorIds, int areaId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.GetAllTestsByOperatorId(operatorIds, areaId);              
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetTrainerOperatorList, null, 0);
        }

        /// <summary>
        /// Get list for TestExecutionStatus
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetTestExecutionStatus(HttpRequestMessage request)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.GetTestExecutionStatus();              
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetTrainerOperatorList, null, 0);
        }

        /// <summary>
        /// get TagArrayTimeStamp by testId and testExeutionId
        /// </summary>
        /// <param name="request"></param>
        /// <param name="testId"></param>
        /// <param name="testExecutionId"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiResponse GetTagArrayTimestamp(HttpRequestMessage request, int testId, int testExecutionId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.GetTagArrayTimestamp(testId, testExecutionId);                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_Fail, null, 0);
        }

        #endregion

        #region Add Webapi
        /// <summary>
        /// Save for test
        /// </summary>
        /// <param name="request"></param>
        /// <param name="testEntity"></param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse AddTest(HttpRequestMessage request, TestEntity testEntity)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.AddTest(testEntity);                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotSaveTest, null, 0);
        }

        /// <summary>
        /// Add trainer operator list in TestAllocation table by passing testId - [Single Assign Test]
        /// </summary>     
        /// <param name="request"></param>
        /// <param name="testTrainerOperEntity"></param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse AddSingleAssignedOperators(HttpRequestMessage request, IEnumerable<TestTrainerOperator> testTrainerOperEntity)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.AddSingleAssignedOperators(testTrainerOperEntity);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotAssignTranOperToTest, null, 0);
        }

        /// <summary>
        /// Add or update testexecute table
        /// </summary>
        /// <param name="request"></param>
        /// <param name="testExecuteEntity"></param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse AddUpdateTestExecute(HttpRequestMessage request, TestExecuteEntity testExecuteEntity)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.AddUpdateTestExecute(testExecuteEntity);                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotSaveAddUpdateTestExecute, null, 0);
        }

        /// <summary>
        /// Add trainer operator list in TestAllocation table by passing testId List - [Multiple Assign for Test]
        /// </summary>     
        /// <param name="request"></param>
        ///<param name="data"> for multiple parameters in Post use dada - dynamic type</param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse AddMultipleAssignedOperators(HttpRequestMessage request, dynamic data)
        {
            List<int> testIdList = JsonConvert.DeserializeObject<List<int>>(data.testIdList.ToString());
            IEnumerable<TestTrainerOperator> testTrainerOprEntity = JsonConvert.DeserializeObject<IEnumerable<TestTrainerOperator>>(data.testTrainerOprEntity.ToString());

            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.AddMultipleAssignedOperators(testIdList, testTrainerOprEntity);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotAssignTranOperToTest, null, 0);
        }
        #endregion

        #region Update Webapi
        /// <summary>
        ///update data for test in multiple tables - Test,TestSnapshot,TestMalfunction,TestGradingTag
        /// </summary>     
        /// <param name="request"></param>
        /// <param name="testEntity"></param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse UpdateTest(HttpRequestMessage request, TestEntity testEntity)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.UpdateTest(testEntity);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotUpdateTest, null, 0);
        }

        /// <summary>
        /// When test has been failed at any stage - It changed in Incomplete State - Save in testExecution table
        /// </summary>
        /// <param name="testExecutionId"></param>
        /// <param name="errorMessage"></param>
        /// <param name="exceptionMessage"></param>
        /// <returns>ApiResponse</returns>
        [HttpPut]
        public ApiResponse TestIncomplete(HttpRequestMessage request, int testExecutionId, string errorMessage, string exceptionMessage)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.TestIncomplete(testExecutionId, errorMessage, exceptionMessage);                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_Fail, null, 0);
        }
        #endregion

        #region Delete Webapi
        /// <summary>
        /// delete test from table
        /// </summary>
        /// <param name="request"></param>
        /// <param name="TestIdList"></param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse DeleteTest(HttpRequestMessage request, List<int> TestIdList)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.DeleteTest(TestIdList);              
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotDeleteTest, null, 0);
        }
        #endregion

        #region Test Playback Backtrack Webapi
        /// <summary>
        /// Update test Execution table when playback is in stopped mode
        /// </summary>       
        /// <param name="request"></param>
        /// <param name="testExecuteListEntity"></param>
        /// <returns>ApiResponse</returns>   
        [HttpPut]
        public ApiResponse StartTestPlaybackBacktrack(HttpRequestMessage request, TestExecuteList testExecuteListEntity)
        {
            try
            {
                if (request.Headers.TryGetValues("Auth_Token", out headerValues))
                {
                    CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                    return _testService.StartTestPlaybackBacktrack(testExecuteListEntity);                  
                }
                return _commonUtils.ReturnValues(false, Resources.Msg_StartTestPlayback_Fail, null, 0);
            }
            catch (Exception ex)
            {
                LoggingExtensions.LogException("StartTestPlaybackBacktrack", ex);
                return _commonUtils.ReturnValues(false, Resources.Msg_StartTestPlayback_Fail, null, 0);
            }
        }

        /// <summary>
        /// Update test Execution table when playback is in stopped mode
        /// </summary>      
        /// <param name="request"></param>
        /// <param name="testExecutionId"></param>
        /// <returns>ApiResponse</returns>  
        [HttpPut]
        public ApiResponse StopTestPlaybackBacktrack(HttpRequestMessage request, int testExecutionId)
        {
            try
            {
                if (request.Headers.TryGetValues("Auth_Token", out headerValues))
                {
                    CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                    return _testService.StopTestPlaybackBacktrack(testExecutionId);                   
                }
                return _commonUtils.ReturnValues(false, Resources.Msg_StopTestPlayback_Fail, null, 0);
            }
            catch (Exception ex)
            {
                LoggingExtensions.LogException("StopTestPlaybackBacktrack", ex);
                return _commonUtils.ReturnValues(false, Resources.Msg_StopTestPlayback_Fail, null, 0);
            }
        }

        /// <summary>
        /// Chcek If test playbacktrack is already started - then restrict to start it again till first one is completed
        /// </summary>
        /// <param name="request"></param>
        /// <param name="mappingKey"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse IsTestPlaybackAlreadyStarted(HttpRequestMessage request, int mappingKey)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.IsTestPlaybackAlreadyStarted(mappingKey);                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_Fail, null, 0);
        }

        /// <summary>
        /// Update testExecution table when it is rewind or forward
        /// </summary>
        /// <param name="request"></param>
        /// <param name="testExecutionId"></param>
        /// <param name="actualDuration"></param>
        /// <returns>ApiResponse</returns>      
        [HttpPut]
        public ApiResponse RewindAndForwardTestPlayback(HttpRequestMessage request, double actualDuration, int testExecutionId)
        {
            try
            {
                if (request.Headers.TryGetValues("Auth_Token", out headerValues))
                {
                    CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                    return _testService.RewindAndForwardTestPlayback(actualDuration, testExecutionId);                  
                }
                return _commonUtils.ReturnValues(false, Resources.Msg_RewindForwardTestPlayback_Fail, null, 0);
            }
            catch (Exception ex)
            {
                LoggingExtensions.LogException("RewindAndForwardTestPlayback", ex);
                return _commonUtils.ReturnValues(false, Resources.Msg_RewindForwardTestPlayback_Fail, null, 0);
            }
        }
        #endregion

        #region Other Webapi
        /// <summary>
        /// Chcek If Test execution is already started - then restrict to start it again till first one is completed
        /// </summary>
        /// <param name="request"></param>
        /// <param name="mappingKey"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse IsSimulationAlreadyStarted(HttpRequestMessage request, int mappingKey)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.IsSimulationAlreadyStarted(mappingKey);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_Fail, null, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="tagArrayTimeStamp"></param>
        /// <param name="testId"></param>
        /// <param name="tagEvaluationMethodId"></param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse TestGrade(HttpRequestMessage request, ApiResponse tagHistoryByTimeRange, int testId, int testExecutionId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.TestGrade(tagHistoryByTimeRange, testId, testExecutionId);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_TestStopGradeIncomplete, null, 0);
        }

        /// <summary>
        /// Test Grade service - For testing grade [not used in application]
        /// </summary>
        /// <param name="request"></param>
        /// <param name="tagArrayTimeStamp"></param>
        /// <param name="testId"></param>
        /// <param name="tagEvaluationMethodId"></param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse TestGrade1(HttpRequestMessage request, ApiResponse tagHistoryByTimeRange, int testId, int testExecutionId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.TestGrade1(tagHistoryByTimeRange, testId, testExecutionId);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotAssignTranOperToTest, null, 0);
        }

        /// <summary>
        /// Chcek If Test execution is already started - then restrict to start it again till first one is completed
        /// </summary>
        /// <param name="request"></param>
        /// <param name="mappingKey"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse IsTestExecuteAlreadyStartedForArea(HttpRequestMessage request, int mappingKey)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.IsTestExecuteAlreadyStartedForArea(mappingKey);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_Fail, null, 0);
        }

        /// <summary>
        /// Unassign User - Delete test allocation from TestAllocation table and TestExecution table
        /// </summary>
        /// <param name="request"></param>
        /// <param name="testAllocationId"></param>
        /// <returns>ApiResponse</returns>
        [HttpPut]
        public ApiResponse UnassignTestUser(HttpRequestMessage request, int testAllocationId, int testId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.UnassignTestUser(testAllocationId, testId);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_UserUnassignedFail, null, 0);
        }

        /// <summary>
        /// check If Test execution is record is already exist - with testexecutionstatusId [Not_started]
        /// </summary>
        /// <param name="request"></param>
        /// <param name="testExecutionId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse CheckIfTestExecutionRecordIsAlreadyExist(HttpRequestMessage request, int testExecutionId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.CheckIfTestExecutionRecordIsAlreadyExist(testExecutionId);              
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_Fail, null, 0);
        }
        #endregion

        #region Methods for Notification

        /// <summary>
        /// Get Test details for Notification
        /// </summary>
        /// <param name="request"></param>
        /// <param name="trainerId"></param>        
        /// <param name="testId"></param>
        /// <returns>List<Notification></returns>
        [HttpGet]
        public ApiResponse GetTestListForNotification(HttpRequestMessage request, int trainerId,int testId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.GetTestListForNotification(trainerId, testId);             
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotificationError, null, 0);
        }

        /// <summary>
        /// Update NotificationReadDate in User Table
        /// </summary>
        /// <param name="trainerId"></param>
        /// <returns>ApiResponse</returns>
        [HttpPut]
        public ApiResponse UpdateNotificationReadDate(HttpRequestMessage request, int trainerId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.UpdateNotificationReadDate(trainerId);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_Fail, null, 0);
        }
        #endregion

        /// <summary>
        /// For test Purpose
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpGet]
        public List<TestExecutionEntity> GetStoppedTestExecutionAndAreaSimulationList(HttpRequestMessage request, int mappingKey, int testExecutionId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _testService.GetStoppedTestExecutionAndAreaSimulationList(mappingKey,testExecutionId);
            }
            return null;
        }

    }
}
