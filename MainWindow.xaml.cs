using GematriaCalculator.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GematriaCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GematriaCalc Calculator;
        string Language = "English";
        string Case = "Upper";
        public MainWindow()
        {
            InitializeComponent();        
        }

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Calculator = new GematriaCalc();
                var languages = Calculator.Languages.Select(r => r.Name).Distinct().ToList();
                cmbLanguage.ItemsSource = languages;
                cmbLanguage.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                Console.WriteLine("ERROR mainWindow_Loaded: " + err);
            }         
        }

        private void cmbLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Language = cmbLanguage.SelectedItem as String;
                Case = Calculator.Languages.Where(r => r.Name == Language).First().Case;         
                Calculator.GenerateGematria(Language);
                switch (Case)
                {
                    case "Upper": textName.CharacterCasing = CharacterCasing.Upper; break;
                    case "Lower": textName.CharacterCasing = CharacterCasing.Lower; break;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("ERROR cmbLanguage_SelectionChanged: " + err);
            }
        }

        private void textName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var name = textName.Text;
                var result = Calculator.CalculateGematria(name, Case);
                gridResult.ItemsSource = result;
                gridSystem1.ItemsSource = null;
                gridSystem2.ItemsSource = null;
                gridSystem3.ItemsSource = null;
                gridMethod.ItemsSource = null;
            }
            catch (Exception err)
            {
                Console.WriteLine("ERROR textName_TextChanged: " + err);
            }
        }

        private void gridResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var men_name = textName.Text;
                var gem_name = (gridResult.SelectedItem as GemResult).Gematria;
                var system = Calculator.GematriaSystem(gem_name);
                var method = Calculator.GematriaMethod(gem_name, men_name);
                gridMethod.ItemsSource = method;
                var n = (int)Math.Ceiling((decimal)(system.Count / 3)) + 1;
                gridSystem1.ItemsSource = system.Take(n); system.RemoveRange(0, n);
                gridSystem2.ItemsSource = system.Take(n); system.RemoveRange(0, n);
                gridSystem3.ItemsSource = system.Take(n); system.RemoveRange(0, n);             
            }
            catch (Exception err)
            {
                Console.WriteLine("ERROR gridResult_SelectionChanged: " + err);
            }
        }


    }
}
