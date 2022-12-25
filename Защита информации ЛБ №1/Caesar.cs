using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MPro;


namespace Защита_информации_ЛБ__1
{
    public partial class Caesar : Form
    {
        MPro.TranspositionTechniques TT = new TranspositionTechniques();

        public Caesar()
        {
            InitializeComponent();
            Debug.WriteLine("В этом");


        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbCeasarWord.Text))
            {
                MessageBox.Show("Введите текст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("Выберите сдвиг", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string s = tbCeasarWord.Text; //Строка, к которой применяется шифрованияе/дешифрование

            string result = "";  //Строка - результат шифрования/дешифрования

            int shift = Int32.Parse(comboBox2.SelectedItem.ToString());//Величина сдвига при шифровании/дешифровании

            //Цикл по каждому символу строки
            for (int i = 0; i < s.Length; i++)
            {

                if (((int)(s[i]) < 1040) || ((int)(s[i]) > 1103)) //Если не кириллица
                {
                    result += s[i];
                }
                //Если буква является строчной
                if ((Convert.ToInt16(s[i]) >= 1072) && (Convert.ToInt16(s[i]) <= 1103))
                {

                    if ((Convert.ToInt16(s[i]) + shift > 1103)) //Если буква, после сдвига выходит за пределы алфавита
                    {
                        result += Convert.ToChar(Convert.ToInt16(s[i]) + shift - 32); //Добавление в строку результатов символ
                    }
                    //Если буква может быть сдвинута в пределах алфавита
                    else
                        result += Convert.ToChar(Convert.ToInt16(s[i]) + shift); //Добавление в строку результатов символ
                }

                if ((Convert.ToInt16(s[i]) >= 1040) && (Convert.ToInt16(s[i]) <= 1071))//Если буква является прописной
                {
                    if ((Convert.ToInt16(s[i]) + shift > 1071))//Если буква, после сдвига выходит за пределы алфавита
                    {
                        result += Convert.ToChar(Convert.ToInt16(s[i]) + shift - 32);//Добавление в строку результатов символ
                    }
                    //Если буква может быть сдвинута в пределах алфавита
                    else
                        result += Convert.ToChar(Convert.ToInt16(s[i]) + shift); //Добавление в строку результатов символ
                }
            }

            tbCaesarCode.Text = result; //Вывод на экран зашифрованной строки
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Введите текст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Выберите сдвиг", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string s = textBox1.Text;


            string r = "";

            int shift = Int32.Parse(comboBox1.SelectedItem.ToString());

            for (int i = 0; i < s.Length; i++)
            {
                //Если не кириллица
                if (((int)(s[i]) < 1040) || ((int)(s[i]) > 1103))
                {
                    r += s[i];
                }
                if (Convert.ToInt16(s[i]) == 32)
                {
                    r += ' ';
                }

                if ((Convert.ToInt16(s[i]) >= 1072) && (Convert.ToInt16(s[i]) <= 1103)) //Если буква является строчной
                {

                    if (Convert.ToInt16(s[i]) - shift < 1072) //Если буква, после сдвига выходит за пределы алфавита
                    {
                        r += Convert.ToChar(Convert.ToInt16(s[i]) - shift + 32);//Добавление в строку результатов символ
                    }
                    //Если буква может быть сдвинута в пределах алфавита
                    else
                        r += Convert.ToChar(Convert.ToInt16(s[i]) - shift);//Добавление в строку результатов символ
                }
                //Если буква является прописной
                if ((Convert.ToInt16(s[i]) >= 1040) && (Convert.ToInt16(s[i]) <= 1071))
                {
                    if (Convert.ToInt16(s[i]) - shift < 1040) //Если буква, после сдвига выходит за пределы алфавита
                    {
                        r += Convert.ToChar(Convert.ToInt16(s[i]) - shift + 32); //Добавление в строку результатов символ
                    }
                    //Если буква может быть сдвинута в пределах алфавита
                    else
                        r += Convert.ToChar(Convert.ToInt16(s[i]) - shift);  //Добавление в строку результатов символ
                }
            }

            textBox2.Text = r;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            tbCeasarWord.Clear();
            tbCaesarCode.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

        }


        //
        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Введите текст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String Coding = textBox7.Text; // считали строчку пользователя
            String Encode = GetAtbash(Coding); // зашифровали сообщение
            String Decode = "";
            for (int i = 0; i <= Encode.Length - 1; i++)
                Decode += Encode[i];
            String DDecode = GetAtbash(Decode); // расшифровали сообщение

            textBox8.Text = Encode;
        }

