using System.Threading.Tasks;
using VirusTotalNet;

namespace TacviewGonkulatorBackend.Services
{
    public interface IAntiVirusScanService
    {
        public Task<object> GetReport(byte[] file);
        public Task<object> ScanFile(byte[] file, string fileName);
    }

    public class VirusTotalAvService : IAntiVirusScanService
    {
        private readonly VirusTotal _virusTotal;
        
        public VirusTotalAvService(string apiKey)
        {
            _virusTotal = new VirusTotal(apiKey)
            {
                UseTLS = true
            };
        }

        public async Task<object> GetReport(byte[] file)
        {
            return await _virusTotal.GetFileReportAsync(file);
        }

        public async Task<object> ScanFile(byte[] file, string fileName)
        {
            return await _virusTotal.ScanFileAsync(file, fileName);
        }
    }
}