using System.Text;
using System.Text.Json;
using WebApi_Common.Models;

namespace Server.Repositories
{
    public class WorkRepository
    {
        private const string _filename = "Works.json";

        public static IEnumerable<Work> LoadWorks()
        {
            if (File.Exists(_filename))
            {
                using var stream = new FileStream(_filename, FileMode.Open, FileAccess.Read);
                using var read = new StreamReader(stream, Encoding.UTF8);
                string rawData = read.ReadToEnd();

                var works = JsonSerializer.Deserialize<IEnumerable<Work>>(rawData);
                return works;
            }

            return new List<Work>();
        }

        public static void SaveWorks(IEnumerable<Work> works)
        {
            if (!File.Exists(_filename))
            {
                File.Create(_filename).Close();
            }
            var rawData = JsonSerializer.Serialize(works);
            using var stream = new FileStream(_filename, FileMode.Truncate, FileAccess.Write);
            using var write = new StreamWriter(stream, Encoding.UTF8);

            write.WriteLine(rawData);
        }
    }
}
