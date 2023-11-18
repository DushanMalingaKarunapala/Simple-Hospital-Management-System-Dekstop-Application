using Microsoft.VisualStudio.TestTools.UnitTesting;
using HMS;
using System;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetNextAppointmentNumber()
        {
            // Setup
            var application = new Reception();
            int doctorId = 101; // Assuming doctor ID 101
            DateTime appointmentDate = new DateTime(2023, 9, 5); // Current  date

            // Test the function
            int nextAppointmentNumber = application.GetNextAppointmentNumber(doctorId, appointmentDate);

            // Check the expected output based on the test database data
            // doctor with ID 101 on date 2023-09-05 already has 3 appointments
            int expectedAppointmentNumber = 4;
            Assert.AreEqual(expectedAppointmentNumber, nextAppointmentNumber);
        }
    }
}