        private string GetAtbash(string s)
        {
            var charArray = s.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                char c = charArray[i];

                if (c >= 'а' && c <= 'я')
                {
                    charArray[i] = (char)(1040 + (1103 - c));//1040 и 1103 коды символов вводимой строчки в кодировке Unicode
                }
                if (c >= 'А' && c <= 'Я')
                {
                    charArray[i] = (char)(1040 + (1103 - c));
                }
                if (c >= 'A' && c <= 'Z')
                {
                    charArray[i] = (char)(65 + (122 - c));
                }
                if (c >= 'a' && c <= 'z')
                {
                    charArray[i] = (char)(65 + (122 - c));
                }
            }
            return new String(charArray);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox9.Text))
            {
                MessageBox.Show("Введите текст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String Coding = ""; // считали строчку пользователя
            String Encode = GetAtbash(Coding); // зашифровали сообщение
            String Decode = textBox9.Text;
            for (int i = 0; i <= Encode.Length - 1; i++)
                Decode += Encode[i];
            String DDecode = GetAtbash(Decode); // расшифровали сообщение

            textBox10.Text = DDecode;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox8.Clear();
            textBox7.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox10.Clear();
            textBox9.Clear();
        }

        //Квадрат Полибия
        public enum Method
        {
            Method1,
            Method2
        }
        class PolybiusSquare
        {
            char[,] square;

            string alphabet;


            Method encryptMethod;

            public PolybiusSquare(string alphabet = null, Method cipherMethod = Method.Method1)
            {
                //this.alphabet = alphabet ?? ",ABCDEFGHIJKLMNOPQRSTUVWXYZ,abcdefghijklmnopqrstuvwxyz ";
                this.alphabet = alphabet ?? "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ,абвгдеёжзийклмнопрстуфхцчшщъыьэюя ";
                encryptMethod = cipherMethod;
            }

            //возвращает квадрат Полибия
            char[,] GetSquare(string key)
            {
                var newAlphabet = alphabet;

                //удаляем из алфавита все символы которые содержит ключ
                for (int i = 0; i < key.Length; i++)
                {
                    newAlphabet = newAlphabet.Replace(key[i].ToString(), "");

                }

                //добавляем пароль в начало алфавита, а в конец дополнительные знаки
                //для того чтобы избежать пустых ячеек
                newAlphabet = key + newAlphabet + "0123456789!@#$%^&*)_+-=<>?,.";

                //получаем размер стороны квадрата
                //округлением квадратного корня в сторону большего целого числа
                var n = (int)Math.Ceiling(Math.Sqrt(alphabet.Length));

                //создаем и заполняем массив
                square = new char[n, n];

                var index = 0;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (index < newAlphabet.Length)
                        {
                            square[i, j] = newAlphabet[index];

                            index++;
                        }

                    }
                }

                return square;
            }

            //поиск символа в двухмерном массиве
            bool FindSymbol(char[,] symbolsTable, char symbol, out int column, out int row)
            {
                var l = symbolsTable.GetUpperBound(0) + 1;
                for (int i = 0; i < l; i++)
                {
                    for (int j = 0; j < l; j++)
                    {
                        if (symbolsTable[i, j] == symbol)
                        {
                            //значение найдено
                            row = i;
                            column = j;
                            return true;
                        }
                    }
                }

                //если ничего не нашли
                row = -1;
                column = -1;
                return false;
            }

            public string PolibiusEncrypt(string text, string password)
            {
                var outputText = "";
                var square = GetSquare(password);
                switch (encryptMethod)
                {
                    case Method.Method1:
                        for (int i = 0; i < text.Length; i++)
                        {
                            if (FindSymbol(square, text[i], out int columnIndex, out int rowIndex))
                            {
                                var newRowIndex = rowIndex == square.GetUpperBound(1)
                                    ? 0
                                    : rowIndex + 1;
                                outputText += square[newRowIndex, columnIndex].ToString();
                            }
                        }
                        break;

                    case Method.Method2:
                        var m = text.Length;
                        var coordinates = new int[m * 2];
                        for (int i = 0; i < m; i++)
                        {
                            if (FindSymbol(square, text[i], out int columnIndex, out int rowIndex))
                            {
                                coordinates[i] = columnIndex;
                                coordinates[i + m] = rowIndex;
                            }
                        }

                        for (int i = 0; i < m * 2; i += 2)
                        {
                            outputText += square[coordinates[i + 1], coordinates[i]];
                        }
                        break;
                }

                return outputText;
            }

            public string PolybiusDecrypt(string text, string password)
            {
                var outputText = "";
                var square = GetSquare(password);
                var m = text.Length;
                switch (encryptMethod)
                {
                    case Method.Method1:
                        for (int i = 0; i < m; i++)
                        {
                            if (FindSymbol(square, text[i], out int columnIndex, out int rowIndex))
                            {
                                var newRowIndex = rowIndex == 0
                                    ? square.GetUpperBound(1)
                                    : rowIndex - 1;
                                outputText += square[newRowIndex, columnIndex].ToString();
                            }
                        }
                        break;

                    case Method.Method2:
                        var coordinates = new int[m * 2];
                        var j = 0;
                        for (int i = 0; i < m; i++)
                        {
                            if (FindSymbol(square, text[i], out int columnIndex, out int rowIndex))
                            {
                                coordinates[j] = columnIndex;
                                coordinates[j + 1] = rowIndex;
                                j += 2;
                            }
                        }

                        for (int i = 0; i < m; i++)
                        {
                            outputText += square[coordinates[i + m], coordinates[i]];
                        }
                        break;
                }

                return outputText;
            }
        }
        private void btnPlayfair_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Введите текст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox11.Text))
            {
                MessageBox.Show("Введите ключ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var polybius = new PolybiusSquare();
            var message = textBox5.Text;
            var pass = textBox11.Text;
            var cipherText = polybius.PolibiusEncrypt(message, pass);
            textBox6.Text = cipherText;


        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Введите зашифрованный текст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Введите ключ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var polybius = new PolybiusSquare();
            var message = textBox5.Text;
            var pass = textBox3.Text;
            var cipherText = polybius.PolibiusEncrypt(message, pass);
            cipherText = textBox4.Text;
            textBox12.Text = polybius.PolybiusDecrypt(cipherText, pass);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox11.Clear();
            textBox6.Clear();


        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();
            textBox12.Clear();
        }


        //Прямоугольник Плейфера 

        string anahtar = ""; //Пользователь может захотеть войти
        string karakterler;
        char[,] kutu = new char[6, 6]; //матрица 
        char[,] ikililer = new char[200, 2]; int ikiliSayisi = 0; //
        char[,] sonuc = new char[200, 2];//результат расшифровки или засшифровки.
        int[] yer = new int[4];//
        Random rnd = new Random();


        //public string temizle(string metin)
        //{
        //    string temizMetin="";

        //    for (int i = 0; i < metin.Length; i++)
        //    {
        //        if (metin[i] != 'q' && metin[i] != 'w' && metin[i] != 'x')
        //            temizMetin += metin[i];
        //    }

        //    return temizMetin;
        //}

        //На экране результатов отображается зашифрованный или расшифрованный текст.
        public string sonucuYaz()
        {
            string sonucMetni = "";

            for (int i = 0; i < ikiliSayisi; i++)
            {
                sonucMetni += sonuc[i, 0].ToString() + sonuc[i, 1].ToString();
            }

            return sonucMetni;
        }

        //
        public void desifrele()
        {
            for (int i = 0; i < ikiliSayisi; i++)
            {
                //
                yerBul(ikililer[i, 0], ikililer[i, 1]);

                if (yer[0] == yer[2]) //если они в одной строке
                {
                    sonuc[i, 0] = kutu[yer[0], (yer[1] + 5) % 6];
                    sonuc[i, 1] = kutu[yer[2], (yer[3] + 5) % 6];
                }
                else if (yer[1] == yer[3]) //если они в одном и том же состоянии
                {
                    sonuc[i, 0] = kutu[(yer[0] + 5) % 6, yer[1]];
                    sonuc[i, 1] = kutu[(yer[2] + 5) % 6, yer[3]];
                }
                else //если разные
                {
                    sonuc[i, 0] = kutu[yer[0], yer[3]];
                    sonuc[i, 1] = kutu[yer[2], yer[1]];
                }
            }
        }

        public void sifrele()
        {
            for (int i = 0; i < ikiliSayisi; i++)
            {

                yerBul(ikililer[i, 0], ikililer[i, 1]);

                if (yer[0] == yer[2])
                {
                    sonuc[i, 0] = kutu[yer[0], (yer[1] + 1) % 6];
                    sonuc[i, 1] = kutu[yer[2], (yer[3] + 1) % 6];
                }
                else if (yer[1] == yer[3])
                {
                    sonuc[i, 0] = kutu[(yer[0] + 1) % 6, yer[1]];
                    sonuc[i, 1] = kutu[(yer[2] + 1) % 6, yer[3]];
                }
                else
                {
                    sonuc[i, 0] = kutu[yer[0], yer[3]];
                    sonuc[i, 1] = kutu[yer[2], yer[1]];
                }
            }
        }


        public void yerBul(char ch1, char ch2)
        {
            // yer[0] = 1. karakterin satırı, yer[1] = 1. karakterin stunu
            // yer[2] = 2. karakterin satırı, yer[3] = 2. karakterin stunu

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (kutu[i, j] == ch1)
                    {
                        yer[0] = i;
                        yer[1] = j;
                    }
                    else if (kutu[i, j] == ch2)
                    {
                        yer[2] = i;
                        yer[3] = j;
                    }
                }
            }
        }

        //Создает последовательность двоичных символов из входного текста
        public void ikilileriOlustur(string metin)
        {
            int j = 0;

            for (int i = 0; i < metin.Length;)
            {
                ikililer[j, 0] = metin[i];

                if (i == metin.Length - 1)
                {   //последний шаг для текста с нечетным числом символов
                    //так как элемент i+1 проверен, то сначала это было написано if, чтобы не получить ошибок
                    ikililer[j, 1] = 'w';
                    j++;
                    break;
                }
                if (metin[i] != metin[i + 1])
                {
                    ikililer[j, 1] = metin[i + 1];
                    i += 2;
                }
                else
                {
                    ikililer[j, 1] = 'x';
                    i++;
                }

                j++;
            }

            ikiliSayisi = j;
        }

        //генерировать случайную матрицу ключей
        public void anahtarUret()
        {
            int k = 0;
            int j = 0;
            int index = 0;

            karakterler = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя., ";
            int i = karakterler.Length;

            while (i > 0)
            {
                index = rnd.Next(0, i); // случайный индекс
                kutu[k, j] = karakterler[index];
                karakterler = karakterler.Remove(index, 1);

                i--;
                j++;

                if (j % 6 == 0)
                {
                    k++;
                    j = 0;
                }
            }
        }

        //создает матрицу ключей
        public void kutuOlustur()
        {
            int j = 0;
            int k = 0;
            int i = anahtar.Length;
            int index1 = 0;

            karakterler = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя., ";


            while (i > 0)
            {

                index1 = karakterler.IndexOf(anahtar[anahtar.Length - i]);//чтобы повторная буква не попадалась 2 раза
                if (index1 >= 0)
                {
                    kutu[k, j] = anahtar[anahtar.Length - i];
                    karakterler = karakterler.Remove(index1, 1);
                    j++;
                }

                i--;

                if (j == 6)
                {
                    k++;
                    j = 0;
                }
            }

            i = 0; //i снова будет использоваться для обработки оставшихся символов


            while (i < karakterler.Length)
            {
                kutu[k, j] = karakterler[i];

                i++;
                j++;

                if (j % 6 == 0)
                {
                    k++;
                    j = 0;
                }
            }
        }

        //записывает матрицу ключей на экран
        public void kutuyuEkranaYaz()
        {
            txtMatris.Text = "";

            for (int i = 1; i < 7; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    txtMatris.Text += kutu[i - 1, j - 1] + "\r\t";
                }
                txtMatris.Text += "\r\n\r\n";
            }
        }

        //Проверяет наличие в тексте неузнаваемых символов
        public string girdiKontrol(string metin)
        {
            for (int i = metin.Length - 1; i >= 0; i--)
            {
                if (!(metin[i] == '.' || metin[i] == ',' || metin[i] == 'ё' || metin[i] == ' ' ||
                    //metin[i] == ':' || metin[i] == ' ' ||
                    (metin[i] >= 1072 && metin[i] <= 1103) // ||

                    ))
                {
                    metin = metin.Remove(i, 1);
                }
            }
            return metin;
        }

        private void txtAnahtar_TextChanged(object sender, EventArgs e)
        {
            if (txtAnahtar.Text == "")
            {
                //txtMetin.Enabled = false;
                //txtSonuc.Enabled = false;
                anahtar = "";
            }
            else
            {
                //txtMetin.Enabled = true;
                //txtSonuc.Enabled = true;
                txtAnahtar.Text = girdiKontrol(txtAnahtar.Text);
                txtAnahtar.Select(txtAnahtar.Text.Length, 0);
                anahtar = txtAnahtar.Text;
            }
            kutuOlustur();
            kutuyuEkranaYaz();
        }

        private void txtMetin_TextChanged(object sender, EventArgs e)
        {
            if (txtMetin.Text == "")
            {
                btnDesifrele.Enabled = false;
                btnSifrele.Enabled = false;
            }
            else
            {
                txtMetin.Text = girdiKontrol(txtMetin.Text);
                txtMetin.Select(txtMetin.Text.Length, 0);
                btnDesifrele.Enabled = true;
                btnSifrele.Enabled = true;
            }

            if (txtMetin.Text.Length < 200)
                lblGirdiMetniSay.Text = "(" + (199 - txtMetin.Text.Length).ToString() + ")";
        }

        private void btnSifrele_Click(object sender, EventArgs e)
        {
            ikilileriOlustur(txtMetin.Text);
            sifrele();
            txtSonuc.Text = sonucuYaz();
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            txtMetin.Text = txtSonuc.Text;
            txtSonuc.Text = "";
        }

        private void btnDesifrele_Click(object sender, EventArgs e)
        {
            txtSonuc.Text = "";

            ikilileriOlustur(txtMetin.Text);
            desifrele();


            txtSonuc.Text = sonucuYaz();
        }

        private void btnAnahtarUret_Click(object sender, EventArgs e)
        {
            anahtarUret();
            kutuyuEkranaYaz();
        }

        private void Caesar_Load(object sender, EventArgs e)
        {
            kutuOlustur();
            kutuyuEkranaYaz();

            //kutuOlustur1();
            //kutuyuEkranaYaz1();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAnahtar.Clear();
            txtMetin.Clear();
            txtSonuc.Clear();
        }

        //Квадрат Полибия (2)
        private static String inputString = "";

        private static String outputString = "";

        private static Char[,] Alphabet = {
                            {'А', 'Б', 'В', 'Г', 'Д', 'Е'},
                            {'Ё', 'Ж', 'З', 'И', 'Й', 'К'},
                            {'Л', 'М', 'Н', 'О', 'П', 'Р'},
                            {'С', 'Т', 'У', 'Ф', 'Х', 'Ц'},
                            {'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь'},
                            {'Э', 'Ю', 'Я', ' ', ' ', ' '},
                           };
        private bool isWrongSymbols = false;

        private String Pdecrypt(String incommingMessage)
        {
            if (!(incommingMessage.Length % 2 == 0))
            {
                return "Неверные данные";

            }
            if (string.IsNullOrEmpty(textBox13.Text))
            {
                MessageBox.Show("Введите текст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            String parsedString = ParseStringBy2(incommingMessage);

            return parsedString;
        }

        private String ParseStringBy2(String StringToParse)
        {
            String bufferPair = "";
            String outputString = "";
            bool characterSkipped = false;
            for (int i = 1; i <= StringToParse.Length; i++)
            {
                bufferPair += StringToParse[i - 1];
                if (i % 2 == 0)//означает, что i = 2, i = 4 и т.д. - Мы прочитали 2 символа
                {
                    outputString += DeconcatString(bufferPair) + " ";
                    characterSkipped = true;
                }
                if (characterSkipped)
                {
                    bufferPair = "";
                    characterSkipped = false;
                }
            }


            return outputString;
        }

        private String DeconcatString(String inputString)
        {
            //if (inputString =="a")
            //{
            //    MessageBox.Show("Введите текст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
            if (inputString.Length != 2)
                return "Ошибка";
            Char outputChar;

            int first = Int32.Parse(inputString[0].ToString());
            int second = Int32.Parse(inputString[1].ToString());
            outputChar = Alphabet[first - 1, second - 1];


            Debug.WriteLine(" " + outputChar);
            return outputChar.ToString();

        }
        private String Pencypt(String incomingMessage)//шифрование Полибия
        {
            String bufferString = "";
            Debug.WriteLine("Зашифруйте!");
            foreach (char ch in incomingMessage)
            {
                bufferString += SearchIndexes(ch).ToString() + " ";
                Debug.Write(" " + SearchIndexes(ch).ToString());
            }
            return bufferString;
        }

        private int SearchIndexes(char inputChar)
        {
            int indexI, indexJ;
            int totalResult = 0;

            bool timeToStop = false;
            for (int i = 1; i <= 6; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    if (inputChar == Alphabet[i - 1, j - 1])
                    {
                        indexI = i;
                        indexJ = j;
                        totalResult = ConcatNumbers(indexI, indexJ);
                        timeToStop = true;
                    }

                    if (timeToStop)
                        break;

                }
                if (timeToStop)
                    break;
            }

            return totalResult;
        }

        private int ConcatNumbers(int firstInt, int secondInt)
        {
            String resultString = "Ошибка";
            int resultNumber = 0;
            String firstNumber = firstInt.ToString();
            String secondNumber = secondInt.ToString();

            resultString = firstNumber;
            resultString += secondNumber;
            resultNumber = Int32.Parse(resultString);

            return resultNumber;
        }


        private void btnPolybiusCode_Click(object sender, EventArgs e)
        {
            inputString = textBox13.Text;
            String bufferString = textBox13.Text;
            bufferString = bufferString.Replace(" ", string.Empty);//Расчистка пространства в обоих вариантах
            Debug.WriteLine("Строка буфера : " + bufferString);

            if (encryptCheckBox.Checked)//шифрование
            {

                bufferString = bufferString.ToUpper();
                Debug.WriteLine("Строка в верхнем регистре без пробелов:" + bufferString);

                outputString = Pencypt(bufferString);
                if (!isWrongSymbols)
                    outputTextBox.Text = outputString;
                else
                    outputTextBox.Text = "Во входной строке были найдены неправильные символы!";
                outputString = "";
            }
            else//расшифровка
            {

                Debug.WriteLine("Расшифровка");
                outputString = Pdecrypt(bufferString);
                outputTextBox.Text = outputString;
                outputString = "";

            }
        }

        private void encryptCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (encryptCheckBox.Checked)//шифрование
            {

                label73.Text = "Текст";
                label72.Text = "Шифр";
                btnPolybiusCode.Text = "Зашифровать";
                textBox13.Text = outputTextBox.Text;
                outputTextBox.Clear();
            }

            else//расшифровка
            {
                label73.Text = "Шифр";
                label72.Text = "Текст";
                btnPolybiusCode.Text = "Расшифровать";
                textBox13.Text = outputTextBox.Text;
                outputTextBox.Clear();
            }

        }

        private void btnPolybiusClear_Click(object sender, EventArgs e)
        {
            outputTextBox.Clear();
            textBox13.Clear();
        }



        //Шифр Веженера
        private static String[,] vigenereSquare;
        private static String[] alphabetEnglish =
        { "A", "B", "C", "D", "E", "F", "G",
          "H", "I", "J", "K", "L", "M", "N",
          "O", "P", "Q", "R", "S", "T", "U",
          "V", "W", "X", "Y", "Z", " ", ".",
          ",", "!", "?"};

        private static String[] alphabetRussia =
        {   "А", "Б", "В", "Г", "Д", "Е", "Ё",
            "Ж", "З", "И", "Й", "К", "Л", "М",
            "Н", "О", "П", "Р", "С", "Т", "У",
            "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ",
            "Ы", "Ь", "Э", "Ю", "Я", " ", ".",
            ",", "!", "?"};




        List<String> alphabetList;

        public String encryptedText;
        public String decryptedText;
        public String reformedText;
        public String reformedSecretWord;

        private bool createVigenereSquare()
        {
            alphabetList = new List<String>(alphabetEnglish);
            if (alphabetList.Contains(tbText.Text.ElementAt(0).ToString().ToUpper()))
            {
                setVigenereSquareLanguageWithAlphabet(alphabetEnglish);

                return true;
            }
            else
            {
                alphabetList = new List<string>(alphabetRussia);
                if (alphabetList.Contains(tbText.Text.ElementAt(0).ToString().ToUpper()))
                {
                    setVigenereSquareLanguageWithAlphabet(alphabetRussia);
                    return true;
                }
            }
            return false;
        }

        private void setVigenereSquareLanguageWithAlphabet(String[] alphabet)
        {
            vigenereSquare = new String[alphabet.Length, alphabet.Length];
            for (int i = 0; i < alphabet.Length; i++)
            {
                alphabetList = new List<string>(alphabet);
                for (int j = 0; j < alphabet.Length; j++)
                {
                    vigenereSquare[i, j] = alphabet[j];
                }
                alphabetList.Insert(alphabet.Length, alphabet.ElementAt(0));
                alphabetList.RemoveAt(0);
                alphabet = alphabetList.ToArray();
            }
        }


        private void btnEncipher_Click(object sender, EventArgs e)
        {
            if (encryptCheckBox_.Checked)//шифрование
            {

                if (createVigenereSquare() /*&& encryptCheckBox_.Checked*/)
                {
                    reformedText = tbText.Text.ToUpper();
                    reformedSecretWord = tbKey.Text.ToUpper();

                    if (reformedText.Length > 0 && reformedSecretWord.Length > 0)
                    {
                        String encryptedString = "";
                        int indexOfSecretWordChar = 0;
                        for (int i = 0; i < reformedText.Length; i++)
                        {
                            if (reformedSecretWord.Length > reformedText.Length)
                            {
                                indexOfSecretWordChar = i % reformedText.Length;
                            }
                            else
                            {
                                indexOfSecretWordChar = i % reformedSecretWord.Length;
                            }


                            encryptedString += vigenereSquare[
                                alphabetList.IndexOf(reformedSecretWord.ElementAt(indexOfSecretWordChar).ToString()),
                                alphabetList.IndexOf(reformedText.ElementAt(i).ToString())];
                        }
                        outputTextBox_.Text = encryptedString;
                        encryptedText = encryptedString;

                        //MessageBox.Show(encryptedText, "Зашифровано", MessageBoxButtons.OK);

                    }
                    else
                    {
                        //label2.Text = "Требуемые поля необходимо заполнить";
                        MessageBox.Show("Требуемые поля необходимо заполнить", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //label2.Text = "Данный язык не поддерживается";
                    MessageBox.Show("Данный язык не поддерживается", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else //расшифровка
            {

                if (tbText.Text.Length > 0 && tbKey.Text.Length > 0)
                {
                    if (encryptedText != null /*&& tbText.Text.ToUpper().Equals(reformedText)*/)
                    {
                        String decryptedString = "";
                        for (int i = 0; i < encryptedText.Length; i++)
                        {
                            int indexOfSecretWordChar = i % reformedSecretWord.Length;

                            int indexOfCurrentLine = alphabetList.IndexOf(reformedSecretWord.ElementAt(indexOfSecretWordChar).ToString());
                            int indexOfDecryptedChar = 0;

                            for (int j = 0; j < alphabetList.Count; j++)
                            {
                                if (vigenereSquare[indexOfCurrentLine, j].Equals(encryptedText.ElementAt(i).ToString()))
                                {
                                    indexOfDecryptedChar = j;
                                }
                            }

                            decryptedString += alphabetList.ElementAt(indexOfDecryptedChar);
                        }
                        decryptedText = decryptedString;
                        //MessageBox.Show(decryptedString, "Расшифровано", MessageBoxButtons.OK);
                        outputTextBox_.Text = decryptedText;

                        //outputTextBox_.Text = decryptedString;
                    }
                    else
                    {
                        //label2.Text = "Для начала зашифруйте текст";
                        MessageBox.Show("Для начала зашифруйте текст", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    //label2.Text = "Требуемые поля необходимо заполнить";
                    MessageBox.Show("Требуемые поля необходимо заполнить", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void encryptCheckBox__CheckedChanged(object sender, EventArgs e)
        {
            if (encryptCheckBox_.Checked)//шифрование
            {

                label75.Text = "Текст";
                label74.Text = "Шифр";
                btnEncipher.Text = "Зашифровать";
                tbText.Text = encryptedText;

                outputTextBox_.Clear();
            }

            else//расшифровка
            {

                label75.Text = "Шифр";
                label74.Text = "Текст";
                btnEncipher.Text = "Расшифровать";

                tbText.Text = encryptedText;


                outputTextBox_.Clear();
            }
        }
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            tbText.Clear();
            tbKey.Clear();
            outputTextBox_.Clear();
        }




        // Аффинный шифр

        private char[] engAlphabet = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

        private int keyAValidation(int a, int b = 33)
        {
            int remainder = -1;

            if (a != 0 && b != 0)
            {
                a = (a < 0) ? Math.Abs(a) : a;
                b = (b < 0) ? Math.Abs(b) : b;

                int tmp;
                double divider;

                if (a > b)
                {
                    tmp = a;
                    a = b;
                    b = tmp;
                }

                while (remainder != 0)
                {
                    divider = b / a;
                    remainder = b - (int)Math.Floor(divider) * a;

                    if (remainder == 0)
                    {
                        return a;
                    }

                    b = a;
                    a = remainder;
                }
            }

            return a;
        }

        private int getIndexPosition(char letter)
        {
            if (engAlphabet.Contains(letter))
            {
                return Array.IndexOf(engAlphabet, letter);
            }
            else if (letter == ' ')
            {
                return -2;
            }

            return -1;
        }

        private int changeIndex(int index, int parA, int parB)
        {
            if (index >= 0)
            {
                int changedIndex = (parA * index + parB) % engAlphabet.Length;
                while (changedIndex > (engAlphabet.Length - 1))
                {
                    changedIndex -= engAlphabet.Length;
                }
                return changedIndex;
            }

            else if (index == -2)
            {
                return -2;
            }

            return -1;
        }


        private void encryption(string openText, int parameterA, int parameterB)
        {
            try
            {
                char[] specialCharacters = { '.', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_',
                                         '+', '-', '}', '{', '?', '>', '<', ':', '|', '[', ']', '"',
                                         '/', ',', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
                                       };

                openText = openText.Trim(specialCharacters).Trim().ToUpper();

                foreach (char c in specialCharacters)
                {
                    openText = (openText.Contains(c)) ? openText.Replace(c, ' ') : openText;
                }

                string normalizedString = openText.Normalize(NormalizationForm.FormD);
                int[] indexPositions = new int[openText.Length];

                StringBuilder engText = new StringBuilder();

                for (int i = 0; i < normalizedString.Length; i++)
                {
                    UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]);
                    if (uc != UnicodeCategory.NonSpacingMark)
                    {
                        engText.Append(normalizedString[i]);
                    }
                }

                string engOutput = engText.ToString();
                filteredTextVal.Text = engOutput;

                for (int i = 0; i < engOutput.Length; i++)
                {
                    indexPositions[i] = getIndexPosition(engOutput[i]);
                }

                int[] changedIndexes = new int[engOutput.Length];

                for (int i = 0; i < engOutput.Length; i++)
                {
                    changedIndexes[i] = changeIndex(indexPositions[i], parameterA, parameterB);
                }


                StringBuilder encryptedLetters = new StringBuilder();
                //foreach (int index in changedIndexes)
                //{
                //    encryptedLetters = (index == -2) ? encryptedLetters.Append("эюя") : encryptedLetters.Append(engAlphabet[index].ToString());
                //}

                decryptOutput.Text = "";

                for (int i = 0; i < encryptedLetters.Length; i++)
                {
                    if (i % 5 == 0)
                    {
                        decryptOutput.Text += " ";
                    }

                    decryptOutput.Text += encryptedLetters[i].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private int modInverse(int a, int sizeOfAlphabet = 33)
        {
            a = a % sizeOfAlphabet;

            for (int i = 1; i < sizeOfAlphabet; i++)
            {
                if ((a * i) % sizeOfAlphabet == 1)
                {
                    return i;
                }
            }

            return 0;
        }

        private int decryptIndex(int index, int invertedA, int b)
        {
            int decryptedIndex = ((index - b) * invertedA) % engAlphabet.Length;
            return (decryptedIndex < 0) ? decryptedIndex + engAlphabet.Length : decryptedIndex;
        }

        private void decryption(string encryptedText, int keyA, int keyB)
        {
            encryptedText = encryptedText.Replace(" ", "");
            encryptedText = (encryptedText.Contains("эюя")) ? encryptedText.Replace("эюя", " ") : encryptedText;

            int[] encryptedTextIndexes = new int[encryptedText.Length];

            for (int i = 0; i < encryptedText.Length; i++)
            {
                encryptedTextIndexes[i] = getIndexPosition(encryptedText[i]);
            }

            int[] decryptedIndexes = new int[encryptedTextIndexes.Length];
            int multInversion = modInverse(keyA);

            for (int i = 0; i < encryptedTextIndexes.Length; i++)
            {
                decryptedIndexes[i] =
                    (encryptedTextIndexes[i] == -2) ?
                    decryptedIndexes[i] = -2 :
                    decryptedIndexes[i] = decryptIndex(encryptedTextIndexes[i], multInversion, keyB);
            }

            StringBuilder decryptedText = new StringBuilder();


            foreach (var index in decryptedIndexes)
            {
                if (index == -2)
                {
                    decryptedText.Append(" ");
                }
                else
                {
                    decryptedText.Append(engAlphabet[index]);
                }
            }

            decryptOutput.Text = decryptedText.ToString();
        }
        private void decryptBtn_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string openText = textBoxDecrypt.Text;
                if (openText.Length < 1)
                {
                    MessageBox.Show("Если вы хотите зашифровать текст, вы должны ввести его.");
                }
                int parA = -1;
                int parB = -1;
                try
                {
                    parA = Convert.ToInt32(keyA.Text);
                    parB = Convert.ToInt32(keyB.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                if (keyAValidation(parA) != 1)
                {
                    MessageBox.Show("Ключевой параметр a не соответствует: (a,33) = 1\nВведите другой параметр(a)\nПодсказка: нечетные числа");
                }
                else
                {
                    encryption(openText, parA, parB);
                }
            }
            else
            {
                string encryptedText = textBoxDecrypt.Text;
                if (encryptedText.Length < 1)
                {
                    MessageBox.Show("Если вы хотите расшифровать текст, вы должны ввести его.");
                }
                else
                {
                    int parA = -1;
                    int parB = -1;

                    try
                    {
                        parA = Convert.ToInt32(keyA.Text);
                        parB = Convert.ToInt32(keyB.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    if (keyAValidation(parA) != 1)
                    {
                        MessageBox.Show("Ключевой параметр a не соответствует: (a,33) = 1\nВведите другой параметр(a)\nПодсказка: нечетные числа");
                    }
                    else
                    {
                        decryption(encryptedText, parA, parB);
                    }
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBoxDecrypt.Clear();
            decryptOutput.Clear();
        }
        private void Caesar_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
          "Вы уверены, что хотите выйти из программы?",
          "Завершение программы",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Process.GetCurrentProcess().Kill();
                e.Cancel = false;
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)//шифрование
            {

                label81.Text = "Текст";
                label80.Text = "Шифр";
                decryptBtn.Text = "Зашифровать";
                textBoxDecrypt.Text = decryptOutput.Text;

                decryptOutput.Clear();
            }

            else//расшифровка
            {

                label81.Text = "Шифр";
                label80.Text = "Текст";
                decryptBtn.Text = "Расшифровать";

                textBoxDecrypt.Text = decryptOutput.Text;


                decryptOutput.Clear();
            }
        }


        //метод перестановок
        //private void tbTexts_TextChanged(object sender, EventArgs e)
        //{
        //    if (tbTexts.Text == "")
        //    {
        //        //txtMetin.Enabled = false;
        //        //txtSonuc.Enabled = false;
        //        anahtar = "";
        //    }
        //    else
        //    {
        //        //txtMetin.Enabled = true;
        //        //txtSonuc.Enabled = true;
        //        tbTexts.Text = girdiKontrol(tbTexts.Text);
        //        tbTexts.Select(tbTexts.Text.Length, 0);
        //        anahtar = tbTexts.Text;
        //    }
        //    kutuOlustur1();
        //    kutuyuEkranaYaz1();
        //}

        //private static Char[,] Alphabet1 = {
        //                    {'А', 'Б', 'В', 'Г', 'Д', 'Е'},
        //                    {'Ё', 'Ж', 'З', 'И', 'Й', 'К'},
        //                    {'Л', 'М', 'Н', 'О', 'П', 'Р'},
        //                    {'С', 'Т', 'У', 'Ф', 'Х', 'Ц'},
        //                    {'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь'},
        //                    {'Э', 'Ю', 'Я', ' ', ' ', ' '},
        //                   };
        //public void kutuOlustur1()
        //{
        //    //int j = 0;
        //    //int k = 0;
        //    //int i = anahtar.Length;
        //    //int index1 = 0;



        //    for (int i = 0; i < 6; i++)
        //    {
        //        char t = Alphabet1[i - 0, Int32.Parse(tbTexts.Text)];
        //        Alphabet1[i - 0, Int32.Parse(tbTexts.Text)] = Alphabet1[i - 0, 1];
        //        Alphabet1[i - 0, 1] = t;

        //    }

        //    for (int j = 1; j < 6; j++)
        //    {
        //        char t = Alphabet1[int.Parse(tbTexts.Text), j - 1];
        //        Alphabet1[int.Parse(tbTexts.Text), j - 1] = Alphabet1[1, j - 1];
        //        Alphabet1[1, j - 1] = t;

        //    }

        //    karakterler = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя., ";


        //    while (i > 0)
        //    {

        //        index1 = karakterler.IndexOf(anahtar[anahtar.Length - i]);//чтобы повторная буква не попадалась 2 раза
        //        if (index1 >= 0)
        //        {
        //            kutu[k, j] = anahtar[anahtar.Length - i];
        //            karakterler = karakterler.Remove(index1, 1);
        //            j++;
        //        }

        //        i--;

        //        if (j == 6)
        //        {
        //            k++;
        //            j = 0;
        //        }
        //    }

        //    i = 0; //i снова будет использоваться для обработки оставшихся символов


        //    while (i < karakterler.Length)
        //    {
        //        kutu[k, j] = karakterler[i];

        //        i++;
        //        j++;

        //        if (j % 6 == 0)
        //        {
        //            k++;
        //            j = 0;
        //        }
        //    }
        //    public void kutuyuEkranaYaz1()
        //    {
        //        tbMatrix.Text = "";




        //        for (int i = 1; i < 7; i++)
        //        {
        //            for (int j = 1; j < 7; j++)
        //            {
        //                tbMatrix.Text += Alphabet1[i - 1, j - 1] + "\r\t";
        //            }
        //            tbMatrix.Text += "\r\n\r\n";
        //        }
        //    }







        //Метод гаммирования

        private int sizeOfChar = 8;
        private void btnXor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox14.Text))
            {
                MessageBox.Show("Введите текст/шифр", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(textBox15.Text))
            {
                MessageBox.Show("Введите гамму", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



            if (radioButton2.Checked == true)
            { sizeOfChar = 16; }
            else  if (radioButton1.Checked == true) { sizeOfChar = 8; }
            string result = "";
            string mainstr = textBox14.Text;
            string key = KeyToRightSize(mainstr.Length, textBox15.Text);
            for (int i = 0; i < mainstr.Length; i++)
            {
                result += FunctionPlus(StringToBinaryHalf(key[i], 0), StringToBinaryHalf(mainstr[i], 0));
                result += FunctionPlus(StringToBinaryHalf(key[i], ((sizeOfChar / 2))), StringToBinaryHalf(mainstr[i], (sizeOfChar / 2)));
            }
            textBox16.Text = BinaryToString(result);
        }
        private string FunctionPlus(string inputKey, string input)
        {
            string result = "";
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if ((inputKey[i] == '1' && input[i] == '1') || (inputKey[i] == '0' && input[i] == '0'))
                    {
                        result = result + "0";
                    }
                    else
                    {
                        result = result + "1";
                    }
                }
            }
            return result;
        }
        private string StringToBinaryHalf(char input, int q)
        {
            string res_binary = Convert.ToString(input, 2);
            if (input == '_') res_binary = "0";
            while (res_binary.Length < sizeOfChar)
            {
                res_binary = "0" + res_binary;
            }
            return StringGetHalf(res_binary, q);
        }
        private string StringGetHalf(string input, int q)
        {
            input = input.Substring(q, (sizeOfChar / 2));
            return input;
        }



        private string BinaryToString(string input)
        {
            string output = "";
            while (input.Length > 0)
            {
                string char_binary = input.Substring(0, sizeOfChar);
                input = input.Remove(0, sizeOfChar);
                int a = 0;
                int degree = char_binary.Length - 1;
                foreach (char c in char_binary)
                    a += Convert.ToInt32(c.ToString()) * (int)Math.Pow(2, degree--);
                if (a == 0) { a = 95; }
                output += ((char)a).ToString();
            }
            return output;
        }
        private string KeyToRightSize(int length, string input)
        {
            int q = 0;
            while (q == 0)
            {
                if (input.Length >= length)
                {
                    input = input.Substring(0, length);
                    q = 1;
                }
                if (input.Length < length)
                {
                    input += input;
                }
            }
            return input;
        }

        private void cbXOR_CheckedChanged(object sender, EventArgs e)
        {
            if (cbXOR.Checked)//расшифровка
            {

                label79.Text = "Шифр";
                label83.Text = "Текст";
                btnXor.Text = "Расшифровать";

                textBox14.Text = textBox16.Text;


                textBox16.Clear();
            }

            else //шифрование
            {

                label79.Text = "Текст";
                label83.Text = "Шифр";
                btnXor.Text = "Зашифровать";
                textBox14.Text = textBox16.Text;

                textBox16.Clear();
            }
        }
        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 240)
            {
                e.Handled = true;
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
        }


        //метод перестановки

        private void btnPermutations_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox18.Text))
            {
                MessageBox.Show("Введите ключ (1 ячейка)", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(textBox19.Text))
            {
                MessageBox.Show("Введите ключ (2 ячейка)", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(textBox20.Text))
            {
                MessageBox.Show("Введите ключ (3 ячейка)", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(textBox21.Text))
            {
                MessageBox.Show("Введите ключ (4 ячейка)", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (checkBox2.Checked)
            {
                if (string.IsNullOrEmpty(tbTexts.Text))
                {
                    MessageBox.Show("Введите шифр", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                tbResult.Text = MPro.TranspositionTechniques.Decryption(tbTexts.Text, textBox18.Text + textBox19.Text + textBox20.Text + textBox21.Text); // Расшифровать
               //разбор на символы
                List<int> a = new List<int>();

                string[] txt = (textBox18.Text + " " + textBox19.Text + " " + textBox20.Text + " " + textBox21.Text).Split(' ');
                for (int i = 0; i < txt.Count(); i++)
                {
                    try
                    {
                        a.Add(Convert.ToInt32(txt[i]));
                    }
                    catch
                    { }
                }
                a.Sort();
                textBox17.Text = "";
                for (int i = 0; i < a.Count(); i++)
                {
                    textBox17.Text = a[0].ToString();
                    textBox22.Text = a[1].ToString();
                    textBox23.Text = a[2].ToString();
                    textBox24.Text = a[3].ToString();

                }
                //разбор на символы
            }


            else
            {
                if (string.IsNullOrEmpty(tbTexts.Text))
                {
                    MessageBox.Show("Введите текст", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                tbResult.Text = MPro.TranspositionTechniques.Encryption(tbTexts.Text, textBox18.Text + textBox19.Text + textBox20.Text + textBox21.Text, '*');//Зашифровать
                //разбор на символы
                List<int> a = new List<int>();

                string[] txt = (textBox18.Text + " " + textBox19.Text + " " + textBox20.Text + " " + textBox21.Text).Split(' ');
                for (int i = 0; i < txt.Count(); i++)
                {
                    try
                    {
                        a.Add(Convert.ToInt32(txt[i]));
                    }
                    catch
                    { }
                }
                a.Sort();
                textBox17.Text = "";
                for (int i = 0; i < a.Count(); i++)
                {
                    textBox17.Text = a[0].ToString();
                    textBox22.Text = a[1].ToString();
                    textBox23.Text = a[2].ToString();
                    textBox24.Text = a[3].ToString();

                }
                //разбор на символы
            }
        }

        private void tbTexts_TextChanged(object sender, EventArgs e)
        {
            if (tbTexts.Text == "")
            {
                //txtMetin.Enabled = false;
                //txtSonuc.Enabled = false;
                anahtar = "";
            }
            else
            {
                //txtMetin.Enabled = true;
                //txtSonuc.Enabled = true;
                tbTexts.Text = girdiKontrol(tbTexts.Text);
                tbTexts.Select(tbTexts.Text.Length, 0);
                anahtar = tbTexts.Text;
            }
            kutuOlustur1();
            kutuyuEkranaYaz1();
        }
        private void tbResult_TextChanged(object sender, EventArgs e)
        {
            if (tbResult.Text == "")
            {
                //txtMetin.Enabled = false;
                //txtSonuc.Enabled = false;
                anahtar = "";
            }
            else
            {
                //txtMetin.Enabled = true;
                //txtSonuc.Enabled = true;
                tbResult.Text = girdiKontrol(tbResult.Text);
                tbResult.Select(tbResult.Text.Length, 0);
                anahtar = tbResult.Text;
            }
            kutuOlustur2();
            kutuyuEkranaYaz2();
        }


        char[,] kutu1 = new char[4, 4];
        //записывает матрицу ключей на экран
        public void kutuyuEkranaYaz1()
        {
            tbMatrix.Text = "";

            for (int i = 1; i < 5; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    tbMatrix.Text += kutu1[i - 1, j - 1] + "\r\t";
                }
                tbMatrix.Text += "\r\n\r\n";
            }
        }
        //создает матрицу ключей
        public void kutuOlustur1()
        {
            int j = 0;
            int k = 0;
            int i = anahtar.Length;
            int index1 = 0;

            karakterler = tbTexts.Text/*"абвгдеёжзийэклмнопрстуфхцчшщъыьэюя.,"*/ ;

            try
            {
                while (i > 0)
                {

                    index1 = karakterler.IndexOf(anahtar[anahtar.Length - i]);//чтобы повторная буква не попадалась 2 раза
                    if (index1 >= 0)
                    {
                        kutu1[k, j] = anahtar[anahtar.Length - i];
                        karakterler = karakterler.Remove(index1, 1);
                        j++;
                    }

                    i--;

                    if (j == 4)
                    {
                        k++;
                        j = 0;
                    }
                }

                i = 0; //i снова будет использоваться для обработки оставшихся символов


                while (i < karakterler.Length)
                {
                    kutu1[k, j] = karakterler[i];

                    i++;
                    j++;

                    if (j % 4 == 0)
                    {
                        k++;
                        j = 0;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Вы превысили размер матрицы!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void kutuyuEkranaYaz2()
        {

            if (checkBox2.Checked) //записывает матрицу ключей на экран
            {
                tbMatrix1.Text = "";

                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        tbMatrix1.Text += kutu1[i - 1, j - 1] + "\r\t";
                    }
                    tbMatrix1.Text += "\r\n\r\n";
                }
            }
            else  //записывает матрицу ключей на экран
            {
                tbMatrix1.Text = "";

                for (int i = 1; i < 5; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        tbMatrix1.Text += kutu1[j - 1, i - 1] + "\r\t";
                    }
                    tbMatrix1.Text += "\r\n\r\n";
                }
            }

        }
        //создает матрицу ключей
        public void kutuOlustur2()
        {

            int j = 0;
            int k = 0;
            int i = anahtar.Length;
            int index1 = 0;

            karakterler = tbResult.Text/*"абвгдеёжзийэклмнопрстуфхцчшщъыьэюя.,"*/ ;

            try
            {
                while (i > 0)
                {

                    index1 = karakterler.IndexOf(anahtar[anahtar.Length - i]);//чтобы повторная буква не попадалась 2 раза
                    if (index1 >= 0)
                    {
                        kutu1[k, j] = anahtar[anahtar.Length - i];
                        karakterler = karakterler.Remove(index1, 1);
                        j++;
                    }

                    i--;

                    if (j == 4)
                    {
                        k++;
                        j = 0;
                    }
                }

                i = 0; //i снова будет использоваться для обработки оставшихся символов


                while (i < karakterler.Length)
                {
                    kutu1[k, j] = karakterler[i];

                    i++;
                    j++;

                    if (j % 4 == 0)
                    {
                        k++;
                        j = 0;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Вы превысили размер матрицы!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)//расшифровка
            {

                label89.Text = "Шифр";
                label90.Text = "Текст";

                btnPermutations.Text = "Расшифровать";
                label86.Text = "Зашифрованное сообщение\n(Считывание по столбцам)";
                label88.Text = "Расшифрованное сообщение\n(Построчное считывание)";

                tbTexts.Text = tbResult.Text;


                tbResult.Clear();
            }

            else //шифрование
            {

                label89.Text = "Текст";
                label90.Text = "Шифр";
                label86.Text = "Расшифрованное сообщение\n(Построчное считывание)";
                label88.Text = "Зашифрованное сообщение\n(Считывание по столбцам)";

                btnPermutations.Text = "Зашифровать";
                tbTexts.Text = tbResult.Text;


                tbResult.Clear();
            }
        }

        private void btnPermutationsClear_Click(object sender, EventArgs e) // очистка textBox
        {

            tbTexts.Clear();
            tbResult.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
            textBox22.Clear();
            textBox23.Clear();
            textBox24.Clear();
            tbMatrix.Clear();
            tbMatrix1.Clear();
            Array.Clear(kutu1, 0, kutu1.Length); // очистка массива

        }

        // 
        private void textBox18_KeyPress(object sender, KeyPressEventArgs e) //ввод только цифр и кнопки удаления
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox18_KeyDown(object sender, KeyEventArgs e) // переход в другой textBox, после ввода одного символа
        {
            if (textBox18.TextLength == 0 || e.KeyCode != Keys.Back)
            {
                textBox19.Focus();
            }

            if (e.KeyCode == Keys.Left)
            {
                textBox21.Focus();
            }


        }

        private void textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox19.TextLength == 0 || e.KeyCode != Keys.Back)
            {
                textBox20.Focus();
            }
            if (e.KeyCode == Keys.Back)
            {
                textBox18.Focus();
            }
            if (e.KeyCode == Keys.Left)
            {
                textBox18.Focus();
            }
        }

        private void textBox20_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox20.TextLength == 0 || e.KeyCode != Keys.Back)
            {
                textBox21.Focus();
            }
            if (e.KeyCode == Keys.Back)
            {
                textBox19.Focus();
            }

            if (e.KeyCode == Keys.Left)
            {
                textBox19.Focus();
            }
        }

        private void textBox21_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back /*&& textBox20.Text == string.Empty*/)
            {
                textBox20.Focus();
            }
            if (e.KeyCode == Keys.Left)
            {
                textBox20.Focus();
            }



        }

        private void tbTexts_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                textBox18.Focus();
            }
        }



        //private void button2_Click(object sender, EventArgs e)
        //{
        //    textBox14.Text = textBox16.Text;
        //    textBox16.Text = "";
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Realization of XORcipher encryption algorithm by IvanovA (2021)\nATTENTION!\nIt's advised NOT to use a symbol '_' as the password or input text to avoid collisions!\n\n- How to encrypt? \nFirst, you need to enter the text you want to encrypt in the top line. " +
        //           "After that, select the key for encryption and press the 'Encrypt' button. You will get the encrypted text in the bottom line. If you need to use more keys, you can Move the encrypted text by pressing the relevant button and encrypt text again." +
        //           "\nP.S. You can also choose encoding type (Unicode or ASCII)." +
        //           "\n\n- How to Decrypt?" +
        //           "\nSimilar to the encryption method. Enter the encrypted text in the top line, necessary key in the middle line and click the 'Encrypt' button. " +
        //           "Order of entering keys, if there were several of them, is not important. You will get the decrypted text in the bottom line.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}






        //Метод гаммирования (2 способ)
        //static private string alf = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        //static private int k, x, z;
        //static private string res;


        //static class Xor
        //{


        //    static public string Encryption(string source, string key)
        //    {

        //        res = string.Empty;

        //        while (key.Length < source.Length)
        //        {
        //            key += key;
        //            if (key.Length > source.Length) key = key.Remove(source.Length);
        //        }
        //        for (int i = 0; i < source.Length; i++)
        //        {
        //            for (int id = 0; id < alf.Length; id++)
        //            {
        //                if (key[i] == alf[id]) k = id;
        //                if (source[i] == alf[id]) x = id;
        //                z = (x + k) % alf.Length;
        //            }
        //            res += alf[z+1];
        //        }
        //        return res;
        //    }

        //    static public string Decryption(string source, string key)
        //    {
        //        res = string.Empty;

        //        while (key.Length < source.Length)
        //        {
        //            key += key;
        //            if (key.Length > source.Length) key = key.Remove(source.Length);
        //        }
        //        for (int i = 0; i < source.Length; i++)
        //        {
        //            for (int id = 0; id < alf.Length; id++)
        //            {
        //                if (key[i] == alf[id]) k = id;
        //                if (source[i] == alf[id]) x = id;
        //                z = (source[i] - key[i]) + alf.Length;
        //            }
        //            res += alf[z-1];
        //        }
        //        return res;
        //    }
        //}


        //private void btnXor_Click(object sender, EventArgs e)
        //{
        //    //char cn = 'с';
        //    //  textBox16.Text = (alf.IndexOf(cn) + 1).ToString();

        //    string text = textBox14.Text;
        //    string key = textBox15.Text;

        //    textBox16.Text = Xor.Encryption(text, key); 
        //    textBox17.Text = Xor.Decryption(textBox16.Text, key); 

        //}
    }
}










//static String Atbash(String ToCode)
//     {
//         String posl = "";
//         for (int i = 0; i <= ToCode.Length - 1; i++)
//             // Очередной байт массива равен = 256 - код символа строчки ToCode в кодировке ANSII.
//             posl += "" + (char)(256 - ToCode[i]);
//         // Посылаем на выход составленную последовательность байтов, переведенных в символы.
//         return posl;
//     }