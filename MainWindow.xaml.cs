using GematriaCalculator.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
        System.Timers.Timer txtDelay;
        string Language = "English";
        string Case = "Upper";
        public MainWindow()
        {
            InitializeComponent();
            txtDelay = new System.Timers.Timer();
            txtDelay.Interval = 1000;
            txtDelay.Elapsed += txtDelay_Elapsed;
        }

        private void txtDelay_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    var men_name = textName.Text;
                    if (!String.IsNullOrWhiteSpace(men_name))
                    {
                        var result = Calculator.CalculateGematria(men_name, Case);
                        txtSystem.Content = "Gematria System";
                        txtMethod.Content = "Gematria Method";
                        gridResult.ItemsSource = result;
                        gridSystem1.ItemsSource = null;
                        gridSystem2.ItemsSource = null;
                        gridSystem3.ItemsSource = null;
                        gridMethod.ItemsSource = null;
                        txtDelay.Stop();
                    }
                });
            }
            catch (Exception err)
            {
                Console.WriteLine("ERROR textName_TextChanged() " + err);
                txtDelay.Stop();
            }
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
                Console.WriteLine("ERROR mainWindow_Loaded() " + err);
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
                Console.WriteLine("ERROR cmbLanguage_SelectionChanged() " + err);
            }
        }

        private void btnReverse_Click(object sender, RoutedEventArgs e)
        {
            try
            {         
                Calculator.GenerateGematria(Language, btnReverse.IsChecked ?? false);
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
                Console.WriteLine("ERROR btnReverse_Checked() " + err);
            }
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtDelay.Stop();
            txtDelay.Start();
        }

        private void gridResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var men_name = textName.Text;
                if (!String.IsNullOrWhiteSpace(men_name) && gridResult.SelectedItem != null)
                {
                    var gem_name = (gridResult.SelectedItem as GemResult).Gematria;
                    Task.Run(() => {
                        var system = Calculator.SelectGematria(gem_name);
                        var method = Calculator.SelectMethod(gem_name, men_name);
                        var n = (int)Math.Ceiling((decimal)(system.Count / 3)) + 1;
                        Dispatcher.Invoke(() => {
                            txtSystem.Content = "Using "  + gem_name + " Gematria";
                            txtMethod.Content = "Total " + men_name + " Gematria";
                            gridMethod.ItemsSource = method;
                            gridSystem1.ItemsSource = system.Take(n); system.RemoveRange(0, n);
                            gridSystem2.ItemsSource = system.Take(n); system.RemoveRange(0, n);
                            gridSystem3.ItemsSource = system.Take(n);
                        });
                    });

                }
            }
            catch (Exception err)
            {
                Console.WriteLine("ERROR gridResult_SelectionChanged() " + err);
            }
        }


    }
}
