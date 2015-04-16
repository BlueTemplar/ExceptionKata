using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ExceptionKata;

namespace ExceptionKataTests
{
    public class ExceptionKataTests
    {
        [Fact]
        public void DateMustBeProvided()
        {
            var bookingRequest = new BookingRequest(5, null);

            try
            {
                bookingRequest.Check();
            }
            catch (Exception ex)
            {
                Assert.IsType(typeof(ArgumentException), ex);
                Assert.Equal("date is missing", ex.Message);
            }
        }

        [Fact]     
        public void DateMustBeValid()
        {
            var bookingRequest = new BookingRequest(5, "Invalid Date");

            try
            {
                bookingRequest.Check();
            }
            catch (Exception ex)
            {
                Assert.IsType(typeof(FormatException), ex);
                Assert.Equal("Invalid format for date", ex.Message);
            }
        }

        [Fact]     
        public void DateCannotBeInThePast()
        {
            var bookingRequest = new BookingRequest(5, "10/10/2010");

            try
            {
                bookingRequest.Check();
            }
            catch (Exception ex)
            {
                Assert.IsType(typeof(ArgumentException), ex);
                Assert.Equal("date cannot be before today", ex.Message);
            }
        }

        [Fact]
        public void NumberOfSeatsCannotBeANegativeNumber()
        {
            var bookingRequest = new BookingRequest(-5, DateTime.Today.AddDays(1).ToString());

            try
            {
                bookingRequest.Check();
            }
            catch (Exception ex)
            {
                Assert.IsType(typeof(ArgumentException), ex);
                Assert.Equal("number of seats must be positive", ex.Message);
            }
        }

        [Fact]
        public void NoExceptionThrownWithPositiveNumberOfSeatsAndFutureDate()
        {
            var bookingRequest = new BookingRequest(-5, DateTime.Today.AddDays(1).ToString());
        }
    }
}
