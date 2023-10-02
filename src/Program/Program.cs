//-------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Linq;
using Full_GRASP_And_SOLID.Library;
using Library;

namespace Full_GRASP_And_SOLID
{
    public class Program
    {
        private static ArrayList productCatalog = new ArrayList();

        private static ArrayList equipmentCatalog = new ArrayList();

        public static void Main(string[] args)
        {
            PopulateCatalogs();

            Recipe recipe = new Recipe();
            recipe.FinalProduct = GetProduct("Café con leche");
            recipe.AddStep(new Step(GetProduct("Café"), 100, GetEquipment("Cafetera"), 120));
            recipe.AddStep(new Step(GetProduct("Leche"), 200, GetEquipment("Hervidor"), 60));

            /* creamos las variables consoleDestination y fileDestination las cuales
             * son de clase ConsolePrinter y FilePrinter pero utilizan la interfaz
             * IPrintDestination para escribir el metodo Print */
            IPrintDestination consoleDestination = new ConsolePrinter();
            IPrintDestination fileDestination = new FilePrinter("Recipe.txt");

            /* ahora, creaos dos variables de tipo AllInOnePrinter, las cuales
             * sin importar si son console o file, esta clase las va a imprimir
             * igual ya que la manera en que se imprimen depende de su propia
             * clase antes del metodo PrintRecipe de la clase AllInOnePrinter */
            AllInOnePrinter printerForConsole = new AllInOnePrinter(consoleDestination);
            AllInOnePrinter printerForFile = new AllInOnePrinter(fileDestination);

            printerForConsole.PrintRecipe(recipe);
            printerForFile.PrintRecipe(recipe);

            /* en este ejercicio yo estaria aplicando SRP porque las clases tienen un unico "proposito" digamos.
             * ConsolePrinter: Solo imprime en consola.
             * FilePrinter: Escribe en un archivo.
             * AllInOnePrinter: Delega la impresion a IPrintDestination sin importar los detalles de como
             * se imprime.
             * Despues tambien tendriamos el principio LSP, porque tanto ConsolePrinter como FilePrinter
             * son subtipos de la interfaz IPrintDestination. Lo que significa que nosotros podemos
             * usar cualquier objeto que implemente esta interfaz sin tneer que cambiar nada de lo
             * que ya esta hecho... */
        }

        private static void PopulateCatalogs()
        {
            AddProductToCatalog("Café", 100);
            AddProductToCatalog("Leche", 200);
            AddProductToCatalog("Café con leche", 300);

            AddEquipmentToCatalog("Cafetera", 1000);
            AddEquipmentToCatalog("Hervidor", 2000);
        }

        private static void AddProductToCatalog(string description, double unitCost)
        {
            productCatalog.Add(new Product(description, unitCost));
        }

        private static void AddEquipmentToCatalog(string description, double hourlyCost)
        {
            equipmentCatalog.Add(new Equipment(description, hourlyCost));
        }

        private static Product ProductAt(int index)
        {
            return productCatalog[index] as Product;
        }

        private static Equipment EquipmentAt(int index)
        {
            return equipmentCatalog[index] as Equipment;
        }

        private static Product GetProduct(string description)
        {
            var query = from Product product in productCatalog where product.Description == description select product;
            return query.FirstOrDefault();
        }

        private static Equipment GetEquipment(string description)
        {
            var query = from Equipment equipment in equipmentCatalog where equipment.Description == description select equipment;
            return query.FirstOrDefault();
        }
    }
}
