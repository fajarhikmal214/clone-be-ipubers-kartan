namespace be_ipubers_kartan.Dtos
{
    public class CetakanServiceDtos
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
    
    public class ResponseLoginCetakanService
    {
        public required string userName { get; set; }
        public required string token { get; set; }
    }
}
