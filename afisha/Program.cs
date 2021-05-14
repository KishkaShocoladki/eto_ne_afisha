using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using MySql.Data.MySqlClient;
using System.Net;
using System.Text.RegularExpressions;

namespace AfishA
{
    static class Program
    {
        public static Panel panel1;
        public static List<UserControl> navigation = new List<UserControl>();
        public static int navigation_pos = 0;
        public static List<UserControl> navigationUserForm = new List<UserControl>();
        public static int navigationUserForm_pos = 0;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            string connString =
                "Server = VH287.spaceweb.ru; Database = beavisabra_afish;" +
                "port = 3306; User Id = beavisabra_afish; password = Beavis1989";
            conn = new MySqlConnection(connString);
            conn.Open();

            Application.Run(new main());

            conn.Close();
        }

        /// <summary>
        /// Соединение
        /// </summary>
        public static MySqlConnection conn;
        public static string user = "_";
        public static string userid = "_";

        public static void Insert(string Text)
        {
            try
            {
                //Создать команду
                MySqlCommand command = new MySqlCommand(Text, conn);

                //Выполнить команду
                command.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                string address = Path.GetTempPath() + "AFSH.txt";
                ERROR f = new ERROR("чет все сдохло извините~~");
                f.ShowDialog();
                if (!File.Exists(address))
                {
                    FileStream file = File.Create(address);
                    file.Close();
                }
                File.AppendAllText(address, "ВРЕМЯ: " + DateTime.Now.ToString() + Environment.NewLine + "ТЕКСТ ОШИБКИ: " + error.Message + Environment.NewLine + "ЗАПРОС: " + Text + Environment.NewLine + Environment.NewLine);
            }
        }
        public static Image SelectImage(String Text)
        {
            Image img = null;
            MySqlCommand command = new MySqlCommand(Text, conn);
            try
            {
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //Предполагается, что в запросе 1 столбец, и в нем картинка
                    byte[] data = (byte[])reader.GetValue(0);
                    try
                    {
                        MemoryStream ms = new MemoryStream(data, 0, data.Length);
                        ms.Write(data, 0, data.Length);
                        img = Image.FromStream(ms, true);//Конвертируем в картинку
                    }
                    catch { }
                }
                reader.Close();
            }
            catch (Exception error)
            {
                string address = Path.GetTempPath() + "AFSH.txt";
                ERROR f = new ERROR("НУ ЧО КАРТИНОЧКИ СДОХЛИ ВСЁ КИНА НЕ БУДЕТ ヽ(´ー` )┌");
                f.ShowDialog();
                if (!File.Exists(address))
                {
                    FileStream file = File.Create(address);
                    file.Close();
                }
                File.AppendAllText(address, "ВРЕМЯ: " + DateTime.Now.ToString() + Environment.NewLine + "ТЕКСТ ОШИБКИ: " + error.Message + Environment.NewLine + "ЗАПРОС: " + Text + Environment.NewLine + Environment.NewLine);
            }
            return img;
        }

        public static List<string> Select(string Text)
        {
            //Результат
            List<string> results = new List<string>();
            //Создать команду
            MySqlCommand command = new MySqlCommand(Text, conn);
            try
            {
                //Выполнить команду
                DbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        results.Add(reader.GetValue(i).ToString());
                }
                reader.Close();
            }
            catch (Exception error)
            {
                string address = Path.GetTempPath() + "AFSH.txt";
                ERROR f = new ERROR("ну че это ошибка. просто закройте уведомление ヽ(´ー` )┌");
                f.ShowDialog();
                if (!File.Exists(address))
                {
                    FileStream file = File.Create(address);
                    file.Close();
                }

                File.AppendAllText(address, "ВРЕМЯ: " + DateTime.Now.ToString() + Environment.NewLine + "ТЕКСТ ОШИБКИ: " + error.Message + Environment.NewLine + "ЗАПРОС: " + Text + Environment.NewLine + Environment.NewLine);
            }

            return results;
        }
        public static void SelectMusic(string sourceUrl)
        {
            //string path = @Application.StartupPath + @"bin\\Debug";
            try 
            {
                WebClient webCl = new WebClient();
                string path = "sample.mp3";
                webCl.DownloadFile("https://drive.google.com/uc?export=download&id=" + sourceUrl, path);
                          }
            catch (Exception) { }
        }
    }
}
