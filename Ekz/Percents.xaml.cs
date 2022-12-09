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
    public partial class Percents : Window
    {
        public class Cost
        {
            public string CostName { get; set; }
            public float CostValue { get; set; }

        }
        public List<Cost> Costs { get; set; }

        public Percents()
        {
            InitializeComponent();
        }

        public Percents(Dictionary<string,float> dictionary)
        {
            List<Cost> list = new List<Cost>();
            float totalCost = 0;
            foreach(KeyValuePair<string,float> kvp in dictionary)
            {
                list.Add(new Cost() { CostName = kvp.Key, CostValue = kvp.Value });
                totalCost += kvp.Value;
            }
            List<Cost> listFinal = new List<Cost>();
            foreach (KeyValuePair<string, float> kvp in dictionary)
            {
                listFinal.Add(new Cost() { CostName = kvp.Key, CostValue = (int)(kvp.Value * 100 / totalCost) });
            }
            Costs = listFinal;
            DataContext = this;
            InitializeComponent();
        }
    }
}
