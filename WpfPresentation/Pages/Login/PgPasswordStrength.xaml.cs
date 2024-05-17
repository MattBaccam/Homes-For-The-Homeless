using DataObjects;
using LogicLayer;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPresentation.Pages.Login
{

    /// <summary>
    /// Creator: Miyada Abas       
    /// Created: 02/27/2024
    /// Summary: This method showes password strength
    /// Last Updated By: 
    /// Last Updated: 02/27/2024
    /// What Was Changed: Inital creation
    /// </summary>
    /// </summary>
    public partial class PgPasswordStrength : Page
    {
        private LoginManagerInterFace loginManger;
        public PgPasswordStrength()
        {
            InitializeComponent();
            loginManger = new LoginManger();
        }

        private static PgPasswordStrength instance = null;
        public static PgPasswordStrength GetPgPasswordStrength()
        {
            return instance ?? (instance = new PgPasswordStrength());
        }

        /// <summary>
        /// Creator: Miyada Abas       
        /// Created: 02/27/2024
        /// Summary: This method showes password strength
        /// Last Updated By: 
        /// Last Updated: 02/27/2024
        /// What Was Changed: Inital creation
        /// </summary>
        /// </summary>
        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password.Length < 5)
            {
                lblPasswordStrength.Content = "weak";
                return;
            }
            if (txtPassword.Password.Length < 8)
            {
                lblPasswordStrength.Content = "Good";
                return;
            }
            lblPasswordStrength.Content = "Strong";
        }
        /// <summary>
        /// Creator: Miyada Abas       
        /// Created: 02/27/2024
        /// Summary: This method submit the logi page
        /// Last Updated By: Tyler Barz
        /// Last Updated: 03/05/2024 
        /// What Was Changed: Changed to EmployeePass to get rid of property PasswordHash as it's already in a VM
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        /// </summary>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFormValid())
            {
                return;
            }
            EmployeePass employee = new EmployeePass();
            employee.EmployeeID = txtEmployeeId.Text;
            employee.FirstName = txtFname.Text;
            employee.LastName = txtEmail.Text;
            employee.PhoneNumber = txtPhone.Text;
            employee.Gender = txtGender.Text == "Male";
            employee.PasswordHash = txtPassword.Password;
            employee.AccountStatus = txtAccountStatus.Text == "true";
            employee.ZipCode = Convert.ToInt32(txtZipCode.Text);
            employee.Address = txtAddress.Text;
            employee.StartDate = DateTime.Now;
            employee.EndDate = DateTime.Now;
            try
            {
                bool result = loginManger.SignUp(employee);
                if (result)
                {
                    lblErrorMessage.Content = "sign up done correctly";
                    clearForm();
                }
                else
                {
                    lblErrorMessage.Content = "sign up did not done";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to sign up \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }

        }
        /// <summary>
        /// Creator: Miyada Abas       
        /// Created: 02/27/2024
        /// Summary: This method clear the form
        /// Last Updated By: 
        /// Last Updated: 02/27/2024
        /// What Was Changed: Inital creation
        /// </summary>
        /// </summary>
        private void clearForm()
        {
            txtEmployeeId.Text = string.Empty;
            txtFname.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtGender.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtStartDate.Text = string.Empty;
            txtEndDate.Text = string.Empty;
            txtZipCode.Text = string.Empty;
            txtPassword.Password = string.Empty;
            txtAccountStatus.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }
        /// <summary>
        /// Creator: Miyada Abas       
        /// Created: 02/27/2024
        /// Summary: This method check if the form is valid
        /// Last Updated By: 
        /// Last Updated: 02/27/2024
        /// What Was Changed: Inital creation
        /// </summary>
        /// </summary>
        private bool IsFormValid()
        {

            if (txtEndDate.Text.Length == 0)
            {
                lblErrorMessage.Content = "EndDate is required";
                return false;
            }
            if (txtStartDate.Text.Length == 0)
            {
                lblErrorMessage.Content = "StartDate is required";
                return false;
            }
            if (txtAddress.Text.Length == 0)
            {
                lblErrorMessage.Content = "Address is required";
                return false;
            }
            if (txtZipCode.Text.Length == 0)
            {
                lblErrorMessage.Content = "zipcode is required";
                return false;
            }
            if (txtAccountStatus.Text.Length == 0)
            {
                lblErrorMessage.Content = "AccountStatus is required";
                return false;
            }
            if (txtGender.Text.Length == 0)
            {
                lblErrorMessage.Content = "Gender is required";
                return false;
            }
            if (txtPhone.Text.Length == 0)
            {
                lblErrorMessage.Content = "Phone is required";
                return false;
            }
            if (txtFname.Text.Length == 0)
            {
                lblErrorMessage.Content = "Fname is required";
                return false;
            }
            if (txtPassword.Password.Length == 0)
            {
                lblErrorMessage.Content = "password is required";
                return false;
            }
            if (txtEmail.Text.Length == 0)
            {
                lblErrorMessage.Content = "Email is required";
                return false;
            }
            if (txtEmployeeId.Text.Length == 0)
            {
                lblErrorMessage.Content = "employeeId is required";
                return false;
            }
            lblErrorMessage.Content = "";
            return true;
        }
    }
}

