using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        IPrizeRequester callingForm;
        public CreatePrizeForm(IPrizeRequester caller)
        {
            InitializeComponent();

            callingForm = caller;
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel(
                    placeNameValue.Text, 
                    placeNumberValue.Text, 
                    prizeAmountValue.Text,
                    prizePercentageValue.Text);

                GlobalConfig.Connections[0].CreatePrize(model);
                /*
                foreach (IDataConnection db in GlobalConfig.Connections)
                {
                    db.CreatePrize(model);
                }*/

                callingForm.PrizeComplete(model);

                this.Close();
                /*placeNameValue.Text = "";
                placeNumberValue.Text = "";
                prizeAmountValue.Text = "";
                prizePercentageValue.Text = "";*/
            }
            else
            {
                MessageBox.Show("Неверный ввод. Пожалуйста проверьте введенные данные");
            }
        } 

        private bool ValidateForm()
        {
            //TODO добавить логи, при любой попытке регистрации писались логи 
            bool output = true;
            int placeNumber = 0;
            bool placeNumberValidator = int.TryParse(placeNumberValue.Text, out placeNumber);

            if (!placeNumberValidator || placeNumber < 1)
            {
                output = false;
            }

            if (placeNameValue.Text.Length == 0)
            {
                output = false;
            }

            decimal prizeAmount = 0;
            double prizePercentage = 0;

            bool prizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out prizeAmount);
            bool prizePercentageValid = double.TryParse(prizePercentageValue.Text, out prizePercentage);   

            if (prizeAmountValid == false && prizePercentageValid == false)
            {
                output = false;
            }
            if ((prizeAmount <= 0 && prizePercentage <= 0) ||
                (prizePercentage < 0 || prizePercentage > 100))
            {
                output = false;
            }
            return output;
        }

        private void priceAmountLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
