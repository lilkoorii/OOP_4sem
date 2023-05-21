using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Data.Entity;
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
using System.Data;

namespace Laba9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EFGenericRep<Item> itemRep = new EFGenericRep<Item>(new ChannelContext());
        EFGenericRep<Channel> chRep = new EFGenericRep<Channel>(new ChannelContext());

        //ChannelContext db;
        public MainWindow()
        {
            InitializeComponent();

            //db = new ChannelContext();

            //db.Items.Load();

            DataGrid1.ItemsSource = itemRep.Get();

            //DataGrid1.ItemsSource = db.Items.Local.ToBindingList();

            //this.Closing += MainWindow_Closing;

        }

        //private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    db.Dispose();
        //}

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ItemWindow iWin = new ItemWindow();

            // из команд в бд формируем список

            //List<Channel> channels = db.Channels.ToList();
            //List<Channel> channels = (List<Channel>)chRep.Get();


            //iWin.comboBox1.ItemsSource = db.Channels.Local.ToBindingList();
            iWin.comboBox1.ItemsSource = chRep.Get();

            iWin.comboBox1.DisplayMemberPath = "Title";

            if (iWin.ShowDialog() == true)
            {
                Item item = new Item();
                item.Title = iWin.textBox1.Text;
                item.Description = iWin.textBox2.Text;
                item.Link = iWin.textBox3.Text;
                item.PubDate = iWin.textBox4.Text;
                item.Channel = (Channel)iWin.comboBox1.SelectedItem;

                itemRep.Create(item);
                UpdateDB();

                MessageBox.Show("Новая статья добавлена");
            }
            else
            {
                return;
            }
        }

        private async void Change_Click(object sender, EventArgs e)
        {
            if (DataGrid1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < DataGrid1.SelectedItems.Count; i++)
                {
                    Item item = DataGrid1.SelectedItems[i] as Item;
                    if (item != null)
                    {
                        ItemWindow iWin = new ItemWindow();

                        iWin.textBox1.Text = item.Title;
                        iWin.textBox2.Text = item.Description;
                        iWin.textBox3.Text = item.Link;
                        iWin.textBox4.Text = item.PubDate;

                        //List<Channel> channels = db.Channels.ToList();

                        //iWin.comboBox1.ItemsSource = db.Channels.Local.ToBindingList();
                        iWin.comboBox1.ItemsSource = chRep.Get();

                        iWin.comboBox1.DisplayMemberPath = "Title";

                        if (item.Channel != null)
                            iWin.comboBox1.SelectedValue = item.Channel.Id;

                        if (iWin.ShowDialog() == true)
                        {
                            item.Title = iWin.textBox1.Text;
                            item.Description = iWin.textBox2.Text;
                            item.Link = iWin.textBox3.Text;
                            item.PubDate = iWin.textBox4.Text;
                            item.Channel = (Channel)iWin.comboBox1.SelectedItem;

                            itemRep.Update(item);
                            await Task.Run(() => UpdateDB());
                            //UpdateDB();
                            
                            //db.Entry(item).State = EntityState.Modified;
                            //db.SaveChanges();

                            MessageBox.Show("Статья редактирована");
                        }
                        else
                        {
                            return;
                        }
                        //DataGrid1.ItemsSource = null;
                        //DataGrid1.ItemsSource = db.Items.Local.ToBindingList();
                    }
                }
            }
        }
        //обновление данных грида
        private void UpdateDB()
        {
            DataGrid1.ItemsSource = null;
            DataGrid1.ItemsSource = itemRep.Get();
        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < DataGrid1.SelectedItems.Count; i++)
                {
                    Item item = DataGrid1.SelectedItems[i] as Item;
                    if (item != null)
                    {
                        itemRep.Remove(item);
                        UpdateDB();

                        //db.Items.Remove(item);
                    }
                }
            }

            //db.SaveChanges();
            MessageBox.Show("Объект удален");
        }

        private void Channels_Click(object sender, RoutedEventArgs e)
        {
            ChannelWindow cWin = new ChannelWindow();
            cWin.Show();
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            using (ChannelContext db2 = new ChannelContext())
            {
                List<Item> itemresult = (from p in db2.Items     //LINQ to Entity
                           orderby p.Title descending
                           where (p.ChannelId == 1)
                           select p).ToList();
                DataGrid1.ItemsSource = itemresult;
            }
        }

        private async void Transaction_Click(object sender, RoutedEventArgs e) //транзакция + sql-запрос
        {
            using (ChannelContext db1 = new ChannelContext())
            {
                using var transaction = db1.Database.BeginTransaction();
                {
                    try
                    {
                        db1.Items.Add(new Item { Link = "channeltest.com/vid" });
                        await db1.SaveChangesAsync(); //асинхронное сохранение

                        int num = db1.Database.ExecuteSqlRaw("Select * from Items");

                        await transaction.CommitAsync();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Транзакция не выполнена");
                    }
                }
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            using (ChannelContext db3 = new ChannelContext())
            {
                //var res1 = db3.Database.ExecuteSqlRaw("Select * from Items where Title like '" + Search1.Text + "';");
                var search = Search1.Text;
                var search2 = Search2.Text;
                List<Item> result = db3.Items    //LINQ to Entity
                                     .FromSqlRaw($"SELECT * FROM Items WHERE Items.Title LIKE '%{search}%' AND Items.Description LIKE '%{search2}%'; ")
                                         .ToList();
                DataGrid1.ItemsSource = result;
            }

        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
