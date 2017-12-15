using Andritz.RTP.Utilities;
using Andritz.RTP.Utilities.Common;
using Andritz.RTP.Utilities.Resources;
using Andritz.RTPApplication.Core;
using Andritz.RTPApplication.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace Andritz.RTPApplication.WebApi.Controllers
{
    public class CourseStructureConfigController : ApiController
    {
        #region Variable Declarations
        private readonly ICourseStructureConfiguration _courseStructureConfig;
        private readonly ICommonUtils _commonUtils;
        #endregion

        #region Region for Authentication Request Token variables      
        private IEnumerable<string> headerValues;
        #endregion

        #region Constructor
        public CourseStructureConfigController(ICourseStructureConfiguration courseStructureConfig, ICommonUtils commonUtils)
        {
            _courseStructureConfig = courseStructureConfig;
            _commonUtils = commonUtils;
        }
        #endregion

        #region Get Webapi
        /// <summary>
        /// get list for all malfunction list
        /// </summary>
        /// <param name="request"></param>        
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetAreaList(HttpRequestMessage request)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _courseStructureConfig.GetAreaList();               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotgetAreaList, null, 0);
        }

        /// <summary>
        /// get list of Courses by passing areaId
        /// </summary>
        /// <param name="request"></param>
        /// <param name="AreaId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetCourseList(HttpRequestMessage request, int AreaId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _courseStructureConfig.GetCourseList(AreaId);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotgetCourseList, null, 0);
        }

        /// <summary>
        /// get list of Lessons by passing CourseId
        /// </summary>
        /// <param name="request"></param>
        /// <param name="CourseId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetLessonList(HttpRequestMessage request, int CourseId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _courseStructureConfig.GetLessonList(CourseId);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotgetLessonList, null, 0);
        }

        /// <summary>
        /// get Course by Id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="courseId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetCourseById(HttpRequestMessage request, int courseId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _courseStructureConfig.GetCourseById(courseId);                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotgetCourseList, null, 0);
        }

        /// <summary>
        /// get lesson by Id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="lessonId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetLessonById(HttpRequestMessage request, int lessonId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _courseStructureConfig.GetLessonById(lessonId);                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotgetLessonList, null, 0);
        }

        /// <summary>
        /// Get list of Activated Data - Area Start simulation data, Activated Malfunction, Loaded Snapshot
        /// </summary>
        /// <param name="request"></param>
        /// <param name="mappingKey"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetActivatedDataListbyArea(HttpRequestMessage request, int mappingKey)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _courseStructureConfig.GetActivatedDataListbyArea(mappingKey);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_GetActivateddataFail, null, 0);
        }

        #endregion

        #region Add Webapi
        /// <summary>
        /// save the course
        /// </summary>
        /// <param name="request"></param>
        /// <param name="courseEntity"></param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse AddCourse(HttpRequestMessage request, CourseStructureEntity courseEntity)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _courseStructureConfig.AddCourse(courseEntity);                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotSaveCourse, null, 0);
        }

        /// <summary>
        /// save lesson in table
        /// </summary>
        /// <param name="request"></param>
        /// <param name="courseEntity"></param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse AddLesson(HttpRequestMessage request, CourseStructureEntity courseEntity)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _courseStructureConfig.AddLesson(courseEntity);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotSaveLesson, null, 0);
        }

        /// <summary>
        /// When Area List is not found in database - Then fetch it from BridgeX and save into Area Table
        /// </summary>
        /// <param name="request"></param>
        /// <param name="arealist"></param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse AddAreaFromBridgeX(HttpRequestMessage request, ApiResponse arealist)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _courseStructureConfig.AddAreaFromBridgeX(arealist);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotgetAreaList, null, 0);
        }
        #endregion

        #region Update Webapi
        /// <summary>
        /// update course in table
        /// </summary>
        /// <param name="request"></param>
        /// <param name="courseEntity"></param>
        /// <returns>ApiResponse</returns>
        [HttpPut]
        public ApiResponse UpdateCourse(HttpRequestMessage request, CourseStructureEntity courseEntity)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _courseStructureConfig.UpdateCourse(courseEntity);                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotSaveLesson, null, 0);
        }

        /// <summary>
        /// update lesson in table
        /// </summary>
        /// <param name="request"></param>
        /// <param name="courseEntity"></param>
        /// <returns>ApiResponse</returns>
        [HttpPut]
        public ApiResponse UpdateLesson(HttpRequestMessage request, CourseStructureEntity courseEntity)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _courseStructureConfig.UpdateLesson(courseEntity);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotSaveLesson, null, 0);
        }
        #endregion

        #region Delete Webapi
        /// <summary>
        /// delete course from table
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <param name="isDelete"></param>
        /// <returns></returns>
        [HttpPut]
        public ApiResponse DeleteCourse(HttpRequestMessage request, int id, bool isDelete)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _courseStructureConfig.DeleteCourse(id, isDelete);              
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotDeleteCourse, null, 0);
        }

        /// <summary>
        /// delete lesson from table
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <param name="isDelete"></param>
        /// <returns></returns>
        [HttpPut]
        public ApiResponse DeleteLesson(HttpRequestMessage request, int id, bool isDelete)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _courseStructureConfig.DeleteLesson(id, isDelete);              
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotDeleteLesson, null, 0);
        }
        #endregion

        #region Other Api
        /// <summary>
        /// Start Simulation from virsual plant - by passing areaId
        /// </summary>
        /// <param name="request"></param>
        /// <param name="executionStatusId"></param>
        /// <param name="mappingKey"></param>
        /// <returns>ApiResponse</returns>
        [HttpPut]
        public ApiResponse StartSimulationbyArea(HttpRequestMessage request, int mappingKey, int executionStatusId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _courseStructureConfig.StartSimulationbyArea(mappingKey, executionStatusId);              
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_simulationStartFail, null, 0);
        }

        /// <summary>
        /// Check if Simulation is started for any other process in bridgeX
        /// </summary>
        /// <param name="request"></param>     
        /// <param name="mappingKey"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse IsSSimulationStartForAnotherActivityForSameMappingKey(HttpRequestMessage request, int mappingKey)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _courseStructureConfig.IsSSimulationStartForAnotherActivityForSameMappingKey(mappingKey);              
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_Fail, null, 0);
        }
        #endregion
    }
}
