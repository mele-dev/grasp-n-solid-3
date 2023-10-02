using System;
using Full_GRASP_And_SOLID.Library;

namespace Library
{
    public class ConsolePrinter : IPrintDestination
    {
        public void Print(Recipe recipe)
        {
            Console.WriteLine(recipe.GetTextToPrint());
        }
    }
}