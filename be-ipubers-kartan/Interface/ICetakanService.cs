using be_ipubers_kartan.Dtos;

namespace be_ipubers_kartan.Interface
{
    public interface ICetakanService
    {
        Task<ResponseLoginCetakanService> LoginAsync();
    }
}
