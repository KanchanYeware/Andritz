using Andritz.RTP.Utilities;
using Andritz.RTP.Utilities.Common;
using Andritz.RTP.Utilities.Extensions;
using Andritz.RTP.Utilities.Resources;
using Andritz.RTPApplication.Core;
using Andritz.RTPApplication.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace Andritz.RTPApplication.WebApi.Controllers
{
    public class BackTrackSnapshotController : ApiController
    {
        #region Variable Declarations
        private readonly IBackTrackSnapshotService _backTrackSnapshot;
        private readonly ICommonUtils _commonUtils;
        private IEnumerable<string> headerValues;
        #endregion

        #region Contructor
        public BackTrackSnapshotController(IBackTrackSnapshotService backTrackSnapshot, ICommonUtils commonUtils)
        {
            _backTrackSnapshot = backTrackSnapshot;
            _commonUtils = commonUtils;
        }
        #endregion

        #region Get Webapi
        /// <summary>
        /// Get All BackTrackSnapshot information
        /// </summary>
        /// <returns></returns>
        [Route("api/BackTrackSnapshot/GetBackTrackSnapshotList/{AreaId}")]
        [HttpGet]
        public ApiResponse GetBackTrackSnapshotList(HttpRequestMessage request, int AreaId)
        {
            try
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _backTrackSnapshot.GetBackTrackSnapshotList(AreaId);
            }
            catch (Exception ex)
            {
                LoggingExtensions.LogException("BackTrackSnapshotController/GetBackTrackSnapshotList", ex);
                return _commonUtils.ReturnValues(false, "ERROR: In BackTrackSnapshotController", null, 0);
            }
        }

        /// <summary>
        /// Get All BackTrackSnapshot information
        /// </summary>
        /// <returns></returns>
        [Route("api/BackTrackSnapshot/GetBackTrackSnapshotSettingList")]
        [HttpGet]
        public ApiResponse GetBackTrackSnapshotSettingList(HttpRequestMessage request)
        {
            try
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _backTrackSnapshot.GetBackTrackSnapshotSettingList();
            }
            catch (Exception ex)
            {
                LoggingExtensions.LogException("BackTrackSnapshotController/GetBackTrackSnapshotSettingList", ex);
                return _commonUtils.ReturnValues(false, "ERROR: In BackTrackSnapshotController", null, 0);
            }
        }       
        #endregion

        #region Add Webapi 
        /// <summary>
        /// Get All BackTrackSnapshot information
        /// </summary>
        /// <returns></returns>
        [Route("api/BackTrackSnapshot/AddUpdateBackTrackSnapshotSetting")]
        [HttpPost]
        public ApiResponse AddUpdateBackTrackSnapshotSetting(HttpRequestMessage request, BackTrackSnapshotSettingEntity backTrackSnapshotSetting)
        {
            try
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _backTrackSnapshot.AddUpdateBackTrackSnapshotSetting(backTrackSnapshotSetting);
            }
            catch (Exception ex)
            {
                LoggingExtensions.LogException("BackTrackSnapshotController/AddUpdateBackTrackSnapshotSetting", ex);
                return _commonUtils.ReturnValues(false, "ERROR: In BackTrackSnapshotController", null, 0);
            }
        }

        /// <summary>
        /// Get All BackTrackSnapshot information
        /// </summary>
        /// <param name="request"></param>
        /// <param name="backTrackSnapshotEntity"></param>
        /// <returns>ApiResponse</returns>      
        [HttpPost]
        public ApiResponse AddBacktrackSnapshot(HttpRequestMessage request, BackTrackSnapshotEntity backTrackSnapshotEntity)
        {
            try
            {
                if (request.Headers.TryGetValues("Auth_Token", out headerValues))
                {
                    CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                    return _backTrackSnapshot.AddBacktrackSnapshot(backTrackSnapshotEntity);                   
                }
                return _commonUtils.ReturnValues(false, Resources.Msg_Fail, null, 0);
            }
            catch (Exception ex)
            {
                LoggingExtensions.LogException("BackTrackSnapshotController/AddUpdateBackTrackSnapshotSetting", ex);
                return _commonUtils.ReturnValues(false, "ERROR: In BackTrackSnapshotController", null, 0);
            }
        }
        #endregion

        #region Delete Webapi       
        /// <summary>
        /// Delete Backtrack from table - For Windows Service
        /// </summary>
        /// <param name="request"></param>
        /// <param name="areaId"></param>
        /// <returns>ApiResponse</returns>       
        [HttpPut]
        public ApiResponse DeleteBacktrackSnapshotInBulkWindowsService(HttpRequestMessage request, int backtrackSnapshotId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _backTrackSnapshot.DeleteBacktrackSnapshotInBulkWindowsService(backtrackSnapshotId);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotDeleteBackTrackSnapshot, null, 0);
        }

        /// <summary>
        /// Delete Backtrack from table 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="backTrackId"></param>
        /// <returns>ApiResponse</returns>
        [Route("api/BackTrackSnapshot/DeleteBackTrackSnapshot/{backTrackId}")]
        [HttpPut]
        public ApiResponse DeleteBackTrackSnapshot(HttpRequestMessage request, int backTrackId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _backTrackSnapshot.DeleteBackTrackSnapshot(backTrackId);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotDeleteBackTrackSnapshot, null, 0);
        }
        #endregion

        #region Playback BacktrackSnapshot Webapi
        /// <summary>
        /// Update backtrack snapshot table when it is started mode
        /// </summary>
        /// <param name="request"></param>
        /// <param name="backTrackSnapshotEntity"></param>
        /// <returns>ApiResponse</returns>      
        [HttpPut]
        public ApiResponse StartPlayBacktrackSnapshot(HttpRequestMessage request, BackTrackSnapshotEntity backTrackSnapshotEntity)
        {
            try
            {
                if (request.Headers.TryGetValues("Auth_Token", out headerValues))
                {
                    CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                    return _backTrackSnapshot.StartPlayBacktrackSnapshot(backTrackSnapshotEntity);                    
                }
                return _commonUtils.ReturnValues(false, Resources.Msg_StartPlayBacktrak_Fail, null, 0);
            }
            catch (Exception ex)
            {
                LoggingExtensions.LogException("StartPlayBacktrackSnapshot", ex);
                return _commonUtils.ReturnValues(false, Resources.Msg_StartPlayBacktrak_Fail, null, 0);
            }
        }

        /// <summary>
        /// Update backtrack snapshot table when it is stopped mode
        /// </summary>
        /// <param name="request"></param>
        /// <param name="backtrackSnapshotId"></param>
        /// <returns>ApiResponse</returns>      
        [HttpPut]
        public ApiResponse StopPlayBacktrackSnapshot(HttpRequestMessage request, int backtrackSnapshotId)
        {
            try
            {
                if (request.Headers.TryGetValues("Auth_Token", out headerValues))
                {
                    CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                    return _backTrackSnapshot.StopPlayBacktrackSnapshot(backtrackSnapshotId);                   
                }
                return _commonUtils.ReturnValues(false, Resources.Msg_StopPlayBacktrak_Fail, null, 0);
            }
            catch (Exception ex)
            {
                LoggingExtensions.LogException("StartPlayBacktrackSnapshot", ex);
                return _commonUtils.ReturnValues(false, Resources.Msg_StopPlayBacktrak_Fail, null, 0);
            }
        }

        /// <summary>
        /// Chcek If playbacktrack snapshot is already started - then restrict to start it again till first one is completed
        /// </summary>
        /// <param name="request"></param>
        /// <param name="mappingKey"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse IsPlaybacktrackSnapshotAlreadyStarted(HttpRequestMessage request, int mappingKey)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _backTrackSnapshot.IsPlaybacktrackSnapshotAlreadyStarted(mappingKey);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_Fail, null, 0);
        }

        /// <summary>
        /// Update backtrack snapshot table when it is rewind or forward
        /// </summary>
        /// <param name="request"></param>
        /// <param name="backtrackSnapshotId"></param>
        /// <param name="actualDuration"></param>
        /// <returns>ApiResponse</returns>      
        [HttpPut]
        public ApiResponse RewindAndForwardPlaybackBacktrackSnapshot(HttpRequestMessage request, double actualDuration, int backtrackSnapshotId)
        {
            try
            {
                if (request.Headers.TryGetValues("Auth_Token", out headerValues))
                {
                    CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                    return _backTrackSnapshot.RewindAndForwardPlaybackBacktrackSnapshot(actualDuration, backtrackSnapshotId);                    
                }
                return _commonUtils.ReturnValues(false, Resources.Msg_RewindForwardPlayback_Fail, null, 0);
            }
            catch (Exception ex)
            {
                LoggingExtensions.LogException("RewindAndForwardPlaybackBacktrackSnapshot", ex);
                return _commonUtils.ReturnValues(false, Resources.Msg_RewindForwardPlayback_Fail, null, 0);
            }
        }
        #endregion

        #region Other Webapi
        /// <summary>
        /// After Load BacktrackSnapshot - Activate current Snapshot within single area and deactivate all others
        /// </summary>
        /// <param name="request"></param>
        /// <param name="mappingKey"></param>
        /// <param name="backtrackSnapshotId"></param>
        /// <returns>ApiResponse</returns>
        [HttpPut]
        public ApiResponse LoadBacktrackSnapshot(HttpRequestMessage request, int mappingKey, int backtrackSnapshotId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _backTrackSnapshot.LoadBacktrackSnapshot(mappingKey, backtrackSnapshotId);                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_LoadBacktrackSnapshotFail, null, 0);
        }
        #endregion
    }
}