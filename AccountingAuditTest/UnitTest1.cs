using AccountingAudit.Controllers;
using AccountingAudit.Domain.Models;
using AccountingAudit.Services;
using Moq;
using Xunit;

namespace AccountingAuditTest
{
    public class UnitTest1
    {
        #region CTOR
        public Mock<IEndPointService> mock = new Mock<IEndPointService>();
        #endregion

        [Fact]
        public async void Get()
        {
            //mock.Setup(p => p.GetType());
            AccountingController accountingController = new AccountingController(mock.Object);
            var result = await accountingController.Get();
               
        }
    }
}