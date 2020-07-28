using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.Entity;
using System.Windows.Forms;

namespace TRPO_EstateAgency
{
    public partial class Form1 : Form
    {
        public static bool enter = false;
        public static string numberOfPhone;
        public static string emailAdress;
        public static string nickname;
        public static string login;
        public static string password;
        public static int id_profile;
        public static int id_advert;
        public static int id_history;
        public static int id_application;
        public static string id_buyer;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "estateagencyDataSet6.history". При необходимости она может быть перемещена или удалена.
            this.historyTableAdapter1.Fill(this.estateagencyDataSet6.history);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "estateagencyDataSet5.history". При необходимости она может быть перемещена или удалена.
            this.historyTableAdapter.Fill(this.estateagencyDataSet5.history);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "estateagencyDataSet4.advertisement". При необходимости она может быть перемещена или удалена.
            this.advertisementTableAdapter2.Fill(this.estateagencyDataSet4.advertisement);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "estateagencyDataSet3.advertisement". При необходимости она может быть перемещена или удалена.
            this.advertisementTableAdapter1.Fill(this.estateagencyDataSet3.advertisement);
        }

        private void EnterButton_Click_1(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(LoginTextBox.Text)
                && !String.IsNullOrEmpty(PasswordTextBox.Text))
            {
                string connStr = "server=localhost;user=root;database=estateagency;password=root";
                // создаём объект для подключения к БД
                MySqlConnection conn = new MySqlConnection(connStr);
                // устанавливаем соединение с БД
                conn.Open();
                // запрос 
                string sql = $"select id_profile from profile where login in ('{LoginTextBox.Text}');";
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(sql, conn);
                // выполняем запрос и получаем ответ
                string NumberId = command.ExecuteScalar().ToString();

                // запрос
                sql = $"SELECT password from profile where id_profile = {NumberId.ToString()};";
                // объект для выполнения SQL-запроса
                command = new MySqlCommand(sql, conn);
                // выполняем запрос и получаем ответ
                string password = command.ExecuteScalar().ToString();

                if (PasswordTextBox.Text == password)
                {
                    enter = true;
                    EditDataBtn.Show();
                    LoginRegText.ReadOnly = true;
                    PasswordRegBox.ReadOnly = true;
                    NumberPhoneText.ReadOnly = true;
                    EmailTextBox.ReadOnly = true;
                    NicknameText.ReadOnly = true;
                    MessageBox.Show("Успешный вход");
                    this.tabControl1.SelectedIndex = 1;

                    sql = $"SELECT phoneNumber from profile where id_profile = {NumberId.ToString()};";
                    command = new MySqlCommand(sql, conn);
                    NumberPhoneText.Text = command.ExecuteScalar().ToString();

                    sql = $"SELECT email from profile where id_profile = {NumberId.ToString()};";
                    command = new MySqlCommand(sql, conn);
                    EmailTextBox.Text = command.ExecuteScalar().ToString();

                    sql = $"SELECT nickname from profile where id_profile = {NumberId.ToString()};";
                    command = new MySqlCommand(sql, conn);
                    NicknameText.Text = command.ExecuteScalar().ToString();
                    nickname = NicknameText.Text;

                    sql = $"SELECT login from profile where id_profile = {NumberId.ToString()};";
                    command = new MySqlCommand(sql, conn);
                    LoginRegText.Text = command.ExecuteScalar().ToString();

                    sql = $"SELECT password from profile where id_profile = {NumberId.ToString()};";
                    command = new MySqlCommand(sql, conn);
                    PasswordRegBox.Text = command.ExecuteScalar().ToString();

                    id_buyer = NumberId.ToString();

                    if (Convert.ToInt32(NumberId) == 0)
                    {
                        AdminBtn.Show();
                    }
                }
                // закрываем соединение с БД

                id_profile = Convert.ToInt32(NumberId);

                int MaxIdApp;

                try
                {
                    sql = $"select max(id_application) from application;";
                    command = new MySqlCommand(sql, conn);
                    MaxIdApp = Convert.ToInt32(command.ExecuteScalar());
                }
                catch
                {
                    MaxIdApp = 0;
                }
                

                string TextForRequest = "";

                try
                {   
                    for (int i = 0; i <= MaxIdApp; i++)
                    {
                        sql = $"SELECT info from application where id_user = {NumberId.ToString()} and id_application = {i.ToString()};";
                        command = new MySqlCommand(sql, conn);
                        TextForRequest += command.ExecuteScalar().ToString() + "\r\n" + "\r\n";
                    }
                }
                catch (Exception)
                {

                }

                textRequest.Text = TextForRequest;

                if (!String.IsNullOrEmpty(textRequest.Text))
                {
                    MessageBox.Show("Вы нашли покупателя!");
                }

                button4.Show();
                button2.Show();
                button3.Show();
                button7.Show();
                button8.Show();
                button9.Show();

                conn.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label7.Text = "Цена, за месяц";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label7.Text = "Цена, за кв метр";
        }

