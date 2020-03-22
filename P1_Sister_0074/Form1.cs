using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace P1_Sister_0074
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            aktikanTextBox(false);
            totalRecord();
        }

        const int kapasitasAwal = 50;
        string[] arrCustomer = new string[kapasitasAwal];
        int jmlMax = kapasitasAwal;
        int idx = -1;
        int jmlCustomer = 0;
        char pemisah = ',';

        private void pisahdataCustomer(string customer)
        {
            char[] pisah = { pemisah };
            string[] dataCustomer = customer.Split(pisah);
            textBoxID.Text = dataCustomer[0];
            textBoxNama.Text = dataCustomer[1];
            textBoxAlamat.Text = dataCustomer[2];

        }

        private void aktikanTextBox(bool sifatKeaktifan)
        {
            textBoxID.Enabled = sifatKeaktifan;
            textBoxNama.Enabled = sifatKeaktifan;
            textBoxAlamat.Enabled = sifatKeaktifan;

        }
        private void bersih()
        {
            textBoxID.Clear();
            textBoxNama.Clear();
            textBoxAlamat.Clear();
        }

        private void totalRecord()
        {
            labelTotal.Text = "Total Record = " + jmlCustomer.ToString();
        }

        private void updateDataArray()
        {
            if (jmlCustomer > 0)
            {
                string customer = "";
                customer = customer + textBoxID.Text + pemisah;
                customer = customer + textBoxNama.Text + pemisah;
                customer = customer + textBoxAlamat.Text ;

                arrCustomer[idx] = customer;
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            DialogResult pilih = dlgOpen.ShowDialog();
            if (pilih == DialogResult.OK)
            {
                arrCustomer = File.ReadAllLines(dlgOpen.FileName);
                jmlCustomer = arrCustomer.Length;
                idx = 0;

                jmlMax = jmlCustomer * 2;
                Array.Resize(ref arrCustomer, jmlMax);

                string customer = arrCustomer[idx];
                pisahdataCustomer(customer);
                aktikanTextBox(true);
                totalRecord();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            updateDataArray();
            DialogResult pilih = dlgSave.ShowDialog();
            if (pilih == DialogResult.OK)
            {
                string[] arrBantuan = new string[jmlCustomer];
                Array.Copy(arrCustomer, arrBantuan, jmlCustomer);
                File.WriteAllLines(dlgSave.FileName, arrBantuan);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonFirst_Click(object sender, EventArgs e)
        {
            updateDataArray();
            if (jmlCustomer > 0)
            {
                idx = 0;
                string customer = arrCustomer[idx];
                pisahdataCustomer(customer);
                totalRecord();
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            updateDataArray();
            if (jmlCustomer > 0)
            {
                idx--;
                if (idx < 0)
                    idx = 0;
                string customer = arrCustomer[idx];
                pisahdataCustomer(customer);
                totalRecord();
            }

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            updateDataArray();
            if (jmlCustomer > 0)
            {
                idx ++;
                if (idx >= jmlCustomer)
                    idx = jmlCustomer - 1;

                string customer = arrCustomer[idx];
                pisahdataCustomer(customer);
                totalRecord();
            }
        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            updateDataArray();
            if (jmlCustomer > 0)
            {
                idx = jmlCustomer - 1;
                string customer = arrCustomer[idx];
                pisahdataCustomer(customer);
                totalRecord();
            }
        }



        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            aktikanTextBox(true);
            updateDataArray();
            if (jmlCustomer == jmlMax)
            {
                jmlMax *= 2;
                Array.Resize(ref arrCustomer, jmlMax);
            }

            bersih();
            textBoxID.Focus();
            idx = jmlCustomer;
            jmlCustomer++;
            totalRecord();
        }

        private void buttonDell_Click(object sender, EventArgs e)
        {
            updateDataArray();
            if (jmlCustomer > 0)
            {
                if (idx == jmlCustomer - 1)
                {
                    idx--;
                }
                else
                {
                    for (int i = idx; i < jmlCustomer; i++)
                    {
                        arrCustomer[i] = arrCustomer[i + 1];
                    }
                }

                jmlCustomer--;

                if (jmlCustomer > 0)
                {
                    string customer = arrCustomer[idx];
                    pisahdataCustomer(customer);
                }
                else
                {
                    bersih();
                    aktikanTextBox(false);
                }

                totalRecord();
            }
        }
    }
}
