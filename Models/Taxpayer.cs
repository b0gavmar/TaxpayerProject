using System;
using System.Collections.Generic;

namespace TaxpayerProject.Models;

public partial class Taxpayer
{
    private int _amount;
    private string _email;

    public Taxpayer(string name, string email)
    {
        if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
        {
            throw new ArgumentNullException("A név és email nem lehet üres");
        }
        Email = email;
        Name = name;
        Amount = 0;
    }

    public string? Email { get => _email; set => _email = value; }

    public string? Name { get; set; }

    public int? Amount { get => _amount; set => _amount = (int)value; }

    public void IncreaseTaxCredit(int amount)
    {
        if(amount < 0)
        {
            throw new ArgumentException("Az összeg nem lehet negatív");
        }
        Amount += amount;
    }

    public void DecreaseTaxCredit(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Az összeg nem lehet pozitív");
        }
        Amount += amount;
    }

    public override string ToString()
    {
        return $"Név: {Name}, Email: {Email}, Adójóváírás: {Amount} Ft";
    }
}
