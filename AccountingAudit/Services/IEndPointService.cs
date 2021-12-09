namespace AccountingAudit.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEndPointService
    {
        public Task<string> GetData();
    }
}
