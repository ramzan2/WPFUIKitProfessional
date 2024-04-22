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
using WPFUIKitProfessional.ClassFolder;
using WPFUIKitProfessional.DataFolder;

namespace WPFUIKitProfessional.Pages.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для EditShiftsWindow.xaml
    /// </summary>
    public partial class EditShiftsWindow : Window
    {
        Shifts shifts = new Shifts();
        public EditShiftsWindow(Shifts shifts)
        {
            InitializeComponent();

            DataContext = shifts;

            this.shifts.IdShifts = shifts.IdShifts;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                shifts = DBEntities.GetContext().Shifts
                  .FirstOrDefault(u => u.IdShifts == shifts.IdShifts);
                shifts.ShiftsName = StaffCb.Text;
                shifts.StartTimeShifts = StartDt.Text;
                shifts.EndTimeShifts = EndDt.Text;
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                Close();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
