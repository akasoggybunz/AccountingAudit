using AccountingAudit.Domain.Models;
using AccountingAudit.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

/// <summary>
/// Accounting Audit 
/// </summary>
/// <note>Could use differnet routing for these methods if needed </note>

namespace AccountingAudit.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountingController : ControllerBase
    {
        #region CTOR

        private readonly IEndPointService _endPointService;
        public AccountingController(IEndPointService endPointService)
        {
            _endPointService = endPointService;
        }
        #endregion

        // GET: api/<AccountingController>
        [HttpGet]
        public async Task<List<Department>> Get()
        {
            try 
            {
                var data = await _endPointService.GetData();
                var departmentData = JsonConvert.DeserializeObject<dynamic>(data);

                List<Department> departmentDataList = new List<Department>();


                // return departments whose expenses meet or exceed their funding
                foreach(var dpt in departmentData.data )
                {
                    // Build out return object
                    departmentDataList.Add(new Department
                    {
                        Name = dpt[11],
                        id = dpt[10],
                        FiscalYear = Convert.ToInt64(dpt[9]),
                        FundsAvailable =  Convert.ToInt64(dpt[12]),
                        FundsUsed =  Convert.ToInt64(dpt[13])
                        // remarks = dpt[14] // TODO
                    });

                }

                return departmentDataList.Where(x => x.FundsUsed >= x.FundsAvailable).ToList();
            }
            catch (Exception ex) 
            {
                // TODO add logging and return something useful
                return new List<Department>();
            }
        }

        // GET: api/<AccountingController>
        [HttpGet("/{percentage}/{years}")]
        public async Task<List<Department>> GetIncrease(string percentage, string years)
        {
            try
            {
                var data = await _endPointService.GetData();
                var departmentData = JsonConvert.DeserializeObject<dynamic>(data);

                List<Department> departmentDataList = new List<Department>();


                // return departments whose expenses meet or exceed their funding
                foreach (var dpt in departmentData.data)
                {
                    // Build out return object
                    departmentDataList.Add(new Department
                    {
                        Name = dpt[11],
                        id = dpt[10],
                        FiscalYear = Convert.ToInt64(dpt[9]),
                        FundsAvailable = Convert.ToInt64(dpt[12]),
                        FundsUsed = Convert.ToInt64(dpt[13])
                        // remarks = dpt[14] // TODO
                    });

                }

                // TODO
                // Actually put departments data together by department
                //departmentDataList

                // Then return departments who have increased over {years} by the {percentage}

                return departmentDataList.Where(x => x.FundsUsed >= x.FundsAvailable).ToList();
            }
            catch (Exception ex)
            {
                // TODO add logging and return something useful
                return new List<Department>();
            }
        }

        // GET: api/<AccountingController>
        [HttpGet("/{percentage}")]
        public async Task<List<Department>> GetBelow(string percentage, string years)
        {
            try
            {
                var data = await _endPointService.GetData();
                var departmentData = JsonConvert.DeserializeObject<dynamic>(data);

                List<Department> departmentDataList = new List<Department>();


                // return departments whose expenses meet or exceed their funding
                foreach (var dpt in departmentData.data)
                {
                    // Build out return object
                    departmentDataList.Add(new Department
                    {
                        Name = dpt[11],
                        id = dpt[10],
                        FiscalYear = Convert.ToInt64(dpt[9]),
                        FundsAvailable = Convert.ToInt64(dpt[12]),
                        FundsUsed = Convert.ToInt64(dpt[13])
                        // remarks = dpt[14] // TODO
                    });

                }

                // TODO
                // Actually put departments data together by department

                // return departments whose expenses are a user specified {Percentage} below their funding year over year.

                return departmentDataList.Where(x => x.FundsUsed >= x.FundsAvailable).ToList();
            }
            catch (Exception ex)
            {
                // TODO add logging and return something useful
                return new List<Department>();
            }
        }

    }
}
