using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class FormDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Chek(FormData formData)
        {
            GoogleCredential credential = GoogleCredential.FromFile("credential.json")
            .CreateScoped(SheetsService.Scope.Spreadsheets);

            var service = new SheetsService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential
            });


            string spreadsheetId = "17JssQGkBsCCe_Xb5sQWZ5e75qZJSNHgaT9GWV0xfO9E";

            string range = "A1:C1";

            var valueRange = new ValueRange
            {
                Values = new List<IList<object>>
            {
                new List<object> { formData.Name, formData.Number, formData.Comment }
            }
            };




            if (ModelState.IsValid)
            {

                var request = service.Spreadsheets.Values.Append(valueRange, spreadsheetId, range);
                request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                var response = request.Execute();
            }

            return Redirect("/");
        }
    }
}
