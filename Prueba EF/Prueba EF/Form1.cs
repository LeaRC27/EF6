using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_EF
{
    public partial class Form1 : Form
    {
        Entities entities; 

        public Form1()
        {
            InitializeComponent();
            entities = new Entities();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            productos p = new productos();
            p.nombre = textBox1.Text;
            p.cantidad = Int32.Parse(textBox2.Text);
            p.precio = float.Parse(textBox3.Text);
            p.subtotal = Int32.Parse(textBox2.Text) * float.Parse(textBox3.Text);


            entities.productos.Add(p);
            entities.SaveChanges();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form2 grid = new Form2();

            grid.Show();
        }
    }
}
