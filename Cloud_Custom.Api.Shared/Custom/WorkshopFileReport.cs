using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class WorkshopFileReport
    {
        public int SlNo { get; set; }
        public int PaticularCode { get; set; }
        public Dropdown Workshop { get; set; }
        public DateTime Billdate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int FilelabourCode { get; set; }
        public string FilelabourName { get; set; }
        public int FileLoadCode { get; set; }
        public string FileLoadName { get; set; }
        public int FileMCPCode { get; set; }
        public string FileMCPName { get; set; }
        public int FileMGACode { get; set; }
        public string FileMGAName { get; set; }
        public int FilePMSCode { get; set; }
        public string FilePMSName { get; set; }
        public int FilePmsPartsCode { get; set; }
        public string FilePmsPartsName { get; set; }
        public int FileSparesCode { get; set; }
        public string FileSparesName { get; set; }
        public int FileSyntheticoilCode { get; set; }
        public string FileSyntheticoilName { get; set; }
        public int FileTrueValueCode { get; set; }
        public string FileTrueValueName { get; set; }
        public int FileTyreCode { get; set; }
        public string FileTyreName { get; set; }
        public int FileBattteryCode { get; set; }
        public string FileBattteryName { get; set; }
        public int FileCCPCode { get; set; }
        public string FileCCPName { get; set; }
        public int FileEWCode { get; set; }
        public string FileEWName { get; set; }


        public decimal Labour { get; set; }
        public decimal Load { get; set; }
        public decimal MCP { get; set; }
        public decimal MGA { get; set; }
        public decimal PMS { get; set; }
        public decimal PMSParts { get; set; }
        public decimal Spares { get; set; }
        public decimal SyntheticOil { get; set; }
        public decimal TrueValue { get; set; }
        public decimal Tyre { get; set; }
        public decimal CCP { get; set; }
        public decimal ExtendedWarranty { get; set; }
        public decimal Battery { get; set; }
        public decimal Total { get; set; }

        public List<WorkshopFileReport> List { get; set; }
        public List<GrandTotall> GrandList { get; set; }
    }
    public class GrandTotall
    {
        public string Name { get; set; }
        public decimal LabourAmt { get; set; }
        public decimal LoadAmt { get; set; }
        public decimal McpAmt { get; set; }
        public decimal MgaAmt { get; set; }
        public decimal Pms20Amt { get; set; }
        public decimal PmsPARTS { get; set; }
        public decimal SparesAmt { get; set; }
        public decimal SyntheticOilAmt { get; set; }
        public decimal TrueValueAmt { get; set; }
        public decimal TyreAmt { get; set; }
        public decimal CcpAmt { get; set; }
        public decimal EwAmt { get; set; }
        public decimal BatteryAmt { get; set; }
        public decimal Total { get; set; }
    }
}
    

