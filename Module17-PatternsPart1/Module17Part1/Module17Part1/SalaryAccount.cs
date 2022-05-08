namespace Module17Part1
{
    public class SalaryAccount : Account, IAccount
    {
        public void CalculateInterest()
        {
            Interest -= Balance * 0.5;
        }
    }
}
