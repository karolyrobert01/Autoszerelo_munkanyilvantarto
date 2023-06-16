using WebApi_Common.Models;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace Autoszerelo_client.Pages
{
    public partial class workList
	{
        [Inject]
        public HttpClient HttpClient { get; set; }

        public Work[] WorkToList { get; set; }

        private Work[] _works;

        public string _search { get; set; }

		protected async Task OnInitializedAsync()
		{
			_works = await HttpClient.GetFromJsonAsync<Work[]>("work");
			_works = _works
				.OrderBy(w => w.ID)
				.ToArray();

			UpdateWorkToList(null);

			await OnInitializedAsync();
		}

		private void UpdateWorkToList(ChangeEventArgs? args)
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
