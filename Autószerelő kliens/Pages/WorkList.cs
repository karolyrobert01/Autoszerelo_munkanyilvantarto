using WebApi_Common.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;


namespace Autoszerelo_client.Pages
{
    public class workList
	{
        [Inject]
        public HttpClient HttpClient { get; set; }

        public Work[] workToList { get; set; }

        private Work[] _works;

        private string _search { get; set; }

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
