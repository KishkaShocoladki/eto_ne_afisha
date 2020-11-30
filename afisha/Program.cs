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
            return img;
        }
        public static void SelectMusic(String Text)
        {
            MySqlCommand command = new MySqlCommand(Text, conn);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                byte[] data = (byte[])reader.GetValue(0);
                try
                {
                    FileStream file = new FileStream("sample.mp3", FileMode.Create);//sample.wav
                    file.Write(data, 0, data.Length);
                    file.Close();
                }
                catch (Exception e){ }
            }
            reader.Close();
        }


        public static List<string> Select(string Text)
        {
            //Результат
            List<string> results = new List<string>();
            //Создать команду
            MySqlCommand command = new MySqlCommand(Text, conn);

            //Выполнить команду
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                    results.Add(reader.GetValue(i).ToString());
            }
            reader.Close();

            return results;
        }
    }
}
