using System.Text.RegularExpressions;

namespace Api_Mongo.Domain.Service
{
    public class EmailValidator
    {
        public static bool Validar(string email)
        {
            Regex regex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            if(regex.IsMatch(email))
            {
                return true;
            }
            return false;
        }
    }
}