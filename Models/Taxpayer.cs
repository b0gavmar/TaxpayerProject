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
    }

    public string? Email { get => _email; set => _email = value; }

    public string? Name { get; set; }

    public int? Amount { get; set; }
}
