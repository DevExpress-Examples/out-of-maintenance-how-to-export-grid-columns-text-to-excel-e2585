using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Editors;
using DevExpress.XtraPrinting;

namespace FilterCombo {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 

    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            cars = new BindingList<Car>();
            colors = new BindingList<CustomColor>();

            cars.Add(new Car() { AvailableColor = 2, Make = "Make1" });
            cars.Add(new Car() { AvailableColor = 1, Make = "Make2" });
            cars.Add(new Car() { AvailableColor = 3, Make = "Make1" });
            
            gridControl1.ItemsSource = cars;

            colors.Add(new CustomColor() { ID = 1, Name="Red"});
            colors.Add(new CustomColor() { ID = 2, Name = "Blue" });
            colors.Add(new CustomColor() { ID = 3, Name = "Pink" });


            ComboBoxEditSettings combo = new ComboBoxEditSettings();
            combo.ItemsSource = colors;
            combo.DisplayMember = "Name";
            combo.ValueMember = "ID";
            combo.IsTextEditable = false;
            gridControl1.Columns["AvailableColor"].EditSettings = combo;

        }


        private void Window_Loaded(object sender, RoutedEventArgs e) {

        }

        public BindingList<Car> cars;
        public BindingList<CustomColor> colors;

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            view.ExportToXls(@"1.xls", new XlsExportOptions() { TextExportMode = TextExportMode.Text });
        }
        

       

    }
    

    public class Car {
        public int AvailableColor { get; set; }
        public string Make{get;set;}
    }

    public class CustomColor
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
