using WebApi_Common.Models;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Server.Repositories;
using System;

namespace Autoszerelo_client.Pages
{
    public partial class WorkList
	{
        [Inject]
        public HttpClient HttpClient { get; set; }

        public Work[] WorkToList { get; set; }
		//public Work[] WorkToList2 { get; set; }

		private Work[] _works;

        public string Search { get; set; }
	    

        protected override async Task OnInitializedAsync()
		{
			_works = await HttpClient.GetFromJsonAsync<Work[]>("work");
			_works = _works
				.OrderBy(w => w.RSZ)
				.ToArray();

			UpdateWorkToList(null);

			await base.OnInitializedAsync();
		}

		private void UpdateWorkToList(ChangeEventArgs? args)
        {
            if (args is not null)
            {
                Search = (string)args.Value;
            }
            else
            {
                Search = "";
            }

            WorkToList = _works.Where(w => w.Name.Contains("")).ToArray();
            //WorkToList2 = (Work[])WorkRepository.LoadWorks();
		}
    }
}
