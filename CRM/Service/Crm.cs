using CRM.DTO;
using CRM.Models;
using CRM.Response;
using Microsoft.EntityFrameworkCore;
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
                                                    Id = a.Id,
                                                    CompanyName = a.CompanyName,
                                                    Date = a.Date.ToLongDateString(),
                                                    State = a.State
                                                }).ToList()
                    });
            return res;
        }
        public IEnumerable GetSingleData(int id)
        {
            var res = _crmContext.BackgroundInformations.Where(e => e.Id == id)
                    .Select(b => new GetCrmDto
                    {
                        BackgroundInformation = b,
                        BusinessExecutionStatuDto = _crmContext.BusinessExecutionStatus.Where(e => e.CompanyName == b.CompanyName)
                                                .Select(a => new BusinessExecutionStatuDto
                                                {
                                                    Id = a.Id,
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
        public void DeleteData(int id)
        {
            var data = _crmContext.BackgroundInformations.Where(e => e.Id == id);
            _crmContext.BackgroundInformations.RemoveRange(data);
            var busdata = _crmContext.BusinessExecutionStatus.Where(e => e.CompanyName == data.SingleOrDefault().CompanyName);
            _crmContext.BusinessExecutionStatus.RemoveRange(busdata);
            _crmContext.SaveChanges();
        }
        public void DeleteChildData(string companyName)
        {
            var data = _crmContext.BusinessExecutionStatus.Where(e => e.CompanyName == companyName);
            _crmContext.BusinessExecutionStatus.RemoveRange(data);
        }
        public ResponseInfo UpdateData(CrmDto value)
        {
            var dataId = _crmContext.BackgroundInformations.SingleOrDefault(e => value.BackgroundInformation.Id == e.Id);
            var data = new BackgroundInformation()
            {
                Id = dataId.Id,
                Area = value.BackgroundInformation.Area,
                AreaAddress = value.BackgroundInformation.AreaAddress,
                CellPhone = value.BackgroundInformation.CellPhone,
                City = value.BackgroundInformation.City,
                Country = value.BackgroundInformation.Country,
                CompantPhone = value.BackgroundInformation.CompantPhone,
                CompanyName = value.BackgroundInformation.CompanyName,
                CompanyUrl = value.BackgroundInformation.CompanyUrl,
                Email = value.BackgroundInformation.Email,
                EmployeeName = value.BackgroundInformation.EmployeeName,
                Fax = value.BackgroundInformation.Fax,
                IndustryType = value.BackgroundInformation.IndustryType,
                NegotiateYear = value.BackgroundInformation.NegotiateYear,
                Position = value.BackgroundInformation.Position,
                Remark = value.BackgroundInformation.Remark,
            };
            _crmContext.Entry(data).State = EntityState.Modified;
            _crmContext.SaveChanges();

            foreach (var item in value.BusinessExecutionStatu)
            {
                var childId = _crmContext.BusinessExecutionStatus.SingleOrDefault(e => e.Id == item.Id);
                var childData = new BusinessExecutionStatu()
                {
                    Id = childId.Id,
                    CompanyName = item.CompanyName,
                    Date = item.Date,
                    State = item.State,
                };
                _crmContext.Entry(childData).State = EntityState.Modified;
                _crmContext.SaveChanges();
            }
            return new ResponseInfo { Status = "200", Message = "修改成功!" };
        }
    }
}
