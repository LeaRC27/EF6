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
    public partial class Form2 : Form
    {
        Entities entities;
        public Form2()
        {
            entities = new Entities();
            InitializeComponent();

            load_dataGrid();
        }

        private void load_dataGrid() {

            List<productos> prod = entities.productos.ToList();

            foreach (productos p in prod) {

                this.dataGridView1.Rows.Add(p.id, p.nombre, p.cantidad, p.precio, p.subtotal, new DataGridViewButtonCell().Value = "Eliminar");

            }


        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;
            if (e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
            {
                return;
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
               e.RowIndex >= 0)
            {
                Console.WriteLine(senderGrid.CurrentRow.Cells["Id"].Value);
                DialogResult res = MessageBox.Show("Desea eliminar la fila?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if ((res == DialogResult.OK) || (res == DialogResult.Yes))
                {
                    
                    productos p = entities.productos.Find(senderGrid.CurrentRow.Cells["Id"].Value);
                    entities.productos.Remove(p);
                    entities.SaveChanges();
                    senderGrid.Rows.RemoveAt(e.RowIndex);

                    Console.WriteLine("Removed Succesfully...");

                }


            }

        }
    }
}
