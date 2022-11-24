using CRM.DTO;
using CRM.Models;
using CRM.Response;
using System.Collections;

namespace CRM.Service
{
    public class Crm
    {
        private readonly CrmContext _crmContext;
        public Crm (CrmContext crmContext)
        {
            _crmContext = crmContext;
        }
        public IEnumerable GetData()
        {
            var res = _crmContext.BackgroundInformations
                    .Select(b => new GetCrmDto
                    {
                        BackgroundInformation = b,
                        BusinessExecutionStatuDto = _crmContext.BusinessExecutionStatus.Where(e => e.CompanyName == b.CompanyName)
                                                .Select(a => new BusinessExecutionStatuDto
                                                {
                                                    CompanyName = a.CompanyName,
                                                    Date = a.Date.ToLongDateString(),
                                                    State = a.State
                                                }).ToList()
                    });
            return res;
        }
        public ResponseInfo PostData(CrmDto value)
        {
            var data = _crmContext.BackgroundInformations.Where(e => e.CompanyName == value.BackgroundInformation.CompanyName);
            if (data.Any())
            {
                return new ResponseInfo { Status = "001", Message = "公司已存在!" };
            }
            _crmContext.BackgroundInformations.Add(value.BackgroundInformation);
            foreach (var item in value.BusinessExecutionStatu)
            {
                _crmContext.BusinessExecutionStatus.Add(item);
            }
            _crmContext.SaveChanges();
            return new ResponseInfo { Status = "200", Message = "新增成功!" };
        }
        public ResponseInfo InsertChilProfile(ICollection<BusinessExecutionStatu> value)
        {
            foreach (var item in value)
            {
                _crmContext.BusinessExecutionStatus.Add(item);
            }
            _crmContext.SaveChanges();
            return new ResponseInfo { Status = "200", Message = "新增成功!" };
        }
    }
}
