//---------------------------------------------------------------------------------
// <copyright file="AllInOnePrinter.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using System;
using System.IO;
using Library;

namespace Full_GRASP_And_SOLID.Library
{
    public enum Destination
    {
        Console,
        File
    }

    public class AllInOnePrinter
    {
        public IPrintDestination PrintDestination;

        public AllInOnePrinter(IPrintDestination printDestination)
        {
            this.PrintDestination = printDestination;
        }
        public void PrintRecipe(Recipe recipe)
        {
            this.PrintDestination.Print(recipe);
        }
    }
}