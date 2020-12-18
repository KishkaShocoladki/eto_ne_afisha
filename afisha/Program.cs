using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using MySql.Data.MySqlClient;

namespace AfishA
{
    static class Program
    {
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
            //Создать команду
            MySqlCommand command = new MySqlCommand(Text, conn);

            //Выполнить команду
            command.ExecuteNonQuery();
        }
        public static Image SelectImage(String Text)
        {
            Image img = null;
            MySqlCommand command = new MySqlCommand(Text, conn);
            MySqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    //Предполагается, что в запросе 1 столбец, и в нем картинка
                    byte[] data = (byte[])reader.GetValue(0);

                    MemoryStream ms = new MemoryStream(data, 0, data.Length);
                    ms.Write(data, 0, data.Length);
                    img = Image.FromStream(ms, true);//Конвертируем в картинку
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
                File.AppendAllText(address, DateTime.Now.ToString() + ";" + Environment.NewLine + error.Message + ";" + Environment.NewLine + "ЗАПРОС: " + Text + ";" + Environment.NewLine);
            }
            return img;
        }
        public static void SelectMusic(String Text)
        {
            MySqlCommand command = new MySqlCommand(Text, conn);
            MySqlDataReader reader = command.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    byte[] data = (byte[])reader.GetValue(0);
                        
                    FileStream file = new FileStream("sample.mp3", FileMode.Create);//sample.wav
                    file.Write(data, 0, data.Length);
                    file.Close();
                }
                reader.Close();
            }
            catch (Exception error)
            {
                string address = Path.GetTempPath() + "AFSH.txt";
                ERROR f = new ERROR("НУ ЧО МУЗЫЧКА СДОХЛА ВСЁ КИНА НЕ БУДЕТ ヽ(´ー` )┌");
                f.ShowDialog();
                if (!File.Exists(address))
                {
                    FileStream file = File.Create(address);
                    file.Close();
                }
                File.AppendAllText(address, DateTime.Now.ToString() + ";" + Environment.NewLine + error.Message + ";" + Environment.NewLine + "ЗАПРОС: " + Text + ";" + Environment.NewLine);
            }
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
            catch(Exception error)
            {
                string address = Path.GetTempPath() + "AFSH.txt";
                ERROR f = new ERROR("ну че это ошибка. просто закройте уведомление ヽ(´ー` )┌");
                f.ShowDialog();
                if (!File.Exists(address))
                {
                    FileStream file = File.Create(address);
                    file.Close();
                }
                
                File.AppendAllText(address, DateTime.Now.ToString() + ";" + Environment.NewLine + error.Message + ";" + Environment.NewLine + "ЗАПРОС: " + Text + ";" + Environment.NewLine);
            }
            return results;
        }
    }
}
