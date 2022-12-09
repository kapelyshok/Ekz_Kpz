using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Ekz
{
    
    public partial class MonthSorting : Window
    {
        public List<Operation> Operations { get; set; }
        public MonthSorting()
        {
            InitializeComponent();
        }
        public MonthSorting(List<Operation> operations)
        {
            InitializeComponent();
            Operations = operations;
            DataContext = this;
        }
    }
}
