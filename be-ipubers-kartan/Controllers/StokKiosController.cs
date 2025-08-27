using be_ipubers_kartan.Constants;
using be_ipubers_kartan.Dtos;
using be_ipubers_kartan.Exceptions;
using be_ipubers_kartan.Helpers;
using be_ipubers_kartan.Services;
using be_ipubers_kartan.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace be_ipubers_kartan.Controllers
{
    [ApiController]
    [Route("")]
    public class StokKiosController : Controller
    {
        private readonly IStokKiosService StokKiosService;

        public StokKiosController(IStokKiosService stokKiosService)
        {
            StokKiosService = stokKiosService;
        }

        [HttpGet()]
        [Route("/stokkios")]
        [Authorize(Roles = "KEMENTAN")]
        public async Task<IActionResult> GetStokKiosByKecamatan([FromQuery] StokKiosRequestDTO request)
        {
            try
            {
                StokKiosRequestDTOValidator validator = new();
                var validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                {
                    ModelResultDtos errorValidation = ValidationHelper.HandleValidationErrors(validationResult, HeadingMessages.StokKios.Failed);
                    throw new BusinessRuleViolationException(errorValidation.StatusDesc, errorValidation.StatusCode, errorValidation.StatusDescHeading);
                }

                var stokData = await StokKiosService.CheckStok(request);

                var response = new ModelResultDtos
                {
                    StatusCode = ResponseCodeMapping.Success,
                    StatusDesc = "Data stok berhasil dimuat",
                    StatusDescHeading = HeadingMessages.StokKios.Success,
                    Data = stokData
                };

                return Ok(response);
            }
            catch (BusinessRuleViolationException brve)
            {
                throw new BusinessRuleViolationException(brve.Message, StatusCodes.Status400BadRequest, HeadingMessages.StokKios.Failed);
            }
            catch (Exception ex)
            {
                throw new BusinessRuleViolationException(ex.Message, StatusCodes.Status500InternalServerError, HeadingMessages.StokKios.Failed);
            }
        }
    }
}