using FlexBazaar.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace FlexBazaar.WebUI.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerInfoAsync(string id);
    }
}
