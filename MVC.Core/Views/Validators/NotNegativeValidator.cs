namespace MVC.Core.Views.Validators
{
    public class NotNegativeValidator
    {
        public string Validate(double number)
        {
            return number < 0
                ? "Число должно быть неотрицательным!"
                : null;
        }
    }
}
