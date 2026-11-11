using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
public interface IDMSSalesMisRepository
    {
        Task<DMSSalesMis> GetTabDetails(UserBase user, int Delearship,     string Fromdate, string ToDate);

        Task<DMSSalesMis> GetBranchWiseDetails(UserBase user, int Delearship,     string Fromdate, string ToDate);
        Task<DMSSalesMis> GetModelWiseDetails(UserBase user, int Delearship,     string Fromdate, string ToDate);
        Task<DMSSalesMis> GetTLWiseDetails(UserBase user, int Delearship,     string Fromdate, string ToDate);
        Task<DMSSalesMis> GetTLVSEMPLOYEEDetails(UserBase user, int Delearship,     string Fromdate, string ToDate, int TLEmployeeCode);
        Task<DMSSalesMis> GetVariantWiseDetails(UserBase user, int Delearship,     string Fromdate, string ToDate);

        Task<DMSSalesMis> GetV1Details(UserBase user, int Branch, string Fromdate, string ToDate, int Model);
    }
}
