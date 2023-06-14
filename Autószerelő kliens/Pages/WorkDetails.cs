using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Autoszerelo_client.Pages
{
    public partial class WorkDetails
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Work Work { get; set; }

        private string _statusClass = "";
        private string _statusMessage = "";

        protected override async Task OnInitializedAsync()
        {
            Work = await HttpClient.GetFromJsonAsync<Work>($"work/{Id}");

            await base.OnInitializedAsync();
        }

        private async Task ModifyPatient()
        {
            _statusClass = "";
            _statusMessage = "";

            Work.Diagnosis = Work.Diagnosis ?? "";    //  Error 400 ha ez nincs itt

            var res = await HttpClient.PutAsJsonAsync<Work>($"work", Work);

            if (res.IsSuccessStatusCode)
            {
                _statusClass = "alert-info";
                _statusMessage = "Adatok sikeresen módosítva!";
            }
            else
            {
                _statusClass = "alert-danger";
                _statusMessage = "Hiba az adatok módosítása közben!";
            }
        }

        private void InvalidSubmit()
        {
            _statusClass = "alert-danger";
            _statusMessage = "Hibás adatok vannak megadva!";
        }

        private async Task DeletePatient()
        {
            await HttpClient.DeleteAsync($"work/{Id}");

            NavigationManager.NavigateTo("/");
        }
    }
}

