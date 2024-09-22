using System.ComponentModel.DataAnnotations;

namespace ApiDayOne.Validation
{
    public class MustBeInThePastAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var date = value as DateTime?;
            if(date == null)
            {
                return false;
            }
            return date < DateTime.Now;
            //if (date < DateTime.Now)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
    }
}
