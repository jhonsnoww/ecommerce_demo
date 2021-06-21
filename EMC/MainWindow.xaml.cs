using EMC.Data;
using EMC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace EMC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 

    public MainWindow()
        {
            InitializeComponent();
            DeleteProduct();
        }

        public void SaveProduct()
        {
            using ContosoPets context = new ContosoPets();

            Product b1 = new Product();

            b1.Name = "Book 1";
            b1.price = 2000.21M;

            context.Products.Add(b1);

            Product b2 = new Product();

            b2.Name = "Book 2";
            b2.price = 2100.21M;

            context.Products.Add(b2);

            context.SaveChanges();



        }

        public void ReadProduct()
        {
            using ContosoPets context = new ContosoPets();

            var products = context.Products.OrderBy(p => p.Name);

            foreach(Product p in products)
            {
                Debug.WriteLine("ID :: " + p.Id);
                Debug.WriteLine("Name :: " + p.Name);
                Debug.WriteLine("Price :: " + p.price);
            }
        }

        public void UpdateProduct()
        {
            using ContosoPets context = new ContosoPets();

            var book1 = context.Products.OrderBy(p => p.Id == 2).FirstOrDefault();

            if (book1 is Product)
            {
                book1.Name = "Book 3";
            }
          
            context.SaveChanges();



            var products = context.Products.OrderBy(p => p.Name);

            foreach (Product p in products)
            {
                Debug.WriteLine("ID :: " + p.Id);
                Debug.WriteLine("Name :: " + p.Name);
                Debug.WriteLine("Price :: " + p.price);
            }
        }


        public void DeleteProduct()
        {
            using ContosoPets context = new ContosoPets();

            var book1 = context.Products.Find(3);

            context.Products.Remove(book1);
            context.SaveChanges();



            var products = context.Products.OrderBy(p => p.Name);

            foreach (Product p in products)
            {
                Debug.WriteLine("ID :: " + p.Id);
                Debug.WriteLine("Name :: " + p.Name);
                Debug.WriteLine("Price :: " + p.price);
            }
        }
    }
}
