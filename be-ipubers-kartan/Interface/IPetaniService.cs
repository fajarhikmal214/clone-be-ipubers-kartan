namespace be_ipubers_kartan.Interface
{
    public interface IPetaniService
    {
        Task<Models.Petani> InsertAvailableNIKIpubers(Models.Petani petani, string createdby);
        Task<Models.Rekan.Petani> InsertAvailableNIKRekan(Models.Rekan.Petani petani, string createdby);
    }
}
