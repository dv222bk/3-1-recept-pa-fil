using FiledRecipes.Domain;
using FiledRecipes.App.Mvp;
using FiledRecipes.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FiledRecipes.Views
{
    /// <summary>
    /// 
    /// </summary>
    public class RecipeView : ViewBase, IRecipeView
    {
        public void Show(IRecipe recipe)
        {
            base.Header = recipe.Name;
            base.ShowHeaderPanel();
            Console.WriteLine(Properties.Strings.Ingredients);
            Console.WriteLine("".CenterAlignString(new String(' ', Properties.Strings.Ingredients.Length)).Replace(" ", "-"));
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                Console.Write(ingredient.Amount + " ");
                Console.Write(ingredient.Measure + " ");
                Console.Write(ingredient.Name);
                Console.WriteLine();
            }
            Console.WriteLine(Properties.Strings.Instructions);
            Console.WriteLine("".CenterAlignString(new String(' ', Properties.Strings.Instructions.Length)).Replace(" ", "-"));
            for (int i = 0; i < recipe.Instructions.Count(); i++)
            {
                Console.WriteLine("<{0}>", i + 1);
                Console.WriteLine(recipe.Instructions.ElementAt(i));
            }
            base.ContinueOnKeyPressed();
        }
        public void Show(IEnumerable<IRecipe> recipes)
        {
            foreach (IRecipe recipe in recipes)
            {
                Show(recipe);
            }
        }
    }
}
