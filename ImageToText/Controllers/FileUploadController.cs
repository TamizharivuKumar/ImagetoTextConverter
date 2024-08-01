using ImageToText.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace ImageToText.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : Controller
    {
        private readonly IComputerVision _computerVisionService;

        public FileUploadController(IComputerVision computerVisionService)
        {
            _computerVisionService = computerVisionService;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return BadRequest(new { message = "No file uploaded!" });
            }

            var allowedExtensions = new[] { ".png", ".jpg", ".jpeg" };
            var fileExtension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(fileExtension))
            {
                return BadRequest(new { message = "Invalid file type. Only .png, .jpg, and .jpeg files are allowed!" });
            }

            try
            {
                string result;
                using (var stream = new MemoryStream())
                {
                    await imageFile.CopyToAsync(stream);
                    stream.Position = 0;
                    result = await _computerVisionService.GenerateImageToTextAsync(stream);
                }
                return Ok(new { message = result });
            }
            catch (ComputerVisionOcrErrorException ex)
            {
                return StatusCode((int)ex.Response.StatusCode, new { message = "Failed to process image. Please check your API credentials." });
            }
        }
    }
}
