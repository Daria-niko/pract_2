using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ежедневник
{
    public partial class MainWindow : Window
    {
        public string title, contant;
        public DateTime date;
        static List<note> notes = new List<note>(); //отсюда все выпихиваем В файл
        public MainWindow()
        {
            InitializeComponent();
            DateTime date = DateTime.Today;
            Create.IsEnabled = false;
            Delete.IsEnabled = false;
            Update.IsEnabled = false;
        }
        
        public void selected_date(object sender, SelectionChangedEventArgs e)
        {
            notes_title.Items.Clear();
            Create.IsEnabled = true;
            Delete.IsEnabled = true;
            Update.IsEnabled = true;
            foreach (var item in notes)
            {
                if(item.date == Calendar.SelectedDate)
                {
                    foreach (var note in notes)
                    {
                        notes_title.Items.Add(note.title);
                    }
                }
            }
        }
        private void click_create(object sender, RoutedEventArgs e)
        {
            title = title_note.Text;
            contant = cont.Text;
            date = Calendar.SelectedDate.Value;
            note note = new note(title, contant, date);
            notes.Add(note);
            in_file.Serialize(notes);
            notes = in_file.Mydeserializer<note>();
            title_note.Text = string.Empty;
            cont.Text = string.Empty;
        }

        private void click_del(object sender, RoutedEventArgs e)
        {
            foreach (var note in notes)
            {
                if (notes_title.SelectedItem == note.title)
                {
                    notes.Remove(note);
                    break;
                }
            }
            in_file.Serialize(notes);
            notes = in_file.Mydeserializer<note>();
            title_note.Text = string.Empty;
        }

        private void click_update(object sender, RoutedEventArgs e)
        {
            foreach (var write in notes)
            {
                if (notes_title.SelectedItem == write.title)
                {
                    notes.Remove(write);
                    break;
                }
            }
            title = title_note.Text;
            contant = cont.Text;
            date = Calendar.SelectedDate.Value;
            note note = new note(title, contant, date);
            notes.Add(note);
            in_file.Serialize(notes);
            notes = in_file.Mydeserializer<note>();
            title_note.Text = string.Empty;
        }
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var write in notes)
            {
                if (notes_title.SelectedItem == write.title)
                {
                    title_note.Text = write.title;
                    cont.Text = write.contant;
                    break;
                }
            }
        }
    }
}
