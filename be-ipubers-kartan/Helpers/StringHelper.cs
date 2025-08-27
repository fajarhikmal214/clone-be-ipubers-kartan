namespace be_ipubers_kartan.Helpers
{
    public class StringHelper
    {
        public static string RunningAlphanumeric(string lastNumber)
        {
            try
            {
                string alphaNumeric = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                List<char> karakter = alphaNumeric.ToCharArray().ToList();
                List<char> chars = new List<char>();

                var splitLastNumber = lastNumber.ToUpper().ToCharArray();

                for (int i = splitLastNumber.Count(); i > 0; i--)
                {
                    if (splitLastNumber[i - 1] != karakter.Last())
                    {
                        splitLastNumber[i - 1] = karakter[karakter.FindIndex(e => e == splitLastNumber[i - 1]) + 1];
                        break;
                    }
                    else
                    {
                        splitLastNumber[i - 1] = alphaNumeric.First();
                        continue;
                    }
                }

                return new string(splitLastNumber);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
