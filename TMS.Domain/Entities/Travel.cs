﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities;
using TMS.Domain.Entities.Enums;
using TMS.Domain.ValueObjects;

namespace TMS.Domain.Entites
{
    public class Travel : BaseEntity
    {
        public Travel(
            DateTime startDate, 
            DateTime endDate,
            AddressVO origin,
            AddressVO destination,
            decimal price,
            LoadVO load
            )
        {
            StartDate = startDate;
            EndDate = endDate;
            Origin = origin;
            Destination = destination;
            Price = price;
            Load = load;
            CreatedAt = DateTime.Now;
        }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public AddressVO Origin { get; private set; }
        public AddressVO Destination { get; private set; }
        public LoadVO Load { get; private set; }
        public decimal Price { get; private set; }
        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; set; }

        public void UpdateTravel(
            DateTime startDate, 
            DateTime endDate,
            AddressVO origin,
            AddressVO destination,
            decimal price,
            LoadVO load
            
            )
        {
            StartDate = startDate;
            EndDate = endDate;
            Price = price;
            Load = load;
            Origin = origin;
            Destination = destination;
            UpdatedAt = DateTime.Now;
        }
       
    }
}
