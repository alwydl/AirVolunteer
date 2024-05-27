using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AirVolunteer.Views
{
    public class MaskedEntry : Entry
    {
        public string Mask { get; set; }
        public string CleanText { get; set; } = "";

        public MaskedEntry() 
        {
            this.TextChanged += OnEntryTextChanged;
        }

        private void OnEntryTextChanged(object? sender, TextChangedEventArgs e)
        {
            string pattern = @"\D+"; // Matches one or more digits
            if (CleanText == Regex.Replace(this.Text, pattern, ""))
            {
                this.CursorPosition = this.Text.Length;
                return;
            }
            string newText = MaskText(this.Text, Mask); // Apply mask to the entered text
            this.Text = newText;
            CleanText = Regex.Replace(this.Text, pattern, "");

            // Optional: Set cursor position after applying mask
            this.CursorPosition = this.Text.Length;
        }

        private string MaskText(string text, string mask)
        {
            int maskIndex = 0;
            int textIndex = 0;
            StringBuilder maskedText = new StringBuilder();
            string pattern = @"\D+"; // Matches one or more digits
            string numbersOnly = Regex.Replace(text, pattern, "");

            while (maskIndex < mask.Length && textIndex < numbersOnly.Length)
            {
                char maskChar = mask[maskIndex];
                char textChar = numbersOnly[textIndex];

                if (maskChar == '#')
                {
                    if (char.IsDigit(textChar))
                    {
                        maskedText.Append(textChar);
                        textIndex++;
                    }
                }
                else
                {
                    maskedText.Append(maskChar);
                }
                maskIndex++;
            }
            return maskedText.ToString();
        }
    }
}
