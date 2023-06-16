using WebApi_Common.Models;
using Microsoft.AspNetCore.Components;

namespace Autoszerelo_client.Pages
{
    public partial class workList
	{
        [Inject]
        public HttpClient HttpClient { get; set; }

        public Work[] workToList { get; set; }

        private Work[] _works;

        private string _search { get; set; }

		protected async Task OnInitializedAsync()
		{
			_works = await HttpClient.GetFromJsonAsync<Work[]>("work");
			_works = _works
				.OrderBy(w => w.ID)
				.ToArray();

			UpdatePatientsToList(null);

			await OnInitializedAsync();
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

            workToList = _works.Where(w => w.Name.Contains(_search)).ToArray();
        }
    }
}
