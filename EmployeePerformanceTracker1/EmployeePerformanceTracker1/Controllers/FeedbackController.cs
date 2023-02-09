using Microsoft.AspNetCore.Mvc;
using EmployeePerformanceTracker1.Models;
using EmployeePerformanceTracker1.Services;

namespace EmployeePerformanceTracker1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : Controller
    {
       public readonly FeedbackService _feedbackService;
        public FeedbackController(FeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        #region insert
        [HttpPost]
        public async Task<IActionResult> Insert([Bind()] Feedback entity)
        {
            await _feedbackService.Insert(entity);
            await _feedbackService.Save();
            return Ok();
        }
        #endregion

        #region edit
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Feedback entity)
        {
            await _feedbackService.Update(entity);
            await _feedbackService.Save();
            return Ok(entity);
        }
        #endregion
    }
}
