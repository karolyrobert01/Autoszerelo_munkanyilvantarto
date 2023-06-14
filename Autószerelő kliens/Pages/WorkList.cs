using WebApi_Common.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Json;

namespace Autoszerelo_client.Pages
{
    public class WorkList
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public Work[] workToList { get; set; }

        private Work[] _works;

        private string _search { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _works = await HttpClient.GetFromJsonAsync<Work[]>("work");
            _works = _works
                .OrderBy(p => p.RecordTime)
                .ToArray();

            UpdatePatientsToList(null);

            await base.OnInitializedAsync();
        }

        private void UpdatePatientsToList(ChangeEventArgs? args)
        {
            if (args is not null)
            {
                _search = (string)args.Value;
            }
            else
            {
                _search = "";
            }

            WorkToList = _works.Where(w => w.Name.Contains(_search)).ToArray();
        }
    }
}
}
