using System;
using SQliteMAUI.Models;

namespace SQliteMAUI.Services
{
    public static class ContactService
    {
        public static IList<MyContact> GetContacts(int quantity = 10)
        {
            var contacts = new List<MyContact>();

            if (quantity <= 0)
            {
                return contacts;
            }

            for (var i = 0; i < quantity; i++)
            {
                contacts.Add(new MyContact
                {
                    FirstName = $"John {i}",
                    LastName = "Doe",
                    Email = $"email{i}@domain.com",
                    PhoneNumber = CreateRandomPhone(),
                });
            }

            return contacts;

        }

        public static string CreateRandomPhone()
        {
            Random random = new Random();

            // codigo de area (XXX)
            int areaCode = random.Next(100, 1000); // Ensures a 3-digit number, excluding 000

            // primera parte del numero (XXX)
            int firstPart = random.Next(100, 1000); // Ensures a 3-digit number, excluding 000

            // second part of the number (XXXX)
            int secondPart = random.Next(1000, 10000); // Ensures a 4-digit number, excluding 0000

            string phoneNumber = $"({areaCode}) {firstPart}-{secondPart}";

            return phoneNumber;
        }
    }

}

