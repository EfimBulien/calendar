namespace Будни_Программиста.Model
{
    internal class Language
    {
        private string Name;
        private string PathPicture;
        private bool isSelected;

        public static Language Create(string name, string pathPicture)
        {
            Language language = new Language();
            language.Name = name;
            language.PathPicture = pathPicture;
            language.isSelected = false;
            return language;
        }
    }
}
