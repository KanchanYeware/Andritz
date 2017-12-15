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
    public class SnapshotsConfigurationController : ApiController
    {
        #region Variable Declarations
        private readonly ISnapshotsConfiguration _snapshotsConfiguration;
        private readonly ICommonUtils _commonUtils; 
        #endregion

        #region Region for Authentication Request Token variables      
        private IEnumerable<string> headerValues;
        #endregion

        #region Constructor
        public SnapshotsConfigurationController(ISnapshotsConfiguration snapshotConfiguration, ICommonUtils commonUtils)
        {
            _snapshotsConfiguration = snapshotConfiguration;
            _commonUtils = commonUtils;
        }
        #endregion

        #region Get Webapi
        /// <summary>
        /// get list for all snapshot list
        /// </summary>
        /// <param name="request"></param>
        /// <param name="areaId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetSnapshotsList(HttpRequestMessage request, int areaId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _snapshotsConfiguration.GetSnapshotsList(areaId);                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetSnapList, null, 0);
        }
        #endregion

        #region Add Webapi
        /// <summary>
        /// save the snapshot in table
        /// </summary>
        /// <param name="request"></param>
        /// <param name="snapshotEntity"></param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse AddSnapshot(HttpRequestMessage request, SnapshotEntity snapshotEntity)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _snapshotsConfiguration.AddSnapshot(snapshotEntity);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotSaveSnapshot, null, 0);
        }
        #endregion

        #region Delete Webapi
        /// <summary>
        /// Delete Snapshot list
        /// </summary>
        /// <param name="request"></param>
        /// <param name="snapshotId"></param>
        /// <returns>ApiResponse</returns>
        [HttpPut]
        public ApiResponse DeleteSnapshot(HttpRequestMessage request, int snapshotId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _snapshotsConfiguration.DeleteSnapshot(snapshotId);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotDeleteSnapshot, null, 0);
        }
        #endregion

        #region Other Webapi
        /// <summary>
        /// After Load Snapshot - Activate current Snapshot within single area and deactivate all others
        /// </summary>
        /// <param name="request"></param>
        /// <param name="mappingKey"></param>
        /// <param name="snapshotId"></param>
        /// <returns>ApiResponse</returns>
        [HttpPut]
        public ApiResponse LoadSnapshot(HttpRequestMessage request, int mappingKey, int snapshotId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _snapshotsConfiguration.LoadSnapshot(mappingKey, snapshotId);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_LoadSnapshotFail, null, 0);
        } 
        #endregion
    }
}
