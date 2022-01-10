namespace MASA.Blazor.Pro.Data.Dashboard.ECommerce;

public class ECommerceService
{
    public static List<CompanyDto> GetCompanyList() => new List<CompanyDto>()
    {
        new("Dixons","Technology","23.4k","$891.2","68%","/img/avatar/1.svg","meguc@ruj.io",1,"in 24 hours",false),
        new("Motels","Grocery","78k","$668.51","97%","/img/avatar/2.svg","vecav@hodzi.co.uk",2,"in 2 days",true),
        new("Zipcar","Fashion","162","$522.29","62%","/img/avatar/3.svg","davcilse@is.gov",3,"in 5 days",true),
        new("Owning","Technology","214","$291.01","88%","/img/avatar/4.svg","meguc@ruj.io",1,"in 24 hours",true),
        new("Cafés","Grocery","208","$783.93","16%","/img/avatar/7.svg","meguc@ruj.io",2,"in 24 hours",false),
    };
}