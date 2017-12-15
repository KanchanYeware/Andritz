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
    public class MalfunctionsConfigController : ApiController
    {
        #region Variable Declarations
        private readonly IMalfunctionsConfiguration _malfuncConfiguration;
        private readonly ICommonUtils _commonUtils;
        #endregion

        #region Region for Authentication Request Token variables      
        private IEnumerable<string> headerValues;
        #endregion

        #region Constructor
        public MalfunctionsConfigController(IMalfunctionsConfiguration malfuncConfiguration, ICommonUtils commonUtils)
        {
            _malfuncConfiguration = malfuncConfiguration;
            _commonUtils = commonUtils;
        }
        #endregion

        #region Get Webapi

        /// <summary>
        /// get list for all malfunction list
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
                return _malfuncConfiguration.GetMalfunctionList(areaId);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetMalfunList, null, 0);
        }

        /// <summary>
        /// get malfunction record by passing id for update
        /// </summary>
        /// <param name="request"></param>
        /// <param name="malfunctionId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetMalfunctionById(HttpRequestMessage request, int malfunctionId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _malfuncConfiguration.GetMalfunctionById(malfunctionId);              
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetMalfunctionByid, null, 0);
        }

        /// <summary>
        /// get malfunction temlate record by passing id for update
        /// </summary>
        /// <param name="request"></param>
        /// <param name="MalTempId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetMalfunctionTempById(HttpRequestMessage request, int MalTempId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _malfuncConfiguration.GetMalfunctionTempById(MalTempId);                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetMalfunctiontempByid, null, 0);
        }

        /// <summary>
        /// Get all malfunction list which are active
        /// </summary>
        /// <param name="request"></param>
        /// <param name="areaId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetMalfunctiontempList(HttpRequestMessage request, string areaId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _malfuncConfiguration.GetMalfunctiontempList(areaId);                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetMalfunList, null, 0);
        }

        /// <summary>
        /// Get Malfuntion related data - by passing malfunctionId - For BridgeX call[ActivateAndDeactivate Malfunction]
        /// </summary>
        /// <param name="request"></param>
        /// <param name="malfunctionId"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse GetMalfunctionDataForActivateDeacitavte(HttpRequestMessage request, int malfunctionId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _malfuncConfiguration.GetMalfunctionDataForActivateDeacitavte(malfunctionId);              
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotGetMalfunctionByid, null, 0);
        }
        #endregion

        #region Add Webapi
        /// <summary>
        /// ActivateDeactivate for Malfunction
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <param name="isActivatedInIdeas"></param>
        /// <returns>ApiResponse</returns>
        [HttpPut]
        public ApiResponse ActivateDeactivate(HttpRequestMessage request, int id, bool isActivatedInIdeas)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _malfuncConfiguration.ActivateDeactivate(id, isActivatedInIdeas);                
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotActvDctvSuccess, null, 0);
        }

        /// <summary>
        /// add record in malfunctiontemplate and malfunctiontemplateparam tables
        /// </summary>
        /// <param name="request"></param>
        /// <param name="malfunctionEntity"></param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse AddMalfunctionTemplate(HttpRequestMessage request, MalfunctionEntity malfunctionEntity)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _malfuncConfiguration.AddMalfunctionTemplate(malfunctionEntity);              
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotSaveMalfunctiontemp, null, 0);
        }

        /// <summary>
        /// add record in malfunction and malfunctionparam tables
        /// </summary>
        /// <param name="request"></param>
        /// <param name="malfunctionEntity"></param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse AddMalfunction(HttpRequestMessage request, MalfunctionEntity malfunctionEntity)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _malfuncConfiguration.AddMalfunction(malfunctionEntity);              
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotSaveMalfunction, null, 0);
        }
        #endregion

        #region Update Webapi
        /// <summary>
        /// Update malfunction template and malfunction template parameter
        /// </summary>
        /// <param name="request"></param>
        /// <param name="malfunctionEntity"></param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse UpdateMalfunctionTemplate(HttpRequestMessage request, MalfunctionEntity malfunctionEntity)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _malfuncConfiguration.UpdateMalfunctionTemplate(malfunctionEntity);              
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotUpdateMalfunctiontemp, null, 0);
        }

        /// <summary>
        /// Update malfunction and malfunction parameter
        /// </summary>
        /// <param name="request"></param>
        /// <param name="malfunctionEntity"></param>
        /// <returns>ApiResponse</returns>
        [HttpPost]
        public ApiResponse UpdateMalfunction(HttpRequestMessage request, MalfunctionEntity malfunctionEntity)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _malfuncConfiguration.UpdateMalfunction(malfunctionEntity);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotUpdateMalfunction, null, 0);
        }
        #endregion

        #region Delete Webapi
        /// <summary>
        /// delete malfunction
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <param name="isDelete"></param>
        /// <returns>ApiResponse</returns>
        [HttpPut]
        public ApiResponse DeleteMalfunction(HttpRequestMessage request, int id, bool isDelete)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _malfuncConfiguration.DeleteMalfunction(id, isDelete);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_NotDeleteMalfunc, null, 0);
        }
        #endregion

        #region Other Webapi
        /// <summary>
        /// Deactivate all malfunction and snapshot when Simulation is stopped or Testexecution is stopped
        /// </summary>
        /// <param name="request"></param>
        /// <param name="testId"></param>
        /// <param name="mappingKey"></param>
        /// <returns>ApiResponse</returns>
        [HttpPut]
        public ApiResponse DeactivateMalfuncAndDeleteSnapshotAfterTestStop(HttpRequestMessage request, int testId, int mappingKey)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _malfuncConfiguration.DeactivateMalfuncAndDeleteSnapshotAfterTestStop(testId, mappingKey);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_Fail, null, 0);
        }

        /// <summary>
        /// Get Malfuntion related data - If test is executed for malfunction
        /// </summary>
        /// <param name="request"></param>
        /// <param name="malfunctionId"></param>
        /// <param name="mappingKey"></param>
        /// <returns>ApiResponse</returns>
        [HttpGet]
        public ApiResponse IsMalfunctionExistInTestExecute(HttpRequestMessage request, int malfunctionId)
        {
            if (request.Headers.TryGetValues("Auth_Token", out headerValues))
            {
                CultureConfiguration.SetCurrentCulture(((string[])request.Headers.GetValues("Current_Culture"))[0]);
                return _malfuncConfiguration.IsMalfunctionExistInTestExecute(malfunctionId);               
            }
            return _commonUtils.ReturnValues(false, Resources.Msg_Fail, null, 0);
        } 
        #endregion
    }
}
