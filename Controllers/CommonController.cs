using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fox.Microservices.Common.Data.Models;
using Fox.Microservices.Common.Data.Helpers;
using Fox.Microservices.Common.Models;
using Fox.Microservices.Common.Models.Entities;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebAPITools.EntityMapper;
using WebAPITools.Helpers;
using WebAPITools.Models;
using WebAPITools.Models.Configuration;
using WebAPITools.ErrorHandling;
using Fox.Microservices.Common.Models.Configuration;
using Fox.Microservices.Common.Helpers.Address;
using Fox.Microservices.CommonUtils;

namespace Fox.Microservices.Common.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class CommonController : ControllerBase
	{
		private readonly IOptions<CustomAppSettings> Settings;
		private readonly CommonContext DBContext;
		private readonly IFoxDataService FoxDataService;

		public CommonController(IOptions<CustomAppSettings> ASettings, CommonContext ADBContext, IFoxDataService foxDataService)
		{
			this.Settings = ASettings;
			DBContext = ADBContext;
			FoxDataService = foxDataService;
		}


		[ApiExplorerSettings(IgnoreApi = true)]
		[NonAction]
		public ActionResult<IEnumerable<string>> Get()
		{
			return new string[] { "value1", "value2" };
		}

		[HttpGet("[action]")]
		public ActionResult<List<Gender>> Gender()
		{
			List<Gender> Result = new List<Gender>();

			foreach (SY_GENDER item in DBContext.SY_GENDER)
				Result.Add(EntityMapper.Map<Gender, SY_GENDER>(DBContext, item));

			return Result;
		}

		[HttpGet("[action]")]
		public ActionResult<List<Clinic>> Clinic(bool? isActive)
		{
			string[] AllowedTypes = { "00", "01", "02" };
			List<Clinic> Result = new List<Clinic>();
			var predicate = PredicateBuilder.New<CM_B_SHOP>(true);
			predicate = predicate.And(E => AllowedTypes.Contains(E.SHOP_TYPE_CODE));
			if (isActive.GetValueOrDefault(true))
				predicate = predicate.And(E => E.FLG_ACTIVE ==  "Y" && E.DT_START.GetValueOrDefault(DateTime.Today.Date) <= DateTime.Today && E.DT_END.GetValueOrDefault(DateTime.Today) >= DateTime.Today.Date);
			else if (isActive.HasValue && !isActive.Value)
				predicate = predicate.And(E => E.FLG_ACTIVE != "Y");

			foreach (CM_B_SHOP item in DBContext.CM_B_SHOP.Where(predicate))
			{
				Clinic clinic = EntityMapper.Map<Clinic, CM_B_SHOP>(DBContext, item);
				Result.Add(clinic);
			}
			return Result.OrderByDescending(E => E.Code == "000").ThenBy(E => E.Description).ToList();
		}

		[HttpGet("[action]")]
		public ActionResult<Clinic> GetClinicByPostCode(string postCode)
		{
			string[] AllowedTypes = { "00", "01", "02" };
			int ZipCode = 0;
			if (!int.TryParse(postCode, out ZipCode))
				postCode = null;
			
			var qryShop = from shop in DBContext.CM_B_SHOP
										join addr in DBContext.CM_B_ADDRESS on shop.OBJ_CODE equals addr.OBJ_CODE
										where AllowedTypes.Contains(shop.SHOP_TYPE_CODE) && shop.FLG_ACTIVE == "Y" && !string.IsNullOrWhiteSpace(addr.ZIP_CODE)
											&& shop.DT_START.GetValueOrDefault(DateTime.Today.Date) <= DateTime.Today && shop.DT_END.GetValueOrDefault(DateTime.Today) >= DateTime.Today.Date
										orderby Math.Abs(Convert.ToInt32(addr.ZIP_CODE) - ZipCode)
										select shop;

			CM_B_SHOP item = !string.IsNullOrWhiteSpace(postCode) ? qryShop.FirstOrDefault() : DBContext.CM_B_SHOP.FirstOrDefault(E => E.SHOP_CODE == "000");
			Clinic Result = EntityMapper.Map<Clinic, CM_B_SHOP>(DBContext, item);

			return Result;
		}

		[HttpGet("[action]")]
		public ActionResult<AddressBase> GetClinicAddress(string shopCode)
		{
			CM_B_SHOP shop = DBContext.CM_B_SHOP.FirstOrDefault(E => E.SHOP_CODE == shopCode);
			if (shop == null)
				throw new NotFoundException($"No clinic found with shopCode = {shopCode}");

			CM_B_ADDRESS address = DBContext.CM_B_ADDRESS.FirstOrDefault(E => E.OBJ_CODE == shop.OBJ_CODE && E.ADDRESS_COUNTER == 1);
			if (address == null)
				throw new NotFoundException($"No address found with shopCode = {shopCode}");

			AddressBase Result = EntityMapper.Map<AddressBase, CM_B_ADDRESS>(DBContext, address);

			return Result;
		}


		[HttpGet("[action]")]
		public ActionResult<List<Salutation>> Salutation(bool? isActive)
		{
			List<Salutation> Result = new List<Salutation>();
			var predicate = PredicateBuilder.New<CU_S_SALUTATION>(true);
			predicate = predicate.And(E => (E.DT_START == null || E.DT_START <= DateTime.Today) && ((E.DT_END == null) || E.DT_END >= DateTime.Today));

			foreach (CU_S_SALUTATION item in DBContext.CU_S_SALUTATION.Where(predicate))
			{
				Salutation model = EntityMapper.Map<Salutation, CU_S_SALUTATION>(DBContext, item);
				Result.Add(model);
			}
			return Result;
		}

		[HttpGet("[action]")]
		public ActionResult<List<Language>> Language(bool? isActive = true)
		{
			List<Language> Result = new List<Language>();
			var predicate = PredicateBuilder.New<SY_LANGUAGE>(true);
			if (isActive.HasValue)
			{
				if (isActive.Value)
					predicate = predicate.And(E => (E.DT_START == null || E.DT_START <= DateTime.Today) && ((E.DT_END == null) || E.DT_END >= DateTime.Today));
				else
					predicate = predicate.And(E => !((E.DT_START == null || E.DT_START <= DateTime.Today) && ((E.DT_END == null) || E.DT_END >= DateTime.Today)));
			}

			foreach (SY_LANGUAGE item in DBContext.SY_LANGUAGE.Where(predicate))
			{
				Language model = EntityMapper.Map<Language, SY_LANGUAGE>(DBContext, item);
				Result.Add(model);
			}
			return Result;
		}

		[HttpGet("[action]")]
		public ActionResult<List<Source>> Source()
		{
			List<Source> Result = new List<Source>();

			foreach (CM_S_REFERENCE_SOURCE_EXT_AUS item in DBContext.CM_S_REFERENCE_SOURCE_EXT_AUS.Where(E => E.REF_CODE == null && E.TYPE_CATEGORY_CODE == "SRC").OrderBy(E => E.SORT_ORDER))
			{
				Source model = EntityMapper.Map<Source, CM_S_REFERENCE_SOURCE_EXT_AUS>(DBContext, item);
				Result.Add(model);
			}
			return Result;
		}

		[HttpGet("[action]")]
		public ActionResult<List<SubSource>> SubSource(string sourceCode)
		{
			List<SubSource> Result = new List<SubSource>();

			foreach (CM_S_REFERENCE_SOURCE_EXT_AUS item in DBContext.CM_S_REFERENCE_SOURCE_EXT_AUS.Where(E => E.REF_CODE == sourceCode && E.TYPE_CATEGORY_CODE == "SS").OrderBy(E => E.SORT_ORDER))
			{
				SubSource model = EntityMapper.Map<SubSource, CM_S_REFERENCE_SOURCE_EXT_AUS>(DBContext, item);
				Result.Add(model);
			}
			return Result;
		}

		[HttpGet("[action]")]
		public ActionResult<List<ReferralSource>> ReferralSource(string subSourceCode)
		{
			List<ReferralSource> Result = new List<ReferralSource>();
			var qryDayCenters = from DC in DBContext.CM_S_DAYCENTER
													join DCE in DBContext.CM_S_DAYCENTER_EXT_AUS on new { DC.COMPANY_CODE, DC.DIVISION_CODE, DC.SHOP_CODE, DC.DAYCENTER_CODE } equals new { DCE.COMPANY_CODE, DCE.DIVISION_CODE, DCE.SHOP_CODE, DCE.DAYCENTER_CODE } into Ext
													select new { DayCenter = DC, DayCenterExt = Ext.SingleOrDefault() };

			foreach (var item in qryDayCenters.Where(E => E.DayCenterExt.LOCATION_TYPE == subSourceCode).OrderBy(E => E.DayCenter.DAYCENTER_DESCR))
			{
				ReferralSource model = EntityMapper.Map<ReferralSource, CM_S_DAYCENTER>(DBContext, item.DayCenter, item.DayCenterExt);
				Result.Add(model);
			}
			
			return Result;
		}

		[HttpGet("[action]")]
		public ActionResult<List<CustomerStatus>> CustomerStatus(bool? isActive = true, bool ExcludeLeadStatus = true)
		{
			List<CustomerStatus> Result = new List<CustomerStatus>();
			var predicate = PredicateBuilder.New<CU_S_STATUS>(true);
			if (isActive.HasValue)
			{
				if (isActive.Value)
					predicate = predicate.And(E => (E.DT_START == null || E.DT_START <= DateTime.Today) && ((E.DT_END == null) || E.DT_END >= DateTime.Today));
				else
					predicate = predicate.And(E => !((E.DT_START == null || E.DT_START <= DateTime.Today) && ((E.DT_END == null) || E.DT_END >= DateTime.Today)));
			}
			if (ExcludeLeadStatus)
			{
				string[] LeadStatus = { "10", "30" };
				predicate = predicate.And(E => !LeadStatus.Contains(E.STATUS_CODE));
			}

			foreach (CU_S_STATUS item in DBContext.CU_S_STATUS.Where(predicate))
			{
				CustomerStatus model = EntityMapper.Map<CustomerStatus, CU_S_STATUS>(DBContext, item);
				Result.Add(model);
			}
			return Result;
		}

		[HttpGet("[action]")]
		public ActionResult<List<FundingType>> FundingType()
		{
			List<FundingType> Result = new List<FundingType>();
			
			foreach (CU_S_CUSTOMER_TYPE_EXT_AUS item in DBContext.CU_S_CUSTOMER_TYPE_EXT_AUS)
			{
				FundingType model = EntityMapper.Map<FundingType, CU_S_CUSTOMER_TYPE_EXT_AUS>(DBContext, item);
				Result.Add(model);
			}
			
			return Result;
		}

		[HttpGet("[action]")]
		public ActionResult<List<CustomerType>> CustomerType()
		{
			List<CustomerType> Result = new List<CustomerType>();

			foreach (CU_S_TYPE item in DBContext.CU_S_TYPE)
			{
				CustomerType model = EntityMapper.Map<CustomerType, CU_S_TYPE>(DBContext, item);
				Result.Add(model);
			}

			return Result;
		}

		[HttpGet("[action]")]
		public ActionResult<List<State>> State()
		{
			List<State> Result = new List<State>();
			
			foreach (CM_S_STATE_EXT_AUS item in DBContext.CM_S_STATE_EXT_AUS)
			{
				State model = EntityMapper.Map<State, CM_S_STATE_EXT_AUS>(DBContext, item);
				Result.Add(model);
			}
			
			return Result;
		}

		[HttpGet("[action]")]
		public ActionResult<List<Category>> Category(bool? isActive = true)
		{
			List<Category> Result = new List<Category>();
			var predicate = PredicateBuilder.New<CU_S_CATEGORY>(true);
			if (isActive.HasValue)
			{
				if (isActive.Value)
					predicate = predicate.And(E => (E.DT_START == null || E.DT_START <= DateTime.Today) && ((E.DT_END == null) || E.DT_END >= DateTime.Today));
				else
					predicate = predicate.And(E => !((E.DT_START == null || E.DT_START <= DateTime.Today) && ((E.DT_END == null) || E.DT_END >= DateTime.Today)));
			}

			foreach (CU_S_CATEGORY item in DBContext.CU_S_CATEGORY)
			{
				Category model = EntityMapper.Map<Category, CU_S_CATEGORY>(DBContext, item);
				Result.Add(model);
			}

			return Result;
		}
		
		[HttpGet("[action]")]
		public ActionResult<List<CityBook>> CityBook()
		{
			List<CityBook> Result = new List<CityBook>();

			foreach (CM_S_CITY_BOOK item in DBContext.CM_S_CITY_BOOK)
			{
				CityBook model = EntityMapper.Map<CityBook, CM_S_CITY_BOOK>(DBContext, item);
				Result.Add(model);
			}

			return Result;
		}


		[HttpGet("[action]")]
		public ActionResult<List<AppointmentType>> AppointmentType(bool? isActive = true, bool? excludeUnavailability = true)
		{
			List<AppointmentType> Result = new List<AppointmentType>();
			var predicate = PredicateBuilder.New<AG_S_SERVICE>(true);
			if (isActive.HasValue)
			{
				if (isActive.Value)
					predicate = predicate.And(E => (E.DT_START == null || E.DT_START <= DateTime.Today) && ((E.DT_END == null) || E.DT_END >= DateTime.Today));
				else
					predicate = predicate.And(E => !((E.DT_START == null || E.DT_START <= DateTime.Today) && ((E.DT_END == null) || E.DT_END >= DateTime.Today)));
			}

			if (excludeUnavailability.GetValueOrDefault(true))
			{
				string[] unavailabilityServiceCodes = FoxDataService.GetUnavailabilityServiceCodes(null);
				predicate = predicate.And(E => !unavailabilityServiceCodes.Contains(E.SERVICE_TYPE_CODE));
			}

			foreach (AG_S_SERVICE item in DBContext.AG_S_SERVICE.Where(predicate))
			{
				AppointmentType model = EntityMapper.Map<AppointmentType, AG_S_SERVICE>(DBContext, item);
				model.ServiceTypeDescription = item.AG_S_SERVICE_TYPE?.SERVICE_TYPE_DESCR;
				Result.Add(model);
			}

			return Result;
		}

		[HttpGet("[action]")]
		public ActionResult<List<AppointmentStatus>> AppointmentStatus(bool? isActive = true)
		{
			List<AppointmentStatus> Result = new List<AppointmentStatus>();
			var predicate = PredicateBuilder.New<SY_GENERAL_STATUS>(true);
			predicate = predicate.And(E => E.ENTITY_TYPE_CODE == "AP");
			if (isActive.HasValue)
			{
				if (isActive.Value)
					predicate = predicate.And(E => (E.DT_START == null || E.DT_START <= DateTime.Today) && ((E.DT_END == null) || E.DT_END >= DateTime.Today));
				else
					predicate = predicate.And(E => !((E.DT_START == null || E.DT_START <= DateTime.Today) && ((E.DT_END == null) || E.DT_END >= DateTime.Today)));
			}

			foreach (SY_GENERAL_STATUS item in DBContext.SY_GENERAL_STATUS.Where(predicate))
			{
				AppointmentStatus model = EntityMapper.Map<AppointmentStatus, SY_GENERAL_STATUS>(DBContext, item);
				Result.Add(model);
			}

			return Result;
		}

		[HttpGet("[action]")]
		public ActionResult<List<Clinician>> Clinician(bool? isActive = true)
		{
			List<Clinician> Result = new List<Clinician>();
			var predicate = PredicateBuilder.New<CM_S_EMPLOYEE>(true);
			string[] AllowedTypes = { "AUD", "CSO" };
			predicate = predicate.And(E => AllowedTypes.Contains(E.EMPLOYEE_TYPE_CODE));
			if (isActive.HasValue)
			{
				if (isActive.Value)
					predicate = predicate.And(E => (E.DT_START == null || E.DT_START <= DateTime.Today) && ((E.DT_END == null) || E.DT_END >= DateTime.Today));
				else
					predicate = predicate.And(E => !((E.DT_START == null || E.DT_START <= DateTime.Today) && ((E.DT_END == null) || E.DT_END >= DateTime.Today)));
			}

			foreach (CM_S_EMPLOYEE item in DBContext.CM_S_EMPLOYEE.Where(predicate))
			{
				Clinician model = EntityMapper.Map<Clinician, CM_S_EMPLOYEE>(DBContext, item);
				Result.Add(model);
			}

			return Result;
		}

		[HttpGet("[action]")]
		public ActionResult<List<Relationship>> Relationship(bool? isActive = true)
		{
			List<Relationship> Result = new List<Relationship>();
			var predicate = PredicateBuilder.New<SY_GENERAL_TYPE_EXT_AUS>(true);
			predicate = predicate.And(E => E.TYPE_CATEGORY_CODE == "REL");
			if (isActive.HasValue)
			{
				if (isActive.Value)
					predicate = predicate.And(E => (E.DT_START == null || E.DT_START <= DateTime.Today) && ((E.DT_END == null) || E.DT_END >= DateTime.Today));
				else
					predicate = predicate.And(E => !((E.DT_START == null || E.DT_START <= DateTime.Today) && ((E.DT_END == null) || E.DT_END >= DateTime.Today)));
			}

			foreach (SY_GENERAL_TYPE_EXT_AUS item in DBContext.SY_GENERAL_TYPE_EXT_AUS.Where(predicate))
			{
				Relationship model = EntityMapper.Map<Relationship, SY_GENERAL_TYPE_EXT_AUS>(DBContext, item);
				Result.Add(model);
			}

			return Result;
		}


		[HttpGet("[action]")]
		public ActionResult<List<Service>> Service(bool? isActive = true)
		{
			List<Service> Result = new List<Service>();
			
			var predicate = PredicateBuilder.New<AG_S_SERVICE>(true);
			if (isActive.HasValue)
			{
				if (isActive.Value)
					predicate = predicate.And(E => (E.DT_START == null || E.DT_START <= DateTime.Today) && ((E.DT_END == null) || E.DT_END >= DateTime.Today));
				else
					predicate = predicate.And(E => !((E.DT_START == null || E.DT_START <= DateTime.Today) && ((E.DT_END == null) || E.DT_END >= DateTime.Today)));
			}

			foreach (AG_S_SERVICE item in DBContext.AG_S_SERVICE.Where(predicate))
			{
				Service model = EntityMapper.Map<Service, AG_S_SERVICE>(DBContext, item);
				Result.Add(model);
			}
			
			return Result;
		}

		[HttpGet("[action]")]
		public ActionResult<List<AddressInfo>> ValidateAddress(string searchString)
		{
			List<AddressInfo> Result = new List<AddressInfo>();

			BaseAddressValidator validator = new GooglePlacesAddressValidator(Settings.Value);
			Result.AddRange(validator.GetAddresses(searchString));
			return Result;
		}

		[HttpGet("[action]")]
		public ActionResult<string> GetParameterValue(string parameterName, string defaultValue, string shopCode = "*")
		{
			return FoxDataService.GetGlobalParameterValue<string>(parameterName, defaultValue, shopCode);
		}


		[HttpGet("[action]")]
		public ActionResult<List<SimpleModel>> PreferredTimeOfContact()
		{
			return EnumHelper.GetEnumItems<PreferredTimeOfContact>();
		}

		/*
		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
		*/
	}
}
