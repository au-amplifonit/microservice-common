using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fox.Microservices.Common.Models;
using Fox.Microservices.Common.Models.Configuration;
using GoogleApi;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.AutoComplete.Request.Enums;
using GoogleApi.Entities.Places.Common;
using WebAPITools.ErrorHandling;

namespace Fox.Microservices.Common.Helpers.Address
{
	public class GooglePlacesAddressValidator: BaseAddressValidator
	{
		public GooglePlacesAddressValidator(CustomAppSettings settings): base(settings)
		{

		}

		public override List<AddressInfo> GetAddresses(string searchString)
		{
			List<AddressInfo> Result = new List<AddressInfo>();
			PlacesAutoCompleteRequest request = new PlacesAutoCompleteRequest()
			{
				Key = Settings.GoogleKey,
				Input = searchString,
				Components = new KeyValuePair<Component, string>[] {new KeyValuePair<Component, string>(Component.Country, "AU")},
				Types = new RestrictPlaceType[] { RestrictPlaceType.Address},			
			};

			var queryResult = GooglePlaces.AutoComplete.Query(request);
			if (queryResult.Status.HasValue && queryResult.Status == Status.ZeroResults)
				throw new NotFoundException("No address found");
			else if (!queryResult.Status.HasValue || queryResult.Status.Value != Status.Ok)
				throw new Exception($"Error while calling Google Place, Status: {queryResult.Status.GetValueOrDefault()}", new Exception(queryResult.ErrorMessage));

			foreach (Prediction address in queryResult.Predictions)
				Result.Add(CreateAddressInfo(address));

			return Result.Where(E => !string.IsNullOrWhiteSpace(E.Address)).ToList();
		}

		AddressInfo CreateAddressInfo(Prediction prediction)
		{
			AddressInfo Result = new AddressInfo();
			/*
			Result.Address = prediction.StructuredFormatting?.MainText;
			string[] additionalInfo = prediction.StructuredFormatting.SecondaryText.Split(",", StringSplitOptions.RemoveEmptyEntries);
			if (additionalInfo.Length > 0)
			{
				string[] info = additionalInfo[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
				Result.Locality = string.Join(" ", info.SkipLast(1));
				Result.State = info.LastOrDefault();
			}
			*/
			Result.Description = prediction.Description;
			Result.Address = prediction.Terms.FirstOrDefault()?.Value;
			Result.Locality = prediction.Terms.Skip(1).FirstOrDefault()?.Value;
			Result.State = prediction.Terms.Skip(2).FirstOrDefault()?.Value;

			return Result;
		}

	}
}
