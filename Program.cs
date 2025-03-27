using TaxpayerProject.Models;
using TaxpayerProject.Repos;

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

TaxpayerRepo repo = new TaxpayerRepo(new TaxpayerContext());
Console.WriteLine("\n1.");
foreach (var item in await repo.GetAll())
{
    Console.WriteLine(item);
}
Console.WriteLine("\n2.");
foreach (var item in await repo.GetWithminimum(17000))
{
    Console.WriteLine(item);
}
Console.WriteLine("\n3.");
foreach (var item in await repo.GetOrderedByAmount())
{
    Console.WriteLine(item);
}
Console.WriteLine("\n4.");
foreach (var item in await repo.GetAllWithEmailDomain("@gmail.com"))
{
    Console.WriteLine(item);
}
Console.WriteLine("\n5.");