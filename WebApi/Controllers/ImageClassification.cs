using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImageClassification.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ML;
using WebApi.ML.DataModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageClassification : ControllerBase
    {
        private IConfiguration Configuration {get;}
        private readonly PredictionEnginePool<InMemoryImageData, ImagePrediction> _predictionEngine;
        private readonly ILogger<ImageClassification> _logger;
        public ImageClassification(
            PredictionEnginePool<InMemoryImageData, ImagePrediction> predictionEngine,
            IConfiguration configuration,
            ILogger<ImageClassification> logger )
        {
            _predictionEngine = predictionEngine;
            Configuration = configuration;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> ClassifyImage(IFormFile imageFile)
        {
            if(imageFile.Length == 0)
                return BadRequest();

            var imageMemoryStream = new MemoryStream();
            await imageFile.CopyToAsync(imageMemoryStream);

            byte[] imageData = imageMemoryStream.ToArray();


            _logger.LogInformation("Start Processing image ...");
            //Measure execution time
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Set the specific image data into the ImageInputData type used in the DataView.
            var imageInputData = new InMemoryImageData(image: imageData,
                                                        label: null,
                                                        imageFileName: null);

            var prediction = _predictionEngine.Predict(imageInputData);
             watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            _logger.LogInformation($"Image processed in {elapsedMs} miliseconds");

            // Predict the image's label (The one with highest probability).
            var imageBestLabelPrediction =
                new ImagePredictedLabelWithProbability
                {
                    PredictedLabel = prediction.PredictedLabel,
                    Probability = prediction.Score.Max(),
                    PredictionExecutionTime = elapsedMs,
                    ImageId = imageFile.FileName,
                };

            return Ok(imageBestLabelPrediction);


        }
    }
}