namespace AppEmployee.WinForms.Extensions
{
    public static class StringExtensions
    {
        public static string AutoGenerateId(string alias,string no)
        {
            string m = alias;
            if (no != null)
            {
                var number = int.Parse(no.Substring(2));
                number++;

                if (number < 10)
                    m += "0000000" + number;
                else if (number < 100)
                    m += "000000" + number;
                else if (number < 1000)
                    m += "00000" + number;
                else if (number < 10000)
                    m += "0000" + number;
                else if (number < 100000)
                    m += "000" + number;
                else if (number < 1000000)
                    m += "00" + number;
                else if (number < 10000000)
                    m += "0" + number;
                else if (number < 100000000)
                    m += number;
                else
                    m = $"{alias}00000001";
            }
            else
                m = $"{alias}00000001";
            return m;
        }
    }
}
