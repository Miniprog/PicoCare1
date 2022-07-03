

namespace PicoCare.Core.Views
{
    /// <summary>
    /// Interaction logic for ViewQuickTransaction.xaml
    /// </summary>
    public partial class ViewTransaction : Window
    {
        public ViewTransaction()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzU3NzI5QDMxMzkyZTM0MmUzMGFiUDZTT0ZVMkY2QXlhZURyWHcyWW8vUVVxWE1MZTRMK1hoQ1A3YmVYY1k9");
            SfSkinManager.SetTheme(this, new Theme("FluentDark"));
            SfSkinManager.ApplyStylesOnApplication = true;
            FluentDarkThemeSettings themeSettings = new FluentDarkThemeSettings();
            themeSettings.FontFamily = new FontFamily("B Yekan");
            SfSkinManager.RegisterThemeSettings("FluentDark", themeSettings);
        }

     

        public string ToPersianDate(DateTime thisDate , bool Timeincluded)
        {
            if (Timeincluded)
            {
                PersianCalendar pc = new PersianCalendar();
                string PersianDateConverter = "" + pc.GetYear(thisDate) + "/"
                    + pc.GetMonth(thisDate) + 

                    + pc.GetDayOfMonth(thisDate) + " /" + pc.GetHour(thisDate) + ":" + pc.GetMinute(thisDate);
                return PersianDateConverter;
            }
            else
            {
                PersianCalendar pc = new PersianCalendar();
                string PersianDateConverter = "" + pc.GetYear(thisDate) 
                    + pc.GetMonth(thisDate) 

                    + pc.GetDayOfMonth(thisDate) ;
                return PersianDateConverter;
            }
           
        }

        private async void btnsearch_Click(object sender, RoutedEventArgs e)
        {
            DealManager dealManager = new DealManager();

            ContactManager.GetContact getContact = new ContactManager.GetContact();
          

            var dit =  await  dealManager.GetDeal(txtTrackingCode.Text);
        
            var dit2 = await  dealManager.GetDealAssoc(txtTrackingCode.Text);
       
            txtDealAmount.Text = dit.properties.amount.ToString();
            txtDealDesc.Text = dit.properties.description;
         
            txtFullName.Text = dit.properties.dealname;
            txtDealDesc.Text = dit.properties.deal_desc;
            txtCloseDate.Text = dit.createdAt.ToString();
        }
    }
}
