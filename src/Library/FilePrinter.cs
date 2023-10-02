using System.IO;
using Full_GRASP_And_SOLID.Library;

namespace Library
{
    public class FilePrinter : IPrintDestination
    {
        private string FilePath;

        public FilePrinter(string filePath)
        {
            this.FilePath = filePath;
        }

        public void Print(Recipe recipe)
        {
            File.WriteAllText(FilePath, recipe.GetTextToPrint());
        }
    }

}