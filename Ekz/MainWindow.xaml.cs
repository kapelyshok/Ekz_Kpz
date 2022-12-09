using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Ekz
{
    public partial class MainWindow : Window
    {
        private BankingContex context;
        public MainWindow()
        {
            InitializeComponent();
            context = new BankingContex();
            context.Operations.Load();
            OperationsGrid.ItemsSource = context.Operations.Local.ToBindingList();            
        }
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            Operation operationToDelete = (Operation)OperationsGrid.SelectedItem;
            context.Entry(operationToDelete).State = EntityState.Deleted;
            context.SaveChanges();
            OperationsGrid.ItemsSource = (from d in context.Operations select d).ToList();
        }
        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }
        private void ButtonPercents_Click(object sender, RoutedEventArgs e)
        {        
            var operations = from d in context.Operations select d;
            Dictionary<string,float> costs = new Dictionary<string,float>();
            foreach(var operation in operations)
            {
                if(costs.ContainsKey(operation.Type))
                {
                    costs[operation.Type] += operation.Cost;
                }
                else
                {
                    costs[operation.Type] = operation.Cost;

                }
            }
            var costsWindow = new Percents(costs);
            costsWindow.Show();
        }

        private void Button_Click_Month(object sender, RoutedEventArgs e)
        {
            Operation operationSelected;
            try
            {
                operationSelected = (Operation)OperationsGrid.SelectedItem;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Select row to define month");
                return;
            }
            if (operationSelected == null)
            {
                MessageBox.Show("Select row to define month");
                return;
            }
            var month = operationSelected.Time.Month;
            var operations = from d in context.Operations
                             where d.Time.Month == month
                             select d;
            MonthSorting newWindow = new MonthSorting(operations.ToList());
            newWindow.Show();
        }
    }
}
