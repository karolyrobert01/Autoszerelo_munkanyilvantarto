using Microsoft.AspNetCore.Mvc;
using WebApi_Common.Models;
using Server.Repositories;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/work")]
    public class WorkController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<Work>> Get()
        {
            var works = WorkRepository.LoadWorks();
            return Ok(works);
        }

        [HttpGet("{id}")]
        public ActionResult<Work> Get(int id)
        {
            var works = WorkRepository.LoadWorks();

            var work = works.FirstOrDefault(x => x.Id == id);
            if (work is not null)
            {
                return Ok(work);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Work work)
        {
            var works = WorkRepository.LoadWorks().ToList();
            work.Id = GetNewId(works);

            works.Add(work);
            WorkRepository.SaveWorks(works);

            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Work work)
        {
            var works = WorkRepository.LoadWorks().ToList();

            var workToUpdate = works.FirstOrDefault(p => p.Id == work.Id);
            if (workToUpdate is not null)
            {
                works.Remove(workToUpdate);
                works.Add(work);

                WorkRepository.SaveWorks(works);

                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var works = WorkRepository.LoadWorks().ToList();

            var workToDelete = works.FirstOrDefault(p => p.Id == id);
            if (workToDelete is not null)
            {
                works.Remove(workToDelete);

                WorkRepository.SaveWorks(works);
                return Ok();
            }

            return NotFound();
        }

        private static long GetNewId(IEnumerable<Work> works)
        {
            long newId = 0;
            foreach (var work in works)
            {
                if (newId < work.Id)
                {
                    newId = work.Id;
                }
            }

            return newId + 1;
        }
    }
}
