using be_ipubers_kartan.Dtos;

namespace be_ipubers_kartan.Interface
{
    public interface IElasticLoggingService
    {
       Task IndexErrorLogAsync(ExceptionLogDto errorLog);
    }

}