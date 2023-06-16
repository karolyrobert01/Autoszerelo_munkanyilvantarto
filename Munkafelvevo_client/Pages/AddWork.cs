using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;
using WebApi_Common.Models;


namespace Munkafelvevo_client.Pages
{
    public partial class AddWork
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

		public Work Work { get; set; } = new Work();

		private string? _statusMessage;
        private string? _statusClass;

        private async Task Submit()
        {
            _statusClass = "";
            _statusMessage = "";
           //  Ha ez nincs beállítva akkor 400-as hibát dob

            var message = await HttpClient.PostAsJsonAsync("work", Work);

            _statusClass = "alert-info";
            _statusMessage = "Munka rögzítve";
            HttpRespond(message);
            ClearInputFields();

        }
        public void ClearInputFields()
        {
            Work.Name = String.Empty;
            Work.Type = String.Empty;
			Work.ID = String.Empty;
            Work.Year = String.Empty;
            Work.Workdetails = String.Empty;
            Work.Error = String.Empty;
            Work.Seriousness = String.Empty;

        }

        private async Task InvalidSubmit()
        {
            _statusClass = "alert-danger";
            _statusMessage = "A munka rögzítése sikertelen!";
        }

        private void HttpRespond(HttpResponseMessage message)
        {
            if (!message.IsSuccessStatusCode)
            {
                _statusClass = "alert-danger";
                _statusMessage = "Hiba a mentés során";
            }
        }

    }
}
