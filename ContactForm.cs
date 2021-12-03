/// Philip Rönnmark 990513-4392 2021-11-10
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
     partial class ContactForm : Form
    {
        private Contact contact;
        private bool edit;
        public ContactForm(bool edit) 
        {
            InitializeComponent();
            this.edit = edit;
            if (edit)
            {
                loadFields();
            }

        }
        /// <summary>
        /// Overloading the default constructor for passing existing customer object to edit
        /// </summary>
        /// <param name="edit"></param>
        /// <param name="cont"></param>
        public ContactForm(bool edit, Contact cont)
        {
            InitializeComponent();
            this.edit = edit;
            
            if (edit)
            {
                contact = cont;
                loadFields();
                
            }

        }

        public Contact Contact { get => contact; set => contact = value; }

        /// <summary>
        /// Window for making sure user want to close and lose data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This will close the window, and data will be lost", "Close", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
            }

        }

        /// <summary>
        /// Load txt fields from loaded existing customer
        /// </summary>
        private void loadFields()
        {
            txtFName.Text = contact.FirstName;
            txtLName.Text = contact.LastName;
            txtHomePhone.Text = contact.Phone.HomePhone;
            txtCellPhone.Text = contact.Phone.CellPhone;
            txtEmailBusiness.Text = contact.Email.BusinessEmail;
            txtEmailPrivate.Text = contact.Email.PrivateEmail;
            txtStreet.Text = contact.Address.AddressName;
            txtCity.Text = contact.Address.CityName;
            txtZipCode.Text = contact.Address.ZipCode;
            txtCountry.Text = contact.Address.Country;
          
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string fname = txtFName.Text;
            string lname = txtLName.Text;

            //Create Phone
            string homePhone = txtHomePhone.Text;
            string cellPhone = txtCellPhone.Text;
            Phone contactPhone = new Phone(homePhone, cellPhone);

            //Create email
            string emailBusiness = txtEmailBusiness.Text;
            string emailPrivate = txtEmailPrivate.Text;
            Email contactEmail = new Email(emailPrivate, emailBusiness);

            //Create address
            string street = txtStreet.Text;
            string city = txtCity.Text;
            string zip = txtZipCode.Text;
            string country = txtCountry.Text;
            Address contactAddress = new Address(street, city, zip, country);

            if (!edit) //Creating a new customer 
            {
                try
                {
                    Contact cont = new Contact(fname, lname, contactPhone, contactEmail, contactAddress);
                    Contact = cont; //Set contact info to object
                    DialogResult = DialogResult.OK;
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Provide atleast First name or Lastname, City and country.");
                }

            } else //Editing an existing customer
            { 

                try
                {
                    Contact cont = new Contact(fname, lname, contactPhone, contactEmail, contactAddress); //Not using the created object, instead checking if exception is throwed.
                    cont = null;
                    contact.FirstName = txtFName.Text;
                    contact.LastName = txtLName.Text;
                    contact.Phone.HomePhone = txtHomePhone.Text;
                    contact.Phone.CellPhone = txtCellPhone.Text;
                    contact.Email.BusinessEmail = txtEmailBusiness.Text;
                    contact.Email.PrivateEmail = txtEmailPrivate.Text;
                    contact.Address.AddressName = txtStreet.Text;
                    contact.Address.CityName = txtCity.Text;
                    contact.Address.ZipCode = txtZipCode.Text;
                    contact.Address.Country = txtCountry.Text;
                    DialogResult = DialogResult.OK;
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Provide atleast First name or Lastname, City and country.");
                }


            }

            
        }
    }
}
