using System;
using System.Text;

namespace Group8.TravelExperts.Data.Domain
{
    //Ricky added this code.
    //Object and its methods generates a BookingNo in teh format of three letters and three numbers.
    public class BookingNoGenerator
    {
        public static string GenerateBookingNo()
        {
            StringBuilder str_bdr = new StringBuilder();
            Random random = new Random();

            char letter;
            double flt;

            for (int i = 0; i < 3; i++)
            {
                flt = random.NextDouble(); 
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_bdr.Append(letter);
            }

            flt = random.NextDouble(); 
            int threeDigitNumber = Convert.ToInt32(Math.Floor(1000 * flt));

            if (threeDigitNumber < 100)
                threeDigitNumber += 100;

            string bookingNo = str_bdr.ToString() + threeDigitNumber.ToString();

            return bookingNo;
        }
    }
}
