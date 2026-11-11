
using Cloud_Custom.Api.Shared.Custom;
using System;
using System.Collections.Generic;
using System.Text;


namespace Cloud_Custom.Api.Shared.General
{
    public class Filter
    {
        public UserBase User { get; set; }
        public Basic_Filter Basic_Filter { get; set; }
        public Advance_Filter Advance_Filter { get; set; }
        public Optional_Filter Optional_Filter { get; set; }
        public Date_Filter Date_Filter { get; set; }
        public int Tabindex { get; set; }
        public int SearchId { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public string Search { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public string searchValue { get; set; }
    }

    public class Basic_Filter
    {
        public FilterDropdown Designation { get; set; }

        public FilterDropdown Department { get; set; }
        public FilterDropdown Location { get; set; }
        public FilterDropdown Category { get; set; }
        public FilterDropdown Grade { get; set; }
        public FilterDropdown PayrollGroup { get; set; }
        public FilterDropdown State { get; set; }
        public Region Region { get; set; }
        public StoreOrBranch StoreOrBranch { get; set; }
        public channel Channel { get; set; }
    }
    public class Optional_Filter
    {
        public FilterDropdown Division { get; set; }
        public FilterDropdown Section { get; set; }
        public FilterDropdown EmploymentType { get; set; }
        public FilterDropdown WorkLocation { get; set; }
        public FilterDropdown WageGradeMaster { get; set; }
        public FilterDropdown EmploymentStatus { get; set; }
        public FilterDropdown Gender { get; set; }
    }



    public class Advance_Filter
    {
        public int AgeAboveBelow { get; set; }
        public string AgeAboveOrBelow { get; set; }
        public string YSAboveOrBelow { get; set; }
        public int Age { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
        public int YrsOfExperience { get; set; }

        public int YSFrom { get; set; }
        public int YSTo { get; set; }

    }

    public class Date_Filter
    {
        public FilterDropdown DateType { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }    }


  
 

}

