namespace MVC.Views.Validators
{
    internal class NotNegativeValidator
    {
        internal string Validate(double number)
        {
            return number < 0
                ? "Число должно быть неотрицательным!"
                : null;
        }
    }
}
