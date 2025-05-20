﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Domain.ValueObjects
{
    public class PhoneVO
    {
        public PhoneVO(string phone)
        {
            string sanitizedPhone = Sanitize(phone);

            if (!IsValidFormat(sanitizedPhone))
            {
                throw new InvalidExpressionException($"The phone number is invalid. Must be exactly 11 digits. Current length: {sanitizedPhone.Length}");

            }
            Phone = sanitizedPhone;
        }
        
        public string Value =>  Phone;
        public string Phone { get; }
        
        public static string Sanitize(string phoneInput)
        {
            if (string.IsNullOrEmpty(phoneInput))
            {
                throw new Exception("The Phone number is empty.");
            }
            return new string(phoneInput.Where(char.IsDigit).ToArray());
        }

        public static bool IsValidFormat(string sanitizedPhone)
        {
            return !string.IsNullOrWhiteSpace(sanitizedPhone) &&
                   sanitizedPhone.Length == 11 &&
                   sanitizedPhone.All(char.IsDigit);
        }
    }
}