﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionKata
{
    public class BookingRequest
    {
        private int numberOfSeats;
        private string date;

        public BookingRequest(int numberOfSeats, string date)
        {
            this.numberOfSeats = numberOfSeats;
            this.date = date;
        }

        public void Check()
        {
            if (date == null)
                throw new ArgumentException("date is missing");

            DateTime parsedDate;
            try
            {
                parsedDate = DateTime.Parse(date);
            }
            catch (FormatException e)
            {
                throw new ArgumentException("Invalid format for date", e);
            }
            if (parsedDate < DateTime.Now) throw new ArgumentException("date cannot be before today");
            if (numberOfSeats < 1) throw new ArgumentException("number of seats must be positive");
        }
    }
}
