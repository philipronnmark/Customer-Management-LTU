/// Philip Rönnmark 990513-4392 2021-12-01
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A5
{
    public partial class MainForm : Form
    {
        private CustomerManager custManager = new CustomerManager();
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Opens ContactForm for creating new customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ContactForm myForm = new ContactForm(false);
            myForm.FormClosed += FormClosed;
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                Customer cust = new Customer(myForm.Contact);
                custManager.AddCustomer(cust);
                refreshCustomers();
            }
            

        }

        /// <summary>
        /// Refreshes Customers in listbox
        /// </summary>
        private void refreshCustomers()
        {
            lboxCustomer.Items.Clear();
            foreach(Customer cust in custManager.Customers)
            {
                lboxCustomer.Items.Add(cust.ToString());
            }
        }

        /// <summary>
        /// When Contact form is closed create customer and add to customermanager.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        /// <summary>
        /// Double click on item listbox to show additional information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LboxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            foreach(Customer cust in custManager.Customers)
            {
                if((lboxCustomer.SelectedIndex > -1) && lboxCustomer.SelectedItem.ToString() == cust.ToString())
                {
                    string info = cust.Contact.FirstName + " "
                        + cust.Contact.LastName + "\r\n"
                        + cust.Contact.Address.CityName + "\r\n"
                        + cust.Contact.Address.ZipCode + " "
                        + cust.Contact.Address.AddressName + "\r\n"
                        + cust.Contact.Address.Country + "\r\n\r\nEmails \r\n"
                        + "  Private: " + cust.Contact.Email.PrivateEmail + "\r\n"
                        + "  Office: " + cust.Contact.Email.PrivateEmail + "\r\n\r\n"
                        + "Phone numbers"
                        + "  Private: " + cust.Contact.Phone.HomePhone + "\r\n"
                        + "  Office: " + cust.Contact.Phone.CellPhone;

                    txtExtraInfo.Text = info;




                }
            }
            
        }



        /// <summary>
        /// Deletes customer from manager by its index in listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lboxCustomer.SelectedIndex != -1)
            {
                custManager.deleteCustomer(lboxCustomer.SelectedIndex);
                refreshCustomers();
                txtExtraInfo.Text = "";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lboxCustomer.SelectedIndex != -1) {
                Contact cont = custManager.getCustomer(lboxCustomer.SelectedIndex).Contact;
                ContactForm myForm = new ContactForm(true, cont);
                myForm.Text = "Edit Customer";
                

            
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                txtExtraInfo.Text = ""; //Clear extra info box
                refreshCustomers();
            }
            }
        }

    }
}
