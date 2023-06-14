namespace MVC.Areas.Entities.Models.ViewModels
{
    public class BaseDto
    {
        public int Id { get; set; }

        /// <summary>
        /// İçeriye bir string alır ve bu stringi belirlenen uzunluktan uzun ise o uzunluğa getirir ve return eder.
        /// </summary>
        /// <param name="text">Formatlanıcak string</param>
        /// <param name="length">İstenen string uzunluğu</param>
        /// <returns>Formatlanmış string</returns>
        public string Format(string text, int length)
        {
            if (text.Length < length)
            {
                return text;
            }
            var formatted = text.Substring(0, length) + "...";
            return formatted;
        }
    }
}