        private void EditDataButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(LoginRegText.Text)
                && !String.IsNullOrEmpty(PasswordRegBox.Text)
                && !String.IsNullOrEmpty(NumberPhoneText.Text)
                && !String.IsNullOrEmpty(EmailTextBox.Text)
                && !String.IsNullOrEmpty(PasswordRegBox.Text))
            {
                // строка подключения к БД
                string connStr = "server=localhost;user=root;database=estateagency;password=root";
                // создаём объект для подключения к БД
                MySqlConnection conn = new MySqlConnection(connStr);
                // устанавливаем соединение с БД
                conn.Open();
                // запрос
                string sql = "select max(id_profile) from profile;";
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(sql, conn);
                // выполняем запрос и получаем ответ
                try
                {
                    id_profile = (int)command.ExecuteScalar() + 1;
                }
                catch
                {
                    id_profile = 0;
                }


                // запрос
                sql = "INSERT INTO `estateagency`.`profile` (`id_profile`, `login`, `password`, `phoneNumber`, `email`, `nickname`)" +
                    $" VALUES ('{id_profile.ToString()}', " +
                    $"'{LoginRegText.Text}', " +
                    $"'{PasswordRegBox.Text}', " +
                    $"'{NumberPhoneText.Text}', " +
                    $"'{EmailTextBox.Text}', " +
                    $"'{PasswordRegBox.Text}');";
                // объект для выполнения SQL-запроса
                command = new MySqlCommand(sql, conn);
                // выполняем запрос и получаем ответ
                command.ExecuteScalar();
                // закрываем соединение с БД
                conn.Close();

                this.tabControl1.SelectedIndex = 0;

                MessageBox.Show("Вы успешно зарегистрированы! Теперь войдите в систему");

                EditDataButton.Hide();
            }
            else
            {
                MessageBox.Show("Сначала заполните ВСЕ поля");
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
        }

        private void EditDataBtn_Click(object sender, EventArgs e)
        {
            NumberPhoneText.ReadOnly = false;
            EmailTextBox.ReadOnly = false;
            NicknameText.ReadOnly = false;

            EditChangeBtn.Show();
        }

        private void EditChangeBtn_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=estateagency;password=root";

            MySqlConnection conn = new MySqlConnection(connStr);

            conn.Open();

            string sql = $"UPDATE profile " +
                $"SET nickname = '{NicknameText.Text}' " +
                $"WHERE id_profile = {id_profile.ToString()};";
            MySqlCommand command = new MySqlCommand(sql, conn);

            command.ExecuteScalar();

            sql = $"UPDATE profile " +
                $"SET email = '{EmailTextBox.Text}' " +
                $"WHERE id_profile = {id_profile.ToString()};";
            command = new MySqlCommand(sql, conn);

            command.ExecuteScalar();

            sql = $"UPDATE profile " +
                 $"SET phoneNumber = '{NumberPhoneText.Text}' " +
                $"WHERE id_profile = {id_profile.ToString()};";
            command = new MySqlCommand(sql, conn);

            command.ExecuteScalar();

            conn.Close();

            NumberPhoneText.ReadOnly = true;
            EmailTextBox.ReadOnly = true;
            NicknameText.ReadOnly = true;
            EditChangeBtn.Hide();
        }

        private void SendAddBtn_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=estateagency;password=root";
            // создаём объект для подключения к БД
            MySqlConnection conn = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            conn.Open();

            string sql = "select max(id_advert) from advertisement;";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ
            try
            {
                id_advert = (int)command.ExecuteScalar() + 1;
            }
            catch
            {
                id_advert = 0;
            }

            string TypeOfAdd = "Аренда";

            if (ArendaRadio.Checked || PriceRadio.Checked)
            {
                if (ArendaRadio.Checked)
                {
                    TypeOfAdd = "Аренда";
                }
                if (PriceRadio.Checked)
                {
                    TypeOfAdd = "Продажа";
                }

            }

            // запрос
            sql = "INSERT INTO `estateagency`.`advertisement` " +
                "(`id_advert`, `City`, `District`, `Street`, `House`, `Floor`, `Square`, `Price`, `TypeOfAd`, `Info`, `Frofile`)" +
                    $" VALUES ('{id_advert.ToString()}', " +
                    $"'{CityText.Text}', " +
                    $"'{DistrictText.Text}', " +
                    $"'{StreetText.Text}', " +
                    $"'{HouseText.Text}', " +
                    $"'{FloorText.Text}', " +
                    $"'{SquareText.Text}', " +
                    $"'{PriceText.Text}', " +
                    $"'{TypeOfAdd.ToString()}', " +
                    $"'{InfoText.Text}', " +
                    $"'{nickname.ToString()}');";
            // объект для выполнения SQL-запроса
            command = new MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ
            command.ExecuteScalar();

            conn.Close();

            MessageBox.Show("Объявление успешно размещено!");
        }

        private void FindSelectBtn_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=estateagency;password=root";

            MySqlConnection conn = new MySqlConnection(connStr);

            conn.Open();

            string sql = "SELECT * From advertisement;";

            if (!String.IsNullOrEmpty(FindCityText.Text) ||
                !String.IsNullOrEmpty(FindDistrictText.Text) ||
                !String.IsNullOrEmpty(FindSquareLowText.Text) ||
                !String.IsNullOrEmpty(FindPriceLowText.Text) ||
                !String.IsNullOrEmpty(FIndPriceMaxText.Text) ||
                TypeArendaRadio.Checked || TypePriceRadio.Checked)
            {
                sql = "SELECT * From advertisement where ";

                if (!String.IsNullOrEmpty(FindCityText.Text))
                {
                    sql += $"city = '{FindCityText.Text}'";
                }

                if (!String.IsNullOrEmpty(FindDistrictText.Text))
                {
                    sql += $" and district = '{FindDistrictText.Text}'";
                }

                if (!String.IsNullOrEmpty(FindSquareLowText.Text))
                {
                    sql += $" and square > '{FindSquareLowText.Text}'";
                }

                if (!String.IsNullOrEmpty(FindSquareMaxText.Text))
                {
                    sql += $" and square < '{FindSquareMaxText.Text}'";
                }

                if (!String.IsNullOrEmpty(FindPriceLowText.Text))
                {
                    sql += $" and price > '{FindPriceLowText.Text}'";
                }

                if (!String.IsNullOrEmpty(FIndPriceMaxText.Text))
                {
                    sql += $" and price < '{FIndPriceMaxText.Text}'";
                }

                if (TypeArendaRadio.Checked || TypePriceRadio.Checked)
                {
                    if (TypeArendaRadio.Checked)
                    {
                        sql += $" and TypeOfAd = 'Аренда'";
                    }

                    if (TypePriceRadio.Checked)
                    {
                        sql += $" and TypeOfAd = 'Продажа'";
                    }
                }

                sql += ";";
            }

            MessageBox.Show(sql);

            MySqlCommand command = new MySqlCommand(sql, conn);

            command.ExecuteScalar();

            MySqlDataAdapter SDA = new MySqlDataAdapter(sql, conn);
            DataTable DATA = new DataTable();
            SDA.Fill(DATA);
            SelectDGV.DataSource = DATA;

            conn.Close();
        }

        private void MyAddBtn_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=estateagency;password=root";

            MySqlConnection conn = new MySqlConnection(connStr);

            conn.Open();

            string sql = $"SELECT * FROM advertisement where Frofile = '{nickname.ToString()}';";

            MySqlDataAdapter SDA = new MySqlDataAdapter(sql, conn);
            DataTable DATA = new DataTable();
            SDA.Fill(DATA);
            ProfileDGV.DataSource = DATA;

            ProfileDGV.Show();

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 3;
        }

        private void DeleteAddBtn_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=estateagency;password=root";
            // создаём объект для подключения к БД
            MySqlConnection conn = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            conn.Open();

            string sql = "select max(id_history) from history;";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ
            try
            {
                id_history = (int)command.ExecuteScalar() + 1;
            }
            catch
            {
                id_history = 0;
            }

            sql = $"SELECT city FROM advertisement where id_advert = '{IdDeleteText.Text}';";
            command = new MySqlCommand(sql, conn);
            string info = "Город: " + command.ExecuteScalar().ToString() + "\n";

            sql = $"SELECT district FROM advertisement where id_advert = '{IdDeleteText.Text}';";
            command = new MySqlCommand(sql, conn);
            info += "Район: " + command.ExecuteScalar().ToString() + "\n";

            sql = $"SELECT street FROM advertisement where id_advert = '{IdDeleteText.Text}';";
            command = new MySqlCommand(sql, conn);
            info += "Улица: " + command.ExecuteScalar().ToString() + "\n";

            sql = $"SELECT house FROM advertisement where id_advert = '{IdDeleteText.Text}';";
            command = new MySqlCommand(sql, conn);
            info += "Дом: " + command.ExecuteScalar().ToString() + "\n";

            sql = $"SELECT floor FROM advertisement where id_advert = '{IdDeleteText.Text}';";
            command = new MySqlCommand(sql, conn);
            info += "Этаж: " + command.ExecuteScalar().ToString() + "\n";

            sql = $"SELECT square FROM advertisement where id_advert = '{IdDeleteText.Text}';";
            command = new MySqlCommand(sql, conn);
            info += "Площадь: " + command.ExecuteScalar().ToString() + "\n";

            sql = $"SELECT price FROM advertisement where id_advert = '{IdDeleteText.Text}';";
            command = new MySqlCommand(sql, conn);
            info += "Цена: " + command.ExecuteScalar().ToString() + "\n";

            sql = $"SELECT TypeOfAd FROM advertisement where id_advert = '{IdDeleteText.Text}';";
            command = new MySqlCommand(sql, conn);
            info += "Тип покупки: " + command.ExecuteScalar().ToString() + "\n";

            sql = $"SELECT info FROM advertisement where id_advert = '{IdDeleteText.Text}';";
            command = new MySqlCommand(sql, conn);
            info += "Инфо: " + command.ExecuteScalar().ToString() + "\n";

            string reason = "Не указано";

            if (BuyRadio.Checked || NotBuyRadio.Checked)
            {
                if (BuyRadio.Checked)
                {
                    reason = "Продал";
                }
                if (NotBuyRadio.Checked)
                {
                    reason = "Не продал";
                }
            }

            // запрос
            sql = "INSERT INTO `estateagency`.`history` " +
                "(`id_history`, `data`, `nickname_Saller`, `nickname_buyer`, `ad_info`, `reason`)" +
                    $" VALUES ('{id_history.ToString()}', " +
                    $"'{Convert.ToString(DateTime.Now)}', " +
                    $"'{nickname.ToString()}'," +
                    $"'{idBuyerText.Text}', "+
                    $"'{info}', " +
                    $"'{reason.ToString()}');";
            // объект для выполнения SQL-запроса
            command = new MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ
            command.ExecuteScalar();

            sql = $"Delete FROM advertisement where id_advert = '{IdDeleteText.Text}';";
            command = new MySqlCommand(sql, conn);
            command.ExecuteScalar();

            conn.Close();

            MessageBox.Show("Объявление успешно удалено!");
        }

        private void SendRequestBtn_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=estateagency;password=root";
            // создаём объект для подключения к БД
            MySqlConnection conn = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            conn.Open(); 

            string sql = "select max(id_application) from application;";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ
            try
            {
                id_application = (int)command.ExecuteScalar() + 1;
            }
            catch
            {
                id_application = 0;
            }

            string info = "Id объявления: " + IdAplicationText.Text  + "\r\n";
            info += "Id покупателя: " + id_buyer +"\r\n";

            sql = $"SELECT phoneNumber FROM profile where id_profile = '{id_buyer}';";
            command = new MySqlCommand(sql, conn);
            info += "Телефон: " + command.ExecuteScalar().ToString() + "\r\n";

            sql = $"SELECT email FROM profile where id_profile = '{id_buyer}';";
            command = new MySqlCommand(sql, conn);
            info += "Почта: " + command.ExecuteScalar().ToString() + "\r\n";

            sql = $"SELECT Frofile FROM advertisement where id_advert = '{IdAplicationText.Text}';";
            command = new MySqlCommand(sql, conn);
            string profile = command.ExecuteScalar().ToString();

            sql = $"SELECT id_profile FROM profile where nickname = '{profile}';";
            command = new MySqlCommand(sql, conn);
            profile = command.ExecuteScalar().ToString();

            sql = "INSERT INTO `estateagency`.`application` " +
                "(`id_application`, `id_user`, `info`)" +
                    $" VALUES ('{id_application.ToString() }', " +
                    $"'{profile}', " +
                    $"'{info + "Инфо: " + TextBoxInfo.Text}');";
            // объект для выполнения SQL-запроса
            command = new MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ
            command.ExecuteScalar();

            conn.Close();

            MessageBox.Show("Завяка отправлена!");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 4;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 5;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 7;
        }

        private void AdminBtn_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 8;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 6;
        }
    }
}
