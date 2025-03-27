using TaxpayerProject.Models;

try
{
    Taxpayer ures = new Taxpayer("üres vagyok", "");
}catch (Exception e)
{
    Console.WriteLine(e.Message);
}
Taxpayer antal = new Taxpayer("Adózó Antal", "adozo.antal@ado.hu");
try
{
    antal.IncreaseTaxCredit(-2000);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
antal.IncreaseTaxCredit(2000);
antal.DecreaseTaxCredit(1000);
Console.WriteLine(antal);