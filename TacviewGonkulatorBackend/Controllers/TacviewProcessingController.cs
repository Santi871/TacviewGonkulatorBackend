using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TacviewGonkulatorBackend.Classes;
using TacviewGonkulatorBackend.Dtos;
using TacviewGonkulatorBackend.Services;

namespace TacviewGonkulatorBackend.Controllers
{
    public record UriResponse
    {
        public string Path { get; set; }
    }

    [ApiController]
    [Route("api/v1/tacviews")]
    public class TacviewProcessingController : ControllerBase
    {
        private readonly ILogger<TacviewProcessingController> _logger;
        private readonly ITacviewService _tacviewService;
        private readonly IFileStorageService _fileStorageService;
        private readonly IAntiVirusScanService _avService;
        private readonly IBus _bus;

        public TacviewProcessingController(ILogger<TacviewProcessingController> logger,
            ITacviewService tacviewService, IFileStorageService fileStorageService, IBus bus,
            IAntiVirusScanService avService)
        {
            _logger = logger;
            _tacviewService = tacviewService;
            _fileStorageService = fileStorageService;
            _bus = bus;
            _avService = avService;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessTacview(TacviewCreateDto tacviewCreateDto)
        {
            string b64Hash;
            var fileBytes = Convert.FromBase64String(tacviewCreateDto.FileContent);
            
            using (var sha256Hash = SHA256.Create())
            {
                var bytes = sha256Hash.ComputeHash(fileBytes);
                b64Hash = Convert.ToBase64String(bytes);
            }

            var tacview = await _tacviewService.GetProcessedTacview(b64Hash);

            if (tacview == null)
            {
                var tacviewGuid = Guid.NewGuid();
                tacview = new Processedtacviewmodel()
                {
                    Filename = tacviewGuid.ToString(),
                    Filehash = b64Hash,
                    TacviewGuid = tacviewGuid,
                    Status = "Queued",
                    UploadedDate = DateTime.UtcNow
                };
                
                await _tacviewService.RegisterTacview(tacview);
                var fileStream = new MemoryStream(fileBytes);
                var fileName = $"{tacviewGuid.ToString()}.zip.acmi";
                // TODO check starting bytes and upload to antivirus service
                var fileReport = await _avService.GetReport(fileBytes);
                var fileUri = await _fileStorageService.UploadFileToStorage(fileStream, fileName);
                await _bus.Publish(new TacviewProcessingMessage
                {
                    TacviewGuid = tacviewGuid.ToString(), 
                    TacviewUri = fileUri.AbsoluteUri
                });
            }

            var status = new TacviewStatusDto
            {
                TacviewGuid = tacview.TacviewGuid,
                Status = tacview.Status
            };
            return CreatedAtRoute("GetTacviewStatus", new {id = tacview.TacviewGuid.ToString()}, status);
        }

        [HttpGet("/api/v1/tacviews/{id:guid}", Name = "GetTacviewStatus")]
        public async Task<IActionResult> GetTacviewStatus(Guid id)
        {
            var tacview = await _tacviewService.GetProcessedTacview(id);

            if (tacview == null)
            {
                return NotFound();
            }

            var status = new TacviewStatusDto
            {
                TacviewGuid = tacview.TacviewGuid,
                Status = tacview.Status
            };
            
            return Ok(status);
        }

        [HttpPatch("/api/v1/tacviews/{id:guid}")]
        public async Task<IActionResult> UpdateTacview(Guid id, TacviewUpdateDto tacviewUpdate)
        {
            return Ok();
        }
    }
}