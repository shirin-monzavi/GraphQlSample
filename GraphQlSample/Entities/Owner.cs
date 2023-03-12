﻿using System.ComponentModel.DataAnnotations;

namespace GraphQlSample.Entities
{
    public class Owner
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
