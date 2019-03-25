using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace CityWeather.Api.Controllers
{
    public class BaseController: ApiController
    {
        protected ResponseMessageResult ValidationError(ValidationException ex)
        {
            return new System.Web.Http.Results.ResponseMessageResult(Request.CreateErrorResponse(
                (HttpStatusCode) 422,
                new HttpError(ex.Message)
            ));
        }
    }
}