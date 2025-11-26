using System;
using System.Linq;
using System.Data;

namespace TMS.Domain.ValueObjects
{
    public enum TaxIdKind
    {
        Unknown,
        Cpf,
        Cnpj
    }

    public class TaxIdVO
    {
        public TaxIdVO(string taxId)
        {
            var sanitized = Sanitize(taxId);

            if (IsCpf(sanitized))
            {
                if (!ValidateCpf(sanitized))
                    throw new InvalidExpressionException("CPF inválido.");

                TaxId = sanitized;
                Kind = TaxIdKind.Cpf;
                return;
            }

            if (IsCnpj(sanitized))
            {
                if (!ValidateCnpj(sanitized))
                    throw new InvalidExpressionException("CNPJ inválido.");

                TaxId = sanitized;
                Kind = TaxIdKind.Cnpj;
                return;
            }

            throw new InvalidExpressionException("O tax id informado não é CPF nem CNPJ válidos.");
        }

        public string TaxId { get; private set; }

        public TaxIdKind Kind { get; private set; } = TaxIdKind.Unknown;

        public static string Sanitize(string taxIdInput)
        {
            if (string.IsNullOrWhiteSpace(taxIdInput))
                throw new ArgumentException("The tax id is empty.");

            var digits = new string(taxIdInput.Where(char.IsDigit).ToArray());
            if (string.IsNullOrEmpty(digits))
                throw new ArgumentException("The tax id does not contain digits.");

            return digits;
        }

        public static bool IsCpf(string sanitizedTaxId)
        {
            return !string.IsNullOrWhiteSpace(sanitizedTaxId) &&
                   sanitizedTaxId.Length == 11 &&
                   sanitizedTaxId.All(char.IsDigit);
        }

        public static bool IsCnpj(string sanitizedTaxId)
        {
            return !string.IsNullOrWhiteSpace(sanitizedTaxId) &&
                   sanitizedTaxId.Length == 14 &&
                   sanitizedTaxId.All(char.IsDigit);
        }

        public static bool ValidateCpf(string cpf)
        {
            if (!IsCpf(cpf)) return false;

            // rejeita sequências com todos os dígitos iguais
            if (cpf.Distinct().Count() == 1) return false;

            int[] nums = cpf.Select(c => c - '0').ToArray();

            // Primeiro dígito verificador
            int sum = 0;
            for (int i = 0; i < 9; i++) sum += nums[i] * (10 - i);
            int r = sum % 11;
            int d1 = (r < 2) ? 0 : 11 - r;
            if (nums[9] != d1) return false;

            // Segundo dígito verificador
            sum = 0;
            for (int i = 0; i < 10; i++) sum += nums[i] * (11 - i);
            r = sum % 11;
            int d2 = (r < 2) ? 0 : 11 - r;
            return nums[10] == d2;
        }

        public static bool ValidateCnpj(string cnpj)
        {
            if (!IsCnpj(cnpj)) return false;

            // rejeita sequências com todos os dígitos iguais
            if (cnpj.Distinct().Count() == 1) return false;

            int[] nums = cnpj.Select(c => c - '0').ToArray();

            int[] weights1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] weights2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int sum = 0;
            for (int i = 0; i < 12; i++) sum += nums[i] * weights1[i];
            int r = sum % 11;
            int d1 = (r < 2) ? 0 : 11 - r;
            if (nums[12] != d1) return false;

            sum = 0;
            for (int i = 0; i < 13; i++) sum += nums[i] * weights2[i];
            r = sum % 11;
            int d2 = (r < 2) ? 0 : 11 - r;
            return nums[13] == d2;
        }

        // opcional: retorna formatado (ex.: 000.000.000-00 ou 00.000.000/0000-00)
        public string ToFormatted()
        {
            if (Kind == TaxIdKind.Cpf && TaxId.Length == 11)
            {
                return $"{TaxId.Substring(0, 3)}.{TaxId.Substring(3, 3)}.{TaxId.Substring(6, 3)}-{TaxId.Substring(9, 2)}";
            }
            else if (Kind == TaxIdKind.Cnpj && TaxId.Length == 14)
            {
                return $"{TaxId.Substring(0, 2)}.{TaxId.Substring(2, 3)}.{TaxId.Substring(5, 3)}/{TaxId.Substring(8, 4)}-{TaxId.Substring(12, 2)}";
            }
            return TaxId;
        }
    }
}