namespace Будни_Программиста.Model
{
    internal class DatesChoice
    {
        public string Date;
        public List<Language> Languages;

        public static DatesChoice Create(string date, List<Language> languages)
        {
            DatesChoice new_date = new DatesChoice();
            new_date.Date = date;
            new_date.Languages = languages;
            return new_date;
        }
    }
}
