using Andritz.RTP.Utilities;
using Andritz.RTP.Utilities.Common;
using Andritz.RTP.Utilities.Resources;
using Andritz.RTPApplication.Core;
using Andritz.RTPApplication.Entities;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Andritz.RTPApplication.WebApi.Controllers
{
    public class UserManagementController : ApiController
    {
        #region Variable Declarations
        private readonly IUserManagementService _userManagementService;
        private readonly ICommonUtils _commonUtils; 
        #endregion

        #region Region for Authentication Request Token variables      
        private IEnumerable<string> headerValues;
        #endregion

        #region Constructor
        public UserManagementController(IUserManagementService userManagementService, ICommonUtils commonUtils)
        {
            _userManagementService = userManagementService;
            _commonUtils = commonUtils;
        }
        #endregion

        #region Get Webapi
        /// <summary>
        /// Get user details by passing Id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetUserById(HttpRequestMessage request, int id)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _userManagementService.GetUserById(id);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetUserList, null, 0);
        }

        /// <summary>
        /// Get all list of users except logged user
        /// </summary>    
        /// <param name="request"></param>
        /// <param name="userId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetAllUsers(HttpRequestMessage request, int userId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _userManagementService.GetAllUsers(userId);                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetUserList, null, 0);
        }

        /// <summary>
        /// Get all users list except logged user.
        /// </summary>       
        /// <param name="request"></param>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetAllUsersList(HttpRequestMessage request, int userId, int roleId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _userManagementService.GetAllUsersList(userId, roleId);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetUserList, null, 0);
        }

        /// <summary>
        /// Chcek validation for login user and return that user details if it is valid user
        /// </summary>
        /// <param name="request"></param>
        ///<param name="validateUserEntity"></param>
        /// <returns>ApiResponse</returns>
      
        [HttpPost]
        public ApiResponse GetValidateUser(HttpRequestMessage request, ValidateUserEntity validateUserEntity)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _userManagementService.ValidateUser(validateUserEntity);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_UserNotValid, null, 0);
        }

        /// <summary>
        /// Get Role name by passing username to User
        /// </summary>       
        /// <param name="request"></param>
        /// <param name="userName"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetRoleByUserName(HttpRequestMessage request, string userName)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _userManagementService.GetRoleByUserName(userName);                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetUserList, null, 0);
        }

        /// <summary>
        /// Get list of unassigned operators.
        /// </summary>            
        /// <param name="request"></param>
        /// <param name="trainerId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetOperatorList(HttpRequestMessage request, int trainerId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _userManagementService.GetOperatorList(trainerId);              
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetOperatorList, null, 0);
        }
        #endregion

        #region Add Webapi
        /// <summary>
        /// Add User to User table
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userdetailEntity"></param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse AddUser(HttpRequestMessage request, UserDetailEntity userdetailEntity)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _userManagementService.AddUser(userdetailEntity);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotSavedUser, null, 0);
        }
        #endregion

        #region Update Webapi
        /// <summary>
        /// Update User
        /// </summary>   
        /// <param name="request"></param>
        /// <param name="userDetailEntity"></param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse UpdateUser(HttpRequestMessage request, UserDetailEntity userDetailEntity)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _userManagementService.UpdateUser(userDetailEntity);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotUpdateUser, null, 0);
        }

        /// <summary>
        /// Update User profile
        /// </summary>   
        /// <param name="request"></param>
        /// <param name="userDetailEntity"></param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse UpdateUserProfile(HttpRequestMessage request, UserDetailEntity userDetailEntity)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _userManagementService.UpdateUserProfile(userDetailEntity);                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotUpdateUser, null, 0);
        }
        #endregion

        #region Other Webapi
        /// <summary>
        /// Send login details mail to user 
        /// </summary>      
        /// <param name="request"></param>
        /// <param name="Id"></param>
        /// <param name="flag"></param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse SendMail(HttpRequestMessage request, int id, bool flag)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _userManagementService.SendMail(id, flag);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotSendmail, null, 0);
        }

        /// <summary>
        /// Set activate or deactivate to User
        /// </summary>       
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <param name="isActive"></param>
        /// <returns>ApiResponse</returns>
        [HttpPut]
        public ApiResponse ActivateDeactivate(HttpRequestMessage request, int id, bool isActive)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _userManagementService.ActivateDeactivate(id, isActive);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotActvDctvSuccess, null, 0);
        }

        [Route("HttpError")]
        [HttpGet]
        public HttpResponseMessage HttpError()
        {
            return Request.CreateResponse(HttpStatusCode.Forbidden, "You cannot access this method at this time.");
        }

        #endregion
    }
}
